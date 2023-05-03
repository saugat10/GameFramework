using GameFramework.Models;

namespace GameFramework.Interface
{
    public interface IWorldObject
    {
        string Name { get; set; }
        public Position position { get; set; }
        int Damage { get; set; }
        int Defence { get; set; }

        public abstract Position GetRandomPosition();
    }
}
