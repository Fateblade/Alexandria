using Fateblade.Alexandria.CrossCutting.Meta.DataClasses;
using Fateblade.Alexandria.Logic.Domain.Meta.MetaManagement.Contract;
using Fateblade.Alexandria.UI.WPF.Base.Messages;
using Fateblade.Alexandria.UI.WPF.Client;
using Fateblade.Alexandria.UI.WPF.Models.Meta;
using Fateblade.Components.Logic.Foundation.Orchestration.Contract;
using Prism.Commands;
using Prism.Mvvm;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Navigation;

namespace Fateblade.Alexandria.UI.WPF.Modules.Core.Views.Meta
{
    public class PlayerListViewModel : BindableBase
    {
        private readonly IPlayerManager _playerManager;
        private readonly ITextInfoManager _textInfoManager;
        private readonly IOrchestrator _orchestrator;
        private readonly ICommonDialogOrchestrator _commonDialogOrchestrator;

        private ObservableCollection<PlayerModel> _existingPlayers;
        private PlayerModel _selectedPlayer;

        public ObservableCollection<PlayerModel> ExistingPlayers
        {
            get => _existingPlayers;
            set => SetProperty(ref _existingPlayers, value);
        }

        public PlayerModel SelectedPlayer
        {
            get => _selectedPlayer;
            set => SetProperty(ref _selectedPlayer, value, onSelectedPlayerChanged);
        }

        public DelegateCommand<PlayerModel> EditPlayerCommand { get; }
        public DelegateCommand AddPlayerCommand { get; }
        public DelegateCommand<PlayerModel> RemovePlayerCommand { get; }
        public DelegateCommand RemoveCurrentlySelectedPlayerCommand { get; }

        public PlayerListViewModel(IPlayerManager playerManager, ITextInfoManager textInfoManager, IOrchestrator orchestrator, ICommonDialogOrchestrator commonDialogOrchestrator)
        {
            _playerManager = playerManager;
            _textInfoManager = textInfoManager;
            _orchestrator = orchestrator;
            _commonDialogOrchestrator = commonDialogOrchestrator;

            EditPlayerCommand = new DelegateCommand<PlayerModel>(editPlayer);
            AddPlayerCommand = new DelegateCommand(addPlayer);
            RemovePlayerCommand = new DelegateCommand<PlayerModel>(removePlayer);
            RemoveCurrentlySelectedPlayerCommand = new DelegateCommand(removeSelectedPlayer, ()=>SelectedPlayer!=null)
                .ObservesProperty(()=>SelectedPlayer);

            loadExistingPlayers();
        }

        private void loadExistingPlayers()
        {
            var playerModelCollection = new ObservableCollection<PlayerModel>();

            foreach (var playerToConvert in _playerManager.GetAll())
            {
                IQueryable<TextInfoModel> noGoTextInfoModels = _textInfoManager
                    .GetAll()
                    .Where(noGo => playerToConvert.NoGoTextInfoIds.Any(id=>id == noGo.Id))
                    .Select(noGoOriginal=>new TextInfoModel(noGoOriginal));

                IQueryable<TextInfoModel> likesTextInfoModels = _textInfoManager
                    .GetAll()
                    .Where(like=> playerToConvert.LikeTextInfoIds.Any(id => id == like.Id))
                    .Select(likeOriginal => new TextInfoModel(likeOriginal));

                IQueryable<TextInfoModel> dislikeTextInfoModels = _textInfoManager
                    .GetAll()
                    .Where(dislike => playerToConvert.DislikeTextInfoIds.Any(id => id == dislike.Id))
                    .Select(dislikeOriginal => new TextInfoModel(dislikeOriginal));

                playerModelCollection.Add(
                    new PlayerModel(
                        playerToConvert, 
                        noGoTextInfoModels, 
                        likesTextInfoModels, 
                        dislikeTextInfoModels));
            }

            ExistingPlayers = playerModelCollection;
        }

        private void onSelectedPlayerChanged()
        {

        }

        private void addPlayer()
        {
            Player newPlayer = new Player {Name = "New Player"};
            _playerManager.Add(newPlayer);

            PlayerModel newPlayerModel = new PlayerModel(
                newPlayer, 
                new List<TextInfoModel>(),
                new List<TextInfoModel>(), 
                new List<TextInfoModel>());

            ExistingPlayers.Add(newPlayerModel);
            SelectedPlayer = newPlayerModel;
        }

        private void editPlayer(PlayerModel playerToEdit)
        {
            var orchestrationRequestInfo = new ShowPageOrchestrationInfo
            {
                PageViewModelToDisplay = new PlayerEditViewModel(),
                HandlePageClosed = editPlayer_EditFinished
            };

            _orchestrator.Orchestrate(orchestrationRequestInfo);
        }

        private void editPlayer_EditFinished(BindableBase viewModel)
        {
            PlayerEditViewModel editViewModel = viewModel as PlayerEditViewModel;

            
        }

        private void removeSelectedPlayer()
        {
            removePlayer(SelectedPlayer);
        }

        private void removePlayer(PlayerModel playerToRemove)
        {
            _commonDialogOrchestrator.GetUserConfirmation("Do you really want to remove this player?", removePlayer_UserInputReceived);
        }

        private void removePlayer_UserInputReceived(bool userConfirmed)
        {
            if (!userConfirmed) { return; }

            PlayerModel playerToRemove = SelectedPlayer;
            ExistingPlayers.Remove(playerToRemove);
            SelectedPlayer = null;

            _playerManager.Delete(playerToRemove.OriginalEntity);
        }
    }

    //edit view:
    //edit nogos
    //edit likes
    //edit dislikes
    //edit name, gender pronoun

}
