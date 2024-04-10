using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemies;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            int rEnemy = Random.Range(0, enemies.Length);
            float rSpawnPoint = Random.Range(-1.5f, 1.5f);
            Instantiate(enemies[rEnemy], new Vector2(rSpawnPoint, transform.position.y), Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(0.5f, 1f));
        }
    }
}
