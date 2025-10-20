
using UnityEngine;

public class Target : MonoBehaviour
{
    public float speed = 2f;
    public int points = 1;

    private Animator animator;
    public static event System.Action<int> OnTargetHit;//event to notify observers
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Move left across the top of the screen
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        // Destroy if off-screen
        if (transform.position.x < -10f)
            Destroy(gameObject);
    }

    // Call this when hit by a bullet
    public void Hit()
    {
        // Trigger hit animation
        animator.SetTrigger("Hit");
        OnTargetHit?.Invoke(points); // Notify any listeners
        // Notify observer (ScoreManager)
        //ScoreManager.instance.AddScore(points);

        // Destroy after short delay for animation
        Destroy(gameObject, 0.4f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerBullet"))
        {
            Hit();
            Destroy(collision.gameObject); // destroy bullet
        }
    }
}

