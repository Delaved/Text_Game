using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Roguelike
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Human hero = new Human("Indefinite", 50, 0, 10, 10, 0);
            string _choice;
            bool _incorrect_input = true;
            string _choice_tolower;
            Console.WriteLine("Choose name and remember you always can check your status when input \"s\"");
            while (_incorrect_input)
            {
                _choice = Console.ReadLine();
                _choice_tolower = _choice.ToLower();
                if (_choice_tolower == "s")
                {
                    hero.Output_Status();
                }
                else
                {
                    hero.Name = _choice;
                    _incorrect_input = false;
                }
            }
            _incorrect_input = true;

            Console.WriteLine($"You wake up in dark site.You remember only that your's name is {hero.Name}.");
            Console.WriteLine($"Looked around you saw vast wooden door behind you, stone walls and infity deep passage in dark.");
            Console.WriteLine("You decide:");
            Console.WriteLine("1.Try to open the door");
            Console.WriteLine("2.Go ahead along the corridor");

            while (_incorrect_input)
            {
                _choice = Console.ReadLine().ToLower();
                switch (_choice)
                {
                    case "s":
                        hero.Output_Status();
                        break;
                    case "1":
                    case "try to open the door":
                    case "door":
                        Console.WriteLine("Pointless and useless try. This door firmly closed on the other side. It seems to impossible knock down the door.Made a decision.");
                        break;
                    case "2":
                    case "go ahead along the corridor":
                    case "corridor":
                        _incorrect_input = false;
                        break;
                    default:
                        Console.WriteLine("Made a decision.");
                        break;
                }
            }
            Console.WriteLine($"You've been walking for a while time.And now you hearing some odd sounds.");
            Console.WriteLine("You made a resolution come close.While you coming closer toward sounds resource, the strange entity noticed you.");
            Console.WriteLine("It's goblin! What you do?");
            Console.WriteLine("1.Try to escape");
            Console.WriteLine("2.You surrender");
            Console.WriteLine("3.Fight");
            _incorrect_input = true;
            while (_incorrect_input)
            {
                _choice = Console.ReadLine().ToLower();
                switch (_choice)
                {
                    case "s":
                        hero.Output_Status();
                        break;
                    case "1":
                    case "try to escape":
                    case "escape":
                        Console.WriteLine("The goblin pursued and caught you. You died.");
                        hero.Current_Health_Point = 0;
                        Console.ReadLine();
                        _incorrect_input = false;
                        break;
                    case "2":
                    case "try to surrender":
                    case "surrender":
                        Console.WriteLine("You surrendered. You died.");
                        hero.Current_Health_Point = 0;
                        Console.ReadLine();
                        _incorrect_input = false;
                        break;
                    case "3":
                    case "fight":
                        _incorrect_input = false;
                        break;
                    default:
                        Console.WriteLine("Made a decision");
                        break;
                }
            }
            if (!Hero_Is_Alive())
            {
                return;
            }

            Console.WriteLine("Start battle.");
            Goblin goblinFirst = new Goblin(30, 1, 1, 5, 5);
            Battle(goblinFirst);
            
            if (!Hero_Is_Alive())
            {
                return;
            }
            Console.WriteLine($"{hero.Name}'s won! And you's picked up the goblin's knife. The attack has increased by {goblinFirst.Weapon_Attack}");
            hero.Weapon_Attack = goblinFirst.Weapon_Attack;
            int _up_lvl_enemy = 1;
            _incorrect_input = true;
            bool _made_resolution = false;
            while (_incorrect_input)
            {
                
                if (_made_resolution || _up_lvl_enemy == 1)
                {
                    _up_lvl_enemy++;
                    Console.WriteLine($"You is going ahead and seeing 2 doors. The left door is usual wooden door and the right door is spooky flesh-bones door.");
                    Console.WriteLine("What you do?");
                    Console.WriteLine("1.The left door");
                    Console.WriteLine("2.The right door");        
                }
                _choice = Console.ReadLine().ToLower();
                switch (_choice)
                {
                    case "s":
                        hero.Output_Status();
                        _made_resolution = false;
                        break;
                    case "1":
                    case "the left door":
                    case "left":
                        _made_resolution = true;
                        goblinFirst.Give_Experience(_up_lvl_enemy);
                        Battle(goblinFirst);
                        break;
                    case "2":
                    case "the right door":
                    case "right":
                        _made_resolution = true;
                        Goblin king_of_goblin = new Goblin(45, 5, 10, 10, 10, "King of goblins");
                        Battle(king_of_goblin);
                        _incorrect_input = false;
                        break;
                    default:
                        Console.WriteLine("Made a decision");
                        break;
                }
            }
            if (!Hero_Is_Alive())
            {
                return;
            }
            Console.WriteLine("Congratulations! You passed this game. Although you haven't remembered about your former life, now it doesn't bother  you.");
            Console.ReadLine();






            void Battle(Live_Entity adversary)
            {
                while (hero.Current_Health_Point > 0 && adversary.Current_Health_Point > 0) 
                {
                    Console.Write($"You:           {adversary.Name}\n");
                    Console.Write($"hp: {hero.Current_Health_Point}/{hero.Max_Health_Point}          hp: {adversary.Current_Health_Point}/{adversary.Max_Health_Point} \n");
                    Console.WriteLine("1.Simple punch");
                    _choice = Console.ReadLine().ToLower();
                    bool _local_incorrect_input = true;
                    while (_local_incorrect_input)
                    {
                        switch (_choice)
                        {
                            case "1":
                            case "punch":
                                Console.WriteLine("You did a simple punch.");
                                adversary.Current_Health_Point -= hero.Finall_Attack;
                                _local_incorrect_input = false;
                                break;
                            default:
                                Console.WriteLine("Made a decision");
                                _local_incorrect_input = true;
                                break;
                        }
                    }
                    if (adversary.Current_Health_Point > 0)
                    {
                        Console.WriteLine("Goblin stabbed you with the knife.");
                        hero.Current_Health_Point -= adversary.Finall_Attack;
                    }        
                }
                if (hero.Current_Health_Point <= 0)
                {
                    hero.Death();
                }
                else if (adversary.Current_Health_Point <= 0)
                {

                    hero.Give_Experience(adversary.Level);
                }
            }
            bool Hero_Is_Alive()
            {
                if (hero.Current_Health_Point <= 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }

            }
        }
    }
}



