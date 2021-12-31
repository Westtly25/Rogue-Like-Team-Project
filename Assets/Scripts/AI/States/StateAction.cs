using UnityEngine;

namespace RogueLike.AI
{
    public abstract class StateAction : ScriptableObject
    {
        public abstract void Act(StateController controller);
    }
}