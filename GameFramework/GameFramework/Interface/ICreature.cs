using GameFramework.Models;

namespace GameFramework.Interface
{
    public interface ICreature
    {
        string Name { get; set; }
        int Health { get; set; }
        int Damage { get; set; }

        Position position { get; set; }

        public void PickUp(IWorldObject worldObject);

        void Attack(Player player);
        void Attack(Enemy enemy);
    }
}
