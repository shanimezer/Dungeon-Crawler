using System;
namespace DevelopHerShani
{
	public class GamePlay
	{
        public Player player;
        public Dungeon dungeon;

         static void Main()
        {
           Play(new GamePlay()); 
        }
        public GamePlay()
		{
            player = new Player();
            player.CreatePlayer(player);

            dungeon = new Dungeon();
            dungeon.CreateDungeon(dungeon);
		}
        
//wee need to let the player the possibility to choose a room to explore if they already were in that room - the monster should stay dead. Else if the player lost and got to [0,0] all monsters should re-live. 
        public static void Play(GamePlay gamePlay)
        {
            int r;
            int c;
            while (gamePlay.player.lifeC > 1 && gamePlay.player.score < gamePlay.dungeon.rooms.Length)
            {
                Console.WriteLine("");
                Console.WriteLine("Which Room would you like to explore?");
                r = ReadValidIntFronUser("Enter room's row number: ") - 1;
                c = ReadValidIntFronUser("Enter room's column number: ") - 1;
                
                Console.WriteLine($"Welcome to the room at : {gamePlay.dungeon.rooms[r,c].displayTxt}! Now take that monster down mate!");
               bool isWin =  gamePlay.dungeon.rooms[r,c].isWin(gamePlay.player,  gamePlay.dungeon.rooms[r,c]);

                //If monster hp equals or lower then 0 => player levels up and moves to the next room
                //If player equals or lower then = 0 => player starts the run over(running all the rooms all over again and all monsters should regain their original state) but keeps his levels and stats
                if (isWin)
                {
                    Console.WriteLine("You've made it to the next room. Good Luck Rockstar!");
                    
                    gamePlay.player.ResetStats(gamePlay.player, gamePlay.player.level);
                }
                else if (!gamePlay.dungeon.rooms[r, c].isMonsterAlive)
                {
                    Console.WriteLine("You've already killed the monster. pick up another room!");
                    continue;
                }
                else if (gamePlay.player.lifeC > 1)
                {
                    gamePlay.player.score = 0;
                    gamePlay.player.lifeC--;
                    Console.WriteLine($"Be greatfull cause I brought you back to life! You have {gamePlay.player.lifeC} more chances left.");
                    Console.WriteLine($"Be-wear. You're not the only one who was brought back to life.. You have to kill all the monsters all over again. OOpsi.. Enjoy :) ");

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
            if (gamePlay.player.lifeC > 1)
            {
                //funny bug which I don't know how to fix at the moment. It prints it all over again each time after the code reaches break.
                Console.WriteLine($"You are the Dungeon Crawler Champion!! Game Over.");
            } 
        }
        public static int ReadValidIntFronUser(string message)
        {
            while (true)
            {
                Console.WriteLine(message);
                string input = Console.ReadLine();

                if (int.TryParse(input, out int number))
                {
                    return number;
                }
                else
                {
                    Console.WriteLine("That's not a valid number. Try again.");
                }
            }
        }
    }
}

