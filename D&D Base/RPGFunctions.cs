
public class RPGFunctions
{
    public static void Main(string[] args)
    {
        Monster monster = new Monster(1, 20, 10, 7, 6, 4, 3);
        Player player = new Player(3, 32, 12, 10, 9 ,8, 7);
        monster.setAttackType("Melee");
        player.setAttackType("Magic");
        
        Console.WriteLine("Monster Stats\nLevel: " + monster.getStat("Level") + "\nHealth: " + monster.getStat("Health"));
        Console.WriteLine("Player Stats\nLevel: " + player.getStat("Level") + "\nHealth: " + player.getStat("Health"));
    }
}