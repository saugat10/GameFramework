using GameFramework.Interface;

namespace GameFramework.Models
{
    /// <summary>
    /// Represents the game world where all creatures and objects exist.
    /// </summary>
    public class World
    {
        public char[,] grid;
        public int maxX;
        public int maxY;
        public List<ICreature> creatures;
        public List<IWorldObject> worldObjects;
        public static World? Instance;

        /// <summary>
        /// Creates a new instance of the <see cref="World"/> class with the specified dimensions.
        /// </summary>
        /// <param name="maxX">The maximum x-coordinate of the world.</param>
        /// <param name="maxY">The maximum y-coordinate of the world.</param>
        public World (int maxX, int maxY)
        {
            this.maxX = maxX;
            this.maxY = maxY;
            grid = new char[maxX, maxY];
            creatures = new List<ICreature>();
            worldObjects = new List<IWorldObject>();
            Instance = this;

            for (int x = 0; x < maxX; x++)
            {
                for (int y = 0; y < maxY; y++)
                {
                    if (x == 0 || x == maxX - 1 || y == 0 || y == maxY - 1)
                    {
                        grid[x, y] = '#';
                    }
                    else
                    {
                        grid[x, y] = ' ';
                    }
                }
            }

            Logger.Log($"World with X: {maxX} and Y: {maxY} has been created");
        }

        /// <summary>
        /// Adds a creature to the world.
        /// </summary>
        /// <param name="creature">The creature to add to the world.</param>
        public void AddCreature(ICreature creature)
        {
            creatures.Add(creature);
            grid[creature.position.X, creature.position.Y] = creature.GetType() == typeof(Player) ? 'P' : 'E';

            Logger.Log($"Added a {creature.GetType().Name} at position ({creature.position.X}, {creature.position.Y}).");

        }

        /// <summary>
        /// Adds a world object to the world.
        /// </summary>
        /// <param name="worldObject">The world object to add to the world.</param>
        public void AddWorldObject(IWorldObject worldObject)
        {
            worldObjects.Add(worldObject);
            if (worldObject is AttackItem)
            {
                grid[worldObject.position.X, worldObject.position.Y] = 'i';

                Logger.Log($"Added an attack item {((AttackItem)worldObject).Name} at position ({worldObject.position.X}, {worldObject.position.Y}).");

            }
            else
            {
                grid[worldObject.position.X, worldObject.position.Y] = 'o';

                Logger.Log($"Added a world object {worldObject.Name} at position ({worldObject.position.X}, {worldObject.position.Y}).");

            }
        }

        /// <summary>
        /// Removes a given World Object from the game world and updates the grid if the object is an instance of AttackItem or DefenceItem.
        /// </summary>
        /// <param name="worldObject">The World Object to remove from the game world.</param>
        /// <remarks>
        public void RemoveWorldObject(IWorldObject worldObject)
        {
            if (worldObjects.Contains(worldObject))
            {
                worldObjects.Remove(worldObject);
                if (worldObject is AttackItem || worldObject is DefenceItem)
                {
                    grid[worldObject.position.X, worldObject.position.Y] = ' ';

                    Logger.Log($"Removed an item at position ({worldObject.position.X}, {worldObject.position.Y}).");

                }
            }
        }

    }
}