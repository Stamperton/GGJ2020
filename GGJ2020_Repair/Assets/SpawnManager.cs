using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    #region Singleton
    public static SpawnManager instance;
    void Awake()
    {
        instance = this;
    }
    #endregion

    List<Wound> woundsList = new List<Wound>();

    public float currentWave = 0; //Wave number
    public Vector2 waveSize; //Wave size variance
    public float enemyCount; //How many this wave
    public float waveIncrement; //How many extra per wave
    public float currentEnemies; //Currently Alive
    public float enemiesSpawned; //Spawned This Wave

    float timer;
    float newWaveTimer;

    public float timeUNtilNewWave;


    public void Update()
    {
        timer += Time.deltaTime;
        newWaveTimer += Time.deltaTime;

        if (currentEnemies <= 3 && timer >= 3f || newWaveTimer >= timeUNtilNewWave)
        {
            NewWave();
        }

    }
    public void NewWave()
    {
        timer = 0f;
        newWaveTimer = 0f;
        if (currentWave > 1)
        {
            waveSize.x += waveIncrement;
            waveSize.y += waveIncrement;
        }

        currentWave++;
        enemiesSpawned = 0;

        enemyCount = Mathf.CeilToInt(Random.Range(waveSize.x, waveSize.y));

    }


    public void AddToList(Wound addWound)
    {
        woundsList.Add(addWound);
    }

    public void RemoveFromList (Wound removeWound)
    {
        woundsList.Remove(removeWound);
    }

    public Transform FindWoundDestination()
    {
        int _random = Random.Range(0, woundsList.Count);
        return woundsList[_random].gameObject.transform;
    }
}
