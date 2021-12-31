using UnityEngine;

namespace RogueLike.AI
{
    [CreateAssetMenu(fileName = "Attack Action", menuName = "Rogue Like Prototype/AI/Actions/New Attack Action", order = 0)]
    public class AttackAction : StateAction
    {
        public override void Act(StateController stateController)
        {
            Attack(stateController);
        }

        private void Attack(StateController stateController)
        {
            
        }
    }
}