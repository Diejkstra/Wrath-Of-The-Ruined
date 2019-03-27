using System;
using System.Collections.Generic;
using System.Text;

namespace Engine
{
    public class Town
    {
        public string townName { get; set; }
        public int townID;
        public Quest quest1;
        public Quest quest2;

        public Town (int ID)
        {
            townID = ID;
            switch (ID)
            {
                case 1:
                    quest1.SetQuest(1);
                    quest2.SetQuest(2);
                    break;
                case 2:
                    quest1.SetQuest(3);
                    quest2.SetQuest(4);
                    break;
                case 3:
                    quest1.SetQuest(5);
                    quest2.SetQuest(6);
                    break;
                case 4:
                    quest1.SetQuest(7);
                    quest2.SetQuest(8);
                    break;
            }


        }
    }
}
