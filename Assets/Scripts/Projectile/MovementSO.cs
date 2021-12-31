using UnityEngine;

namespace RogueLike.Projectiles
{
    [CreateAssetMenu( fileName = "MovementSO", menuName = "Rogue Like Prototype/Projectiles/MovementSO")]
    public abstract class MovementSO : ScriptableObject
    {
        public abstract void Move(Transform startPos, float speed);

        public abstract void Move(Transform startPos, Transform endPos, float speed);
    }
}