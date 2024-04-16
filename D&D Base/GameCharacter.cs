
public abstract class GameCharacter
{
    // Enums & Variables
    enum UseableDice{d6 = 6, d8 = 8, d10 = 10, d12 = 12, d20 = 20};
    enum AttackTypes{Melee, Ranged, Magic};
    /* Access will be swapped to [SerializeField] private instead of public if Unity is used */
    public int level, health, strength, speed, dexterity, intelligence, armor, attackType;
    public GameCharacter[] targets;
    private UseableDice dodgeDice, hitDice;
    public int curDiceRoll;

    // Functions
    public void Attack(GameCharacter[] curTargets)
    {
        for(int i = 0; i < curTargets.Length; i++)
        {
            if((speed + curDiceRoll) > (curTargets[i].speed + curTargets[i].level + curTargets[i].curDiceRoll))
            {
                if(attackType == (int) AttackTypes.Melee || attackType == (int) AttackTypes.Ranged)
                {
                    curTargets[i].health -= strength + curDiceRoll;
                }
                else
                {
                    curTargets[i].health -= intelligence + curDiceRoll; 
                }
            }
        }
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
        Console.WriteLine("Attack type set to: " + Enum.GetName(typeof(AttackTypes), attackType));
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