using System;
namespace DevelopHerShani
{
	public class GamePlay
	{
        public Player player;
        public Corridor corridor;

         static void Main()
        {

            Play(new GamePlay());
        }


        public GamePlay()
		{
            player = new Player();
            player.CreatePlayer(player);

            corridor = new Corridor();
            corridor.CreateCorridor(corridor);
		}


        public static void Play(GamePlay gamePlay)
        {

            foreach (Room r in gamePlay.corridor.rooms)
            {
                Console.WriteLine($"Welcome to room Number {r.displayTxt}! Now take that monster down mate!");
               int newLevel =  r.Fight(gamePlay.player, r);

                //If monster hp equals or lower then 0 => player levels up and moves to the next room
                //If player equals or lower then = 0 => player starts the run over(running all the rooms all over again and all monsters should regain their original state) but keeps his levels and stats
                if (newLevel > gamePlay.player.level)
                {
                    gamePlay.player.level = newLevel;

                    Console.WriteLine($"You made it! Youv'e leveled up to level {gamePlay.player.level}!");
                }
                else
                {
                    Play(gamePlay);
                    break;
                }

            }
            Console.WriteLine($"You are the Dungeon Crawler Champion!! Game Over.");
        }
    }


}

