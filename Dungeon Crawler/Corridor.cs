using System;

namespace DevelopHerShani
{
	public class Corridor
	{
		public List<Room> rooms { get; set; }

		public Corridor CreateCorridor(Corridor corridor, int rLength)
		{
			corridor.rooms = new List<Room>();

			for (int i = 0; i < rLength; i++)
			{
				Room room = new Room();
				corridor.rooms.Add(room.CreateRoom(1,i));
			}

			return corridor;
		}
	}
}


