using UnityEngine;

[CreateAssetMenu(menuName = "Boss/Skills/Shoot Skill")]
public class ShootSkill10x : BossSkill
{
    public GameObject projectilePrefab;// hasar verme foksiyonu vs bunda oacak
    public int bulletCount = 10;
    public float spreadAngle = 120f;
    public float bulletSpeed = 10f;

    protected override void Execute(BossController boss)
    {
        float startAngle = -spreadAngle / 2f;
        float angleStep = spreadAngle / (bulletCount - 1);

        for (int i = 0; i < bulletCount; i++)
        {
            float angle = startAngle + (angleStep * i);

            Quaternion rotation = Quaternion.Euler(0, angle, 0);
            GameObject bullet = Instantiate(projectilePrefab, boss.transform.position, rotation);

            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = rotation * Vector3.forward * bulletSpeed;
            }
        }
    }
}
