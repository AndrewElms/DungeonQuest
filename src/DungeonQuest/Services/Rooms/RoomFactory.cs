using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonGenerator
{
    public class RoomFactory : IRoom
    {
        public RoomModel CreateRoom(int maxWidth, int maxLength)
        {
            Random random = new Random();
            var Room = new RoomModel();

            Room.Width = random.Next(1, maxWidth);
            Room.Length = random.Next(1, maxLength);

            Room.NorthExit = Convert.ToBoolean(random.Next(0,2));
            Room.SouthExit = Convert.ToBoolean(random.Next(0, 2));
            Room.EastExit = Convert.ToBoolean(random.Next(0, 2));
            Room.WestExit = Convert.ToBoolean(random.Next(0, 2));

            return Room;
        }
    }
}
