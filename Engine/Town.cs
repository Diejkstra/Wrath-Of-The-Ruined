using System.Collections.Generic;

namespace Engine
{
    public class Town
    {
        public string Name { get; set; }
        public string PreviousTownName { get; set; }
        public string NextTownName { get; set; }
        public string Descriptor { get; set; }
        public string Description { get; set; }
        public string DepartureString { get; set; }
        public int TownID { get; set; }
        public int GBPValue { get; set; }
        public List<Enemy> Townsfolk = new List<Enemy>();
        public Quest Quest1 = new Quest();
        public Quest Quest2 = new Quest();

        public Town (int ID)
        {
            TownID = ID;
            switch (ID)
            {
                case 0:
                    Name = "Lancaster";
                    PreviousTownName = "Home";
                    NextTownName = "Doveport";
                    Descriptor = "small town";
                    DepartureString = "You decide to head for greener pastures.";
                    Quest1.SetQuest(0);
                    Quest2.SetQuest(1);
                    GBPValue = 250;
                    Townsfolk.Add(new Enemy("Citizen", 0, 0, 0, 5, 15));
                    Townsfolk.Add(new Enemy("Citizen", 0, 0, 0, 5, 15));
                    Townsfolk.Add(new Enemy("Citizen", 0, 0, 0, 5, 15));
                    Townsfolk.Add(new Enemy("Guard", 6, 0, 1, 5, 25));
                    Townsfolk.Add(new Enemy("Guard", 6, 0, 1, 5, 25));
                    Townsfolk.Add(new Enemy("Guard", 6, 0, 1, 5, 25));
                    break;
                case 1:
                    Name = "Doveport";
                    PreviousTownName = "Lancaster";
                    NextTownName = "Venzor";
                    Descriptor = "town";
                    DepartureString = "Doveport has given everything it has to offer, and have you decided to move on.";
                    Quest1.SetQuest(2);
                    Quest2.SetQuest(3);
                    GBPValue = 300;
                    Townsfolk.Add(new Enemy("Citizen", 3, 0, 0, 7, 25));
                    Townsfolk.Add(new Enemy("Citizen", 3, 0, 0, 7, 25));
                    Townsfolk.Add(new Enemy("Citizen", 3, 0, 0, 8, 25));
                    Townsfolk.Add(new Enemy("Citizen", 3, 0, 0, 10, 25));
                    Townsfolk.Add(new Enemy("Guard", 11, 0, 1, 5, 30));
                    Townsfolk.Add(new Enemy("Guard", 11, 0, 1, 5, 30));
                    Townsfolk.Add(new Enemy("Guard", 11, 0, 1, 5, 30));
                    Townsfolk.Add(new Enemy("Guard", 11, 0, 1, 5, 30));
                    Townsfolk.Add(new Enemy("Guard", 11, 0, 1, 5, 30));
                    break;
                case 2:
                    Name = "Venzor";
                    PreviousTownName = "Doveport";
                    NextTownName = "Fallholt";
                    Descriptor = "bustling city";
                    DepartureString = "You decide to close the distance to the Royal Palace once again.";
                    Quest1.SetQuest(4);
                    Quest2.SetQuest(5);
                    GBPValue = 500;
                    Townsfolk.Add(new Enemy("Citizen", 5, 0, 0, 15, 15));
                    Townsfolk.Add(new Enemy("Citizen", 5, 0, 0, 15, 15));
                    Townsfolk.Add(new Enemy("Citizen", 5, 0, 0, 15, 15));
                    Townsfolk.Add(new Enemy("Citizen", 5, 0, 0, 15, 15));
                    Townsfolk.Add(new Enemy("Guard", 12, 0, 2, 5, 35));
                    Townsfolk.Add(new Enemy("Guard", 13, 0, 2, 5, 35));
                    Townsfolk.Add(new Enemy("Guard", 13, 0, 2, 5, 35));
                    Townsfolk.Add(new Enemy("Guard", 13, 0, 2, 5, 35));
                    Townsfolk.Add(new Enemy("Guard", 15, 0, 2, 5, 40));
                    break;
                case 3:
                    Name = "Fallholt";
                    PreviousTownName = "Venzor";
                    NextTownName = "The Royal Palace";
                    Descriptor = "royal city";
                    DepartureString = "The time has come, you start walking towards the entrance of the Royal Palace.";
                    Quest1.SetQuest(6);
                    Quest2.SetQuest(7);
                    GBPValue = 1000;
                    Townsfolk.Add(new Enemy("Citizen", 5, 5, 0, 130, 15));
                    Townsfolk.Add(new Enemy("Citizen", 5, 5, 0, 130, 15));
                    Townsfolk.Add(new Enemy("Citizen", 5, 5, 0, 132, 15));
                    Townsfolk.Add(new Enemy("Citizen", 5, 5, 0, 135, 15));
                    Townsfolk.Add(new Enemy("Guard", 18, 0, 3, 5, 50));
                    Townsfolk.Add(new Enemy("Guard", 19, 0, 3, 5, 55));
                    Townsfolk.Add(new Enemy("Guard", 20, 0, 3, 5, 55));
                    Townsfolk.Add(new Enemy("Guard", 20, 0, 3, 5, 60));
                    Townsfolk.Add(new Enemy("Guard", 21, 0, 3, 5, 75));
                    break;
            }
        }
    }
}
