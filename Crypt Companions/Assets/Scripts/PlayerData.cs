public static class PlayerData
{
    public static int CurrentHealth { get; set; }
    public static int MaxHealth { get; set; }
    public static int Arrows { get; set; }
    public static int HealFlasks { get; set; }

    public static void Initialize(int maxHealth, int arrows, int healFlasks)
    {
        MaxHealth = maxHealth;
        CurrentHealth = maxHealth;
        Arrows = arrows;
        HealFlasks = healFlasks;
    }
}