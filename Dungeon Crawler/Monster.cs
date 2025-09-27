using System;
namespace DevelopHerShani
{
	public class Monster : Character
	{
        public int OriginHp;
        public int OriginPower;
        
        public Monster CreateMonster(int roomlevel)
		{
            Monster monster = new Monster();
            Random rnd = new Random();
            monster.power = rnd.Next(20, 100*roomlevel);
            monster.OriginPower = monster.power;
            monster.hp = rnd.Next(30, 100*roomlevel);
            monster.OriginHp = monster.hp;   
            monster.ID = "Monster" + roomlevel.ToString();
            Console.WriteLine($"Monster stats : power is : {monster.power} and hp is : {monster.hp}");
            return monster;
        }
        
        public void ResetMonster (Monster monster)
        {
            monster.power = monster.OriginPower;
            monster.hp = monster.OriginHp;
        }
    }
}

