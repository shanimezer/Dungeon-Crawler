using System;
using System.Numerics;
using System.Threading;

namespace DevelopHerShani
{
	public class Player
	{

        public int level;
        public int power;
        public int hp;
        public int lifeC = 10;
        public int score;
        public int xp;

        public Player CreatePlayer()
		{
            Player player = new Player();
            player.hp = 100;
            player.power = 50;
            player.level = 1;
            Console.WriteLine($"Your stats are:  power is : {power} , hp is  :{hp}");
            return player;
           
        }
        
        public bool Fight(Player player, Room room)
        {
            if (room.isMonsterAlive)
            {
                bool isPlayerTurn = true;
                room.currentMonster.ResetMonster(room.currentMonster);

                Console.WriteLine("Press Enter to start the Battle!");
                Console.ReadLine();
                while (player.hp > 0 && room.currentMonster.currentHp > 0)
                {
                    if (isPlayerTurn)
                    {
                        Console.WriteLine("It's your turn to attack : press enter when you're ready! ");
                        Console.ReadLine();
                        room.currentMonster.currentHp = room.currentMonster.GetAttacked(room.currentMonster, player);
                        player.power = player.Attack(room.currentMonster, player);
                        Console.WriteLine($"Keep up: your power is : {player.power} and your currentHp is: {player.hp}");
                        Console.WriteLine($"Monster's stats: power: {room.currentMonster.currentPower} , hp is: {room.currentMonster.currentHp}");
                        Console.WriteLine();

                    }
                    else
                    {
                        Console.WriteLine("Bewear the monster is attacking you :");
                        player.hp = player.GetAttacked(room.currentMonster, player);
                        room.currentMonster.currentPower = room.currentMonster.Attack(room.currentMonster, player);
                        Console.WriteLine();
                        Console.WriteLine($"Your stats are: your power is {player.power} and your hp is {player.hp}");
                        Console.WriteLine($"Monster's stats: power : {room.currentMonster.currentPower}, hp : {room.currentMonster.currentHp}");
                        Console.WriteLine();
                    }

                    isPlayerTurn = !isPlayerTurn;
					
                    if (room.currentMonster.currentHp <= 0)
                    {
                        player.level++;
                        player.score++;
                        room.isMonsterAlive = false;
                        Console.WriteLine($"You killed the monster. Good for you! Youv'e leveled up to level {player.level}!");
                        return true;
                    }
                }
            }
            return false;
        }

        public int Attack(Monster monster, Player player)
        {
            return player.power -= 10;
        }

        public int GetAttacked (Monster monster, Player player)
        {
            return (player.hp - monster.currentPower);
        }

        public Player ResetStats(Player player,int level)
        {
            player.hp = 100*level;
            player.power = 50*level;
            player.level = level;
            Console.WriteLine($"Your level is {level}, your power is: {player.power} and your hp is {player.hp}");
            return player;
        }
        
  
    }

}
