using UnityEngine;

[CreateAssetMenu(menuName = "Boss/Skills/Multi Shoot 10x")]
public class ShootSkill : BossSkill
{
    public GameObject projectilePrefab;

    public int projectileCount = 1;
    public float spreadAngle = 30f;   // cone açýsý
    public float projectileSpeed = 8f;

    protected override void Execute(BossController boss)
    {
        Vector2 baseDir = (boss.Player.position - boss.transform.position).normalized;

        if (projectileCount <= 1)
        {
            SpawnProjectile(boss, baseDir);
            return;
        }

        float angleStep = spreadAngle / (projectileCount - 1);
        float startAngle = -spreadAngle / 2f;

        for (int i = 0; i < projectileCount; i++)
        {
            float angle = startAngle + angleStep * i;
            Vector2 dir = RotateVector(baseDir, angle);
            SpawnProjectile(boss, dir);
        }
    }

    void SpawnProjectile(BossController boss, Vector2 direction)
    {
        GameObject proj = Instantiate(
            projectilePrefab,
            boss.transform.position,
            Quaternion.identity
        );

        proj.GetComponent<Rigidbody2D>().velocity = direction.normalized * projectileSpeed;
    }

    Vector2 RotateVector(Vector2 v, float degrees)
    {
        float rad = degrees * Mathf.Deg2Rad;
        float sin = Mathf.Sin(rad);
        float cos = Mathf.Cos(rad);

        float tx = v.x;
        float ty = v.y;

        return new Vector2(
            cos * tx - sin * ty,
            sin * tx + cos * ty
        );
    }
}
