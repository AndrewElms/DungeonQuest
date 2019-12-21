using DungeonGenerator.Infrastructure.Repository;
using DungeonGenerator.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonGenerator
{
    // This is the orchestrator
    // Get Config file max width length settings
    // Get a Room object from the RoomFactory
    public class DungenonGeneratorService
    {
        private readonly IPresentation _presentationAdapter;
        private readonly IRoom _roomFactory;
        private readonly IRepositoryListTransformer _transformer;
        private readonly IRepository _Repo;
        private readonly IMonsterFactory _monsterFactory;
        private readonly ILootFactory _lootFactory;
        private readonly IStoryMaker _storyMaker;

        public DungenonGeneratorService(
            IPresentation presentationAdapter,
            IRoom roomFactory,
            IRepositoryListTransformer transformer,
            IRepository Repo,
            IMonsterFactory monsterFactory,
            ILootFactory lootFactory,
            IStoryMaker storyMaker)
        {
            _presentationAdapter = presentationAdapter;
            _roomFactory = roomFactory;
            _transformer = transformer;
            _Repo = Repo;
            _monsterFactory = monsterFactory;
            _lootFactory = lootFactory;
            _storyMaker = storyMaker;
        }

        public void Create()
        {
            // Get the master lists of things like monsters and loot
            var monsterData = _Repo.GetList(@"Monsters.json");   // SMELL: Should the file names be here?
            var lootData = _Repo.GetList(@"Loot.json");          // SMELL: Should the file names be here?

            while (true)
            {
                // Create a randomly sized room
                var roomModel = _roomFactory.CreateRoom(10, 10);

                // Randomly select a single monster from the master monster list
                var monsters = _transformer.TransformJSON<MonsterCollection>(monsterData);
                var monster = _monsterFactory.GetMonster(monsters);

                // Randomly select a single loot item from the master loot list
                var loot = _transformer.TransformJSON<LootCollection>(lootData);
                var lootItem = _lootFactory.GetLoot(loot);

                // Use the story maker to combine these elements into a readable story
                var story = _storyMaker.MakeAStory(roomModel, lootItem, monster);

                // Output the story
                _presentationAdapter.Print(story);                
            }
        }
    }
}
