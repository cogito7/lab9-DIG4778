using System.Linq;
using LitJson;
using TMPro.EditorUtilities;
using UnityEngine;

public class EnemySpawner : MonoBehaviour, ISaveable
{
    public GameObject[] enemyPrefabs; // assign your enemy prefabs in Inspector
    public float spawnInterval = 2f;
    private float timer;
    public string _saveID;

    public string SaveID
    {
        get
        {
            if (_saveID == null)
            {
                _saveID = System.Guid.NewGuid().ToString();
            }
            return _saveID;
        }
        set { _saveID = value; }
    }

    private const string ENEMY_TYPE = "enemyType";
    private const string ENEMY_SPEED = "enemySpeed";
    private const string ENEMY_POINTS = "enemyPoints";
    private const string ENEMY_TRANSFORM = "enemyTransform";

    public JsonData SavedData
    {
        get
        {
            JsonData result = new JsonData();
            var allEnemies = Object.FindObjectsByType<MonoBehaviour>(FindObjectsSortMode.None).OfType<Target>();
            int i = 0;
            foreach (var enemy in allEnemies)
            {
                JsonData enemyData = new JsonData();
                enemyData[ENEMY_TYPE] = enemy.type;
                enemyData[ENEMY_SPEED] = enemy.speed;
                enemyData[ENEMY_POINTS] = enemy.points;
                enemyData[ENEMY_TRANSFORM] = enemy.GetComponent<TransformSaver>().SavedData;
                result[i.ToString()] = enemyData;
                i++;
            }
            return result;
        }
    }

    public void LoadFromData(JsonData data)
    {
        // -1 accounts for $saveID
        for (int i = 0; i < data.Count - 1; i++)
        {
            JsonData enemyData = data[i.ToString()];
            EnemyBuilder builder = new EnemyBuilder();
            int enemyType = (int)enemyData[ENEMY_TYPE];
            double speed = (double)enemyData[ENEMY_SPEED];
            int points = (int)enemyData[ENEMY_POINTS];
            GameObject enemy = builder.CreateBaseEnemy(enemyPrefabs[enemyType])
                   .SetSpeed((float)speed)
                   .SetPoints(points)
                   .SetSize(1f)
                   .Build();
            enemy.GetComponent<TransformSaver>().LoadFromData(enemyData[ENEMY_TRANSFORM]);
        }
    }

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
