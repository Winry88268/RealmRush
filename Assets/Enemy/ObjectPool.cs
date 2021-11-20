using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] int poolSize = 5;
    [SerializeField] float spawnTimer = 1f;

    GameObject[] gamePool;

    void Awake() 
    {
        PopulatePool();
    }

    void Start() 
    {
        StartCoroutine(SpawnEnemy());
    }

    void PopulatePool()
    {
        gamePool = new GameObject[poolSize];

        for(int i = 0; i < gamePool.Length; i++)
        {
            gamePool[i] = Instantiate(this.enemyPrefab, this.transform);
            gamePool[i].SetActive(false);
        }
    }

    void EnableObjectInPool()
    {
        for(int i = 0; i < gamePool.Length; i++)
        {
            if(gamePool[i].activeInHierarchy == false)
            {
                gamePool[i].SetActive(true);
                return;
            }
        }
    }

    IEnumerator SpawnEnemy()
    {
        while(true)
        {
            EnableObjectInPool();
            yield return new WaitForSeconds(spawnTimer);
        } 
    }
}
