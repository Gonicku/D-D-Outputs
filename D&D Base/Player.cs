/** Player
*   A subclass of the GameCharacter class that is used for any playable characters.
*/
public class Player : GameCharacter
{
    public Player(int level, int health, int strength, int dexterity, int speed, int intelligence, int armor)
    {
        this.level = level;
        this.health = health;
        this.strength = strength;
        this.dexterity = dexterity;
        this.speed = speed;
        this.intelligence = intelligence;
        this.armor = armor;
    }

    // Methods
    public void levelUp()
    {
        level++;
        // Increase stats accordingly
    }
}