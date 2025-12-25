using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject obstaclePrefab;

    [SerializeField]
    private Transform player;

    [SerializeField]
    private float minDistance = 4f;

    [SerializeField]
    private float maxDistance = 7f;

    private float laneOffset = 2f;

    private float nextSpawnZ;

    void Start()
    {
        nextSpawnZ = transform.position.z;
    }

    void Update()
    {
        if (player.position.z + 20f > nextSpawnZ)
        {
            SpawnObstacle();
        }
    }

    void SpawnObstacle()
    {
        int laneIndex = Random.Range(0, 3);
        float xPos = (laneIndex - 1) * laneOffset;

        Vector3 spawnPos = new Vector3(xPos, 0.5f, nextSpawnZ);

        GameObject obstacle = Instantiate(obstaclePrefab, spawnPos, Quaternion.identity);
        DestroyBehindPlayer destroyScript  = obstacle.GetComponent<DestroyBehindPlayer>();
        destroyScript.player = player;
        // Increase Z for next spawn
        nextSpawnZ += Random.Range(minDistance, maxDistance);
    }
}
