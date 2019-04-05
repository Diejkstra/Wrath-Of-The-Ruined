using System;
using System.Collections.Generic;
using System.Text;

namespace Engine
{
    public class Creature
    {
        public int AP { get; set; } //Base Armor Points
        public int MR { get; set; } //Base Magic Resist
        public int MaxHP { get; set; }
        public int PDamage { get; set; } //physical damage
        public int Intellect { get; set; }
        public int Endurance { get; set; }
        public int Strength { get; set; }
        public int MDamage { get; set; } //magic damage
        public int CurrentHP { get; set; }
        public int GoldDrop { get; set; }
        public Stance stance;
        public Sword sword;
        public Armor armor;
        public Staff staff;

        public Creature(int SwordID, int StaffID, int ArmorID)
        {
            AP = 10;
            MR = 10;
            MaxHP = 150;
            PDamage = 20;
            Intellect = 5;
            Endurance = 100;
            Strength = 5;
            MDamage = 20;
            sword = new Sword();
            armor = new Armor();
            staff = new Staff();
            stance = new Stance();
            CurrentHP = MaxHP;
            sword.AssignSwordStats(SwordID);
            armor.AssignArmorStats(ArmorID);
            staff.AssignStaffStats(StaffID);
        }

        public int CalculatePhysicalAttack()
        {
            return Convert.ToInt32(Math.Round(PDamage + (PDamage * (Strength * .01) * (Endurance * .01))));
        }
        public int CalculateMagicalAttack()
        {
            return Convert.ToInt32(Math.Round(MDamage + (MDamage * (Intellect * .01) * (Endurance * .01))));
        }
    }
}
