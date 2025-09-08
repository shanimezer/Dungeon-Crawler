using System;
namespace DevelopHerShani
{
	public class Monster
	{
        public int hp;
        public int power;

		public Monster CreateMonster (Monster monster)
		{
            Random rnd = new Random();
            monster.power = rnd.Next(50, 500);
            monster.hp = rnd.Next(50, 700);
            Console.WriteLine($"Monster stats : power is : {monster.power} and hp is : {monster.hp}");
            return monster;
        }

        public int Attack(Monster monster, Player player)
        {
            return monster.power -= 10;
        }

        public int GetAttacked(Monster monster, Player player)
        {
            return monster.hp -= player.power ;
        }
    }
}

