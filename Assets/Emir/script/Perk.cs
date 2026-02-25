using UnityEngine;

[CreateAssetMenu(fileName = "NewPerk", menuName = "DungeonGame/Perk")]
public class Perk : ScriptableObject
{
    public string perkName;
    public int maxLevel = 5;
    public int currentLevel;

    [Header("Avantaj (Bonus)")]
    public string bonusType; // "Health", "Speed", "Damage" yazacağız
    public float bonusAmount;

    [Header("Lanet (Bedel)")]
    public string curseType; // "Health", "Speed", "Damage" yazacağız
    public float curseAmount;

    public int GetCost() => 20 * (currentLevel + 1); // İstersen hala altınla da olabilir
}