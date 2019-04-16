using System.ComponentModel;

namespace Engine
{
    public class Player : Creature
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public int XP { get; set; }
        public int MaxXP { get; set; }
        public int GBP { get; set; } //Good Boy Points or GBP is a karma system
        public int Gold { get; set; }
        public bool Direction { get; set; } //determines walking direction in wilderness, true = foward, false = backwards
        public bool[] townSlaughtered = new bool[4];  //Array tracking which towns are slaughtered. townID matched the array.
        public bool[] questComplete = new bool[8];   //Array tracking which quests are complete. questID matches the array.
        public int progress { get; set; }
        public BindingList<Item> Inventory = new BindingList<Item>();

        public Player() { }

        public Player(int SwordID, int StaffID, int ArmorID) : base(SwordID, StaffID, ArmorID)
        {
            Level = 1;
            XP = 0;
            MaxXP = 100;
            GBP = 0;
            Gold = 10;
            Direction = true;
            Inventory.Add(sword);
            Inventory.Add(staff);
            Inventory.Add(armor);
        }
    }
}
