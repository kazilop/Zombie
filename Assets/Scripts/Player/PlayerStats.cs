using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{

    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private Slider healthSlider;
    [SerializeField] BoxCollider2D healthCollider;

    

    private Player player;

    private float currentHealth;

    private void Start()
    {
        healthSlider.maxValue = maxHealth;
        healthSlider.minValue = 0;
        currentHealth = maxHealth;
        healthSlider.value = currentHealth;

    }

    private void DamageRecieve(float damage)
    {
        if (currentHealth > damage)
        {
            currentHealth -= damage;
            healthSlider.value = currentHealth;
            Debug.Log("Fire");
        }

        else
        {
            //player.Die();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Bullet")
        {
            DamageRecieve(5f);
        }
    }
}
