using UnityEngine;

public class BossController : MonoBehaviour
{
    public BossData data;

    private int currentHealth;
    private Rigidbody2D rb;
    private Transform player;

    private int currentSkillIndex = 0;

    public Transform Player => player;
    public Rigidbody2D Rigidbody => rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        currentHealth = data.maxHealth;
    }

    void FixedUpdate()
    {
        Move();
        UseSkillSequence();
    }

    void Move()
    {
        if (player == null) return;

        Vector2 dir = (player.position - transform.position).normalized;
        rb.velocity = dir * data.moveSpeed;
    }

    void UseSkillSequence()
    {
        if (data.skills.Length == 0) return;

        BossSkill currentSkill = data.skills[currentSkillIndex];

        if (currentSkill.TryUse(this))
        {
            currentSkillIndex++;

            if (currentSkillIndex >= data.skills.Length)
                currentSkillIndex = 0;
        }
    }

    public void TakeDamage(int dmg)
    {
        currentHealth -= dmg;

        if (currentHealth <= 0)
            Die();
    }

    void Die()
    {
        Destroy(gameObject);
    }
}

