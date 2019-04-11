using System.ComponentModel;

namespace Engine
{
    public class Player : Creature
    {

        public int Gold { get; set; }
        public int ExperiencePoints { get; set; }
        public int GBP { get; set; } //Good Boy Points or GBP is a karma system
        public string Name { get; set; }
        public bool Direction { get; set; } //determines walking direction in wilderness, true = foward, false = backwards
        public BindingList<Item> Inventory = new BindingList<Item>();

        public Player(int SwordID, int StaffID, int ArmorID) : base(SwordID, StaffID, ArmorID)
        {
            Gold = 10;
            ExperiencePoints = 0;
            GBP = 0;
            Direction = true;
            Inventory.Add(sword);
            Inventory.Add(staff);
            Inventory.Add(armor);
        }
    }
}
