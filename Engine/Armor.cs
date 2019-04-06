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
        public int Price { get; set; }

        public void AssignArmorStats(int ID)
        {
            ArmorID = ID;
            switch (ID)
            {
                case -1:
                    ArmorName = "None";
                    ArmorPoints = 0;
                    Price = 0;
                    break;
                case 0:
                    ArmorName = "Cloth Armor";
                    ArmorPoints = 10;
                    Price = 10;
                    break;
                case 1:
                    ArmorName = "Leather Armor";
                    ArmorPoints = 20;
                    Price = 30;
                    break;
                case 2:
                    ArmorName = "Chain Mail";
                    ArmorPoints = 30;
                    Price = 50;
                    break;
                case 3:
                    ArmorName = "Iron Plate Armor";
                    ArmorPoints = 40;
                    Price = 75;
                    break;
                case 4:
                    ArmorName = "Steel Plate Armor";
                    ArmorPoints = 50;
                    Price = 150;
                    break;
                case 5:
                    ArmorName = "Silver Plate Armor";
                    ArmorPoints = 60;
                    Price = 500;
                    break;
                case 100:
                    ArmorName = "Black T-Shirt";
                    ArmorPoints = 1001;
                    break;
                case 200:
                    ArmorName = "Short Sleeve T-Shirt with a DSU logo";
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
