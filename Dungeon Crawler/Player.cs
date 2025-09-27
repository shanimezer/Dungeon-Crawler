using System;
using System.Numerics;
using System.Threading;

namespace DevelopHerShani
{
	public class Player : Character
	{
        public int level;
       // public int power;
       // public int hp;
        public int lifeC = 10;
        public int score;
        public int xp;

        public Player CreatePlayer()
		{
            Player player = new Player();
            player.hp = 100;
            player.power = 50;
            player.level = 1;
            player.xp = 0;
            player.score = 0;
            Console.WriteLine($"Your stats are:  power is : {player.power} , hp is  :{player.hp}");
            return player;
           
        }
        
        public bool Fight(Player player, Room room, Actions actions)
        {
            if (room.isMonsterAlive)
            {
                bool isPlayerTurn = true;
                room.currentMonster.ResetMonster(room.currentMonster);

                Console.WriteLine("Press Enter to start the Battle!");
                Console.ReadLine();
                while (player.hp > 0 && room.currentMonster.hp > 0)
                {
                    if (isPlayerTurn)
                    {
                        Console.WriteLine("It's your turn to attack : press enter when you're ready! ");
                        Console.ReadLine();
                        Actions.Round(player, room.currentMonster,actions);
                        //room.currentMonster.currentHp = room.currentMonster.GetAttacked(room.currentMonster, player);
                        //player.power = player.Attack(room.currentMonster, player);
                        Console.WriteLine($"Keep up: you have left: {player.power} power points" );
                        Console.WriteLine($"Monster has left : {room.currentMonster.hp} HP ");
                        Console.WriteLine();

                    }
                    else
                    {
                        Console.WriteLine("Be-wear the monster is attacking you :");
                        Actions.Round(room.currentMonster, player,actions);
                       // player.hp = player.GetAttacked(room.currentMonster, player);
                       // room.currentMonster.currentPower = room.currentMonster.Attack(room.currentMonster, player);
                        Console.WriteLine();
                        Console.WriteLine($"You have left {player.hp} HP.");
                        Console.WriteLine($"Monster has left {room.currentMonster.power} power points.");
                        Console.WriteLine();
                    }

                    isPlayerTurn = !isPlayerTurn;
					
                    if (room.currentMonster.hp <= 0)
                    {
                        player.xp += actions.xpAdd * room.level;
                        player.score++;
                        room.isMonsterAlive = false;
                        Console.WriteLine($"You've KILLED THE MONSTER. Good for you!");
                        while (player.xp >= actions.xpToLevelUp)
                        {
                            player.level++;
                            actions.xpToLevelUp += actions.xpToLevelUp;
                            Console.WriteLine($"You've been leveled up to level {player.level}");
                        }
                        return true;
                    }
                }
            }
            return false;
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
