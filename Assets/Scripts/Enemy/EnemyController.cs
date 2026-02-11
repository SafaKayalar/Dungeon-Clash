using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyController : MonoBehaviour
{
    public EnemyData data;

    public Rigidbody2D rb;
    public Transform player; // manegerdan alınacak

    private int currentHealth;
    private bool isKnocked;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; //manegerdan alacak

        currentHealth = data.maxHealth;
    }

    void FixedUpdate()
    {
        if (player == null) return;

        if (!isKnocked)
        {
            Move();
        }
    }

    void Move()
    {
        Vector2 dir = (player.position - transform.position).normalized;
        rb.velocity = dir * data.moveSpeed;
    }

    public void TakeHeal(int Heal)
    {
        if (Heal < 0) return;

        currentHealth += Heal;

        if (currentHealth >= data.maxHealth)
        {
            currentHealth = data.maxHealth;
        }

        //update heal ui
            
    }


    public void TakeDamage(int dmg, Vector2 hitSource)
    {
        currentHealth -= dmg;
        ApplyKnockback(hitSource);

        //update healt ui

        if (currentHealth <= 0)
            Die();
    }

    void ApplyKnockback(Vector2 source)
    {
        if (data.knockbackResistance >= 1f) return;

        StopAllCoroutines();
        StartCoroutine(KnockbackRoutine(source));
    }

    IEnumerator KnockbackRoutine(Vector2 source)
    {
        isKnocked = true;

        Vector2 dir = (rb.position - source).normalized;
        rb.velocity = dir * data.knockbackForce * (1f - data.knockbackResistance);

        yield return new WaitForSeconds(0.15f);

        isKnocked = false;
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
