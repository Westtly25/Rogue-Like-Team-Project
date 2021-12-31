using UnityEngine;

namespace RogueLike.AI
{
    [CreateAssetMenu(fileName = "Chase Action", menuName = "Rogue Like Prototype/AI/Actions/New Chase Action", order = 0)]
    public class ChaseAction : StateAction
    {
        public override void Act(StateController controller)
        {
            Chase(controller);
        }

        private void Chase(StateController controller)
        {
            //controller.mover.MoveTo(controller.fighterAI.Target.transform.position, 0.5f);
        }
    }
}