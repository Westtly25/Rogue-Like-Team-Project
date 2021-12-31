using UnityEngine;

namespace RogueLike.Projectiles
{
    [CreateAssetMenu(fileName = "ForwardMovementSO", menuName = "Rogue Like Prototype/Projectiles/ForwardMovementSO")]
    public class ForwardMovementSO : MovementSO
    {
        public override void Move(Transform startPos, float speed)
        {
            startPos.position += (startPos.position).normalized * speed * Time.deltaTime;
        }

        public override void Move(Transform startPos, Transform endPos, float speed)
        {
            startPos.position = Vector3.MoveTowards(startPos.position, endPos.position , speed * Time.deltaTime);
        }
    }
}