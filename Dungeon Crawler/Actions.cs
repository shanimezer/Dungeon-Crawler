namespace DevelopHerShani;

public class Actions
{
    public int xpAdd;
    public int xpToLevelUp;
    public int hpSubtract;
    public int powerSubtract;

    public Actions SetActionsStats()
    {
        Actions actions = new Actions();
        actions.xpAdd = 10;
        actions.xpToLevelUp = 10;
        actions.hpSubtract = 10;
        actions.powerSubtract = 10;
        return actions;
    }

    public static void Round (Character attacker, Character defender, Actions actions)
    {
        if (attacker.power > 0)
        {
            attacker.power -= actions.powerSubtract * (defender.level+1);
            defender.hp -= actions.hpSubtract * (attacker.level+1);    
        }
        else
        {
            Console.WriteLine($"Power is up. {attacker.ID} is resting for this round to recive some power points back. Press enter to continue for the next round. ");
            Console.ReadLine();
            attacker.power = actions.powerSubtract * (attacker.level+1);
        }
    }
}