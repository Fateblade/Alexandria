using Fateblade.Alexandria.CrossCutting.Meta.DataClasses;
using Fateblade.Alexandria.UI.WPF.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Fateblade.Alexandria.UI.WPF.Models.Managers;

namespace Fateblade.Alexandria.UI.WPF.Models.Meta
{
    public class PlayerModel : ModifiableIdentifiableDataClassModel<Player>
    {
        private string _name;
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        private ObservableCollection<TextInfoModel> _noGos;
        public ObservableCollection<TextInfoModel> NoGos
        {
            get => _noGos;
            set => SetProperty(ref _noGos, value);
        }

        private string _genderPronoun;
        public string GenderPronoun
        {
            get => _genderPronoun;
            set => SetProperty(ref _genderPronoun, value);
        }

        private ObservableCollection<TextInfoModel> _likes;
        public ObservableCollection<TextInfoModel> Likes
        {
            get => _likes;
            set => SetProperty(ref _likes, value);
        }

        private ObservableCollection<TextInfoModel> _dislikes;
        public ObservableCollection<TextInfoModel> Dislikes
        {
            get => _dislikes;
            set => SetProperty(ref _dislikes, value);
        }

        public PlayerModel(Player original, IEnumerable<TextInfoModel> noGos, IEnumerable<TextInfoModel> likes, IEnumerable<TextInfoModel> dislikes) : base(original)
        {
            Name = original.Name;
            GenderPronoun = original.GenderPronoun;

            NoGos = new ObservableCollection<TextInfoModel>(noGos ?? throw new ArgumentException("noGos collection must not be null", nameof(noGos)));
            Likes = new ObservableCollection<TextInfoModel>(likes ?? throw new ArgumentException("likes collection must not be null", nameof(likes)));
            Dislikes = new ObservableCollection<TextInfoModel>(dislikes ?? throw new ArgumentException("dislikes collection must not be null", nameof(dislikes)));
        }

        public override Player ModifiedEntity
        {
            get
            {
                var player = new Player()
                {
                    Id = OriginalEntity.Id,
                    Name = OriginalEntity.Name,
                    GenderPronoun = OriginalEntity.Name
                };

                NoGos.Select(t=>t.Id).ToList().ForEach(id=>player.NoGoTextInfoIds.Add(id));
                Likes.Select(t => t.Id).ToList().ForEach(id => player.LikeTextInfoIds.Add(id));
                Dislikes.Select(t => t.Id).ToList().ForEach(id => player.DislikeTextInfoIds.Add(id));

                return player;
            }
        }

        public override void ModifyOriginalEntity()
        {
            OriginalEntity.Name = Name;
            OriginalEntity.GenderPronoun = GenderPronoun;

            GuidListRefresher.Instance.RefreshList(OriginalEntity.NoGoTextInfoIds, NoGos.Select(t => t.Id));
            GuidListRefresher.Instance.RefreshList(OriginalEntity.LikeTextInfoIds, Likes.Select(t => t.Id));
            GuidListRefresher.Instance.RefreshList(OriginalEntity.DislikeTextInfoIds, Dislikes.Select(t=>t.Id));
        }
    }
}
