using GameFramework.Interface;


namespace GameFramework.Models
{
    public class SuperAttack : AttackDecoratorPattern
    {
        private readonly int _superDamage;

        public SuperAttack(IPowerAttack powerAttack, int powerDamage) : base(powerAttack)
        {
            _superDamage = powerDamage;
        }

        public override void PowerAttack(Enemy enemy)
        {
            base.PowerAttack(enemy);
            enemy.Health -= _superDamage;
            Console.WriteLine($"You used super attack, {_superDamage} damage dealt");
        }
    }
}
