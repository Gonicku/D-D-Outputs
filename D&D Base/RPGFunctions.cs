
using System.Globalization;

/** RPGFunctions
*   Acts as the main class to run all our code
*/
public class RPGFunctions
{
    public static void Main(string[] args)
    {
        // Creates our initial monster(s) and player(s)
        Monster monster = new Monster(1, 20, 10, 7, 6, 4, 3, 20, 12);
        Player player = new Player(3, 32, 12, 10, 9 ,8, 7);
        Console.WriteLine("Please enter a name for your player.");
        player.name = Console.ReadLine();
        Console.WriteLine("Player Name '" + player.name + "' accepted.\n");
        monster.name = "Orc";
        // Sets the dice they're able to use
        player.SetDice(GameCharacter.UseableDice.d8, GameCharacter.UseableDice.d10);
        monster.SetDice(GameCharacter.UseableDice.d6, GameCharacter.UseableDice.d6);
        // Sets their attack type
        monster.setAttackType("Melee");
        player.setAttackType("Magic");
        
        // Test Run
        //Console.WriteLine(monster.name + " Stats\nLevel: " + monster.getStat("Level") + "\nHealth: " + monster.getStat("Health"));
        //Console.WriteLine(player.name + " Stats\nLevel: " + player.getStat("Level") + "\nHealth: " + player.getStat("Health"));

        Console.WriteLine(player.name + " ran into an " + monster.name + "!\n\t*BATTLE START*");
        // Combat loop
        while(player.health > 0 && monster.health > 0)
        {
            string playerResponse = "";
            // Player attacks
            Console.WriteLine("Attack the " + monster.name + "? Type 'ATTACK' to fight it.");
            playerResponse = Console.ReadLine();
            if(playerResponse.Equals("ATTACK"))
            {
                player.targets.Add(monster);
                player.Attack(player.targets);
            }
            // Check if player killed a target
            if(monster.health <= 0)
            {
                Console.WriteLine(monster.name + " fell!\nYou got " + monster.droppedEXP +
                " EXP & " + monster.droppedGold + " Gold!");
                player.curEXP += monster.droppedEXP;
                player.gold += monster.droppedGold;
                if(player.curEXP >= player.maxEXP)
                {
                    player.levelUp();
                }
                break;
            }
            // Monster attacks
            monster.targets.Add(player);
            monster.Attack(monster.targets);
            // Check if monster killed a player
            if(monster.health <= 0)
            {
                Console.WriteLine(player.name + " died!");
                break;
            }
        }
    }
}