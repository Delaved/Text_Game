using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Roguelike
{
    internal class Human : Live_Entity
    {
        
        public Human(string _name,int _health, int _lvl, int _att, int _max_exp, int _weapon_att)  
        {   
            Name = _name;
            Max_Health_Point = _health + Convert.ToInt32(_health * 0.2 * _lvl);
            Current_Health_Point = Max_Health_Point;
            Base_Attack = _att;
            Max_Experience = _max_exp;
            Weapon_Attack = _weapon_att;
        }
        public override void Death()
        {
            Current_Health_Point = 0;
            Console.WriteLine("You died.");
        }

    }
}
