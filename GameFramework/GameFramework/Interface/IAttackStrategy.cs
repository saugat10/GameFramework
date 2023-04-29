using GameFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework.Interface
{
    public interface IAttackStrategy
    {
        void Attack(Creature attacker, Creature target);
    }
}
