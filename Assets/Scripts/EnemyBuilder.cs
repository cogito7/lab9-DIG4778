using UnityEngine;

// Builds an ememy with the builder pattern
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

    // Sets speed
    // Return this for builder pattern.
    public EnemyBuilder SetSpeed(float speed)
    {
        targetScript.speed = speed;
        return this;
    }

    // Sets points scored for hitting this target
    // Return this for builder pattern.
    public EnemyBuilder SetPoints(int points)
    {
        targetScript.points = points;
        return this;
    }

    // Sets size
    // Return this for builder pattern.
    public EnemyBuilder SetSize(float size)
    {
        enemy.transform.localScale = new Vector3(size, size, 1);
        return this;
    }

    // Sets position
    // Return this for builder pattern.
    public EnemyBuilder SetPosition(Vector3 position)
    {
        enemy.transform.position = position;
        return this;
    }

    // Builds enemy
    public GameObject Build()
    {
        return enemy;
    }
}
