using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Enemies/Enemy Data")]
public class EnemyData : ScriptableObject
{
    public string enemyName;

    [Header("Stats")]
    public int maxHealth = 10;
    public float moveSpeed = 2f;
    public float damage = 1f;

    [Header("Combat")]
    public float knockbackForce = 5f;
    [Range(0f, 1f)]
    public float knockbackResistance = 0f;

    [Header("Visual")]
    public Sprite sprite;
    public Color color = Color.white;
}
