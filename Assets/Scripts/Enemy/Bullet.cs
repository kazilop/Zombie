using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float destroyTime = 3f;

    private Rigidbody2D rb;

    void Start() { 

        rb = GetComponent<Rigidbody2D>();

        if(rb != null)
        {
            rb.gravityScale = 0f;
        }
  
       
        Invoke("DestroyObject", destroyTime);
    }

    void DestroyObject()
    {
       Destroy(gameObject);
    }
}
