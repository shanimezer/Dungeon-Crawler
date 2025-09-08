using System;
using System.Numerics;

namespace DevelopHerShani
{
	public class Player
	{

        public int level;
        public int power;
        public int hp;

        public Player CreatePlayer(Player player)
		{
            player.hp = 100;
            player.power = 50;
            player.level = 1;
            return player;
        }

        public int Attack(Monster monster, Player player)
        {
            return player.power--;
        }

        public int GetAttacked (Monster monster, Player player)
        {
            return (player.hp - monster.power);
        }
    }
}

