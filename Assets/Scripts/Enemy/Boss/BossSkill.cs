using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BossSkill : ScriptableObject
{
    public float cooldown = 3f;
    protected float lastUseTime;

    public bool TryUse(BossController boss)
    {
        if (Time.time < lastUseTime + cooldown) return false;

        lastUseTime = Time.time;

        Execute(boss);
        return true;
    }

    protected abstract void Execute(BossController boss);
}
