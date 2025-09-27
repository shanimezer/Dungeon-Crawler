namespace DevelopHerShani;

public class Dungeon
{
    /**
     * Make the dungeon a matrix (2d array)
    that way our dungeon is now a 2d grid , with rows and columns for me to explore
        That way I can navigate as much as I like.
        After each room interaction, tell me in what room I'm(row index, and column index)
    and let me choose to move up, down, left, right (if possible)
    If I visited the same room twice without dying, I shouldn't fight that monster again (it is dead) just ask me again where I would like to go
    if I die, reset me to [0,0] and “respawn” all the dead monsters
    if I get to the bottom right corner I win.
        learn more about using list in list to represent a grid here:
        **/

    public Room [,] rooms;
    public int  rLength;
    public int  cLength;

    public Dungeon CreateDungeon()
    { 
        Dungeon dungeon = new Dungeon(); 
       Random rnd= new Random();
        dungeon.rLength = rnd.Next(1, 7);
        dungeon.cLength = rnd.Next(1, 7);
        
        dungeon.rooms = new Room[dungeon.rLength, dungeon.cLength];

        for (int row = 0; row < dungeon.rLength; row++) 
        {
            for (int col = 0; col < dungeon.cLength; col++)
            {
                dungeon.rooms[row,col] =  new Room().CreateRoom(col, row);
            }
        }
        return dungeon;
    }

    public static void ResetDungeon(Dungeon dungeon)
    {
        for (int row = 0; row < dungeon.rLength; row++)
        {
            for (int col = 0; col < dungeon.cLength; col++)
            {
                dungeon.rooms[row, col].isMonsterAlive = true;
            }
        } 
    }

    public static void displayDungeonMap(Dungeon dungeon)
    {
        
    }
}