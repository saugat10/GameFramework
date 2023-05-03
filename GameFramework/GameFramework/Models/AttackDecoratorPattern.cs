using GameFramework.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework.Models
{
    public class AttackDecoratorPattern : IPowerAttack
    {
        private readonly IPowerAttack _attack;

        public AttackDecoratorPattern(IPowerAttack attack)
        {
            _attack = attack;
        }

        public virtual void PowerAttack(Enemy enemy)
        {
            _attack.PowerAttack(enemy);
        }
    }
}
