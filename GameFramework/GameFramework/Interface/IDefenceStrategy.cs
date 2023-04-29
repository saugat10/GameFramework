using GameFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework.Interface
{
    public interface IDefenceStrategy
    {
        void Defend(Creature defender, int damage);
    }
}
