using System;

namespace Engine
{
    [Serializable]
    public class Creature
    {
        public string Name { get; set; }
        public int AP { get; set; } //Base Armor Points
        public int MR { get; set; } //Base Magic Resist
        public int MaxHP { get; set; }
        public int CurrentHP { get; set; }
        public int PDamage { get; set; } //physical damage
        public int MDamage { get; set; } //magic damage
        public int Strength { get; set; }
        public int Intellect { get; set; }
        public int Endurance { get; set; }
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
            sword = new Sword(SwordID);
            armor = new Armor(ArmorID);
            staff = new Staff(StaffID);
            stance = new Stance();
            CurrentHP = MaxHP;
        }

        public Creature() { }

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
