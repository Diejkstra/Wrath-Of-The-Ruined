namespace Engine
{
    public class Consumable : Item
    {
        public int HealthGain { get; set; }
        
        public Consumable() { }

        public Consumable(int ConsumableID)
        {
            ID = ConsumableID;
            switch (ConsumableID)
            {
                case -1:
                    Name = "None";
                    Price = 0;
                    HealthGain = 0;
                    break;
                case 0:
                    Name = "Venzorian Pizza Pie";
                    Price = 5;
                    HealthGain = 5;
                    break;
                case 1:
                    Name = "Minor Healing Potion";
                    Price = 10;
                    HealthGain = 10;
                    break;
                case 2:
                    Name = "Healing Potion";
                    Price = 20;
                    HealthGain = 25;
                    break;
                case 3:
                    Name = "Potent Healing Potion";
                    Price = 50;
                    HealthGain = 100;
                    break;
                case 4:
                    Name = "Perfect Healing Potion";
                    Price = 150;
                    HealthGain = 250;
                    break;
            }
        }
    }
}
