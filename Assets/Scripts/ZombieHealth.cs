using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieHealth : ObjectHealth
{
    public GameObject ZombieRemains;
    public GameObject ZombieExplosion;

    public override void HandleCollision(GameObject otherObject)
    {
        if (otherObject.gameObject.CompareTag("Bullet"))
        {
            SubtractHealth(otherObject.GetComponent<Bullet>().Damage);
        }
    }
    public override void OnDeath()
    {
         GameObject splat = Instantiate(ZombieRemains,transform.position, Quaternion.identity);
        GameObject explode = Instantiate(ZombieExplosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

}
