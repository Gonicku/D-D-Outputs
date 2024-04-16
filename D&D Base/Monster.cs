
public class Monster : GameCharacter
{
    public Monster(int level, int health, int strength, int dexterity, int speed, int intelligence, int armor)
    {
        this.level = level;
        this.health = health;
        this.strength = strength;
        this.dexterity = dexterity;
        this.speed = speed;
        this.intelligence = intelligence;
        this.armor = armor;
    }
}