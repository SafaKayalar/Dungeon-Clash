using UnityEngine;
[CreateAssetMenu(fileName = "EnemyAttack",menuName = "Enemies/Attack/Melee")]
public class MeleeAttack : EnemyAttackBehaviour
{
    public float attackRange = 1.2f;
    public int damage = 1;

    public override void Execute(EnemyController enemy)
    {
        float dist = Vector2.Distance(enemy.player.transform.position, enemy.transform.position);

        if (dist <= attackRange)
        {
            //enemy.Player.GetComponent<Player>().TakeDamage(damage);
        }
    }
}
