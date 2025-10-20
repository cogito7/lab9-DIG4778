using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyBuilder : MonoBehaviour
{
    private GameObject enemy;
    private Target targetScript;

    // Start a new enemy from a prefab
    public EnemyBuilder CreateBaseEnemy(GameObject prefab)
    {
        enemy = Object.Instantiate(prefab);
        targetScript = enemy.GetComponent<Target>();
        return this;
    }

    public EnemyBuilder SetSpeed(float speed)
    {
        targetScript.speed = speed;
        return this;
    }

    public EnemyBuilder SetPoints(int points)
    {
        targetScript.points = points;
        return this;
    }

    public EnemyBuilder SetSize(float size)
    {
        enemy.transform.localScale = new Vector3(size, size, 1);
        return this;
    }

    public EnemyBuilder SetPosition(Vector3 position)
    {
        enemy.transform.position = position;
        return this;
    }

    public GameObject Build()
    {
        return enemy;
    }
}
