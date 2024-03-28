using UnityEngine;

public class Movement : MonoBehaviour
{
    public Joystick joy;
    private float joyspeed;
    private Vector3 move = Vector3.zero;
    private Rigidbody2D rb;

    [Header("Setting")]
    [SerializeField] float speed;

    [Header("Bullet")]
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        JoystickFun();
    }     

    void JoystickFun()
    {
        joyspeed = joy.speed;
        Vector2 direction = joy.direction;

        if (joyspeed > 0.0f)
        {
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            move.z = direction.y;
            move.y = 0f;
            move.x = direction.x;

            direction.Normalize();
        }


        if (joyspeed == 0.0f) 
        {
            direction = Vector2.zero;
        }

        rb.velocity = direction * speed * Time.deltaTime;
    }

    private void Shoot()
    {
        Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
    }
}
