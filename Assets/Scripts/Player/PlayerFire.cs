using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class PlayerFire : MonoBehaviour
{

    [SerializeField] private Transform _player;

    [Header("Shoot settings")]
    [SerializeField] private Rigidbody2D myBullet;
    [SerializeField] int ammo = 200;
    [SerializeField] private float _fireRange = 3f;
    [SerializeField] private float _bulletSpeed = 10f;
    [SerializeField] private AudioClip _audioClip;


    [Header("Canvas")]
    [SerializeField] private TextMeshProUGUI _ammoText;

    private List<GameObject> enemiesList;
    private GameObject _targetEnemy;

    private bool iCanShoot = false;

    private void Start()
    {
        enemiesList = new List<GameObject>();
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            enemiesList.Add(enemy);
        }

        iCanShoot = false;
    }


    private void Update()
    {
        enemiesList.RemoveAll(item => item == null);

        foreach (GameObject enemy in enemiesList)
        {

            float distance = Vector3.Distance(enemy.transform.position, _player.position);
            


            if (distance <= _fireRange)
            {
                iCanShoot = true;
                _targetEnemy = enemy;
            }
        }
    }


    public void Fire()
    {
        if ( _targetEnemy != null && iCanShoot && ammo > 0)
        {
            ammo--;
            _ammoText.text = ammo.ToString();

            Vector2 direction = (_targetEnemy.transform.position - transform.position).normalized;

            Rigidbody2D bullet = GameObject.Instantiate(myBullet, transform.position, Quaternion.identity);
            bullet.velocity = direction * _bulletSpeed;

            AudioSource.PlayClipAtPoint(_audioClip, transform.position);
        }
        
    }
}
