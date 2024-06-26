using UnityEngine;

public class EnemyAgroChaeck : MonoBehaviour
{
    public GameObject playerTarget { get; set; }
    private Enemy _enemy;

    private void Awake()
    {
        playerTarget = GameObject.FindGameObjectWithTag("Player");

        _enemy = GetComponentInParent<Enemy>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == playerTarget)
        {
            _enemy.SetAgroStatus(true);
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == playerTarget)
        {
            _enemy.SetAgroStatus(false);
        }
    }
}
