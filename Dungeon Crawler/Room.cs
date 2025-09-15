using System;

namespace DevelopHerShani
{
	public class Room
	{
		public string displayTxt;
		public Monster currentMonster;
		public bool hasBeenHere;
		public bool isMonsterAlive;
		public int level;

		public Room CreateRoom(Room room, int c, int r)
		{
			room.level = r+1;
			room.displayTxt = $" | Row : {room.level.ToString()} | Col : {(c+1).ToString()} |"; // Rooms Id for now.
			room.hasBeenHere = false;
			Console.WriteLine($"Room Location : {room.displayTxt}");
			room.currentMonster = new Monster();
			room.currentMonster = room.currentMonster.CreateMonster(room.currentMonster, room.level);
			isMonsterAlive = true;
			
			return room;
		}

		public bool isWin(Player player, Room room)
		{
			if (!room.hasBeenHere)
			{
				bool isPlayerTurn = true;
				room.currentMonster.ResetMonster(room.currentMonster);

				Console.WriteLine("Let the Battle Begine!");
				Console.ReadLine();
				while (player.hp > 0 && room.currentMonster.currentHp > 0)
				{
					if (isPlayerTurn)
					{
						Console.WriteLine("It's your turn! Kill it you hear me?!");
						currentMonster.currentHp = room.currentMonster.GetAttacked(room.currentMonster, player);
						player.power = player.Attack(room.currentMonster, player);
						Console.WriteLine(
							$"Keep up: your power is : {player.power} and your currentHp is: {player.hp}");
						Console.WriteLine(
							$"Monster's stats: power: {room.currentMonster.currentPower} , hp is: {room.currentMonster.currentHp}");

					}
					else
					{
						Console.WriteLine("Be Carefull from the monster!");
						player.hp = player.GetAttacked(room.currentMonster, player);
						room.currentMonster.currentPower = room.currentMonster.Attack(room.currentMonster, player);
						Console.WriteLine($"Your stats are: your power is {player.power} and your hp is {player.hp}");
						Console.WriteLine(
							$"Monster's stats: power : {room.currentMonster.currentPower}, hp : {room.currentMonster.currentHp}");
					}

					isPlayerTurn = !isPlayerTurn;
					
					if (room.currentMonster.currentHp <= 0)
					{
						player.level++;
						player.score++;
						room.hasBeenHere = true;
						room.isMonsterAlive = false;
						Console.WriteLine($"You killed the monster. Good for you! Youv'e leveled up to level {player.level}!");
						return true;
					}
				}
			}
			return false;
		}
	}
}

