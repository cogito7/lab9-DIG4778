using UnityEngine;


public class Bullet : MonoBehaviour
{
    public float speed = 10f;

    private void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    private void OnBecameInvisible()
    {
        ObjectPool.Instance.ReturnBullet(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("trigger: " + collision.tag);
        if (collision.CompareTag("Target"))
        {
            Debug.Log("target");
            collision.GetComponent<Target>().Hit();
            ObjectPool.Instance.ReturnBullet(gameObject);
        }
    }


}
