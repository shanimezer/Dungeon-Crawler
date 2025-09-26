using System;
namespace DevelopHerShani
{
	public class Monster
	{
        private int OriginHp;
        public int currentHp;
        private int OriginPower;
        public int currentPower;


        public Monster CreateMonster(int roomlevel)
		{
            Monster monster = new Monster();
            Random rnd = new Random();
            monster.currentPower = rnd.Next(20, 40*roomlevel);
            monster.OriginPower = monster.currentPower;
            monster.currentHp = rnd.Next(30, 50*roomlevel);
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

