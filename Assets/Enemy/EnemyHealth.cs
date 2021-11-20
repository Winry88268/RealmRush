using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHitPoints = 5;

    Enemy enemy;
    int currHitPoints;

    void OnEnable() 
    {
        this.currHitPoints = this.maxHitPoints;
    }

void Start() 
    {
        this.enemy = this.GetComponent<Enemy>();
    }

    void OnParticleCollision(GameObject other)
    {

        ProcessHit();
    }

    void ProcessHit()
    {
        this.currHitPoints--;

        if (this.currHitPoints <= 0)
        {
            this.gameObject.SetActive(false);
            this.enemy.RewardGold();
        }
    }
}
