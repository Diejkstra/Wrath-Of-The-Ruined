using System;
using System.Collections.Generic;
using System.Text;

namespace Engine
{
    public class Town
    {
        public string name { get; set; }
        public string descriptor { get; set; }
        public string desctription { get; set; }
        public string departureString { get; set; }
        public int townID { get; set; }
        public Quest quest1 = new Quest();
        public Quest quest2 = new Quest();

        public Town (int ID)
        {
            townID = ID;
            switch (ID)
            {
                case 0:
                    name = "Lancaster";
                    descriptor = "small town";
                    departureString = "You decide to head for greener pastures.";
                    quest1.SetQuest(0);
                    quest2.SetQuest(1);
                    break;
                case 1:
                    name = "Doveport";
                    descriptor = "town";
                    departureString = "Doveport has given everything it has to offer, and have you decided to move on.";
                    quest1.SetQuest(2);
                    quest2.SetQuest(3);
                    break;
                case 2:
                    name = "Venzor";
                    descriptor = "bustling city";
                    departureString = "You decide to close the distance to the Royal Palace once again.";
                    quest1.SetQuest(4);
                    quest2.SetQuest(5);
                    break;
                case 3:
                    name = "Fallholt";
                    descriptor = "royal city";
                    departureString = "The time has come, you start walking towards the entrance of the Royal Palace.";
                    quest1.SetQuest(6);
                    quest2.SetQuest(7);
                    break;
            }
        }
    }
}
