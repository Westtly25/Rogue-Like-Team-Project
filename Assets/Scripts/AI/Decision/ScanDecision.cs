using UnityEngine;

namespace RogueLike.AI
{
    [CreateAssetMenu(fileName = "Scan Decision", menuName = "Rogue Like Prototype/AI/Decisions/Scan Decision", order = 0)]
    public class ScanDecision : Decision
    {
        public override bool Decide(StateController stateController)
        {
            bool noEnemyInSight = Scan(stateController);
            return noEnemyInSight;
        }

        private bool Scan(StateController stateController)
        {
            //stateController.navMeshAgent.isStopped = true;
            return stateController.ChackIfCountDownElapse(5f);
        }
    }
}