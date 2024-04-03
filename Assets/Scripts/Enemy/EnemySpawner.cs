using System.Threading;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private RectTransform spawnArea; 
    [SerializeField] private GameObject monsterPrefab; 
    [SerializeField] private int monsterCount = 5;
    [SerializeField] private Transform parentObject;

    void Awake()
    {
        SpawnMonsters();
    }

    void SpawnMonsters()
    {
        Vector2 minSpawnPosition = spawnArea.rect.min;
        Vector2 maxSpawnPosition = spawnArea.rect.max;

        Vector2 monsterSize = monsterPrefab.GetComponent<Collider2D>().bounds.size;

        for (int i = 0; i < monsterCount; i++)
        {
            
            Vector2 spawnPosition = new Vector2(Random.Range(minSpawnPosition.x, maxSpawnPosition.x), Random.Range(minSpawnPosition.y, maxSpawnPosition.y));
            
            Collider2D[] colliders = Physics2D.OverlapBoxAll(spawnPosition, monsterSize, 0f);
            if (colliders.Length > 0)
            {
                i--;
                continue;
            }

            GameObject monster = Instantiate(monsterPrefab, spawnPosition, Quaternion.identity);
            
            if (parentObject != null)
            {
                monster.transform.parent = parentObject;
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(spawnArea.position, spawnArea.rect.size);
    }
}
