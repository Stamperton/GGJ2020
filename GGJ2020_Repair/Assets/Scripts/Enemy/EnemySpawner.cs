using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;

    public Vector2 spawnDelay;
    float spawn;
    float timer;

    void Start()
    {
        NewSpawnTimer();   
    }

    public void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawn)
        {
            SpawnEnemy();
            timer = 0f;
            NewSpawnTimer();
        }
    }

    void NewSpawnTimer()
    {
        spawn = Mathf.CeilToInt(Random.Range(spawnDelay.x, spawnDelay.y));
    }

    void SpawnEnemy()
    {
        if (SpawnManager.instance.enemiesSpawned >= SpawnManager.instance.enemyCount)
        {
            return;
        }
        SpawnManager.instance.enemiesSpawned++;
        GameObject _enemy = Instantiate(enemyPrefab, transform.position, transform.rotation);
        _enemy.transform.SetParent(this.transform);
    }
}
