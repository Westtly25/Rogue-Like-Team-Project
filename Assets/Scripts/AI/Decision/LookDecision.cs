using UnityEngine;

namespace RogueLike.AI
{
    [CreateAssetMenu(fileName = "Look Decision", menuName = "Rogue Like Prototype/AI/Decisions/New Look Decision", order = 0)]
    public class LookDecision : Decision
    {
        public override bool Decide(StateController stateController)
        {
            bool targetVisible = Look(stateController);
            return targetVisible;
        }

        private bool Look(StateController stateController)
        {
            RaycastHit rayHit;

            return false;

            //if (Physics.SphereCast(stateController.transform.position, 10f, stateController.transform.forward, out rayHit, Mathf.Infinity, targetMask) & stateController.fighterAI.Target == null)
            //{
                //stateController.fighterAI.Target = rayHit.transform.gameObject.GetComponent<Health>();
            //}

            //Health target = stateController.fighterAI.Target;

            //if (target != null && !target.IsDead())
            //{
                //return true;
            //}
            //else
            //{
                //return false;
            //}
        }
    }
}