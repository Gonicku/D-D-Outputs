
/** Monster
*   A subclass of the GameCharacter class that is used for any non-playable enemy characters.
*/
public class Monster : GameCharacter
{
    public int droppedEXP, droppedGold;
    public Monster(int level, int health, int strength, int dexterity, int speed, int intelligence, int armor, int exp, int gold)
    {
        this.level = level;
        this.health = health;
        this.strength = strength;
        this.dexterity = dexterity;
        this.speed = speed;
        this.intelligence = intelligence;
        this.armor = armor;
        this.droppedEXP = exp;
        this.droppedGold = gold;
    }
}