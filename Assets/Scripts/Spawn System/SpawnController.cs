#if UNITY_EDITOR
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private SpawnPoint[] spawnPoints;

    private int lastSpawnPoint = 0;
    private int lastSpawnEnemy = 0;

    public GameObject[] Enemies => enemies;
    public SpawnPoint[] SpawnPoints => spawnPoints;

    private void Awake()
    {
        Initialize();
    }

    private void Initialize()
    {
        spawnPoints = FindObjectsOfType<SpawnPoint>();

        if(spawnPoints == null)
        {
            Debug.Log("No Spawn Points on Scene");
        }
    }

    private void OnEnemySelectedToSpawn(GameObject enemy)
    {
        if(spawnPoints == null) { return; }

        int randomSpawnPoint = Random.Range(0, spawnPoints.Length);

        lastSpawnPoint = randomSpawnPoint;

        GameObject tempEnemy = Instantiate(enemy, spawnPoints[randomSpawnPoint].transform.position, Quaternion.identity);
    }

    [ContextMenu("Spawn Random Enemy")]
    private void SpawnRandomEnemy()
    {
        if (spawnPoints == null) { return; }

        int randomSpawnPoint = Random.Range(0, spawnPoints.Length);
        int randomEnemyToSpawn = Random.Range(0, enemies.Length);

        lastSpawnPoint = randomSpawnPoint;
        lastSpawnEnemy = randomEnemyToSpawn;

        GameObject tempEnemy = Instantiate(enemies[randomEnemyToSpawn], spawnPoints[randomSpawnPoint].transform.position, Quaternion.identity);
    }
}
#endif