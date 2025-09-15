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

        public Player CreatePlayer(Player player)
		{
            player.hp = 100;
            player.power = 50;
            player.level = 1;
            Console.WriteLine($"Your stats are:  power is : {player.power} , hp is  :{player.hp}");
            return player;
           
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

