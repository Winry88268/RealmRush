using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    [SerializeField] float towerRange = 25f;
    [SerializeField] ParticleSystem projectileParticles;
    [SerializeField] Transform weapon;
    Transform target;

    void Update() 
    {
        FindClosestTarget();
        AimWeapon();
    }

    void FindClosestTarget()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        Transform closestTarget = null;
        float maxDistance = Mathf.Infinity;

        foreach(Enemy i in enemies)
        {
            float targetDistance = Vector3.Distance(this.transform.position, i.transform.position);

            if(targetDistance < maxDistance)
            {
                closestTarget = i.transform;
                maxDistance = targetDistance;
            }
        }
        this.target = closestTarget;
    }

    void AimWeapon()
    {
        float targetDistance = Vector3.Distance(this.transform.position, this.target.position);

        this.weapon.LookAt(target);

        if(targetDistance < this.towerRange)
        {
            Attack(true);
        }
        else
        {
            Attack(false);
        }
    }

    void Attack(bool isActive)
    {
        var emissionModule = this.projectileParticles.emission;
        emissionModule.enabled = isActive;
    }
}
