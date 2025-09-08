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
			room.displayTxt = id.ToString(); // Rooms Id for now.

			return room;
		}

		public int Fight (Player player, Room room)
		{
			bool isPlayerTurn = true;

	
			while (player.hp > 0 || currentMonster.hp > 0)
			{
				if (isPlayerTurn)
				{
					player.power = player.Attack(currentMonster, player);
					currentMonster.hp = currentMonster.GetAttacked(currentMonster, player);
				}
				else
				{
                    player.hp = player.GetAttacked(currentMonster, player);
                    currentMonster.power = currentMonster.Attack(currentMonster, player);
                }

				isPlayerTurn = !isPlayerTurn;
			}

         //   If monster hp equals or lower then 0 => player levels up and moves to the next room

			if (currentMonster.hp <= 0 )
			{
				player.level++;
			}

			return player.level;
        }
    }
}

