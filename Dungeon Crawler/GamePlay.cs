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
               bool isWin =  r.isWin(gamePlay.player, r);

                //If monster hp equals or lower then 0 => player levels up and moves to the next room
                //If player equals or lower then = 0 => player starts the run over(running all the rooms all over again and all monsters should regain their original state) but keeps his levels and stats
                if (isWin)
                {
                    Console.WriteLine("You've made it to the next room. Good Luck Rockstar!");
                    
                    gamePlay.player.ResetStats(gamePlay.player, gamePlay.player.level);
                }
                else
                {
                    if (gamePlay.player.lifeC > 1)
                    {
                        gamePlay.player.lifeC--;
                        Console.WriteLine($"Be Greatfull cause I brout you back to life! You have {gamePlay.player.lifeC} more chances left.");
                        gamePlay.player.ResetStats(gamePlay.player, gamePlay.player.level);
                        Play(gamePlay);
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"You have died for real this time. Oh well, maybe the after life are fine as well. Bye!");
                        break;
                    }
                   
                }

            }
            if (gamePlay.player.lifeC > 1)
            {
                //funny bug which I don't know how to fix at the moment. It prints it all over again each time after the code reaches break.
                Console.WriteLine($"You are the Dungeon Crawler Champion!! Game Over.");
            } 
           
        }
    }


}

