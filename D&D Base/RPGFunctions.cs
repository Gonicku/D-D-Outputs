
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
        List<Player> players = new List<Player>();
        List<Monster> monsters = new List<Monster>();
        players.Add(player);
        monsters.Add(monster);
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
        int totalEXP = 0, totalGold = 0;
        // Combat loop; Can be updated to add players into a queue based on speed
        while(player.health > 0 && monster.health > 0)
        {
            string playerResponse = "";
            int targetNumber = 0;
            // Player attacks
            Console.WriteLine("Attack the " + monster.name + "? Type 'ATTACK' to fight an enemy.");
            playerResponse = Console.ReadLine();
            if(playerResponse.Equals("ATTACK"))
            {
                Console.WriteLine("Choose an enemy to attack! (E.g. Type '1' for the first enemy)\nNumber of available enemies: " +
                monsters.Count);
                targetNumber = Int32.Parse(Console.ReadLine()) - 1;
                player.targets.Add(monsters[targetNumber]);
                player.Attack(player.targets);
            }
            // Check if player killed a target
            if(monsters[targetNumber].health <= 0)
            {
                Console.WriteLine(monsters[targetNumber].name + " fell!");
                totalEXP += monster.droppedEXP;
                totalGold += monster.droppedGold;
                monsters.Remove(monsters[targetNumber]);
                // If every monster is killed, end the battle
                if(monsters.Count == 0)
                {
                    Console.WriteLine("You got " + totalEXP + " EXP & " + totalGold + " Gold!");
                    for(int i = 0; i < players.Count; i++)
                    {
                        players[i].curEXP += totalEXP;
                        // If a player has enough EXP, they'll level up
                        if(players[i].curEXP >= players[i].maxEXP)
                        {
                            players[i].levelUp();
                        }
                    }
                    players[0].gold += totalGold;
                    break;
                }
            }
            // Monster attacks
            Random rand = new Random();
            targetNumber = rand.Next(0, players.Count - 1);
            monster.targets.Add(players[targetNumber]);
            Console.WriteLine("Target: " + targetNumber);
            monster.Attack(monster.targets);
            // Check if monster killed a player
            if(monster.health <= 0)
            {
                Console.WriteLine(player.name + " died!");
                players.Remove(players[players.IndexOf(player)]);
                // If all players die, end the battle
                if(players.Count == 0)
                {
                    Console.WriteLine("The entire party has been wiped out...");                
                    break;
                }
            }
        }
    }
}