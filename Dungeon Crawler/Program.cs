using System;
namespace DevelopHerShani
{
	public class Program
	{
        public Player player;
        public Dungeon dungeon;
        public Actions actions;

         static void Main()
        {
           Play(new Program()); 
        }
        public Program()
		{
            player = new Player().CreatePlayer();
            dungeon = new Dungeon().CreateDungeon();
            actions = new Actions().SetActionsStats();
        }
        
        public static void Play(Program program)
        {
            int r;
            int c;
            while (program.player.lifeC > 1 && program.player.score < program.dungeon.rooms.Length)
            {
                
                Console.WriteLine("");
                Dungeon.DisplayDungeonMap(program.dungeon);
                Console.WriteLine("Which Room would you like to explore?");
                r = ReadValidIntFronUser("Enter room's row number: ") - 1;
                c = ReadValidIntFronUser("Enter room's column number: ") - 1;
                
                Console.WriteLine($"Welcome to the room at : {program.dungeon.rooms[r,c].displayTxt}");
                Console.WriteLine("Now take that monster down ;) ");
               bool isWin =  program.player.Fight(program.player,  program.dungeon.rooms[r,c], program.actions);
               
                if (isWin)
                {
                    Console.WriteLine("You've made it to the next room. Good Luck Rockstar!");
                    
                    program.player.ResetStats(program.player, program.player.level);
                }
                else if (!program.dungeon.rooms[r, c].isMonsterAlive)
                {
                    Console.WriteLine("You've already killed that monster. pick up another room!");
                    continue;
                }
                else if (program.player.lifeC > 1)
                {
                    program.player.score = 0;
                    program.player.lifeC--;
                    Console.WriteLine($"Be greatfull - I brought you back to life! You have {program.player.lifeC} more chances left.");
                    Console.WriteLine($"Be-wear. You're not the only one who was brought back to life.. You have to kill each monster all over again. OOpsi.. Enjoy :) ");

                    program.player.ResetStats(program.player, program.player.level);
                    Play(program);
                    break;
                }
                else
                {
                    Console.WriteLine($"You have died FOR REAL! Oh well, maybe the after life are fine as well. Ba-Bye!");
                    break;
                }
            }
            if (program.player.lifeC > 1)
            {
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

