using System;
using System.Collections.Generic;
using System.Text;

namespace Engine
{
    public class Quest
    {
        public int QuestID { get; set; }
        public string QuestName { get; set; }
        public string QuestLoc { get; set; }

        public void SetQuest (int ID)
        {
            switch (ID)
            {
                case 0:
                    QuestName = "Abandoned Dog";
                    QuestLoc = "Lancaster";
                    break;
                case 1:
                    QuestName = "Case of the Lost Teddy";
                    QuestLoc = "Lancaster";
                    break;
                case 2:
                    QuestName = "Blacksmith in Need";
                    QuestLoc = "Doveport";
                    break;
                case 3:
                    QuestName = "The Future of Doveport";
                    QuestLoc = "Doveport";
                    break;
                case 4:
                    QuestName = "PIZZA THYME";
                    QuestLoc = "Venzor";
                    break;
                case 5:
                    QuestName = "Killer Bears";
                    QuestLoc = "Venzor";
                    break;
                case 6:
                    QuestName = "Misplaced Love";
                    QuestLoc = "Fallholt";
                    break;
                case 7:
                    QuestName = "Wire Fraud";
                    QuestLoc = "Fallholt";
                    break;
            }
        }
    }
}
