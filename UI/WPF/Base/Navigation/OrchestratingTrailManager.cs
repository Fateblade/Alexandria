using Fateblade.Alexandria.UI.WPF.Base.Messages;
using Fateblade.Components.Logic.Foundation.Orchestration.Contract;
using System;
using System.Collections.Generic;

namespace Fateblade.Alexandria.UI.WPF.Base.Navigation
{
    public class OrchestratingTrailManager : INavigationTrailManager
    {
        private readonly LinkedList<NavigationTrailStep> _navigationTrail;
        private readonly IOrchestrator _orchestrator;

        public OrchestratingTrailManager(IOrchestrator orchestrator)
        {
            _orchestrator = orchestrator;
            _navigationTrail = new LinkedList<NavigationTrailStep>();
        }

        public void ContinueTrail(ITrailableView nextView)
        {
            NavigationTrailStep nextStep = new NavigationTrailStep
            {
                TrailableView = nextView, 
                Id = Guid.NewGuid()
            };

            _navigationTrail.AddLast(nextStep);

            _orchestrator.Orchestrate(new AddToNavigationTrailOrchestrationInfo()
            {
                TrailStepId = nextStep.Id, 
                TrailToDisplay = nextStep.TrailableView.TrailDisplayName
            });
        }

        public void TrailBack(Guid trailStepId, bool forceClose)
        {
            while(_navigationTrail.Last.Value.Id != trailStepId && tryMoveOneStepBackwards(forceClose)){ }

            if (_navigationTrail.Last.Value.Id != trailStepId)
            {
                _orchestrator.Orchestrate(new ShowExistingPageOrchestrationInfo()
                {
                    HandlePageClosed = (closedPage) => { TrailBack(trailStepId, forceClose); },
                    PageViewModelToDisplay = _navigationTrail.Last.Value.TrailableView.GetView()
                });
            }

            _navigationTrail.Last.Value.TrailableView.TrailReturned();
        }

        public void StartNewTrail(ITrailableView firstView, bool forceClose)
        {
            while(_navigationTrail.Count>0 && tryMoveOneStepBackwards(forceClose)){ /*navigate back step by step until a view cannot be closed without user input*/ }

            if (_navigationTrail.Count > 0)
            {
                _navigationTrail.Last.Value.TrailableView.TrailReturned();
                _orchestrator.Orchestrate(new ShowExistingPageOrchestrationInfo()
                {
                    HandlePageClosed = (closedPage)=>{ StartNewTrail(firstView, forceClose);},
                    PageViewModelToDisplay = _navigationTrail.Last.Value.TrailableView.GetView()
                });
            }
            else
            {
                ContinueTrail(firstView);
            }
        }


        private bool tryMoveOneStepBackwards(bool forceClose)
        {
            if (forceClose || _navigationTrail.Last.Value.TrailableView.CanBeClosedWithoutUserInput())
            {
                _orchestrator.Orchestrate(new TrailBackNavigationOnceOrchestrationMessage());
                _navigationTrail.RemoveLast();
                return true;
            }

            return false;
        }

        private void ContinueStartNewTrail(ITrailableView firstView)
        {

        }
    }
}                                                                                                                                                                                                                                                                                                                                       
