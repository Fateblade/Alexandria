using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Alexandrian.Base.Interfaces;

namespace Alexandrian.Base.Models
{
    public abstract class Character : BaseObject, ISummarizable, IRelatable
    {
        private string _System;
        public string System
        {
            get { return _System; }
            set { SetProperty(ref _System, value); }
        }
        
        private string _Name;
        public string Name
        {
            get { return _Name; }
            set { SetProperty(ref _Name, value); }
        }

        private string _PowerLevel;
        public string PowerLevel
        {
            get { return _PowerLevel; }
            set { SetProperty(ref _PowerLevel, value); }
        }

        private string _Classification;
        public string Classification
        {
            get { return _Classification; }
            set { SetProperty(ref _Classification, value); }
        }

        private string _Summary;
        public string Summary
        {
            get { return _Summary; }
            set { SetProperty(ref _Summary, value); }
        }

        private string _Description;
        public string Description
        {
            get { return _Description; }
            set { SetProperty(ref _Description, value); }
        }

        private string _Backstory;
        public string Backstory
        {
            get { return _Backstory; }
            set { SetProperty(ref _Backstory, value); }
        }

        private ObservableCollection<TextInfo> _Flaws;
        public ObservableCollection<TextInfo> Flaws
        {
            get { return _Flaws; }
            set { SetProperty(ref _Flaws, value); }
        }

        private ObservableCollection<TextInfo> _StrongSuits;
        public ObservableCollection<TextInfo> StrongSuits
        {
            get { return _StrongSuits; }
            set { SetProperty(ref _StrongSuits, value); }
        }

        private ObservableCollection<TextInfo> _Ambitions;
        public ObservableCollection<TextInfo> Ambitions
        {
            get { return _Ambitions; }
            set { SetProperty(ref _Ambitions, value); }
        }

        private ObservableCollection<TextInfo> _Fears;
        public ObservableCollection<TextInfo> Fears
        {
            get { return _Fears; }
            set { SetProperty(ref _Fears, value); }
        }

        private ObservableCollection<TextInfo> _Goals;
        public ObservableCollection<TextInfo> Goals
        {
            get { return _Goals; }
            set { SetProperty(ref _Goals, value); }
        }

        private string _Moral;
        public string Moral
        {
            get { return _Moral; }
            set { SetProperty(ref _Moral, value); }
        }

        protected RelationCategory _RelationCategory;
        public RelationCategory RelationCategory
        {
            get { return _RelationCategory; }
        }

        private ObservableCollection<Item> _Items;
        public ObservableCollection<Item> Items
        {
            get { return _Items; }
            set { SetProperty(ref _Items, value); }
        }
    }
}
/*
    19:04 - agath: - Hintergrunggeschichte / Herkunft
    - Stärken / Schwächen
    - Neigungen / Ambitionen
    - Fähigkeiten / Berufung
    - Moralvorstellungen

    19:04 - Wolfskin: Also was für mich immer das mit abstand spannendste ist, und was bei mir auch bei charaktererstellung ganz früh im prozess kommt, 
            ist es mir irgendwelche charakter-flaws auszudenken, die man dann auch im Rollenspiel richtig ausleben kann
    19:05 - Wolfskin: ansonsten so grundlegende fragen was für eine moralvorstellung der charakter hat, wie er konflikte löst

    19:15 - Injac: also aufzeichnen tu ich üblicherweise für eigene chars: werte (duh), inventar, geschichte (kindheit, wichtige sachen, 
    die den charakter des chars prägen (vor allem zu vor- und nachteilen), aussehen, etwas über die wichtige fähigkeiten 
    / die soziale klasse / die profession / das verhalten / die bekanntschaften des chars (npcs); aber alles unterschiedlich ausführlich, je nach char),
    weitere metasachen zum char (tradition eines magiers, aussehen von sprites usw.), ein bild (immer), während der abenteuer / runs erlebte wichtige sachen 
    (getroffene spielerchars, getroffene wichtige npcs, teilweise auch meinungen des chars zu diesen, wichtige erlebte ereignisse)
    19:15 - Injac: von anderen chars fürs leiten interessieren mich in erster linie:
    19:22 - Injac: was der char im allgemeinen für fähigkeiten hat, was der char für vor-/nachteile hat, was der char für eine vergangenheit (story) hat, 
    welche npcs der char kennt, die ich eventuell in einem abenteuer / run verweben kann, ob in einem vorherigen abenteuer / run (vor allem von mir) etwas 
    bezüglich des chars passiert ist, was ich in meinem nächsten abenteuer / run verwenden kann, wie der char momentan zu den anderen chars aus der gruppe 
    steht (ob man sich auf konflikte zwischen den chars vorbereiten sollte), welche sachen der char demnächst vorhat, wo er meine spielleiterentscheidung 
    und betreuung braucht (artefakte erschaffen? verbündete beschwören?)

 */
