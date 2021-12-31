using UnityEngine;

namespace RogueLike.AI
{
    public abstract class Decision : ScriptableObject
    {
        [Header("LAYERS")]
        [SerializeField] protected LayerMask targetMask;

        public abstract bool Decide(StateController stateController);    
    }
}