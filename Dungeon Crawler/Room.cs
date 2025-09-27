using System;

namespace DevelopHerShani
{
	public class Room
	{
		public string displayTxt;
		public Monster currentMonster;
		public bool isMonsterAlive;
		public int level;

		public Room CreateRoom(int c, int r)
		{
			Room room = new Room();
			room.level = r + 1;
			room.displayTxt = $" | Row : {room.level.ToString()} | Col : {(c + 1).ToString()} |"; // Rooms Id for now.
			Console.WriteLine($"Room Location : {room.displayTxt}");
			room.currentMonster = new Monster();
			room.currentMonster = room.currentMonster.CreateMonster(room.level);
			room.isMonsterAlive = true;
			return room;
		}
	}
}