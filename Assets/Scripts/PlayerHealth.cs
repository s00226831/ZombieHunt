using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : ObjectHealth
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        HandleCollision(collision.gameObject);
    }

    public override void HandleCollision(GameObject otherObject)
    {
        if (otherObject.gameObject.CompareTag("Zombie"))
        {
            SubtractHealth(otherObject.GetComponent<Zombie>().Damage);    
        }
    }
    public override void OnDeath()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        base.OnDeath();
    }

}
