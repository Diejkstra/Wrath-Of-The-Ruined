namespace Engine
{
    public class Enemy : Creature
    {
        public int GoldDrop { get; set; }
        public int XPValue { get; set; }

        public Enemy(string Name, int SwordID, int StaffID, int ArmorID, int GoldDrop, int XPValue) : base(SwordID, StaffID, ArmorID)
        {
            this.Name = Name;
            this.GoldDrop = GoldDrop;
            this.XPValue = XPValue;
        }
    }
}
