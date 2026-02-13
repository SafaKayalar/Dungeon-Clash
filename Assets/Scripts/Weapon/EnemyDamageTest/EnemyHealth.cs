using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health = 5;

    public void TakeDamage(int damage)
    {
        health -= damage;

        Debug.Log("Enemy can: " + health);

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Enemy öldü");
        Destroy(gameObject);
    }
}
