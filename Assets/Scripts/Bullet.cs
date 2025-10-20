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

    // Handle collision with targets
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Target"))
        {
            collision.GetComponent<Target>().Hit();
            ObjectPool.Instance.ReturnBullet(gameObject);
        }
    }


}
