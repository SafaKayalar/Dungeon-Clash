using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Boss/Skills/Dash")]
public class DashSkill : BossSkill
{
    public float dashSpeed = 15f;
    public float dashDuration = 0.3f;

    protected override void Execute(BossController boss)
    {
        boss.StartCoroutine(DashRoutine(boss));
    }

    private System.Collections.IEnumerator DashRoutine(BossController boss)
    {
        Vector2 dir = (boss.Player.position - boss.transform.position).normalized;

        boss.Rigidbody.velocity = dir * dashSpeed;

        yield return new WaitForSeconds(dashDuration);
    }
}

