using System;
using System.Collections.Generic;
using System.Text;

namespace Engine
{
    public class Enemy : Creature
    {
        public int GoldDrop { get; set; }
        public int XPValue { get; set; }

        public Enemy(int SwordID, int StaffID, int ArmorID, int GoldDrop, int XPValue) : base(SwordID, StaffID, ArmorID)
        {
            this.GoldDrop = GoldDrop;
            this.XPValue = XPValue;
        }
    }
}
