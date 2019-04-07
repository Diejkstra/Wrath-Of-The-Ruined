using System;
using System.Collections.Generic;
using System.Text;

namespace Engine
{
    public class Quest
    {
        public int ID { get; set; }
        public string name { get; set; }
        public int townID { get; set; }
        public string startString { get; set; }

        public void SetQuest (int switchID)
        {
            ID = switchID;
            switch (switchID)
            {
                case 0:
                    name = "Abandoned Dog";
                    townID = 0;
                    startString = "You see a flyer describing the physical appearance a dog that has gone missing.";
                    break;
                case 1:
                    name = "Case of the Lost Teddy";
                    townID = 0;
                    startString = "You see a flyer noting that a child has lost her stuffed bear.";
                    break;
                case 2:
                    name = "Blacksmith in Need";
                    townID = 1;
                    startString = "The local blacksmith has requested some help in dealing with some thugs harrassing his place of business.";
                    break;
                case 3:
                    name = "The Future of Doveport";
                    townID = 1;
                    startString = "The guards have requested that someone deal with the band of bandits camped out just east of town. The request specifies that the bandits are asking for a large sum of gold before they leave town.";
                    break;
                case 4:
                    name = "Pizza Thyme";
                    townID = 2;
                    startString = "The local bakery has asked someone to deliver a large round food item, the classic Venzorian Pizza Pie, to someone in the next village over.";
                    break;
                case 5:
                    name = "Killer Bears";
                    townID = 2;
                    startString = "A string of bear attacks has been reported to the north of town, and multiple requests have been made to deal with them so the citizens can hike peacefully again.";
                    break;
                case 6:
                    name = "Misplaced Love";
                    townID = 3;
                    startString = "One of the citizens posted a rumor about an affair between a certain noble and a peasent, a crime punishable with death in this city.";
                    break;
                case 7:
                    name = "Armando De Santo";
                    townID = 3;
                    startString = "A wanted poster of a noble by the name of Armando 'Silence' De Santo is posted, with a reward of 2500 gold pieces, dead or alive.";
                    break;
            }
        }
    }
}
