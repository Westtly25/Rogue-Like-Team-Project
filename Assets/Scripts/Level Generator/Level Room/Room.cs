using UnityEngine;

public class Room : MonoBehaviour
{
    [SerializeField] private RoomConfigSO roomConfigSO;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawCube(transform.position, new Vector3(roomConfigSO.WidthX * 10f, 0.1f, roomConfigSO.WidthZ * 10f));
    }
}
