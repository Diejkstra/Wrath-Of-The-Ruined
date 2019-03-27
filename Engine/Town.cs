using System;
using System.Collections.Generic;
using System.Text;

namespace Engine
{
    public class Town
    {
        public string townName { get; set; }
        public int townID { get; set; }
        public Quest quest1 = new Quest();
        public Quest quest2 = new Quest();

        public Town (int ID)
        {
            townID = ID;
            switch (ID)
            {
                case 0:
                    townName = "Lancaster";
                    quest1.SetQuest(0);
                    quest2.SetQuest(1);
                    break;
                case 2:
                    townName = "Doveport";
                    quest1.SetQuest(2);
                    quest2.SetQuest(3);
                    break;
                case 3:
                    townName = "Venzor";
                    quest1.SetQuest(4);
                    quest2.SetQuest(5);
                    break;
                case 4:
                    townName = "Fallholt";
                    quest1.SetQuest(6);
                    quest2.SetQuest(7);
                    break;
            }
        }
    }
}
