using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonGenerator
{
    // This is the domain logic that knows how to make a story by combining a Room, Loot and Monster
    // Eventually this domain logic would also contain hit point attack calculators and other game mechanics
    public class StoryMaker
    {
        public string MakeAStory(RoomModel room, LootModel loot, MonsterModel monster)
        {
            var numberOfMonsters = (monster.NumberOfMonsters == 1) ? "a" : monster.NumberOfMonsters.ToString();

            var doorLocations = string.Empty;

            if(room.NorthExit || room.SouthExit || room.EastExit || room.WestExit)
            {
                doorLocations = $"There are doors on the ";
                if (room.NorthExit) { doorLocations += "north, "; };
                if (room.SouthExit) { doorLocations += "south, "; };
                if (room.EastExit) { doorLocations += "east, "; };
                if (room.WestExit) { doorLocations += "west, "; };

                doorLocations = doorLocations.Substring(0, doorLocations.Length - 2);

                if (room.NorthExit ^ room.SouthExit ^ room.EastExit ^ room.WestExit)
                {
                    doorLocations += " wall.\n";
                }
                else
                {
                    doorLocations += " walls.\n";
                }
            }

            var story = $"You stand in a room {room.Width}' x {room.Length}'.\n"
                        + doorLocations
                        + $"On the far side of the room you see {numberOfMonsters} {monster.Name}, "
                        + $"guarding a {loot.Description}";

            return story;
        }
    }
}
