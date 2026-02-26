using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [Header("Karakter Gerçek Statlarý (Test)")]
    public float health = 100f;
    public float speed = 5f;
    public float damage = 10f;

    public Perk[] availablePerks; // Inspector'dan 20 taneyi buraya atacaðýz

    void Update()
    {
        // 1 tuþuna basýnca RASTGELE bir lanetli perk al
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ApplyRandomCursedPerk();
        }
    }

    void ApplyRandomCursedPerk()
    {
        // Rastgele bir perk seç
        int randomIndex = Random.Range(0, availablePerks.Length);
        Perk p = availablePerks[randomIndex];

        if (p.currentLevel < p.maxLevel)
        {
            p.currentLevel++;

            // 1. AVANTAJI UYGULA
            ApplyStatChange(p.bonusType, p.bonusAmount, true);

            // 2. LANETÝ UYGULA
            ApplyStatChange(p.curseType, p.curseAmount, false);

            Debug.Log($"<color=green>{p.perkName}</color> ALINDI!");
            Debug.Log($"Yeni Durum -> Can: {health}, Hýz: {speed}, Hasar: {damage}");
        }
    }

    void ApplyStatChange(string type, float amount, bool isBonus)
    {
        float multiplier = isBonus ? 1 : -1; // Bonus ise ekle, lanet ise çýkar
        float finalChange = amount * multiplier;

        if (type == "Health") health += finalChange;
        else if (type == "Speed") speed += finalChange;
        else if (type == "Damage") damage += finalChange;
    }
}