using UnityEngine;


public class Damage : MonoBehaviour
{
    [SerializeField] private CircleCollider2D circleCollider;


    private Enemy enemy;
    public float damageStrange = 10;

    void Start()
    {
        enemy = GetComponentInParent<Enemy>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (enemy != null && collision.tag == "PlayerBullet")
        {
            enemy.Damage(damageStrange);
        }
    }
}
