using System;
namespace DevelopHerShani
{
	public class Monster
	{
        private int OriginHp;
        public int currentHp;
        private int OriginPower;
        public int currentPower;


        public Monster CreateMonster(Monster monster, int level)
		{
            Random rnd = new Random();
            monster.currentPower = rnd.Next(20, 40*level);
            monster.OriginPower = monster.currentPower;
            monster.currentHp = rnd.Next(30, 50*level);
            monster.OriginHp = monster.currentHp;   
            Console.WriteLine($"Monster stats : power is : {monster.OriginPower} and hp is : {monster.OriginHp}");
            return monster;
        }

        public int Attack(Monster monster, Player player)
        {
            return monster.currentPower -=10 ;
        }

        public int GetAttacked(Monster monster, Player player)
        {
            return monster.currentHp -= player.power ;
        }

        public void ResetMonster (Monster monster)
        {
            monster.currentPower = monster.OriginPower;
            monster.currentHp = monster.OriginHp;
        }
    }
}

