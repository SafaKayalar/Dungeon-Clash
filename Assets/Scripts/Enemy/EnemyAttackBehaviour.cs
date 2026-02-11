using UnityEngine;

public abstract class EnemyAttackBehaviour : ScriptableObject
{
    public abstract void Execute(EnemyController enemy);
}
