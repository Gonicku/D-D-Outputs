/** Player
*   A subclass of the GameCharacter class that is used for any playable characters.
*/
public class Player : GameCharacter
{
    public int curEXP, maxEXP, gold;
    public Player(int level, int health, int strength, int dexterity, int speed, int intelligence, int armor)
    {
        this.level = level;
        this.health = health;
        this.strength = strength;
        this.dexterity = dexterity;
        this.speed = speed;
        this.intelligence = intelligence;
        this.armor = armor;

        curEXP = 0;
        maxEXP = 20;
        gold = 0;
    }

    // Methods
    public void levelUp()
    {
        curEXP -= maxEXP;
        level++;
        Console.WriteLine(name + " leveled up! They are now Level " + level);
        // Increase stats accordingly
    }
}