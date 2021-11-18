using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] Enemy enemyPrefab;
    [SerializeField] float spawnTimer = 1f;

    void Start() 
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        while(true)
        {
            Instantiate(this.enemyPrefab, this.transform);
            yield return new WaitForSeconds(spawnTimer);
        } 
    }
}
