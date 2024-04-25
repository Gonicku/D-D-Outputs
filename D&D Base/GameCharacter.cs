
/** GameCharacter
*   An abstract superclass that holds the base information for both playable and enemy characters.
*/
public abstract class GameCharacter
{
    // Enums & Variables
    public enum UseableDice{d6 = 6, d8 = 8, d10 = 10, d12 = 12, d20 = 20};
    public enum AttackTypes{Melee, Ranged, Magic};
    /* Access will be swapped to [SerializeField] private instead of public if Unity is used */
    public int level, health, strength, speed, dexterity, intelligence, armor, attackType;
    public List<GameCharacter> targets = new List<GameCharacter>();
    public UseableDice dodgeDice, hitDice;
    public int curDiceRoll;
    public string name;

    // Functions

    public void SetDice(UseableDice dodge, UseableDice hit)
    {
        dodgeDice = dodge;
        hitDice = hit;
    }

    public void RollDice(UseableDice die)
    {
        // Randomizes the roll based on the die chosen
        curDiceRoll = 0;
        var random = new Random();
        curDiceRoll = random.Next(1, (int) die);
        //Console.WriteLine("Die Rolled = " + curDiceRoll);
    }

    public void Attack(List<GameCharacter> curTargets)
    {
        for(int i = 0; i < curTargets.Count; i++)
        {
            // Roll the hit dice for the attacker and the roll dice for the target(s)
            RollDice(hitDice);
            curTargets[i].RollDice(dodgeDice);
            Console.WriteLine("The dice are cast! " + name + " rolls a '" + curDiceRoll
            + "' vs. " + curTargets[i].name + "'s '" + curTargets[i].curDiceRoll + "'");

            if((speed + curDiceRoll) > (curTargets[i].speed + curTargets[i].level + curTargets[i].curDiceRoll))
            {
                if(attackType == (int) AttackTypes.Melee || attackType == (int) AttackTypes.Ranged)
                {
                    Console.WriteLine(name + "struck " + curTargets[i].name + " for " + (strength + curDiceRoll) + " damage!\n");
                    curTargets[i].health -= strength + curDiceRoll;
                }
                else
                {
                    Console.WriteLine(name + " blasted " + curTargets[i].name + " for " + (intelligence + curDiceRoll) + " damage!\n");
                    curTargets[i].health -= intelligence + curDiceRoll; 
                }
            }
            else
            {
                Console.WriteLine(name + " missed!\n");
            }
        }
        targets.Clear();
    }

    public void setAttackType(string attType)
    {
        string lcAttType = attType.ToLower();
        switch (lcAttType)
        {
            case "melee":
                attackType = 0;
                break;
            
            case "ranged":
                attackType = 1;
                break;

            case "magic":
                attackType = 2;
                break;
        }
        //Console.WriteLine("Attack type set to: " + Enum.GetName(typeof(AttackTypes), attackType));
    }

    public int getStat(string stat)
    {
        string lcStat = stat.ToLower();
        return lcStat switch
        {
            "level" => level,
            "health" => health,
            "strength" => strength,
            "dexterity" => dexterity,
            "speed" => speed,
            "intelligence" => intelligence,
            "armor" => armor,
            _ => -1,
        };
    }

    public void setLevel(int level)
    {
        this.level = level;
    }

}