namespace Engine
{
    public class Consumable : Item
    {
        public int HealthGain { get; set; }

        public Consumable(int ConsumableID)
        {
            ID = ConsumableID;
            switch (ConsumableID)
            {
                case 0:
                    Name = "Venzorian Pizza Pie";
                    Price = 5;
                    HealthGain = 15;
                    break;
            }
            StoreName = Name + " - " + Price + "gp";
        }
    }
}
