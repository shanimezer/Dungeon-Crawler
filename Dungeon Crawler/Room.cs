using System;
namespace DevelopHerShani
{
	public class Room
	{
		public string displayTxt;
		public Monster currentMonster;

		public Room CreateRoom(Room room, int id)
		{
			room.currentMonster = new Monster();
			room.currentMonster = currentMonster.CreateMonster(currentMonster);
			room.displayTxt = (id+1).ToString(); // Rooms Id for now.

			return room;
		}

		public bool isWin (Player player, Room room)
		{
			bool isPlayerTurn = true;
			Console.WriteLine("Let the Battle Begine!");
			Console.ReadLine();

	
			while (player.hp > 0 && currentMonster.hp > 0)
			{
			
				if (isPlayerTurn)
				{
                    Console.WriteLine("It's your turn! Kill it you hear me?!");
                    player.power = player.Attack(currentMonster, player);
					currentMonster.hp = currentMonster.GetAttacked(currentMonster, player);
                    Console.WriteLine($"Keep up: your power is : {player.power} and your hp is: {player.hp}");
                    Console.WriteLine($"Monster's stats: power: {currentMonster.power} , hp is: {currentMonster.hp}");

                }
				else
				{
                    Console.WriteLine("Be Carefull from the monster!");
                    player.hp = player.GetAttacked(currentMonster, player);
                    currentMonster.power = currentMonster.Attack(currentMonster, player);
                    Console.WriteLine($"Your stats are: your power is {player.power} and your hp is {player.hp}");
                    Console.WriteLine($"Monster's stats: power : {currentMonster.power}, hp : {currentMonster.hp}");
                }

                isPlayerTurn = !isPlayerTurn;
			}

         //   If monster hp equals or lower then 0 => player levels up and moves to the next room

			if (currentMonster.hp <= 0 )
			{
				player.level++;
                Console.WriteLine($"You made it! Youv'e leveled up to level {player.level}!");
				return true;
            }

			return false;
        }
    }
}

