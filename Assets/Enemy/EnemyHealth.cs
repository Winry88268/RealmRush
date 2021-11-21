using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHitPoints = 5;
    
    [Tooltip("Addition to Max Hit Point on Enemy Death")]
    [SerializeField] int diffRamp = 1;

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
            this.maxHitPoints += this.diffRamp;
            this.gameObject.SetActive(false);
            this.enemy.RewardGold();
        }
    }
}
