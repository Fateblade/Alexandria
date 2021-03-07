using System.Collections.Generic;

namespace Fateblade.Alexandria.CrossCutting.Entities.DataClasses
{
    public abstract class Character : Entity
    {
        public string PowerLevel { get; set; }
        public string Classification { get; set; }
        public string Backstory { get; set; }
        public string Origin { get; set; } //maybe bind to location?

        public List<Flaw> Flaws { get; set; }
        public List<StrongSuit> StrongSuits { get; set; }
        public List<Ambition> Ambitions { get; set; }
        public List<Fear> Fears { get; set; }
        public List<Goal> Goals { get; set; }
        public string Moral { get; set; }
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
