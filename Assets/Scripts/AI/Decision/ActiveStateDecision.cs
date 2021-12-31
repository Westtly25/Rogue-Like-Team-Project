using UnityEngine;

namespace RogueLike.AI
{
    [CreateAssetMenu(fileName = "Active State Decision", menuName = "Rogue Like Prototype/AI/Decisions/Active State Decision", order = 0)]
    public class ActiveStateDecision : Decision
    {
        public override bool Decide(StateController stateController)
        {
            //bool chaseTargetIsActive = stateController.fighterAI.Target.IsDead();
            //return chaseTargetIsActive;

            return false;
        }
    }
}