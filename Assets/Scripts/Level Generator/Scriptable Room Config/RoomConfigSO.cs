using UnityEngine;

[CreateAssetMenu(fileName = "RoomConfigSO", menuName = "Rogue Like Prototype/Level Generator System/Rooms/RoomConfigSO", order = 0)]
public class RoomConfigSO : ScriptableObject
{
    [Header("ROOM SIZES")]
    [SerializeField] private int widthX;
    [SerializeField] private int widthZ;

    [Header("GRID INSIDE ROOM")]
    [SerializeField] private Grid grid;

    [Header("ROOM PARTS")]
    [SerializeField] private GameObject[] walls;
    [SerializeField] private GameObject[] doors;


    [Header("ROOM CONTENT")]
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private GameObject[] chests;


    [Range(0, 20)]
    [SerializeField] private int enemiseAmount;
    [Range(0, 20)]
    [SerializeField] private int enemiesWavesAmount;

    public int WidthX => widthX;
    public int WidthZ => widthZ;

    public GameObject[] Walls => walls;
    public GameObject[] Doors => doors;
    public GameObject[] Enemies => enemies;
    public GameObject[] Chests => chests;


    public void Initialize()
    {

    }
}