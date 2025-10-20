using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Animator animator;
    private Vector2 moveInput;// horizonatal and vertical directions
    [SerializeField] private Transform firePoint;//firepoint from where bullets come out of
    [SerializeField] private float fireRate = 0.5f;
    private float nextFireTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //get player input for WASD or arrow keyes
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        //prevent diagonals
        moveInput.Normalize();

        //update animator MoveSpeed
        animator.SetFloat("MoveSpeed", moveInput.sqrMagnitude);

        //shooting
        if (Input.GetKey(KeyCode.Space) && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    void FixedUpdate()
    {
        //apply movement
        rb.velocity = moveInput * moveSpeed;
    }

    //shooting function
    void Shoot()
    {
        if (firePoint == null) return;

        // get a bullet from the object pool
        GameObject bullet = ObjectPool.Instance.GetBullet();
        bullet.transform.position = firePoint.position;
        bullet.transform.rotation = firePoint.rotation;
    }
}
