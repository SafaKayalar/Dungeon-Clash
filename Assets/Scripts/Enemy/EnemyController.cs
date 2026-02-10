using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyController : MonoBehaviour
{
    public EnemyData data;
    private Rigidbody2D rb;
    private Transform player;
    private int currentHealth;
    private bool isKnocked;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        currentHealth = data.maxHealth;

        //ApplyVisuals();   //sprite kýsmý için
    }

    void FixedUpdate()
    {
        if (player == null || isKnocked) return;

        Vector2 dir = (player.position - transform.position).normalized;
        rb.velocity = dir * data.moveSpeed;
    }

    void ApplyVisuals()
    {
        var sr = GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            sr.sprite = data.sprite;
            sr.color = data.color;
        }
    }

    public void TakeDamage(int dmg, Vector2 hitSource)
    {
        currentHealth -= dmg;
        ApplyKnockback(hitSource);

        if (currentHealth <= 0)
            Die();
    }

    void ApplyKnockback(Vector2 source)
    {
        if (data.knockbackResistance >= 1f) return;

        StartCoroutine(KnockbackRoutine(source));
    }

    IEnumerator KnockbackRoutine(Vector2 source)
    {
        isKnocked = true;

        Vector2 dir = (rb.position - source).normalized;
        rb.velocity = dir * data.knockbackForce * (1f - data.knockbackResistance);

        yield return new WaitForSeconds(0.12f);

        isKnocked = false;
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
