using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Roguelike
{
    internal class Goblin : Live_Entity
    {
        public Goblin(int _health, int _lvl, int _att, int _weapon_att, int _max_exp, string _name = "An ordinary goblin")
        {
            Name = _name;
            Max_Health_Point = _health + Convert.ToInt32(_health * 0.2 * _lvl);
            Level = _lvl;
            Current_Health_Point = Max_Health_Point;
            Base_Attack = _att;
            Weapon_Attack = _weapon_att;
            Max_Experience = _max_exp;
        }
        public override void Death()
        {
           
        }
    }
}
