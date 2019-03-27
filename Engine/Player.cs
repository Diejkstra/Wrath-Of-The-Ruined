using System;
using System.Collections.Generic;
using System.Text;

namespace Engine
{
    public class Player : Creature
    {
        
        public int Gold { get; set; }
        public int ExperiencePoints { get; set; }
        public int GBP { get; set; } //Good Boy Points or GBP is a karma system
        public string Name { get; set; }
        

        public Player(int stance, int SwordID, int StaffID, int ArmorID) : base(stance, SwordID, StaffID, ArmorID)
        {
            Gold = 100;
            ExperiencePoints = 0;
            GBP = 0;
        }
    
              
    }
}
