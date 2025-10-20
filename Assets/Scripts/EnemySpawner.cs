using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs; // assign your enemy prefabs in Inspector
    public float spawnInterval = 2f;
    private float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnEnemy();
            timer = 0f;
        }
    }

    void SpawnEnemy()
    {
        // Pick a random prefab
        int enemyType = Random.Range(0, enemyPrefabs.Length);
        GameObject prefab = enemyPrefabs[enemyType];

        // Random speed
        float speed = Random.Range(1.5f, 3f) * (enemyType * 0.5f + 1.0f);

        //points
        int points = 1 + enemyType;

        // Position at the top of the screen
        float yPos = Camera.main.orthographicSize - 1f - enemyType * 2; // top of the screen
        float xPos = 10f; // right side of the screen
        Vector3 spawnPos = new Vector3(xPos, yPos, 0);

        // Use the builder to create the enemy
        EnemyBuilder builder = new EnemyBuilder();
        builder.CreateBaseEnemy(prefab)
               .SetSpeed(speed)
               .SetPoints(points)
               .SetPosition(spawnPos)
               .SetSize(1f)
               .Build();
    }
}
