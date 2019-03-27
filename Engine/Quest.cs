using System;
using System.Collections.Generic;
using System.Text;

namespace Engine
{
    public class Quests
    {
        public int QuestID { get; set; }
        public string QuestName { get; set; }
        public string QuestLoc { get; set; }

        public void GenQuests(int ID)
        {
            if(ID == 1)
            {
                QuestName = "Blacksmith in Need";
                QuestLoc = "Doveport";                
            }
            else if(ID==2)
            {
                QuestName = "The Future of Doveport";
                QuestLoc = "Doveport";
            }
            else if (ID == 3)
            {
                QuestName = "Wire Fraud";
                QuestLoc = "Fallholt";
            }
            else if (ID == 4)
            {
                QuestName = "Case of the Lost Teddy";
                QuestLoc = "Lancaster";
            }
            else if (ID == 5)
            {
                QuestName = "Killer Bears";
                QuestLoc = "Venzor";
            }
            else if (ID == 6)
            {
                QuestName = "Misplaced Love";
                QuestLoc = "Fallholt";
            }
            else if (ID == 7)
            {
                QuestName = "Abandoned Dog";
                QuestLoc = "Lancaster";
            }
            else if (ID == 8)
            {
                QuestName = "PIZZA THYME";
                QuestLoc = "Venzor";
            }
        }
    }
}
