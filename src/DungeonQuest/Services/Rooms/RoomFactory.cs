using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonGenerator
{
    public class RoomFactory : IRoom
    {
        // ToDo: These would be safer to be enums. It just makes the random selection code a little fiddlier
        string[] RoomTypeCollection = new string[] {"natural cave formation", "square room", "corridor", "dead end room"};        
        string[] CompassPoints = new string[] {"North","South","East","West"};

        public RoomModel CreateRoom(int maxWidth, int maxLength)
        {
            Random random = new Random();
            var Room = new RoomModel();           

            Room.RoomType = RoomTypeCollection[random.Next(0, RoomTypeCollection.Length - 1)];

            Room.Width = random.Next(1, maxWidth);
            Room.Length = random.Next(1, maxLength);

            Room.ExitLocations = CreateDoors(Room.RoomType);

            return Room;
        }

        private List<string> CreateDoors(string roomType)
        {
            Random random = new Random();

            var exitLocations = new List<string>();

            int numberOfExits = 0;

            if (roomType == "dead end room")
            {
                // Can only have one entry/exit point
                numberOfExits = 1;
            }
            else
            {
                // Can have many entry exit points but for now only one per wall
                numberOfExits = random.Next(2, 4);
            }

            var numberOfExitsCreated = 0;            

            while(numberOfExitsCreated < numberOfExits)
            {
                var randomCompassPoint = CompassPoints[random.Next(1, 4)];

                switch (randomCompassPoint)
                {
                    // Always check to see if we have already put a door in this location.
                    // If we have just go around the loop again
                    case "North":
                        if (!exitLocations.Contains("North"))
                        {
                            exitLocations.Add("North");
                            numberOfExitsCreated++;
                        }
                        break;
                    case "South":
                        if (!exitLocations.Contains("South"))
                        {
                            exitLocations.Add("South");
                            numberOfExitsCreated++;
                        }
                        break;
                    case "East":
                        if (!exitLocations.Contains("East"))
                        {
                            exitLocations.Add("East");
                            numberOfExitsCreated++;
                        }
                        break;
                    case "West":
                        if (!exitLocations.Contains("West"))
                        {
                            exitLocations.Add("West");
                            numberOfExitsCreated++;
                        }
                        break;
                }             
            };

            return exitLocations;
        }
    }
}
