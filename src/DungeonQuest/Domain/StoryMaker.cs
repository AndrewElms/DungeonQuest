using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonGenerator
{
    // This is the domain logic that knows how to make a story by combining a Room, Loot and Monster
    // Eventually this domain logic would also contain hit point attack calculators and other game mechanics
    public class StoryMaker : IStoryMaker
    {
        public string MakeAStory(RoomModel room, LootModel loot, MonsterModel monster)
        {
            var numberOfMonsters = (monster.NumberOfMonsters == 1) ? "a" : monster.NumberOfMonsters.ToString();

            var story = $"You stand in a {room.Width}' x {room.Length}' {room.RoomType}.\n"
                        + DoorLocations(room)
                        + $"On the far side of the room you see {numberOfMonsters} {monster.Name}, "
                        + $"guarding a {loot.Description}";

            return story;
        }

        private static string DoorLocations(RoomModel room)
        {
            var prefix = string.Empty;
            var doorLocations = string.Empty;
            var suffix = string.Empty;

            for (int i = 1; i <= room.ExitLocations.Count; i++)
            {

                doorLocations += room.ExitLocations[i - 1];


                if (i == room.ExitLocations.Count - 1)
                    doorLocations += " and ";
                else if (i < room.ExitLocations.Count)
                    doorLocations += ", ";
            }

            if (room.ExitLocations.Count == 1)
            {
                prefix = $"There is a door on the ";
                suffix += " wall.\n";
            }
            else
            {
                prefix = $"There are doors on the ";
                suffix += " walls.\n";
            }


            return prefix + doorLocations + suffix;
        }
    }
}
