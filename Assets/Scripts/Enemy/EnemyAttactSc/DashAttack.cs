using System.Collections.Generic;
using System.Collections;
using UnityEngine;


[CreateAssetMenu(menuName = "Enemies/Attack/Dash")]
public class DashAttack : EnemyAttackBehaviour
{
    public float triggerRange = 3f;
    public float dashSpeed = 10f;
    public float dashDuration = 0.3f;

    private bool isDashing;

    public override void Execute(EnemyController enemy)
    {
        if (isDashing) return;

        float dist = Vector2.Distance(enemy.player.position, enemy.transform.position);

        if (dist <= triggerRange)
        {
            enemy.StartCoroutine(Dash(enemy));
        }
    }

    private IEnumerator Dash(EnemyController enemy)
    {
        isDashing = true;

        Vector2 dir = (enemy.player.position - enemy.transform.position).normalized;
        enemy.rb.velocity = dir * dashSpeed;

        yield return new WaitForSeconds(dashDuration);

        isDashing = false;
    }
}

