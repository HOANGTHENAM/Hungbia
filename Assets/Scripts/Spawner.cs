using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    bool canSpawn = true;
    public ObjectPooling objectPool;
    public Vector3 spawnPosition;
    public float timeToSpawn = 2f;
    public float timeElapse = 0f;

    private void OnEnable()
    {
        GameManager.OnGamePlay += ContinueSpawn;
        GameManager.OnGamePause += PauseSpawn;
        GameManager.OnGameOver += PauseSpawn;
        //them replay
    }
    public void OnDisable()
    {
        GameManager.OnGamePlay -= ContinueSpawn;
        GameManager.OnGamePause -= PauseSpawn;
        GameManager.OnGameOver -= PauseSpawn;
        //them replay
    }
    private void Update()
    {
        if (!canSpawn)
        {
            return;
        }

        spawnPosition = new Vector3(Random.Range(-2f, 2f), 7f, 0);
        if (timeElapse >= timeToSpawn)
        {
            objectPool.SpawnFromPool(spawnPosition, Quaternion.identity, this.transform);
            timeElapse = 0f;
        }
        else
        {
            timeElapse += Time.deltaTime;
        }



    }
    public void PauseSpawn()
    {
        canSpawn = false;
    }
    public void ContinueSpawn()
    {
        canSpawn = true;
    }
}
