namespace Engine
{
    public class Armor : Item
    {
        public int ArmorPoints { get; set; }

        public void AssignArmorStats(int ArmorID)
        {
            ID = ArmorID;
            switch (ArmorID)
            {
                case -1:
                    Name = "None";
                    ArmorPoints = 0;
                    Price = 0;
                    break;
                case 0:
                    Name = "Cloth Armor";
                    ArmorPoints = 10;
                    Price = 10;
                    break;
                case 1:
                    Name = "Leather Armor";
                    ArmorPoints = 20;
                    Price = 30;
                    break;
                case 2:
                    Name = "Chain Mail";
                    ArmorPoints = 30;
                    Price = 50;
                    break;
                case 3:
                    Name = "Iron Plate Armor";
                    ArmorPoints = 40;
                    Price = 75;
                    break;
                case 4:
                    Name = "Steel Plate Armor";
                    ArmorPoints = 50;
                    Price = 150;
                    break;
                case 5:
                    Name = "Silver Plate Armor";
                    ArmorPoints = 60;
                    Price = 500;
                    break;
                case 100:
                    Name = "Black T-Shirt";
                    ArmorPoints = 1001;
                    break;
                case 200:
                    Name = "Short Sleeve T-Shirt with a DSU logo";
                    ArmorPoints = 1001;
                    break;
                default:
                    Name = "Error";
                    ArmorPoints = 0;
                    break;
            }
            StoreName = Name + " - " + Price + "gp";
        }
    }
}
