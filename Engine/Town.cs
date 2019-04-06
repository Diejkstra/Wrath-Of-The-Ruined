using System;
using System.Collections.Generic;
using System.Text;

namespace Engine
{
    public class Town
    {
        public string Name { get; set; }
        public string PreviousTownName { get; set; }
        public string Descriptor { get; set; }
        public string Description { get; set; }
        public string DepartureString { get; set; }
        public int TownID { get; set; }
        public Quest Quest1 = new Quest();
        public Quest Quest2 = new Quest();

        public Town (int ID)
        {
            TownID = ID;
            switch (ID)
            {
                case 0:
                    Name = "Lancaster";
                    Descriptor = "small town";
                    DepartureString = "You decide to head for greener pastures.";
                    Quest1.SetQuest(0);
                    Quest2.SetQuest(1);
                    break;
                case 1:
                    Name = "Doveport";
                    PreviousTownName = "Lancaster";
                    Descriptor = "town";
                    DepartureString = "Doveport has given everything it has to offer, and have you decided to move on.";
                    Quest1.SetQuest(2);
                    Quest2.SetQuest(3);
                    break;
                case 2:
                    Name = "Venzor";
                    PreviousTownName = "Doveport";
                    Descriptor = "bustling city";
                    DepartureString = "You decide to close the distance to the Royal Palace once again.";
                    Quest1.SetQuest(4);
                    Quest2.SetQuest(5);
                    break;
                case 3:
                    Name = "Fallholt";
                    PreviousTownName = "Venzor";
                    Descriptor = "royal city";
                    DepartureString = "The time has come, you start walking towards the entrance of the Royal Palace.";
                    Quest1.SetQuest(6);
                    Quest2.SetQuest(7);
                    break;
            }
        }
    }
}
