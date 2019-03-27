using System;
using System.Collections.Generic;
using System.Text;
using Engine;

namespace Engine
{
    public class Stance
    {
        public string stanceName { get; set; }
        public double stanceDMG { get; set; }
        public double stanceMGK { get; set; }
        public double totalArmor { get; set; }
        public double totalMR { get; set; }
        public int stanceNum { get; set; }

        public void ChangeStance(Creature player, int newStance)
        {
            if (newStance == 1)     //DEFENSIVE
            {
                if (player.Endurance <= 100 && player.Endurance >= 60)
                {
                    stanceDMG = .75 * (player.totaldamage + player.sword.MaxSwordDamage);
                    totalArmor = 1.5 * (player.AP + player.armor.ArmorPoints);
                    totalMR = 1.5 * player.MR;
                }
                else if (player.Endurance < 60 && player.Endurance >= 30)
                {
                    stanceDMG = .50 * (player.totaldamage + player.sword.MaxSwordDamage);
                    totalArmor = 1.75 * (player.AP + player.armor.ArmorPoints);
                    totalMR = 1.75 * player.MR;
                }
                else if (player.Endurance < 20 && player.Endurance >= 0)
                {
                    stanceDMG = .25 * (player.totaldamage + player.sword.MaxSwordDamage);
                    totalArmor = 2.0 * (player.AP + player.armor.ArmorPoints);
                    totalMR = 2.0 * player.MR;
                }
                stanceMGK = (player.totalmagic + player.staff.BaseStaffDamage);
                totalMR = 1.5 * player.MR;
                stanceName = "Defensive";
                stanceNum = newStance;
            }
            else if (newStance == 2)    //NEUTRAL
            {
                if (player.Endurance <= 100 && player.Endurance >= 40)
                {
                    stanceDMG = 1.1 * (player.totaldamage + player.sword.MaxSwordDamage);
                    stanceMGK = 1.1 * (player.totalmagic + player.staff.MaxStaffDamage);
                    totalArmor = 1.1 * (player.AP + player.armor.ArmorPoints);
                    totalMR = 1.1 * player.MR;
                }
                else if (player.Endurance < 40 && player.Endurance >= 0)
                {
                    stanceDMG = player.totaldamage + player.sword.MaxSwordDamage;
                    stanceMGK = player.totalmagic + player.staff.MaxStaffDamage;
                    totalArmor = player.AP + player.armor.ArmorPoints;
                    totalMR = player.MR;
                }
                stanceName = "Neutral";
                stanceNum = newStance;
            }
            else if (newStance == 3)    //AGGRESSIVE
            {
                if (player.Endurance <= 100 && player.Endurance >= 60)
                    stanceDMG = 1.75 * (player.totaldamage + player.sword.MaxSwordDamage);
                else if (player.Endurance < 60 && player.Endurance >= 30)
                    stanceDMG = 1.25 * (player.totaldamage + player.sword.MaxSwordDamage);
                else if (player.Endurance < 30 && player.Endurance >= 0)
                    stanceDMG = player.totaldamage + player.sword.MaxSwordDamage;
                stanceMGK = (player.totalmagic + player.staff.MaxStaffDamage);
                totalArmor = .75 * (player.AP + player.armor.ArmorPoints);
                totalMR = .75 * player.MR;
                stanceName = "Aggressive";
                stanceNum = newStance;
            }
        }
    }
}