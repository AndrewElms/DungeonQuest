using System.Collections.Generic;

namespace DungeonGenerator
{
    public class RoomModel
    {
        public int Width { get; set; }
        public int Length { get; set; }
        public string RoomType { get; set; }
        public List<string> ExitLocations { get; set; }

    }
}