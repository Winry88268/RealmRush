using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHitPoints = 5;
    
    int currHitPoints;

    void Start() 
    {
        this.currHitPoints = this.maxHitPoints;
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
            Destroy(this.gameObject);
        }
    }
}