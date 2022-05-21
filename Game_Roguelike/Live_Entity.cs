using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Roguelike
{
    internal abstract class Live_Entity
    {
        public string Name { get; set; }
        public int Max_Health_Point { get; set; }
        public int Current_Health_Point { get; set; }

        public int Current_Experience { get; set; }
        public int Max_Experience { get; set; }
        public int Level { get; set; }
        public int Base_Attack { get; set; }
        public int Weapon_Attack { get; set; }
        public int Finall_Attack { get { return Convert.ToInt32(Math.Round(Base_Attack + Weapon_Attack + Base_Attack * 0.1 * Level)); }  }


        public void Give_Experience(int _level_foe)
        {
            Current_Experience += _level_foe * 10;

            while (Current_Experience >= Max_Experience)
            {
                Level = Level + 1;
                Current_Experience -= Max_Experience;
                Max_Experience = Convert.ToInt32(Max_Experience  * Level);
                Max_Health_Point += Convert.ToInt32(Max_Health_Point * 0.2);
                Current_Health_Point = Max_Health_Point;
                Base_Attack += Convert.ToInt32(Base_Attack * 0.1);
            } 
        }
        //public void Output_Status(Live_Entity entity)
        //{
        //    Console.WriteLine($"Name - {entity.Name}, level - {entity.Level}");
        //    Console.WriteLine($"Exp - {entity.Current_Experience}/{entity.Max_Experience}");
        //    Console.WriteLine($"HP - {entity.Current_Health_Point}/{entity.Max_Health_Point}");
        //    Console.WriteLine($"Atk - {entity.Finall_Attack}");
        //}
        public void Output_Status()
        {
            Console.WriteLine($"Name - {Name}, level - {Level}");
            Console.WriteLine($"Exp - {Current_Experience}/{Max_Experience}");
            Console.WriteLine($"HP - {Current_Health_Point}/{Max_Health_Point}");
            Console.WriteLine($"Atk - {Finall_Attack}");
        }

        public abstract void Death();

    }

}
