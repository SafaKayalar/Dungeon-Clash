using UnityEngine;

public static class SaveSystem // Sýnýf static olmalý
{
    public static void SavePerk(string name, int level) // Metot static olmalý
    {
        PlayerPrefs.SetInt("Perk_" + name, level);
        PlayerPrefs.Save();
    }

    public static int LoadPerk(string name) // Metot static olmalý
    {
        return PlayerPrefs.GetInt("Perk_" + name, 0);
    }
}