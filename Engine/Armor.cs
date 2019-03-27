using System;
using System.Collections.Generic;
using System.Text;

namespace Engine
{
    public class Armor
    {
        public string ArmorName { get; set; }
        public int ArmorID { get; set; }
        public int ArmorPoints { get; set; }


        public void AssignArmorStats(int ID)
        {
            ArmorID = ID;
            switch (ID)
            {
                case 0:
                    ArmorName = "Cloth Armor";
                    ArmorPoints = 10;
                    break;
                case 1:
                    ArmorName = "Leather Armor";
                    ArmorPoints = 20;
                    break;
                case 2:
                    ArmorName = "Chain Mail";
                    ArmorPoints = 30;
                    break;
                case 3:
                    ArmorName = "Iron Plate Armor";
                    ArmorPoints = 40;
                    break;
                case 4:
                    ArmorName = "Steel Plate Armor";
                    ArmorPoints = 50;
                    break;
                case 421:
                    ArmorName = "player.armor.toms_god_armor";
                    ArmorPoints = 1001;
                    break;
                default:
                    ArmorName = "Error";
                    ArmorPoints = 0;
                    break;
            }
        }
    }
}
