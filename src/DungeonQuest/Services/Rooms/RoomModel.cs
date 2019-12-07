namespace DungeonGenerator
{
    public class RoomModel
    {
        public int Width { get; set; }
        public int Length { get; set; }
        public bool NorthExit { get; set; }
        public bool SouthExit { get; set; }
        public bool EastExit { get; set; }
        public bool WestExit { get; set; }

    }
}