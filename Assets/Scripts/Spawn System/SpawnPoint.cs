using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public Vector3 SpawnPosition => transform.position;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(this.transform.position, 1f);
    }
}