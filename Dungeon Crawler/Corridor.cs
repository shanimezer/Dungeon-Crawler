using System;
namespace DevelopHerShani
{
	public class Corridor
	{
		public List<Room> rooms { get; set; }

		public Corridor CreateCorridor(Corridor corridor)
		{
			corridor.rooms = new List<Room>();

			Random rnd = new Random();
			int numberOfRooms = rnd.Next(2, 10);

			for (int i=0; i<numberOfRooms; i++)
			{
				Room room = new Room();
				corridor.rooms.Add(room.CreateRoom(room,i));
			}
			
			return corridor;
		}
	}


