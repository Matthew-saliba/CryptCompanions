public static class PlayerData
{
    public static int CurrentHealth { get; set; }
    public static int MaxHealth { get; set; } = 100;
    public static int Arrows { get; set; } = 30;
    public static int HealFlasks { get; set; } = 2;

    public static void Initialize(int maxHealth, int arrows, int healFlasks)
    {
        MaxHealth = maxHealth;
        CurrentHealth = maxHealth;
        Arrows = arrows;
        HealFlasks = healFlasks;
    }
}