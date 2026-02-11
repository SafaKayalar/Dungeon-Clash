using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Boss/Boss Data")]
public class BossData : ScriptableObject
{
    public int maxHealth;
    public float moveSpeed;

    public BossSkill[] skills;
}
