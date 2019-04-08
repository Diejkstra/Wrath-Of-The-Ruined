using System;
using System.Collections.Generic;
using System.Text;
using Engine;

namespace Engine
{
    public class Stance
    {
        public string stanceName { get; set; }
        public int stanceMaxP_DMG { get; set; }
        public int stanceMinP_DMG { get; set; }
        public int stanceMaxM_DMG { get; set; }
        public int stanceMinM_DMG { get; set; }
        public int totalArmor { get; set; }
        public int totalMR { get; set; }
        public int stanceNum { get; set; }

        public void ChangeStance(Creature player, int newStance)
        {
            if (newStance == 1)     //DEFENSIVE
            {
                if (player.Endurance <= 100 && player.Endurance >= 60)
                {
                    stanceMaxP_DMG = Convert.ToInt32(Math.Round( .25 * (player.CalculatePhysicalAttack() + player.sword.MaxSwordDamage)));
                    stanceMinP_DMG = Convert.ToInt32(Math.Round(.25 * (player.CalculatePhysicalAttack() + player.sword.BaseSwordDamage)));
                    totalArmor = Convert.ToInt32(Math.Round(2.5 * (player.AP + player.armor.ArmorPoints)));
                    totalMR = Convert.ToInt32(Math.Round(2.5 * player.MR));
                }
                else if (player.Endurance < 60 && player.Endurance >= 30)
                {
                    stanceMaxP_DMG = Convert.ToInt32(Math.Round(.25 * (player.CalculatePhysicalAttack() + player.sword.MaxSwordDamage)));
                    stanceMinP_DMG = Convert.ToInt32(Math.Round(.25 * (player.CalculatePhysicalAttack() + player.sword.BaseSwordDamage)));
                    totalArmor = Convert.ToInt32(Math.Round(1.75 * (player.AP + player.armor.ArmorPoints)));
                    totalMR = Convert.ToInt32(Math.Round(1.75 * player.MR));
                }
                else if (player.Endurance < 20 && player.Endurance >= 0)
                {
                    stanceMaxP_DMG = Convert.ToInt32(Math.Round(.25 * (player.CalculatePhysicalAttack() + player.sword.MaxSwordDamage)));
                    stanceMinP_DMG = Convert.ToInt32(Math.Round(.25 * (player.CalculatePhysicalAttack() + player.sword.BaseSwordDamage)));
                    totalArmor = Convert.ToInt32(Math.Round(1.0 * (player.AP + player.armor.ArmorPoints)));
                    totalMR = Convert.ToInt32(Math.Round(1.0 * player.MR));
                }
                stanceMaxM_DMG = player.CalculateMagicalAttack() + player.staff.MaxStaffDamage;
                stanceMinM_DMG = player.CalculateMagicalAttack() + player.staff.BaseStaffDamage;
                stanceName = "Defensive";
                stanceNum = newStance;
            }
            else if (newStance == 2)    //NEUTRAL
            {
                if (player.Endurance <= 100 && player.Endurance >= 40)
                {
                    stanceMaxP_DMG = Convert.ToInt32(Math.Round(1.1 * (player.CalculatePhysicalAttack() + player.sword.MaxSwordDamage)));
                    stanceMinP_DMG = Convert.ToInt32(Math.Round(1.1 * (player.CalculatePhysicalAttack() + player.sword.BaseSwordDamage)));
                    stanceMaxM_DMG = Convert.ToInt32(Math.Round(1.1 * (player.CalculateMagicalAttack() + player.staff.MaxStaffDamage)));
                    stanceMinM_DMG = Convert.ToInt32(Math.Round(1.1 * (player.CalculateMagicalAttack() + player.staff.BaseStaffDamage)));
                    totalArmor = Convert.ToInt32(Math.Round(1.1 * (player.AP + player.armor.ArmorPoints)));
                    totalMR = Convert.ToInt32(Math.Round(1.1 * player.MR));
                }
                else if (player.Endurance < 40 && player.Endurance >= 0)
                {
                    stanceMaxP_DMG = player.CalculatePhysicalAttack() + player.sword.MaxSwordDamage;
                    stanceMinP_DMG = player.CalculatePhysicalAttack() + player.sword.BaseSwordDamage;
                    stanceMaxM_DMG = player.CalculateMagicalAttack() + player.staff.MaxStaffDamage;
                    stanceMinM_DMG = player.CalculateMagicalAttack() + player.staff.BaseStaffDamage;
                    totalArmor = player.AP + player.armor.ArmorPoints;
                    totalMR = player.MR;
                }
                stanceName = "Neutral";
                stanceNum = newStance;
            }
            else if (newStance == 3)    //AGGRESSIVE
            {
                if (player.Endurance <= 100 && player.Endurance >= 60)
                {
                    stanceMaxP_DMG = Convert.ToInt32(Math.Round(2.0 * (player.CalculatePhysicalAttack() + player.sword.MaxSwordDamage)));
                    stanceMinP_DMG = Convert.ToInt32(Math.Round(2.0 * (player.CalculatePhysicalAttack() + player.sword.BaseSwordDamage)));
                }
                else if (player.Endurance < 60 && player.Endurance >= 30)
                {
                    stanceMaxP_DMG = Convert.ToInt32(Math.Round(1.5 * (player.CalculatePhysicalAttack() + player.sword.MaxSwordDamage)));
                    stanceMinP_DMG = Convert.ToInt32(Math.Round(1.5 * (player.CalculatePhysicalAttack() + player.sword.BaseSwordDamage)));
                }
                else if (player.Endurance < 30 && player.Endurance >= 0)
                {
                    stanceMaxP_DMG = player.CalculatePhysicalAttack() + player.sword.MaxSwordDamage;
                    stanceMinP_DMG = player.CalculatePhysicalAttack() + player.sword.BaseSwordDamage;
                }
                stanceMaxM_DMG = player.CalculateMagicalAttack() + player.staff.MaxStaffDamage;
                stanceMinM_DMG = player.CalculateMagicalAttack() + player.staff.BaseStaffDamage;
                totalArmor = Convert.ToInt32(Math.Round(.25 * (player.AP + player.armor.ArmorPoints)));
                totalMR = Convert.ToInt32(Math.Round(.25 * player.MR));
                stanceName = "Aggressive";
                stanceNum = newStance;
            }
        }
    }
}