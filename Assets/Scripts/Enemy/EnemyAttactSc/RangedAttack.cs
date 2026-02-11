using UnityEngine;

[CreateAssetMenu(menuName = "Enemies/Attack/Ranged")]
public class RangedAttack : EnemyAttackBehaviour
{
    public float attackRange = 5f;
    public GameObject projectilePrefab;
    public float fireCooldown = 2f;

    private float lastFireTime;

    public override void Execute(EnemyController enemy)
    {
        float dist = Vector2.Distance(enemy.player.position, enemy.transform.position);

        if (dist <= attackRange && Time.time > lastFireTime + fireCooldown)
        {
            lastFireTime = Time.time;

            GameObject proj = Instantiate(projectilePrefab,
                enemy.transform.position,
                Quaternion.identity);

            Vector2 dir = (enemy.player.position - enemy.transform.position).normalized;
            proj.GetComponent<Rigidbody2D>().velocity = dir * 8f;
        }
    }
}
