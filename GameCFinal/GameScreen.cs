using Engine;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace WrathOfTheRuined
{
    public partial class GameScreen : Form
    {
        public Player player;

        Music GameScreenMusic = new Music();

        public GameScreen() //NewGame
        {
            InitializeComponent();

            NewCharacterForm NewCharacter = new NewCharacterForm();
            if (NewCharacter.ShowDialog(this) == DialogResult.OK)
            {
                player = new Player(0, 0, 0)
                {
                    Name = NewCharacter.nameTextBox.Text,
                    MaxHP = Convert.ToInt32(NewCharacter.numMaxHP.Value),
                    Strength = Convert.ToInt32(NewCharacter.numStrength.Value),
                    Intellect = Convert.ToInt32(NewCharacter.numIntellect.Value),
                    AP = Convert.ToInt32(NewCharacter.numAP.Value),
                    MR = Convert.ToInt32(NewCharacter.numMR.Value)
                };
            }
            NewCharacter.Dispose();

            if (player.Name == "Tully")
            {
                Sword sword = new Sword(100);
                Staff staff = new Staff(100);
                Armor armor = new Armor(100);
                player.sword = sword;
                player.staff = staff;
                player.armor = armor;
                player.Gold = 50000;
                player.GBP = -100000;
                player.Inventory.Clear();
                player.Inventory.Add(sword);
                player.Inventory.Add(staff);
                player.Inventory.Add(armor);
            }
            else if (player.Name == "Tom")
            {
                Sword sword = new Sword(200);
                Staff staff = new Staff(100);
                Armor armor = new Armor(200);
                player.sword = sword;
                player.staff = staff;
                player.armor = armor;
                player.Gold = 50000;
                player.GBP = 100000;
                player.Inventory.Clear();
                player.Inventory.Add(sword);
                player.Inventory.Add(staff);
                player.Inventory.Add(armor);
            }

            ShowData(player);
            GameScreenMusic.soundplayer = GameScreenMusic.StartMusic("Mellow");

            TbMain.Text = "Hello " + player.Name + ". You have been asleep for a long time. Have you forgotten who you are? You are a proud member of the Vanin race. I hope you know how to survive." + Environment.NewLine +
            "You awake after a year long hibernation. While it is not unusual for a Vanin to have long slumber periods, a year is unheard of." + Environment.NewLine +
            "Your family is huddled around you, amazed that you have awoken. They break the news that the rest of the Vanins have been slaughtered by order of the King. " + Environment.NewLine +
            "Your kind was feared because of the immense potential you hold. Your race has the ability to absorb part of the skill and wisdom from those you defeat. After several horrific wars, your kind has learned to live peacefully with Humans.";
            TbMain.AppendText(Environment.NewLine + Environment.NewLine + "Or so you thought.");
            TbMain.AppendText(Environment.NewLine + Environment.NewLine + "(Press Continue)");
        }

        public GameScreen(Player loadedPlayer)    //LoadGame
        {
            player = loadedPlayer;
            InitializeComponent();
            ShowData(player);
            GameScreenMusic.soundplayer = GameScreenMusic.StartMusic("Mellow");
        }

        private void ShowData(Player player)
        {
            listBoxPlayerInventory.DataSource = null;
            listBoxPlayerInventory.DataSource = player.Inventory;
            listBoxPlayerInventory.DisplayMember = "Name";
        }

        public void GameTutorial()
        {
            MessageBox.Show("Welcome to Wrath of the Ruined. This is a tutorial to teach you the basics of of the game.", "Tutorial");
            lblPlayerGold.BackColor = Color.Gold;
            lblPlayerGBP.BackColor = Color.SkyBlue;
            MessageBox.Show("Highlighted in yellow is your amount of Gold. You can use gold to buy items from shops in towns." + Environment.NewLine +
                Environment.NewLine + "Blue is your Good Boy Points counter. The more Good Boy Points you have, the more honorable you are.", "Tutorial");
            lblPlayerGold.BackColor = Color.Transparent;
            lblPlayerGBP.BackColor = Color.Transparent;
            lblLoc.BackColor = Color.Red;
            MessageBox.Show("Highlighted in Red is your current location.", "Tutorial");
            lblLoc.BackColor = Color.Transparent;
            TbMain.Text = "You are walking in the wilderness and an enemy approaches." + Environment.NewLine + "You draw your weapon";
            Enemy enemy = new Enemy("Bandit", 0, 0, 0, 0, 0);
            Combat(player, enemy);
            player.progress++;
            TbMain.Text = "Will you protect your family, or will you tremble as your cowardess takes hold of you?" + Environment.NewLine +
                "You arm yourself with what scraps your family has left and you head off to the first town Lancaster. Do you help the locals out of the kindness of your heart, or for power and money?" + Environment.NewLine;
        }

        private void Game_Load(object sender, EventArgs e)
        {
            progressBarXP.Value = player.XP;
            lblPlayerGold.Text = player.Gold.ToString();
            lblPlayerGBP.Text = player.GBP.ToString();
            lblEquippedSword.Text = player.sword.Name.ToString();
            lblEquippedStaff.Text = player.staff.Name.ToString();
            lblEquippedArmor.Text = player.armor.Name.ToString();
            lblLoc.Text = "Wilderness";
        }

        private void Game_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void OutsideTownContinueClick(object sender, EventArgs e)
        {
            switch (player.progress)
            {
                case 0:
                    GameTutorial();
                    break;
                case 1:
                    Town(0);
                    break;
                case 2:
                    Wilderness(1);
                    break;
                case 3:
                    Town(1);
                    break;
                case 4:
                    Wilderness(5);
                    break;
                case 5:
                    Town(2);
                    break;
                case 6:
                    Wilderness(8);
                    break;
                case 7:
                    Town(3);
                    break;
                case 8:
                    RoyalPalace();
                    break;
            }
        }

        private void equipButton_Click(object sender, EventArgs e)
        {
            if (listBoxPlayerInventory.SelectedItem != null)
            {
                Item item = listBoxPlayerInventory.SelectedItem as Item;
                if( item is Sword )
                {
                    Sword sword = item as Sword;
                    if(sword == player.sword)
                    {
                        player.sword = new Sword(-1);
                        TbMain.Text = "You unequipped the " + sword.Name + ".";
                    }
                    else
                    {
                        player.sword = sword;
                        TbMain.Text = "You equipped the " + sword.Name + ".";
                    }
                    lblEquippedSword.Text = player.sword.Name.ToString();
                }
                else if (item is Staff)
                {
                    Staff staff = item as Staff;
                    if(staff == player.staff)
                    {
                        player.staff = new Staff(-1);
                        TbMain.Text = "You unequipped the " + staff.Name + ".";
                    }
                    else
                    {
                        player.staff = staff;
                        TbMain.Text = "You equipped the " + staff.Name + ".";
                    }
                    lblEquippedStaff.Text = player.staff.Name.ToString();
                }
                else if (item is Armor)
                {
                    Armor armor = item as Armor;
                    if(armor == player.armor)
                    {
                        player.armor = new Armor(-1);
                        TbMain.Text = "You unequipped the " + armor.Name + ".";
                    }
                    else
                    {   
                        player.armor = armor;
                        TbMain.Text = "You equipped the " + armor.Name + ".";
                    }
                    lblEquippedArmor.Text = player.armor.Name.ToString();
                }
                else
                    TbMain.Text = "You cannot equip the " + item.Name + ".";
                ActionBox.SelectedIndex = -1;
            }
        }

        public void Town(int townID)
        {
            Town Town = new Town(townID);
            BtnContinue.Click -= OutsideTownContinueClick;
            BtnContinue.Click += InsideTownContinueClick;
            ActionBox.SelectedIndex = -1;
            BtnContinue.PerformClick();

            void InsideTownContinueClick(object sender, EventArgs e)
            {
                if (!player.townSlaughtered[Town.TownID])
                {
                    switch (ActionBox.SelectedIndex)
                    {
                        case 0:
                            BtnContinue.Click -= InsideTownContinueClick;
                            BtnContinue.Click += QuestBoardContinueClick;

                            TbMain.Text = "You check out the quest board.";

                            ActionBox.Items.Clear();
                            ActionBox.Items.Add(Town.Quest1.name);
                            ActionBox.Items.Add(Town.Quest2.name);
                            ActionBox.Items.Add("Leave Quest Board");
                            break;
                        case 1:
                            Store(player, Town.TownID, 1);
                            ActionBox.Items.Clear();
                            ActionBox.SelectedIndex = -1;
                            BtnContinue.PerformClick();
                            break;
                        case 2:
                            Store(player, Town.TownID, 2);
                            ActionBox.Items.Clear();
                            ActionBox.SelectedIndex = -1;
                            BtnContinue.PerformClick();
                            break;
                        case 3:
                            TbMain.Text = "You decide to slaughter everyone in " + Town.Name + ".";
                            ActionBox.Items.Clear();
                            ActionBox.Items.Add("Start the slaughter");
                            ActionBox.SelectedIndex = 0;
                            BtnContinue.Click -= InsideTownContinueClick;
                            BtnContinue.Click += SlaughterClick;
                            void SlaughterClick(object sender_1, EventArgs e_1)
                            {
                                int result = 0;
                                foreach(Enemy enemy in Town.Townsfolk)
                                {
                                    result = Combat(player, enemy);
                                    if( result == 2 )
                                    {
                                        ActionBox.Items.Clear();
                                        ActionBox.SelectedIndex = -1;
                                        TbMain.Text = "Despite running away from the fight, " + Town.Name +  " now shuns you for your attempt on their lives. -" + Town.GBPValue + "GPB";
                                        player.GBP -= Town.GBPValue;
                                        BtnContinue.Click -= SlaughterClick;
                                        BtnContinue.Click += InsideTownContinueClick;
                                    }
                                }
                                if( result == 1 )
                                {
                                    player.townSlaughtered[townID] = true;
                                    ActionBox.Items.Clear();
                                    ActionBox.SelectedIndex = -1;
                                    TbMain.Text = "You have successfully killed as many people in " + Town.Name + " as you could manage, the rest of them have fleed to the surrounding cities. -" + Town.GBPValue + "GBP";
                                    player.GBP -= Town.GBPValue;
                                    BtnContinue.Click -= SlaughterClick;
                                    BtnContinue.Click += InsideTownContinueClick;
                                }
                            }
                            break;
                        case 4:
                            TbMain.Text = Town.DepartureString;
                            ActionBox.Items.Clear();
                            ActionBox.SelectedIndex = -1;
                            player.progress++;
                            player.Direction = true;
                            BtnContinue.Click -= InsideTownContinueClick;
                            BtnContinue.Click += OutsideTownContinueClick;
                            break;
                        case 5:
                            if(Town.TownID == 0)
                            {
                                TbMain.Text = "You cannot head back home, your familiy needs you to finish what the humans have started.";
                                ActionBox.Items.Clear();
                                ActionBox.SelectedIndex = -1;
                            }
                            else
                            {
                                TbMain.Text = "You start heading back towards " + Town.PreviousTownName + ", you have unfinished business to attend to.";
                                ActionBox.Items.Clear();
                                ActionBox.SelectedIndex = -1;
                                player.progress--;
                                player.Direction = false;
                                BtnContinue.Click -= InsideTownContinueClick;
                                BtnContinue.Click += OutsideTownContinueClick;
                                break;
                            }
                            break;
                        default:
                            progressBarXP.Value = player.XP;
                            lblPlayerGold.Text = player.Gold.ToString();
                            lblPlayerGBP.Text = player.GBP.ToString();
                            lblLoc.Text = Town.Name;
                            listBoxPlayerInventory.Refresh();
                            TbMain.Text = "You are standing in the " + Town.Descriptor + " of " + Town.Name + ".";

                            ActionBox.Items.Clear();
                            ActionBox.Items.Add("Check quest board");
                            ActionBox.Items.Add("Visit the blacksmith");
                            ActionBox.Items.Add("Visit the apothecary");
                            ActionBox.Items.Add("Slaughter everyone");
                            ActionBox.Items.Add("Leave for next town");
                            ActionBox.Items.Add("Leave for previous town");
                            break;
                    }
                }
                else
                {
                    progressBarXP.Value = player.XP;
                    lblPlayerGold.Text = player.Gold.ToString();
                    lblPlayerGBP.Text = player.GBP.ToString();
                    lblLoc.Text = Town.Name;
                    TbMain.Text = "You are standing in the remains of " + Town.Name + ".";
                    ActionBox.Items.Clear();
                    ActionBox.Items.Add("Leave for next town");
                    ActionBox.Items.Add("Leave for previous town");
                    ActionBox.SelectedIndex = -1;
                    BtnContinue.Click -= InsideTownContinueClick;
                    BtnContinue.Click += InsideTownClick2;
                    void InsideTownClick2(object sender_1, EventArgs e_1)
                    {
                        switch (ActionBox.SelectedIndex)
                        {
                            case 0:
                                TbMain.Text = Town.DepartureString;
                                ActionBox.Items.Clear();
                                ActionBox.SelectedIndex = -1;
                                player.progress++;
                                player.Direction = true;
                                BtnContinue.Click -= InsideTownClick2;
                                BtnContinue.Click += OutsideTownContinueClick;
                                break;
                            case 1:
                                if (Town.TownID == 0)
                                {
                                    TbMain.Text = "You cannot head back home, your familiy needs you to finish what the humans have started.";
                                    ActionBox.Items.Clear();
                                    ActionBox.SelectedIndex = -1;
                                }
                                else
                                {
                                    TbMain.Text = "You start heading back towards " + Town.PreviousTownName + ", you have unfinished business to attend to.";
                                    ActionBox.Items.Clear();
                                    ActionBox.SelectedIndex = -1;
                                    player.progress--;
                                    player.Direction = false;
                                    BtnContinue.Click -= InsideTownClick2;
                                    BtnContinue.Click += OutsideTownContinueClick;
                                    break;
                                }
                                break;
                        }
                    }
                }
            }

            void QuestBoardContinueClick(object sender, EventArgs e)

            {
                switch (ActionBox.SelectedIndex)
                {
                    case 0:
                        if(!player.questComplete[Town.Quest1.ID])
                        {
                            TbMain.Text = Town.Quest1.startString;
                            ActionBox.Items.Clear();
                            BtnContinue.Click -= QuestBoardContinueClick;
                            ActionBox.SelectedIndex = -1;
                            StartQuest(Town.Quest1.ID);
                            ActionBox.SelectedIndex = -1;
                        }
                        else
                        {
                            TbMain.Text = "You have already completed this quest.";
                            ActionBox.Items.Clear();
                            ActionBox.Items.Add("Look at the Quest Board");
                            ActionBox.SelectedIndex = 0;
                            BtnContinue.Click -= QuestBoardContinueClick;
                            BtnContinue.Click += InsideTownContinueClick;
                        }
                        break;
                    case 1:
                        if (!player.questComplete[Town.Quest2.ID])
                        {
                            TbMain.Text = Town.Quest2.startString;
                            ActionBox.Items.Clear();
                            BtnContinue.Click -= QuestBoardContinueClick;
                            ActionBox.SelectedIndex = -1;
                            StartQuest(Town.Quest2.ID);
                            ActionBox.SelectedIndex = -1;
                        }
                        else
                        {
                            TbMain.Text = "You have already completed this quest.";
                            ActionBox.Items.Clear();
                            ActionBox.Items.Add("Look at the Quest Board");
                            ActionBox.SelectedIndex = 0;
                            BtnContinue.Click -= QuestBoardContinueClick;
                            BtnContinue.Click += InsideTownContinueClick;
                        }
                        break;
                    case 2:
                        TbMain.Text = "You decide to leave the quest board, and walk back to center of this " + Town.Descriptor + ".";
                        ActionBox.Items.Clear();
                        BtnContinue.Click -= QuestBoardContinueClick;
                        BtnContinue.Click += InsideTownContinueClick;
                        break;
                }


            }

            void StartQuest(int questID)
            {
                switch (questID)
                {
                    case 0:     //Abandonded Dog
                        BtnContinue.Click += Quest0Start;
                        ActionBox.Items.Add("Try to find the dog");
                        ActionBox.Items.Add("You are a bit hungry...");
                        ActionBox.Items.Add("Ignore the flyer");
                        void Quest0Start(object sender, EventArgs e)
                        {
                            switch (ActionBox.SelectedIndex)
                            {
                                case 0:
                                    TbMain.Text = "You decide to try to find the dog. After searching for about two hours, you finally find the dog on the outskirts of town.";
                                    ActionBox.Items.Clear();
                                    ActionBox.SelectedIndex = -1;
                                    BtnContinue.Click -= Quest0Start;
                                    BtnContinue.Click += Quest0Click1;
                                    ActionBox.Items.Add("Return the dog to its owner");
                                    ActionBox.Items.Add("Kill the dog");
                                    void Quest0Click1(object sender_1, EventArgs e_1)
                                    {
                                        switch (ActionBox.SelectedIndex)
                                        {
                                            case 0:
                                                TbMain.Text = "You go to the address that was posted on the flyer, and walk the dog back to his owner. The dog jumps into the owner having not seen him for who knows how long, and nearly knocks him off his feet. The owner gives you 10 gold pieces as thanks." + Environment.NewLine + "+10 Gold, +5 GPB" + Environment.NewLine + "Quest Complete";
                                                ActionBox.Items.Clear();
                                                ActionBox.SelectedIndex = -1;
                                                player.questComplete[0] = true;
                                                player.Gold += 10;
                                                player.GBP += 5;
                                                lblPlayerGold.Text = player.Gold.ToString();
                                                BtnContinue.Click -= Quest0Click1;
                                                BtnContinue.Click += InsideTownContinueClick;
                                                break;
                                            case 1:
                                                TbMain.Text = "You pull out your sword, and strike the dog right on his head, killing it nearly instantly." + Environment.NewLine + "-5 GBP" + Environment.NewLine + "Quest Complete";
                                                ActionBox.Items.Clear();
                                                ActionBox.SelectedIndex = -1;
                                                player.questComplete[0] = true;
                                                player.GBP -= 5;
                                                BtnContinue.Click -= Quest0Click1;
                                                BtnContinue.Click += InsideTownContinueClick;
                                                break;
                                        }
                                    }
                                    break;
                                case 1:
                                    TbMain.Text = "You decide to try to find the dog, you are getting peckish. After searching for about two hours, you finally found your prey on the outside of town.";
                                    ActionBox.Items.Clear();
                                    ActionBox.SelectedIndex = -1;
                                    BtnContinue.Click -= Quest0Start;
                                    BtnContinue.Click += Quest0Click2;
                                    ActionBox.Items.Add("Don't eat the dog");
                                    ActionBox.Items.Add("Kill the dog");
                                    void Quest0Click2(object sender_1, EventArgs e_1)
                                    {
                                        switch (ActionBox.SelectedIndex)
                                        {
                                            case 0:
                                                TbMain.Text = "Looking deep into the eyes of the dog, you can see how happy he is. You can't bring yourself to kill and eat the dog.";
                                                ActionBox.Items.Clear();
                                                ActionBox.SelectedIndex = -1;
                                                BtnContinue.Click -= Quest0Click2;
                                                BtnContinue.Click += Quest0Click1;
                                                ActionBox.Items.Add("Return the dog to its owner");
                                                ActionBox.Items.Add("Kill the dog");
                                                break;
                                            case 1:
                                                TbMain.Text = "You pull out your sword, and strike the dog right on his head, killing it nearly instantly. After skinning the dog, you start a small fire, cook the meat, then you eat it." + Environment.NewLine + "-10 GBP" + Environment.NewLine + "Quest Complete";
                                                ActionBox.Items.Clear();
                                                ActionBox.SelectedIndex = -1;
                                                player.questComplete[0] = true;
                                                player.GBP -= 10;
                                                BtnContinue.Click -= Quest0Click2;
                                                BtnContinue.Click += InsideTownContinueClick;
                                                break;
                                        }
                                    }
                                    break;
                                case 2:
                                    TbMain.Text = "You decide you have better things to do than search for someone elses dog.";
                                    ActionBox.Items.Clear();
                                    ActionBox.Items.Add("Look at the Quest Board");
                                    ActionBox.SelectedIndex = 0;
                                    BtnContinue.Click -= Quest0Start;
                                    BtnContinue.Click += InsideTownContinueClick;
                                    break;
                            }
                        }
                        break;
                    case 1:     //Case of the Lost Teddy
                        BtnContinue.Click += Quest1Start;
                        ActionBox.Items.Add("Try to find the teddy bear");
                        ActionBox.Items.Add("Ignore the flyer");
                        void Quest1Start(object sender, EventArgs e)
                        {
                            switch (ActionBox.SelectedIndex)
                            {
                                case 0:
                                    TbMain.Text = "You decide to look for the teddy bear. After searching in and around the vicinity of the child's neighborhood, you find the stuffed animal in an alleyway. It's a bit dirty, but you're sure the little child won't mind.";
                                    ActionBox.Items.Clear();
                                    ActionBox.SelectedIndex = -1;
                                    ActionBox.Items.Add("Keep the teddy bear");
                                    ActionBox.Items.Add("Go to the child's home");
                                    BtnContinue.Click -= Quest1Start;
                                    BtnContinue.Click += Quest1Click1;
                                    void Quest1Click1(object sender_1, EventArgs e_1)
                                    {
                                        switch (ActionBox.SelectedIndex)
                                        {
                                            case 0:
                                                TbMain.Text = "After putting in all of this effort, why not keep the teddy bear? You deserve it." + Environment.NewLine + "-3 GBP" + Environment.NewLine + "Quest Complete";
                                                ActionBox.Items.Clear();
                                                ActionBox.SelectedIndex = -1;
                                                player.questComplete[1] = true;
                                                player.GBP -= 3;
                                                BtnContinue.Click -= Quest1Click1;
                                                BtnContinue.Click += InsideTownContinueClick;
                                                break;
                                            case 1:
                                                TbMain.Text = "You walk to the address that was posted on the flyer, teddy bear in hand. The father walks outside, and greets you.";
                                                ActionBox.Items.Clear();
                                                ActionBox.SelectedIndex = -1;
                                                ActionBox.Items.Add("Return the teddy bear");
                                                ActionBox.Items.Add("Ask for compensation");
                                                ActionBox.Items.Add("Keep the teddy bear");
                                                ActionBox.Items.Add("Kill the father");
                                                BtnContinue.Click -= Quest1Click1;
                                                BtnContinue.Click += Quest1Click2;
                                                void Quest1Click2(object sender_2, EventArgs e_2)
                                                {
                                                    switch (ActionBox.SelectedIndex)
                                                    {
                                                        case 0:
                                                            TbMain.Text = "You give the stuffed animal to the father, who thanks you. He then hands his daughter the teddy bear and you can see she is happy to be reunited, despite the poor shape that the teddy bear is in." + Environment.NewLine + "+3 GBP" + Environment.NewLine + "Quest Complete";
                                                            ActionBox.Items.Clear();
                                                            ActionBox.SelectedIndex = -1;
                                                            player.questComplete[1] = true;
                                                            player.GBP += 3;
                                                            BtnContinue.Click -= Quest1Click2;
                                                            BtnContinue.Click += InsideTownContinueClick;
                                                            break;
                                                        case 1:
                                                            TbMain.Text = "The father looks at you quizzically, but shortly thereafter, seems to realize that you must have put in some time into searching for the stuffed animal. He pulls out a coin pouch, takes out five gold pieces, and hands them over. You then hand over the teddy bear to the father. He then hands his daughter the teddy bear and you can see she is happy to be reunited, despite the poor shape that the teddy bear is in." + Environment.NewLine + "+5 Gold, +1 GBP" + Environment.NewLine + "Quest Complete";
                                                            ActionBox.Items.Clear();
                                                            ActionBox.SelectedIndex = -1;
                                                            player.questComplete[1] = true;
                                                            player.GBP += 1;
                                                            player.Gold += 5;
                                                            lblPlayerGold.Text = player.Gold.ToString();
                                                            BtnContinue.Click -= Quest1Click2;
                                                            BtnContinue.Click += InsideTownContinueClick;
                                                            break;
                                                        case 2:
                                                            TbMain.Text = "After seeing the father and his daughter, you realize the father seems to spoil his daughter, and you reconsider giving the teddy bear back. The father looks appaulled that you even bothered to come back at all. He walks his daughter back into the house, trying to explain to her what just happened. You hope she learned a valuable lesson." + Environment.NewLine + "-4 GBP" + Environment.NewLine + "Quest Complete";
                                                            ActionBox.Items.Clear();
                                                            ActionBox.SelectedIndex = -1;
                                                            player.questComplete[1] = true;
                                                            player.GBP -= 4;
                                                            BtnContinue.Click -= Quest1Click2;
                                                            BtnContinue.Click += InsideTownContinueClick;
                                                            break;
                                                        case 3:
                                                            TbMain.Text = "After meeting the father, you can tell what kind of scum he is. His daughter is clearly spoiled, and you know the town would be better off without these two in it. As you pull out your sword, the father screams in fear, but the screams fall on deaf ears." + Environment.NewLine + Environment.NewLine + "The child had no gold, but the father had some, he certainly won't be needing it anytime soon. You leave the house, knowing there is very little time before someone finds the bodies." + Environment.NewLine + "+75 Gold, -25 GPB" + Environment.NewLine + "Quest Complete";
                                                            ActionBox.Items.Clear();
                                                            ActionBox.SelectedIndex = -1;
                                                            player.questComplete[1] = true;
                                                            player.Gold += 75;
                                                            player.GBP -= 25;
                                                            lblPlayerGold.Text = player.Gold.ToString();
                                                            BtnContinue.Click -= Quest1Click2;
                                                            BtnContinue.Click += InsideTownContinueClick;
                                                            break;
                                                    }
                                                }
                                                break;
                                        }
                                    }
                                    break;
                                case 1:
                                    TbMain.Text = "You decide you have better things to do than search for a children's toy.";
                                    ActionBox.Items.Clear();
                                    ActionBox.Items.Add("Look at the Quest Board");
                                    ActionBox.SelectedIndex = 0;
                                    BtnContinue.Click -= Quest1Start;
                                    BtnContinue.Click += InsideTownContinueClick;
                                    break;
                            }
                        }
                        break;
                    case 2:     //Blacksmith in need
                        BtnContinue.Click += Quest2Start;
                        ActionBox.Items.Add("Go to the blacksmith");
                        ActionBox.Items.Add("Ignore the request");
                        void Quest2Start(object sender, EventArgs e)
                        {
                            switch (ActionBox.SelectedIndex)
                            {
                                case 0:
                                    TbMain.Text = "You go to the blacksmith. After walking into the workshop he asks you if you are here about the help request.";
                                    ActionBox.Items.Clear();
                                    ActionBox.Items.Add("Ask about the thugs");
                                    ActionBox.Items.Add("Pretend not to know");
                                    ActionBox.SelectedIndex = -1;
                                    BtnContinue.Click -= Quest2Start;
                                    BtnContinue.Click += Quest2Click1;
                                    void Quest2Click1(object sender_1, EventArgs e_1)
                                    {
                                        switch (ActionBox.SelectedIndex)
                                        {
                                            case 0:
                                                TbMain.Text = "He breathes a sigh of relief, and starts to explain the situation. From what you can gather, a few people in town did not like the quality of swords that the blacksmith made, and started beating him up wherever he went in town. He knows his swords aren't the finest on this side of the country, but he knows that they're worth the price he sells them at.";
                                                ActionBox.Items.Clear();
                                                ActionBox.Items.Add("Agree to help");
                                                ActionBox.Items.Add("Refuse to help");
                                                ActionBox.SelectedIndex = -1;
                                                BtnContinue.Click -= Quest2Click1;
                                                BtnContinue.Click += Quest2Click2;
                                                void Quest2Click2(object sender_2, EventArgs e_2)
                                                {
                                                    switch (ActionBox.SelectedIndex)
                                                    {
                                                        case 0:
                                                            TbMain.Text = "The blacksmith thanks you for your kindness, and promises compensation as soon as the thugs are taken care of. He points you to the direction of a local bar that they frequent, and you head off to the bar." + Environment.NewLine + Environment.NewLine + "Inside the bar, you can see 3 men that match the blacksmith's description of his assailants.";
                                                            ActionBox.Items.Clear();
                                                            ActionBox.Items.Add("Talk to them");
                                                            ActionBox.Items.Add("Drag them outside");
                                                            ActionBox.SelectedIndex = -1;
                                                            BtnContinue.Click -= Quest2Click2;
                                                            BtnContinue.Click += Quest2Click4;
                                                            void Quest2Click4(object sender_3, EventArgs e_3)
                                                            {
                                                                switch (ActionBox.SelectedIndex)
                                                                {
                                                                    case 0:
                                                                        TbMain.Text = "You walk up to the thugs, and start talking to them. The leader explains that his father also works as a blacksmith, but claims he makes much better swords, but his father's traffic is being stolen from the other blacksmith. All he wants is for his father to have a successful workshop as well.";
                                                                        ActionBox.Items.Clear();
                                                                        ActionBox.Items.Add("Donate gold (50g)");
                                                                        ActionBox.Items.Add("Give friendly advice");
                                                                        ActionBox.Items.Add("Drag them outside");
                                                                        ActionBox.SelectedIndex = -1;
                                                                        BtnContinue.Click -= Quest2Click4;
                                                                        BtnContinue.Click += Quest2Click5;
                                                                        void Quest2Click5(object sender_4, EventArgs e_4)
                                                                        {
                                                                            switch (ActionBox.SelectedIndex)
                                                                            {
                                                                                case 0:
                                                                                    TbMain.Text = "Obviously the leader thug has never learned how to properly vent his feelings. You give him 50 gold pieces in the hopes that his family can make use of it. The other two men explain that they're employee's of the poor blacksmith, and this donation means a lot to them. They promise to put the money to good use, and then they leave the bar, hopefully to go back to work." + Environment.NewLine + Environment.NewLine + "Upon returning to the original blacksmith, you tell him of the other blacksmith's inability to attract business. The blacksmith thinks about this, and tosses out a few ideas to help his competitor, one being a merger between the two. He gives you money to cover the donation, and some more on top of it, because the problem seems to have been solved." + Environment.NewLine + "+50 Gold, +15 GBP" + Environment.NewLine + "Quest Complete";
                                                                                    ActionBox.Items.Clear();
                                                                                    ActionBox.SelectedIndex = -1;
                                                                                    player.questComplete[2] = true;
                                                                                    player.Gold += 50;
                                                                                    player.GBP += 15;
                                                                                    lblPlayerGold.Text = player.Gold.ToString();
                                                                                    BtnContinue.Click -= Quest2Click5;
                                                                                    BtnContinue.Click += InsideTownContinueClick;
                                                                                    break;
                                                                                case 1:
                                                                                    TbMain.Text = "Obviously the leader thug has never learned how to properly vent his feelings. You tell him that instead of sitting at the bar, or beating up the competition, they should probably be working if his family business is really failing. The man thinks about it, and reluctantly agrees with you. The three men leave the bar, clearly still angry, but hopefully they can clear their heads and get back to honest work." + Environment.NewLine + Environment.NewLine + "Upon returning to the original blacksmith, he is happy to hear that they are back to work, but fears he may still be beaten up in the future. Either way, the problem is solved in the short term. He hands you some gold in thanks, and returns to his work." + Environment.NewLine + "+75 Gold, +10 GBP" + Environment.NewLine + "Quest Complete";
                                                                                    ActionBox.Items.Clear(); ;
                                                                                    ActionBox.SelectedIndex = -1;
                                                                                    player.questComplete[2] = true;
                                                                                    player.Gold += 75;
                                                                                    player.GBP += 10;
                                                                                    lblPlayerGold.Text = player.Gold.ToString();
                                                                                    BtnContinue.Click -= Quest2Click5;
                                                                                    BtnContinue.Click += InsideTownContinueClick;
                                                                                    break;
                                                                                case 2:
                                                                                    BtnContinue.Click -= Quest2Click5;
                                                                                    BtnContinue.Click += Quest2Click4;
                                                                                    ActionBox.SelectedIndex = 1;
                                                                                    BtnContinue.PerformClick();
                                                                                    break;
                                                                            }
                                                                        }
                                                                                    break;
                                                                    case 1:
                                                                        TbMain.Text = "You walk closer to the three men. You grab the closest one by his jacket, and drag him outside. The other two are clearly not happy with this, and jump from their seats. However, you were quick enough to pull him outside, and thus the other two have followed you outside.";
                                                                        ActionBox.Items.Clear();
                                                                        ActionBox.Items.Add("Beat them up");
                                                                        ActionBox.Items.Add("Kill them");
                                                                        ActionBox.SelectedIndex = -1;
                                                                        BtnContinue.Click -= Quest2Click4;
                                                                        BtnContinue.Click += Quest2Click6;
                                                                        void Quest2Click6(object sender_4, EventArgs e_4)
                                                                        {
                                                                            switch (ActionBox.SelectedIndex)
                                                                            {
                                                                                case 0:
                                                                                    TbMain.Text = "You start kicking the one on the ground. This casues one of the two thugs that are standing to run at you, fists swinging. The one that was being kicked has no strength left to fight, but the other two thugs put up a good fight. At the end of the brawl, the three thugs lay nearly motionless on the ground. Seems like they got the message." + Environment.NewLine + Environment.NewLine + "Upon telling the blacksmith of the news, he seems slightly worried, but nonetheless glad the threat has been taken care of. He pays you some gold, and continues with his work." + Environment.NewLine + "+75 Gold, +5GBP" + Environment.NewLine + "Quest Complete";
                                                                                    ActionBox.Items.Clear();
                                                                                    ActionBox.SelectedIndex = -1;
                                                                                    player.questComplete[2] = true;
                                                                                    player.Gold += 75;
                                                                                    player.GBP += 5;
                                                                                    lblPlayerGold.Text = player.Gold.ToString();
                                                                                    BtnContinue.Click -= Quest2Click6;
                                                                                    BtnContinue.Click += InsideTownContinueClick;
                                                                                    break;
                                                                                case 1:
                                                                                    TbMain.Text = "You pull out your weapon and swiftly execute the man on the ground. This alarms the other two, and they pull out their daggers.";
                                                                                    ActionBox.Items.Clear();
                                                                                    ActionBox.SelectedIndex = -1;
                                                                                    BtnContinue.Click -= Quest2Click6;
                                                                                    BtnContinue.Click += Quest2Click7;
                                                                                    void Quest2Click7(object sender_5, EventArgs e_5)
                                                                                    {
                                                                                        Enemy thug1 = new Enemy("Thug", 3, -1, 0, 5, 5);
                                                                                        Enemy thug2 = new Enemy("Thug", 5, -1, 1, 5, 5);
                                                                                        int combatresult = Combat(player, thug1);
                                                                                        if( combatresult == 1)
                                                                                        {
                                                                                            combatresult = Combat(player, thug2);
                                                                                            if ( combatresult == 1 )
                                                                                            {
                                                                                                BtnContinue.Click -= Quest2Click7;
                                                                                                TbMain.Text = "After killing the thugs, you run from the bar back to the blacksmith. The blacksmith looks horrified that you are covered in blood. He never meant for you to kill them. Frightened, he tosses his coin pouch at you, and pushes you outside and locks the door behind you." + Environment.NewLine + "+150 Gold, -30GBP";
                                                                                                player.questComplete[2] = true;
                                                                                                player.Gold += 150;
                                                                                                player.GBP -= 30;
                                                                                                lblPlayerGold.Text = player.Gold.ToString();
                                                                                                BtnContinue.Click += InsideTownContinueClick;
                                                                                            }
                                                                                            else
                                                                                            {
                                                                                                BtnContinue.Click -= Quest2Click7;
                                                                                                TbMain.Text = "Having ran from the last thug, you return to the blacksmith. You tell him that they attacked you, but you managed to kill two before needing to run away. He thanks you for trying to help him, but did not wish for you to kill anyone. However, given that you said they attacked you, he understands. He gives you some gold for trying." + Environment.NewLine + "+100 Gold, -20GBP";
                                                                                                player.questComplete[2] = true;
                                                                                                player.Gold += 100;
                                                                                                player.GBP -= 20;
                                                                                                lblPlayerGold.Text = player.Gold.ToString();
                                                                                                BtnContinue.Click += InsideTownContinueClick;
                                                                                            }
                                                                                        }
                                                                                        else
                                                                                        {
                                                                                            BtnContinue.Click -= Quest2Click7;
                                                                                            TbMain.Text = "Having ran from the last two thugs, you return to the blacksmith. You tell him that they attacked you, but you managed to kill one before needing to run away. He thanks you for trying to help him, but did not wish for you to kill anyone. However, given that you said they attacked you, he understands. He gives you some gold for trying." + Environment.NewLine + "+50 Gold, -10GBP";
                                                                                            player.questComplete[2] = true;
                                                                                            player.Gold += 50;
                                                                                            player.GBP -= 10;
                                                                                            BtnContinue.Click += InsideTownContinueClick;
                                                                                        }
                                                                                    }
                                                                                    break;
                                                                            }
                                                                        }
                                                                        break;
                                                                }
                                                            }
                                                            break;
                                                        case 1:
                                                            TbMain.Text = "He is saddened, but understands, this is quite a lot to ask of someone. He sighs, and goes back to his work." + Environment.NewLine + "Quest Complete";
                                                            ActionBox.Items.Clear();
                                                            ActionBox.SelectedIndex = -1;
                                                            player.questComplete[2] = true;
                                                            BtnContinue.Click -= Quest2Click2;
                                                            BtnContinue.Click += Quest2Click8;
                                                            void Quest2Click8(object sender_3, EventArgs e_3)
                                                            {
                                                                ActionBox.Items.Add("");
                                                                ActionBox.Items.Add("");
                                                                BtnContinue.Click -= Quest2Click8;
                                                                BtnContinue.Click += InsideTownContinueClick;
                                                                ActionBox.SelectedIndex = 1;
                                                                BtnContinue.PerformClick();
                                                            }
                                                            break; 
                                                    }
                                                }
                                                break;
                                            case 1:
                                                TbMain.Text = "The blacksmith sighs sadly and tells you to let him know if you have any questions.";
                                                ActionBox.Items.Clear();
                                                ActionBox.Items.Add("Ask about the request");
                                                ActionBox.Items.Add("Wander around the workshop");
                                                ActionBox.SelectedIndex = -1;
                                                BtnContinue.Click -= Quest2Click1;
                                                BtnContinue.Click += Quest2Click3;
                                                void Quest2Click3(object sender_2, EventArgs e_2)
                                                {
                                                    switch (ActionBox.SelectedIndex)
                                                    {
                                                        case 0:
                                                            BtnContinue.Click -= Quest2Click3;
                                                            BtnContinue.Click += Quest2Click1;
                                                            ActionBox.SelectedIndex = 0;
                                                            BtnContinue.PerformClick();
                                                            break;
                                                        case 1:
                                                            BtnContinue.Click -= Quest2Click3;
                                                            BtnContinue.Click += InsideTownContinueClick;
                                                            ActionBox.SelectedIndex = 1;
                                                            BtnContinue.PerformClick();
                                                            break;
                                                    }
                                                }
                                                break;
                                        }
                                    }
                                    break;
                                case 1:
                                    TbMain.Text = "Perhaps you will help later, but not right now.";
                                    ActionBox.Items.Clear();
                                    ActionBox.Items.Add("Look at the Quest Board");
                                    ActionBox.SelectedIndex = 0;
                                    BtnContinue.Click -= Quest2Start;
                                    BtnContinue.Click += InsideTownContinueClick;
                                    break;
                            }
                        }
                        break;
                    case 3:     //The Future of Doveport
                        BtnContinue.Click += Quest3Start;
                        ActionBox.Items.Add("Find the bandit camp");
                        ActionBox.Items.Add("Ignore the request");
                        void Quest3Start(object sender, EventArgs e)
                        {
                            switch (ActionBox.SelectedIndex)
                            {
                                case 0:
                                    TbMain.Text = "You head east towards the bandit camp, and it takes 15 minutes to arrive. The bandits have not seen you yet and they do not look friendly.";
                                    ActionBox.Items.Clear();
                                    ActionBox.Items.Add("Walk into camp");
                                    ActionBox.Items.Add("Kill the bandits");
                                    ActionBox.Items.Add("Walk back to town");
                                    ActionBox.SelectedIndex = -1;
                                    BtnContinue.Click -= Quest3Start;
                                    BtnContinue.Click += Quest3Click1;
                                    void Quest3Click1(object sender_1, EventArgs e_1)
                                    {
                                        switch (ActionBox.SelectedIndex)
                                        {
                                            case 0:
                                                TbMain.Text = "Walking into camp, you try to act as freindly as possible, which goes fairly well. One of the bandit guardsman tells you to halt, and asks you why you're here.";
                                                ActionBox.Items.Clear();
                                                ActionBox.Items.Add("Kill the bandits");
                                                ActionBox.Items.Add("Pay the bandits (-500 gp)");
                                                ActionBox.Items.Add("Ask to join the bandits");
                                                ActionBox.SelectedIndex = -1;
                                                BtnContinue.Click -= Quest3Click1;
                                                BtnContinue.Click += Quest3Click2;
                                                void Quest3Click2(object sender_2, EventArgs e_2)
                                                {
                                                    switch (ActionBox.SelectedIndex)
                                                    {
                                                        case 0:
                                                            Enemy bandit1 = new Enemy("Bandit", 5, 0, 1, 0, 10);
                                                            Enemy bandit2 = new Enemy("Bandit", 5, 0, 2, 0, 10);
                                                            Enemy bandit3 = new Enemy("Bandit", 7, 0, 1, 10, 15);
                                                            Enemy bandit4 = new Enemy("Bandit", 7, 0, 2, 15, 35);
                                                            Enemy bandit5 = new Enemy("Bandit", 11, 0, 2, 20, 50);
                                                            Enemy bandit6 = new Enemy("Bandit", 11, 0, 3, 75, 70);
                                                            Enemy bandit7 = new Enemy("Bandit", 15, 0, 3, 100, 100);
                                                            Enemy banditLeader = new Enemy("Bandit Leader", 20, 0, 3, 150, 100);

                                                            TbMain.Text = "You pull out yor blade, and the guardsman charges at you, screaming. This alerts the rest of the camp to your motive. A very difficult battle against over half a dozen bandits has started.";
                                                            BtnContinue.Click -= Quest3Click2;
                                                            BtnContinue.Click += Quest3Click3;
                                                            ActionBox.Items.Clear();
                                                            ActionBox.Items.Add("Battle");
                                                            ActionBox.SelectedIndex = 0;
                                                            void Quest3Click3(object sender_3, EventArgs e_3)
                                                            {
                                                                bool killedEnough = false;
                                                                int result1 = Combat(player, bandit1);
                                                                if (result1 != 2)
                                                                    result1 = Combat(player, bandit2);
                                                                if (result1 != 2)
                                                                    result1 = Combat(player, bandit3);
                                                                if (result1 != 2)
                                                                {
                                                                    killedEnough = true;
                                                                    result1 = Combat(player, bandit4);
                                                                }
                                                                if (result1 != 2)
                                                                    result1 = Combat(player, bandit5);
                                                                if (result1 != 2)
                                                                    result1 = Combat(player, bandit6);
                                                                if (result1 != 2)
                                                                    result1 = Combat(player, bandit7);
                                                                if (result1 != 2)
                                                                    result1 = Combat(player, banditLeader);
                                                                if (result1 != 2)
                                                                {
                                                                    TbMain.Text = "Despite all odds, you manage to kill every last bandit. This should take care of the bandit problem. After searching the camp for some extra gold, you walk back to town with the good news." + Environment.NewLine + "+150 Gold, +50GBP" + Environment.NewLine + "Quest Complete";
                                                                    ActionBox.Items.Clear();
                                                                    ActionBox.SelectedIndex = -1;
                                                                    player.questComplete[3] = true;
                                                                    player.Gold += 150;
                                                                    player.GBP += 50;
                                                                    BtnContinue.Click -= Quest3Click3;
                                                                    BtnContinue.Click += InsideTownContinueClick;
                                                                }
                                                                else
                                                                {
                                                                    if (killedEnough)
                                                                    {
                                                                        TbMain.Text = "Sometime during the battle, you decide this might not end well for you. However, you managed to kill a few of them before needing to run away. When you get to town, you tell the guards the bandit camp has seen some losses, and shouldn't pose a great threat to Doveport for the time being. The guards thank you for the help." + Environment.NewLine + "+25 GBP" + Environment.NewLine + "Quest Complete";
                                                                        ActionBox.Items.Clear();
                                                                        ActionBox.SelectedIndex = -1;
                                                                        player.questComplete[3] = true;
                                                                        player.GBP += 25;
                                                                        BtnContinue.Click -= Quest3Click3;
                                                                        BtnContinue.Click += InsideTownContinueClick;
                                                                    }
                                                                    else
                                                                    {
                                                                        TbMain.Text = "Sometime during the battle, you decide this might not end well for you. Using your better judgement, you run back to town. After arriving back in town, you alert the guards that the bandits are angry. It seems Doveport's days are numbererd." + Environment.NewLine + "+5 GBP" + Environment.NewLine + "Quest Complete";
                                                                        ActionBox.Items.Clear();
                                                                        ActionBox.SelectedIndex = -1;
                                                                        player.GBP += 5;
                                                                        player.questComplete[3] = true;
                                                                        BtnContinue.Click -= Quest3Click3;
                                                                        BtnContinue.Click += InsideTownContinueClick;
                                                                    }
                                                                }
                                                            }
                                                            break;
                                                        case 1:
                                                            if (player.Gold >= 500)
                                                            {
                                                                TbMain.Text = "You pull out a large gold pouch, and toss it towards the camp. 500 gold pieces slam into the dirt, and the guardsman drops everything to start grabbing the gold. A mini frenzy has broken loose, which causes the bandit leader to appear. He thanks you for the gold, and tells you the bandit camp will move on from Doveport. You start the walk home, slightly saddened by the loss of gold. You tell the guards of your payment, and that the bandits should no longer be a threat to the town" + Environment.NewLine + "-500 Gold, +50GBP" + Environment.NewLine + "Quest Complete";
                                                                ActionBox.SelectedIndex = -1;
                                                                player.questComplete[3] = true;
                                                                player.Gold -= 500;
                                                                player.GBP += 50;
                                                                BtnContinue.Click -= Quest3Click2;
                                                                BtnContinue.Click += InsideTownContinueClick;
                                                            }
                                                            else
                                                            {
                                                                TbMain.Text = "Feeling around inside your coin purse, you can't seem to find 500 gold. Perhaps it was in your other pair of pants...";
                                                                ActionBox.SelectedIndex = -1;
                                                            }
                                                            break;
                                                        case 2:
                                                            Enemy citizen1 = new Enemy("Citizen", 3, 0, 1, 15, 35);
                                                            Enemy citizen2 = new Enemy("Citizen", 5, 0, 1, 20, 40);
                                                            Enemy citizen3 = new Enemy("Citizen", 7, 0, 1, 25, 40);
                                                            Enemy guard1 = new Enemy("Guard", 11, 0, 2, 50, 25);
                                                            Enemy guard2 = new Enemy("Guard", 11, 0, 2, 50, 25);

                                                            TbMain.Text = "The bandit guardsman is confused by this, but tells you to wait there. He comes back with the bandit leader, and he looks you over. The leader seems impressed, and allows you to join in the raid on Doveport, which will take place tonight. You spend the rest of the day preparing for the raid. At around 2:00 AM, the band sets off towards Doveport, and begins the pillage.";
                                                            BtnContinue.Click -= Quest3Click2;
                                                            BtnContinue.Click += Quest3Click4;
                                                            ActionBox.Items.Clear();
                                                            ActionBox.Items.Add("Siege Doveport");
                                                            ActionBox.SelectedIndex = 0;
                                                            void Quest3Click4(object sender_3, EventArgs e_3)
                                                            {
                                                                int result2 = Combat(player, citizen1);
                                                                if (result2 != 2)
                                                                    result2 = Combat(player, citizen2);
                                                                if (result2 != 2)
                                                                    result2 = Combat(player, guard1);
                                                                if (result2 != 2)
                                                                    result2 = Combat(player, citizen3);
                                                                if (result2 != 2)
                                                                    result2 = Combat(player, guard2);
                                                                if (result2 != 2)
                                                                {
                                                                    TbMain.Text = "After the siege is over, most of the townsfolk have fled to Lancaster, or have died protecting their belongings. The nine of you scrounge around and come up with enough gold to split about 400 gold each, and 750 for the leader. You and the bandits then part ways, having taken everything this town has to offer." + Environment.NewLine + "+400 Gold, -75GBP" + Environment.NewLine + "Quest Complete";
                                                                    ActionBox.Items.Clear();
                                                                    ActionBox.SelectedIndex = -1;
                                                                    player.questComplete[3] = true;
                                                                    player.Gold += 400;
                                                                    player.GBP -= 75;
                                                                    player.townSlaughtered[1] = true;
                                                                    BtnContinue.Click -= Quest3Click4;
                                                                    BtnContinue.Click += InsideTownContinueClick;
                                                                }
                                                                else
                                                                {
                                                                    TbMain.Text = "For whatever reason, you have fled from Doveport, and cannot bring yourself to look behind you.";
                                                                    ActionBox.Items.Clear();
                                                                    ActionBox.SelectedIndex = -1;
                                                                    player.questComplete[3] = true;
                                                                    player.GBP -= 50;
                                                                    player.townSlaughtered[1] = true;
                                                                    player.progress++;
                                                                    player.Direction = true;
                                                                    BtnContinue.Click -= Quest3Click4;
                                                                    BtnContinue.Click += OutsideTownContinueClick;
                                                                }
                                                            }
                                                            break;
                                                    }
                                                }
                                                break;
                                            case 1:
                                                ActionBox.Items.Clear();
                                                ActionBox.Items.Add("");
                                                ActionBox.SelectedIndex = 0;
                                                BtnContinue.Click -= Quest3Click1;
                                                BtnContinue.Click += Quest3Click2;
                                                BtnContinue.PerformClick();
                                                break;
                                            case 2:
                                                TbMain.Text = "You decide to head back to town, now is not the time to deal with the bandits.";
                                                ActionBox.Items.Clear();
                                                ActionBox.Items.Add("Walk back");
                                                ActionBox.SelectedIndex = 0;
                                                BtnContinue.Click -= Quest3Click1;
                                                BtnContinue.Click += OutsideTownContinueClick;
                                                break;
                                        }
                                    }
                                    break;
                                case 1:
                                    TbMain.Text = "You can't solve every problem you come across, maybe the guards can handle this one.";
                                    ActionBox.Items.Clear();
                                    ActionBox.Items.Add("Look at the Quest Board");
                                    ActionBox.SelectedIndex = 0;
                                    BtnContinue.Click -= Quest3Start;
                                    BtnContinue.Click += InsideTownContinueClick;
                                    break;
                            }
                        }
                        break;
                    case 4:     //Pizza Thyme
                        BtnContinue.Click += Quest4Start;
                        ActionBox.Items.Add("Go to the bakery");
                        ActionBox.Items.Add("Ignore the request");
                        void Quest4Start(object sender, EventArgs e)
                        {
                            switch (ActionBox.SelectedIndex)
                            {
                                case 0:
                                    GameScreenMusic.StopMusic(GameScreenMusic.soundplayer);
                                    GameScreenMusic.soundplayer = GameScreenMusic.StartMusic("PizzaThyme");
                                    TbMain.Text = "Eventually you find the baker that posted the request. You step into the bakery, and smell all sorts of delicious smells from freshly baked bread, to the all-to-familiar scent of Venzorian Pizza. The baker greets you happily.";
                                    ActionBox.Items.Clear();
                                    ActionBox.Items.Add("Order One Venzorian Pizza (-5 gp)");
                                    ActionBox.Items.Add("Ask about the delivery job");
                                    BtnContinue.Click -= Quest4Start;
                                    BtnContinue.Click += Quest4Click1;
                                    void Quest4Click1(object sender_1, EventArgs e_1)
                                    {
                                        switch (ActionBox.SelectedIndex)
                                        {
                                            case 0:
                                                if(player.Gold >= 5)
                                                {
                                                    player.Gold -= 5;
                                                    TbMain.Text = "The baker smiles at you, and informs you that a pie is comin' right up. In nearly no time flat, you are given a classic Venzorian Pizza Pie, the most round food you can think of.";
                                                    lblPlayerGold.Text = player.Gold.ToString();
                                                    Consumable pizza = new Consumable(0);
                                                    player.Inventory.Add(pizza);
                                                    ActionBox.SelectedIndex = -1;
                                                }
                                                else
                                                {
                                                    TbMain.Text = "Pulling out your coin pouch, you can't seem to find even 5 gold pieces for the pie. This saddens you.";
                                                    ActionBox.SelectedIndex = -1;
                                                }
                                                break;
                                            case 1:
                                                if (!player.townSlaughtered[1])
                                                {
                                                    TbMain.Text = "The baker tells you that you need to deliver one of his pies to Doveport. His normal delivery person is no where to be found.";
                                                    ActionBox.Items.Clear();
                                                    ActionBox.Items.Add("Accept job");
                                                    ActionBox.Items.Add("Refuse job");
                                                    ActionBox.SelectedIndex = -1;
                                                    BtnContinue.Click -= Quest4Click1;
                                                    BtnContinue.Click += Quest4Click2;
                                                    void Quest4Click2(object sender_2, EventArgs e_2)
                                                    {
                                                        switch (ActionBox.SelectedIndex)
                                                        {
                                                            case 0:
                                                                Enemy bandit1 = new Enemy("Bandit", 10, 0, 1, 10, 10);
                                                                Enemy bandit2 = new Enemy("Bandit", 10, 0, 2, 10, 10);
                                                                Enemy bandit3 = new Enemy("Bandit", 15, 0, 2, 10, 10);

                                                                TbMain.Text = "You accept his job offer. He gets the pie out of the oven, and tosses it into a delivery bag. He gives you the address, and you are on your way. In the wilderness between Venzor and Doveport, you are confronted by bandits that wish to steal the pie.";
                                                                BtnContinue.Click -= Quest4Click2;
                                                                BtnContinue.Click += Quest4Click3;
                                                                ActionBox.Items.Clear();
                                                                ActionBox.Items.Add("Protect the Pizza");
                                                                ActionBox.SelectedIndex = 0;
                                                                void Quest4Click3(object sender_3, EventArgs e_3)
                                                                {
                                                                    int result = Combat(player, bandit1);
                                                                    if (result != 2)
                                                                        result = Combat(player, bandit2);
                                                                    if (result != 2)
                                                                        result = Combat(player, bandit3);
                                                                    if (result != 2)
                                                                    {
                                                                        TbMain.Text = "After finally killing the bandits, you pick up the pie, and continue on your journey. It is starting to smell pretty good... really... really... good...";
                                                                        BtnContinue.Click -= Quest4Click3;
                                                                        BtnContinue.Click += Quest4Click4;
                                                                        ActionBox.Items.Clear();
                                                                        ActionBox.Items.Add("Do it");
                                                                        ActionBox.Items.Add("Don't do it");
                                                                        ActionBox.SelectedIndex = -1;
                                                                        void Quest4Click4(object sender_4, EventArgs e_4)
                                                                        {
                                                                            switch (ActionBox.SelectedIndex)
                                                                            {
                                                                                case 0:
                                                                                    TbMain.Text = "The pizza smelled too good to be true. You open up the delivery bag, and open up the box the pizza is in. And you see it in all of it's glory. The perfectly melted Meblon Cheese, Venzorian Pepperoni slices, and the garlic crust is to die for. Before you know it, the pizza is nothing but crumbs. You ditch the bag, and head into Doveport, one pizza fewer than when you started this journey." + Environment.NewLine + "-10 GBP" + Environment.NewLine + "Quest Complete";
                                                                                    ActionBox.Items.Clear();
                                                                                    ActionBox.SelectedIndex = -1;
                                                                                    player.questComplete[4] = true;
                                                                                    player.GBP -= 10;
                                                                                    player.progress -= 2;
                                                                                    BtnContinue.Click -= Quest4Click4;
                                                                                    BtnContinue.Click += OutsideTownContinueClick;
                                                                                    break;
                                                                                case 1:
                                                                                    TbMain.Text = "This pizza is strictly for the Doveport citizen that placed the order. You come to grips with this unfortunate fact, and keep heading towards Doveport. After finally reaching the town, you go to the address listed on the order. You knock on the door, and hear someone yell pizza's here. He opens the door, and you deliver the pie. A single tear falls from one eye, and the man sees it, and understands. He gives you a gold pouch as compensation. He thanks you, and before he shuts the door, you see that no one else is inside." + Environment.NewLine + "+ 30 Gold, +15 GBP" + Environment.NewLine + "Quest Complete"; ;
                                                                                    ActionBox.Items.Clear();
                                                                                    ActionBox.SelectedIndex = -1;
                                                                                    player.questComplete[4] = true;
                                                                                    player.GBP += 15;
                                                                                    player.Gold += 30;
                                                                                    player.progress -= 2;
                                                                                    lblPlayerGold.Text = player.Gold.ToString();
                                                                                    BtnContinue.Click -= Quest4Click4;
                                                                                    BtnContinue.Click += OutsideTownContinueClick;
                                                                                    break;
                                                                            }
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        TbMain.Text = "The battle was too intense, and you had to abandon the pie to the remaining bandits. Hopefully they enjoy it..." + Environment.NewLine + "You run back to Venzor as fast as possible." + Environment.NewLine + "Quest Complete";
                                                                        ActionBox.Items.Clear();
                                                                        ActionBox.SelectedIndex = -1;
                                                                        player.questComplete[4] = true;
                                                                        BtnContinue.Click -= Quest4Click3;
                                                                        BtnContinue.Click += InsideTownContinueClick;
                                                                    }
                                                                }
                                                                    break;
                                                            case 1:
                                                                TbMain.Text = "As much as you enjoy Venzorian Pizza Pies, you are not a delivery service.";
                                                                ActionBox.Items.Clear();
                                                                ActionBox.Items.Add("Go Back to Town");
                                                                ActionBox.SelectedIndex = 0;
                                                                BtnContinue.Click -= Quest4Click2;
                                                                BtnContinue.Click += OutsideTownContinueClick;
                                                                GameScreenMusic.StopMusic(GameScreenMusic.soundplayer);
                                                                GameScreenMusic.soundplayer = GameScreenMusic.StartMusic("Mellow");
                                                                break;
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    TbMain.Text = "The baker tells you that you need to deliver one of his pies to Doveport. You then mention that you just came from Doveport, and that it is not in the mood to recieve pizza anytime soon. The baker is confused by this, and you then explain that the town, for whatever reason, has been slaughtered. The color drains from his face, and he sits down. He apologizes, and closes up shop for the day." + Environment.NewLine + "Quest Complete";
                                                    ActionBox.Items.Clear();
                                                    ActionBox.SelectedIndex = -1;
                                                    player.questComplete[4] = true;
                                                    BtnContinue.Click -= Quest4Click1;
                                                    BtnContinue.Click += InsideTownContinueClick;
                                                    GameScreenMusic.StopMusic(GameScreenMusic.soundplayer);
                                                    GameScreenMusic.soundplayer = GameScreenMusic.StartMusic("Mellow");
                                                }
                                                break;
                                        }
                                    }
                                    break;
                                case 1:
                                    TbMain.Text = "As much as you enjoy Venzorian Pizza Pies, you are not a delivery service.";
                                    ActionBox.Items.Clear();
                                    ActionBox.Items.Add("Look at the Quest Board");
                                    ActionBox.SelectedIndex = 0;
                                    BtnContinue.Click -= Quest4Start;
                                    BtnContinue.Click += InsideTownContinueClick;
                                    break;
                            }
                        }
                        break;
                    case 5:     //Killer Bears
                        BtnContinue.Click += Quest5Start;
                        ActionBox.Items.Add("Hike to the north of town");
                        ActionBox.Items.Add("Ignore the requests");
                        void Quest5Start(object sender, EventArgs e)
                        {
                            switch (ActionBox.SelectedIndex)
                            {
                                case 0:
                                    TbMain.Text = "The journey into the Casadosa Mountains is not one you really wanted to go on, but considering the threat to Venzor, you see it as your civic duty to help them. After 30 minutes of walking, you finally reach the base of the mountains, and start the hike. After 25 more minutes of walking, you finally see a bear by a cave entrance.";
                                    ActionBox.Items.Clear();
                                    ActionBox.Items.Add("Approach the cave");
                                    ActionBox.Items.Add("Walk back to Venzor");
                                    ActionBox.SelectedIndex = -1;
                                    BtnContinue.Click -= Quest5Start;
                                    BtnContinue.Click += Quest5Click1;
                                    void Quest5Click1(object sender_1, EventArgs e_1)
                                    {
                                        switch (ActionBox.SelectedIndex)
                                        {
                                            case 0:
                                                TbMain.Text = "You slowly approach the cave. You scent alerts the bears to your presence, and three bears start charging at you.";
                                                ActionBox.Items.Clear();
                                                ActionBox.Items.Add("Run Away");
                                                ActionBox.Items.Add("Attack the Bears");
                                                ActionBox.SelectedIndex = -1;
                                                BtnContinue.Click -= Quest5Click1;
                                                BtnContinue.Click += Quest5Click2;
                                                void Quest5Click2 ( object sender_2, EventArgs e_2)
                                                {
                                                    switch (ActionBox.SelectedIndex)
                                                    {
                                                        case 0:
                                                            TbMain.Text = "After seeing them charge at you, the logical thing to do is to run, right? You start sprinting down the mountain and eventually make it back to Venzor. The bears, thankfully, didn't follow.";
                                                            ActionBox.Items.Clear();
                                                            ActionBox.SelectedIndex = -1;
                                                            BtnContinue.Click -= Quest5Click2;
                                                            BtnContinue.Click += OutsideTownContinueClick;
                                                            break;
                                                        case 1:
                                                            Enemy Bear1 = new Enemy("Bear", 30, -1, -1, 0, 200);
                                                            Enemy Bear2 = new Enemy("Bear", 30, -1, -1, 0, 200);
                                                            Enemy Bear3 = new Enemy("Bear", 30, -1, -1, 0, 200);
                                                            Bear1.MaxHP = 450;
                                                            Bear2.MaxHP = 450;
                                                            Bear3.MaxHP = 450;
                                                            Bear1.CurrentHP = Bear1.MaxHP;
                                                            Bear2.CurrentHP = Bear2.MaxHP;
                                                            Bear3.CurrentHP = Bear3.MaxHP;

                                                            int result = Combat(player, Bear1);
                                                            if(result != 2)
                                                                Combat(player, Bear2);
                                                            if (result != 2)
                                                                Combat(player, Bear3);
                                                            if(result != 2)
                                                            {
                                                                TbMain.Text = "You cut down the bears, and their huge bodies lay slumped in the dirt. Searching the cave, you find the remains of a few hikers, almost all of their belongings clawed and ruined. You decide to head back into the city and let them know that the bears are taken care of." + Environment.NewLine + "+30 GBP" + Environment.NewLine + "Quest Complete";
                                                                player.GBP += 30;
                                                                player.questComplete[5] = true;
                                                                ActionBox.Items.Clear();
                                                                ActionBox.SelectedIndex = -1;
                                                                BtnContinue.Click -= Quest5Click2;
                                                                BtnContinue.Click += OutsideTownContinueClick;
                                                            }
                                                            else
                                                            {
                                                                TbMain.Text = "During the battle against the bears, it suddenly dawned on you that this may not be a battle that ends happily for anyone. You run back to Venzor as fast as possible, and the bears don't follow.";
                                                                ActionBox.Items.Clear();
                                                                ActionBox.SelectedIndex = -1;
                                                                BtnContinue.Click -= Quest5Click2;
                                                                BtnContinue.Click += OutsideTownContinueClick;
                                                            }
                                                            break;
                                                    }
                                                }
                                                break;
                                            case 1:
                                                TbMain.Text = "The bears seem content, and you don't think its a good idea to disturb them right now.";
                                                ActionBox.Items.Clear();
                                                ActionBox.SelectedIndex = -1;
                                                BtnContinue.Click -= Quest5Click1;
                                                BtnContinue.Click += OutsideTownContinueClick;
                                                break;
                                        }
                                    }
                                    break;
                                case 1:
                                    TbMain.Text = "The hikers probably disturbed the bears before the bears even attacked them. Who are you to kill them for defending their home?";
                                    ActionBox.Items.Clear();
                                    ActionBox.Items.Add("Look at the Quest Board");
                                    ActionBox.SelectedIndex = 0;
                                    BtnContinue.Click -= Quest5Start;
                                    BtnContinue.Click += InsideTownContinueClick;
                                    break;
                            }
                        }
                        break;
                    case 6:     //Misplaced Love
                        BtnContinue.Click += Quest6Start;
                        ActionBox.Items.Add("Report the rumor to the guards");
                        ActionBox.Items.Add("Search for the couple");
                        ActionBox.Items.Add("Ignore the rumor");
                        void Quest6Start(object sender, EventArgs e)
                        {
                            switch (ActionBox.SelectedIndex)
                            {
                                case 0:
                                    TbMain.Text = "The guards thank you for letting them know, and the couple will be handled approproiately. The guard hands you 25 gold as a reward." + Environment.NewLine + "+25 Gold, -10 GBP" + Environment.NewLine + "Quest Complete";
                                    player.Gold += 25;
                                    player.GBP -= 10;
                                    lblPlayerGBP.Text = player.GBP.ToString();
                                    lblPlayerGold.Text = player.Gold.ToString();
                                    player.questComplete[6] = true;
                                    ActionBox.Items.Clear();
                                    ActionBox.SelectedIndex = -1;
                                    BtnContinue.Click -= Quest6Start;
                                    BtnContinue.Click += OutsideTownContinueClick;
                                    break;
                                case 1:
                                    TbMain.Text = "Asking around downtown, you find some people that help point you in the right direction. One of the young lovers works to the west, outside of the city limits. Eventually, you find one of the young lovers, as described by the citizens at his work. He seems to be an apprentice tanner.";
                                    ActionBox.Items.Clear();
                                    ActionBox.Items.Add("Talk to him");
                                    ActionBox.Items.Add("Kill Him");
                                    ActionBox.SelectedIndex = -1;
                                    BtnContinue.Click -= Quest6Start;
                                    BtnContinue.Click += Quest6Click1;
                                    void Quest6Click1(object sender_1, EventArgs e_1)
                                    {
                                        switch (ActionBox.SelectedIndex)
                                        {
                                            case 0:
                                                TbMain.Text = "You start to speak with him, and tell him to...";
                                                ActionBox.Items.Clear();
                                                ActionBox.Items.Add("Leave the noblewoman alone");
                                                ActionBox.Items.Add("Continue with the relationship");
                                                ActionBox.Items.Add("Tell you where his lover lives");
                                                ActionBox.SelectedIndex = -1;
                                                BtnContinue.Click -= Quest6Click1;
                                                BtnContinue.Click += Quest6Click2;
                                                void Quest6Click2(object sender_2, EventArgs e_2)
                                                {
                                                    switch (ActionBox.SelectedIndex)
                                                    {
                                                        case 0:
                                                            TbMain.Text = "He refuses, this is the love of his life you're talking about, and he knows it's worth it, even if he himself dies for the relationship.";
                                                            ActionBox.SelectedIndex = -1;
                                                            break;
                                                        case 1:
                                                            TbMain.Text = "He breathes a sigh of relief. While a bit confused as to why you are here just to tell him this, he is happy that you haven't killed him. You tell each other goodbye, and make you way back to town." + Environment.NewLine + "+15 GBP" + Environment.NewLine + "Quest Complete";
                                                            ActionBox.Items.Clear();
                                                            ActionBox.SelectedIndex = -1;
                                                            break;
                                                        case 2:
                                                            TbMain.Text = "He refuses at first, but eventually, he tells you where she lives. He asks you to spare her life. Eventually, you find the noblewoman's home in the city. It's quite densely populated here, with many buildings every which way; a crime here most certainly be noticed.";
                                                            ActionBox.Items.Clear();
                                                            ActionBox.Items.Add("Sneak into the house");
                                                            ActionBox.Items.Add("Knock on the door");
                                                            ActionBox.SelectedIndex = -1;
                                                            BtnContinue.Click -= Quest6Click2;
                                                            BtnContinue.Click += Quest6Click3;
                                                            void Quest6Click3(object sender_3, EventArgs e_3)
                                                            {
                                                                switch (ActionBox.SelectedIndex)
                                                                {
                                                                    case 0:
                                                                        TbMain.Text = "Looking around the outside of the house, you notice the building directly next to it may grant you access to the second floor. Luckily, that building seems to be vacant. After breaking in and climbing to the second floor, you leap across the gap to the noblewoman's house. Peering in, you see she is in her room, and she is writing letters.";
                                                                        ActionBox.Items.Clear();
                                                                        ActionBox.Items.Add("Talk to her");
                                                                        ActionBox.Items.Add("Kill her");
                                                                        ActionBox.SelectedIndex = -1;
                                                                        BtnContinue.Click -= Quest6Click3;
                                                                        BtnContinue.Click += Quest6Click4;
                                                                        void Quest6Click4(object sender_4, EventArgs e_4)
                                                                        {
                                                                            switch (ActionBox.SelectedIndex)
                                                                            {
                                                                                case 0:
                                                                                    TbMain.Text = "You walk into her room, and before you can say anything, she screams. This alerts the maid downstairs, and you can hear here coming up the stairs.";
                                                                                    ActionBox.Items.Clear();
                                                                                    ActionBox.Items.Add("Calm her down");
                                                                                    ActionBox.Items.Add("Tell her to forget the tanner");
                                                                                    ActionBox.Items.Add("Kill her");
                                                                                    ActionBox.SelectedIndex = -1;
                                                                                    BtnContinue.Click -= Quest6Click4;
                                                                                    BtnContinue.Click += Quest6Click6;
                                                                                    void Quest6Click6(object sender_5, EventArgs e_5)
                                                                                    {
                                                                                        switch (ActionBox.SelectedIndex)
                                                                                        {
                                                                                            case 0:
                                                                                                TbMain.Text = "You explain why you're here as fast as you can, in an attempt to calm her down, but to no avail. The maid comes into the room, armed with a dagger. The maid lunges at you with the dagger, and you very easily disarm her. After this, you tell the noblewoman to...";
                                                                                                ActionBox.Items.Clear();
                                                                                                ActionBox.Items.Add("Continue the relationship");
                                                                                                ActionBox.Items.Add("Stop the relationship");
                                                                                                ActionBox.SelectedIndex = -1;
                                                                                                BtnContinue.Click -= Quest6Click6;
                                                                                                BtnContinue.Click += Quest6Click7;
                                                                                                void Quest6Click7(object sender_6, EventArgs e_6)
                                                                                                {
                                                                                                    switch (ActionBox.SelectedIndex)
                                                                                                    {
                                                                                                        case 0:
                                                                                                            TbMain.Text = "In a very confusing turn of events, you tell the noblewoman that she should continue the relationship with the tanner. She seems happy that you aren't going to kill her, but is still angry that you broke into her home. With this, you go to the balcony, and jump to the vacant building. While not the most elegent solution, you seem content with the outcome." + Environment.NewLine + " + 10 GBP" + Environment.NewLine + "Quest Complete";
                                                                                                            player.GBP += 10;
                                                                                                            lblPlayerGBP.Text = player.GBP.ToString();
                                                                                                            player.questComplete[6] = true;
                                                                                                            ActionBox.Items.Clear();
                                                                                                            BtnContinue.Click -= Quest6Click7;
                                                                                                            BtnContinue.Click += OutsideTownContinueClick;
                                                                                                            break;
                                                                                                        case 1:
                                                                                                            TbMain.Text = "You politely remind the noblewoman the consequences of her actions if she chooses to continue with her relationship. This frightens the noblewoman and the maid again. And with this, you go to the balcony and jump to the vacant building. Upon further reflection, you realize you told the noblewoman what she already knew, but only after breaking into her home." + Environment.NewLine + "-3 GBP" + Environment.NewLine + "Quest Complete";
                                                                                                            player.GBP -= 3;
                                                                                                            lblPlayerGBP.Text = player.GBP.ToString();
                                                                                                            player.questComplete[6] = true;
                                                                                                            ActionBox.Items.Clear();
                                                                                                            BtnContinue.Click -= Quest6Click7;
                                                                                                            BtnContinue.Click += OutsideTownContinueClick;
                                                                                                            break;
                                                                                                    }
                                                                                                }
                                                                                                break;
                                                                                            case 1:
                                                                                                TbMain.Text = "In an attempt to end this quickly, you tell her to forget about the tanner. Hearing the maid approach, you run to the balcony and jump to the vacant building. Hopefully she forgets about the tanner, it is probably best for the both of them." + Environment.NewLine + "+5 GBP" + Environment.NewLine + "Quest Complete";
                                                                                                player.GBP += 5;
                                                                                                lblPlayerGBP.Text = player.GBP.ToString();
                                                                                                player.questComplete[6] = true;
                                                                                                ActionBox.Items.Clear();
                                                                                                BtnContinue.Click -= Quest6Click6;
                                                                                                BtnContinue.Click += OutsideTownContinueClick;
                                                                                                break;
                                                                                            case 2:
                                                                                                TbMain.Text = "Seeing no other choice, you bring out your weapon, and kill the noblewoman. In a few more seconds, the maid appears. However, by the time this happens, you are already outside running away." + Environment.NewLine + "-25 GBP" + Environment.NewLine + "Quest Complete";
                                                                                                player.GBP -= 25;
                                                                                                lblPlayerGBP.Text = player.GBP.ToString();
                                                                                                player.questComplete[6] = true;
                                                                                                ActionBox.Items.Clear();
                                                                                                BtnContinue.Click -= Quest6Click6;
                                                                                                BtnContinue.Click += OutsideTownContinueClick;
                                                                                                break;
                                                                                        }
                                                                                    }
                                                                                    break;
                                                                                case 1:
                                                                                    TbMain.Text = "As quietly as possible, you pull out your weapon, and approach the noblewoman. In just a few seconds, you change the color of her desk to a dark shade of crimson. Having finished what you came here to do, you scrounge around for some extra spending money, and then leave the way you came in. The tanner will find out about this crime, but for now, you're safe." + Environment.NewLine + "+250 Gold, -25 GBP" + Environment.NewLine + "Quest Complete";
                                                                                    player.Gold += 250;
                                                                                    player.GBP -= 25;
                                                                                    lblPlayerGold.Text = player.Gold.ToString();
                                                                                    lblPlayerGBP.Text = player.GBP.ToString();
                                                                                    player.questComplete[6] = true;
                                                                                    ActionBox.Items.Clear();
                                                                                    BtnContinue.Click -= Quest6Click4;
                                                                                    BtnContinue.Click += OutsideTownContinueClick;
                                                                                    break;
                                                                            }
                                                                        }
                                                                        break;
                                                                    case 1:
                                                                        TbMain.Text = "You approach the front door, and knock. The maid appears and asks you what business you have here.";
                                                                        ActionBox.Items.Clear();
                                                                        ActionBox.Items.Add("Ask to see the noblewoman");
                                                                        ActionBox.Items.Add("Kill her");
                                                                        ActionBox.SelectedIndex = -1;
                                                                        BtnContinue.Click -= Quest6Click3;
                                                                        BtnContinue.Click += Quest6Click5;
                                                                        void Quest6Click5(object sender_4, EventArgs e_4)
                                                                        {
                                                                            switch (ActionBox.SelectedIndex)
                                                                            {
                                                                                case 0:
                                                                                    TbMain.Text = "Politely as possible, you ask to see the head of the house. The maid asks why do you want to see the noblewoman. You reply saying its about the tannery across town. She seems to understand what this means, and walks upstairs to grab the noblewoman. When she finally comes downstairs, she greets you. You tell her to...";
                                                                                    ActionBox.Items.Clear();
                                                                                    ActionBox.Items.Add("Continue the relationship");
                                                                                    ActionBox.Items.Add("Stop the relationship");
                                                                                    ActionBox.SelectedIndex = -1;
                                                                                    BtnContinue.Click -= Quest6Click5;
                                                                                    BtnContinue.Click += Quest6Click8;
                                                                                    void Quest6Click8(object sender_5, EventArgs e_5)
                                                                                    {
                                                                                        switch (ActionBox.SelectedIndex)
                                                                                        {
                                                                                            case 0:
                                                                                                TbMain.Text = "She's happy that you support her relationship with the tanner, but she did not ask for your advice. With this, she shuts the door on you, and you walk back to the center of the city." + Environment.NewLine + "+15 GBP" + Environment.NewLine + "Quest Complete";
                                                                                                ActionBox.Items.Clear();
                                                                                                player.GBP += 15;
                                                                                                lblGBP.Text = player.GBP.ToString();
                                                                                                player.questComplete[6] = true;
                                                                                                ActionBox.Items.Clear();
                                                                                                BtnContinue.Click -= Quest6Click8;
                                                                                                BtnContinue.Click += OutsideTownContinueClick;
                                                                                                break;
                                                                                            case 1:
                                                                                                TbMain.Text = "She is clearly saddened by the thought of ending the relationship with the tanner, but knows it's probably the safest for the two of them. She thanks you for your time, and shuts the door, and you walk back to the center of the city." + Environment.NewLine + "+15 GBP" + Environment.NewLine + "Quest Complete";
                                                                                                ActionBox.Items.Clear();
                                                                                                player.GBP += 15;
                                                                                                lblGBP.Text = player.GBP.ToString();
                                                                                                player.questComplete[6] = true;
                                                                                                ActionBox.Items.Clear();
                                                                                                BtnContinue.Click -= Quest6Click8;
                                                                                                BtnContinue.Click += OutsideTownContinueClick;
                                                                                                break;
                                                                                        }
                                                                                    }
                                                                                    break;
                                                                                case 1:
                                                                                    TbMain.Text = "Pulling out your weapon, you stab and cover her mouth at the same time. However, as you are in the front door, facing a fairly busy street, someone sees this happen, and screams. Your cover is blown, and you are confronted by Fallholtian guards.";
                                                                                    Enemy Guard1 = new Enemy("Guard", 20, -1, 4, 20, 50);
                                                                                    Enemy Guard2 = new Enemy("Guard", 20, -1, 4, 30, 75);
                                                                                    Enemy Guard3 = new Enemy("Guard", 20, -1, 4, 40, 90);
                                                                                    BtnContinue.Click -= Quest6Click5;
                                                                                    BtnContinue.Click += Quest6Click9;
                                                                                    ActionBox.Items.Clear();
                                                                                    ActionBox.Items.Add("Enter combat");
                                                                                    ActionBox.SelectedIndex = 0;
                                                                                    void Quest6Click9(object sender_5, EventArgs e_5)
                                                                                    {
                                                                                        BtnContinue.Click -= Quest6Click9;
                                                                                        int result = Combat(player, Guard1);
                                                                                        if (result != 2)
                                                                                            result = Combat(player, Guard2);
                                                                                        if (result != 2)
                                                                                            result = Combat(player, Guard3);
                                                                                        if(result != 2)
                                                                                        {
                                                                                            TbMain.Text = "After killing the guards, you run from the scene of the crime. Hopefully the noblewoman learns a valuable lesson from this." + Environment.NewLine + "-50 GBP" + Environment.NewLine + "Quest Complete"; ;
                                                                                            player.GBP -= 50;
                                                                                            lblPlayerGBP.Text = player.GBP.ToString();
                                                                                            player.questComplete[6] = true;
                                                                                            ActionBox.Items.Clear();
                                                                                            ActionBox.SelectedIndex = -1;
                                                                                            BtnContinue.Click += OutsideTownContinueClick;
                                                                                        }
                                                                                        else
                                                                                        {
                                                                                            TbMain.Text = "After seeing more guards round the corner, you figure its time to leave. You push the guard you were locked in combat with to the ground, and head in a dead sprint to the outskirts of town, and lay low for a day or two. Hopefully the noblewoman has learned something from this." + Environment.NewLine + "-40 GBP" + Environment.NewLine + "Quest Complete"; ;
                                                                                            player.GBP -= 40;
                                                                                            lblPlayerGBP.Text = player.GBP.ToString();
                                                                                            player.questComplete[6] = true;
                                                                                            ActionBox.Items.Clear();
                                                                                            ActionBox.SelectedIndex = -1;
                                                                                            BtnContinue.Click += OutsideTownContinueClick;
                                                                                        }
                                                                                    }
                                                                                    break;
                                                                            }
                                                                        }
                                                                        break;
                                                                }
                                                            }
                                                            break;
                                                    }
                                                }
                                                break;
                                            case 1:
                                                TbMain.Text = "You pull out your weapon, and the young tanner is obviously frightened by this. He stops curing the animal skins to bring out his dagger. However, in his haste to pull out his dagger, he lets go and flings it across the room. Seeing an opportunity to teach him a lesson, you strike quickly. The noblewoman should have know better than this, but you have done the noblewoman a favor. You walk back into the city." + Environment.NewLine + "-25 GBP" + Environment.NewLine + "Quest Complete";
                                                player.GBP -= 25;
                                                lblPlayerGBP.Text = player.GBP.ToString();
                                                player.questComplete[6] = true;
                                                ActionBox.Items.Clear();
                                                ActionBox.SelectedIndex = -1;
                                                BtnContinue.Click -= Quest6Click1;
                                                BtnContinue.Click += OutsideTownContinueClick;
                                                break;
                                        }
                                    }
                                    break;
                                case 2:
                                    TbMain.Text = "The last thing you want to do is spend time looking into a rumor.";
                                    ActionBox.Items.Clear();
                                    ActionBox.Items.Add("Look at the Quest Board");
                                    ActionBox.SelectedIndex = 0;
                                    BtnContinue.Click -= Quest6Start;
                                    BtnContinue.Click += InsideTownContinueClick;
                                    break;
                            }
                        }
                        break;
                    case 7:     //Armado De Santo
                        BtnContinue.Click += Quest7Start;
                        ActionBox.Items.Add("Search for Armando De Santo");
                        ActionBox.Items.Add("Ignore the poster");
                        void Quest7Start(object sender, EventArgs e)
                        {
                            switch (ActionBox.SelectedIndex)
                            {
                                case 0:
                                    TbMain.Text = "2500 is quite the sum of gold, you decide it is worth looking into. Searching for a criminial on the run is not an easy task, but you figure that it can't be that hard. After over six days of working with the local bounty hunters and guards, you eventually track De Santo back to Lancaster. You and a team of well equipped bounty hunters take to the road to apprehend De Santo. Just as you learned back in Fallholt, De Santo and a couple of his lackeys have holed up in a barn outside of Lancaster, not too far from your own family farm. You and your team approach the barn, and begin the attack.";
                                    ActionBox.Items.Clear();
                                    ActionBox.Items.Add("Find and Apprehend De Santo");
                                    ActionBox.SelectedIndex = 0;
                                    BtnContinue.Click -= Quest7Start;
                                    BtnContinue.Click += Quest7Click1;
                                    void Quest7Click1(object sender_1, EventArgs e_1)
                                    {
                                        Enemy lackey1 = new Enemy("Lackey", 20, -1, 4, 20, 20);
                                        Enemy lackey2 = new Enemy("Lackey", 24, -1, 4, 20, 20);
                                        Enemy lackey3 = new Enemy("Lackey", 26, -1, 4, 20 ,20);
                                        Enemy Armando = new Enemy("Armando", 29, -1, 5, 20, 20);
                                        int result = Combat(player, lackey1);
                                        if(result != 2)
                                            result = Combat(player, lackey2);
                                        if (result != 2)
                                            result = Combat(player, lackey3);
                                        if (result != 2)
                                            result = Combat(player, Armando);
                                        if (result != 2)
                                        {
                                            TbMain.Text = "After a long and arduous battle, De Santo lays dead on the ground. Numerous other bodies lay dead, including one of your teammates. However, the menace that has been Armando has finally been silenced. The team takes everything they can from the barn, which was about 500 gold, and splits it evenly between the four of you. After telling the guards that Armando has been slain, the guards also give your team the reward, which is split up evenly." + Environment.NewLine + "+750 Gold, +100 GBP" + Environment.NewLine + "Quest Complete";
                                            ActionBox.Items.Clear();
                                            ActionBox.SelectedIndex = -1;
                                            player.progress = 1;
                                            player.questComplete[7] = true;
                                            player.Gold += 750;
                                            player.GBP += 100;
                                            lblPlayerGold.Text = player.Gold.ToString();
                                            lblPlayerGBP.Text = player.GBP.ToString();
                                            BtnContinue.Click -= Quest7Click1;
                                            BtnContinue.Click += OutsideTownContinueClick;
                                        }
                                        else
                                        {
                                            TbMain.Text = "Looking around you, you see that this is a losing battle. You rally whats left of the team, and run back into town. Knowing that their location has been compromised, Armando and his gang are sure to relocate, and who knows where they'll go this time..." + Environment.NewLine + "Quest Complete";
                                            ActionBox.Items.Clear();
                                            ActionBox.SelectedIndex = -1;
                                            player.progress = 1;
                                            player.questComplete[7] = true;
                                            BtnContinue.Click -= Quest7Click1;
                                            BtnContinue.Click += OutsideTownContinueClick;
                                        }
                                    }
                                    break;
                                case 1:
                                    TbMain.Text = "Now is not the time for bounty hunting anyway.";
                                    ActionBox.Items.Clear();
                                    ActionBox.Items.Add("Look at the Quest Board");
                                    ActionBox.SelectedIndex = 0;
                                    BtnContinue.Click -= Quest7Start;
                                    BtnContinue.Click += InsideTownContinueClick;
                                    break;
                            }
                        }
                        break;
                }
            }
        }

        public void RoyalPalace()
        {
            BtnContinue.Click -= OutsideTownContinueClick;
            BtnContinue.Click += RPClick1;
            ActionBox.Items.Clear();
            ActionBox.Items.Add("Battle");
            ActionBox.SelectedIndex = 0;
            lblLoc.Text = "Royal Palace";
            TbMain.Text = "You have geared up, gained some cash, and are ready to remove the threat to your family." + Environment.NewLine + "You'll have to fight your way through to the king. Do you still have the strength to manage? Before you can answer this question, 3 royal knights run at you and begin an attack.";

            void RPClick1(object sender, EventArgs e)
            {
                Enemy knight1 = new Enemy("Knight", 18, 1, 1, 0, 0);
                if (Combat(player, knight1) != 2)
                {
                    Enemy knight2 = new Enemy("Knight", 18, 1, 2, 0, 0);
                    if (Combat(player, knight2) != 2)
                    {
                        Enemy knight3 = new Enemy("Knight", 18, 2, 2, 0, 0);
                        if (Combat(player, knight3) != 2)
                        {
                            TbMain.Text = "After slaying the three knights, you have arrive at the throne room. Inside you see the king and his royal protector. The king glances at you and speaks." + Environment.NewLine + "'You've made it this far, but I'm afriad this is where your journey ends.'";
                            BtnContinue.Click -= RPClick1;
                            BtnContinue.Click += RPClick2;
                            ActionBox.Items.Clear();
                            ActionBox.SelectedIndex = -1;
                            void RPClick2(object sender_1, EventArgs e_1)
                            {
                                if (player.GBP >= 0)
                                {
                                    TbMain.Text = "'Since you have fought honorably in my kingdom, I shall fight you myself.'" + Environment.NewLine + "Strike against the king and carve your legacy in stone!";
                                    BtnContinue.Click -= RPClick2;
                                    BtnContinue.Click += RPClick3;
                                    void RPClick3(object sender_2, EventArgs e_2)
                                    {
                                        Enemy king = new Enemy("King", 29, 29, 5, 250, 250);
                                        king.CurrentHP = king.MaxHP = 250;

                                        if (Combat(player, king) != 2)
                                        {
                                            TbMain.Text = "You have done it! You have defeated the king and can rule in his stead." + Environment.NewLine + "How will you rule over the people? Will you maintain your honor and generosity, or will you make them pay in blood for the genocide of the Vanins?";
                                            BtnContinue.Click -= RPClick3;
                                            BtnContinue.Click += RPClick4;
                                            ActionBox.Items.Add("The End");
                                            ActionBox.SelectedIndex = 0;
                                            void RPClick4(object sender_3, EventArgs e_3)
                                            {
                                                MessageBox.Show("Thank you for playing!");
                                                Application.Restart();
                                            }
                                        }
                                        else
                                        {
                                            TbMain.Text = "The king was too strong for you to battle and win. You run out of the throne room, having failed the Vanins and your family.";
                                            BtnContinue.Click -= RPClick3;
                                            BtnContinue.Click += RPClick5;
                                            ActionBox.Items.Add("The End");
                                            ActionBox.SelectedIndex = 0;
                                            void RPClick5 (object sender_3, EventArgs e_3)
                                            {
                                                MessageBox.Show("Thank you for playing!");
                                                Application.Restart();
                                            }
                                        }
                                    }
                                }
                                else if (player.GBP < 0)
                                {
                                    TbMain.Text = "'You are nothing but scum. I will not give you the gift of fighting me. Royal Protector, Remove him.'";
                                    BtnContinue.Click -= RPClick2;
                                    BtnContinue.Click += RPClick6;
                                    void RPClick6(object sender_2, EventArgs e_2)
                                    {
                                        Enemy royalProtector = new Enemy("Royal Protector", 29, 29, 5, 250, 250);
                                        if (Combat(player, royalProtector) != 2)
                                        {
                                            TbMain.Text = "You have vanquished the royal protector as the king ran away in fear. You can take the crown by force and rule over the people." + Environment.NewLine + "How will you rule over the people? Will your thirst for blood cloud your judgement, or will you bring peace to the land?";
                                        }
                                        else
                                        {
                                            MessageBox.Show("In the final moments, you couldn't kill the royal protector, and ran away. Game over.");
                                        }
                                        BtnContinue.Click -= RPClick6;
                                        BtnContinue.Click += RPClick7;
                                        void RPClick7(object sender_3, EventArgs e_3)
                                        {
                                            MessageBox.Show("Thank you for playing!");
                                            Application.Restart();
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            //ran away fighting the protector
                            MessageBox.Show("You ran away during the fight. Game over.");
                            Application.Restart();
                        }
                    }
                    else
                    {
                        //ran away fighting the knight
                        MessageBox.Show("You ran away during the fight. Game over.");
                        Application.Restart();
                    }

                }
                else
                {
                    //ran away on fighting the noble
                    MessageBox.Show("You ran away during the fight. Game over.");
                    Application.Restart();
                }
            }
        }

        public void Wilderness( int difficulty )
        {
            Random rand = new Random();
            int type = rand.Next(0,3); // 0 Magic enemy, 1 Melee enemy, 2 both
            int setEnemySword = rand.Next(difficulty, 3 * difficulty);
            if (setEnemySword > 29)
                setEnemySword = 29;
            int setEnemyStaff = rand.Next(difficulty, 3 * difficulty);
            if (setEnemyStaff > 29)
                setEnemyStaff = 29;
            int setEnemyArmor = difficulty;
            if (setEnemyArmor > 4)
                setEnemyArmor = 4;

            switch (type)
            {
                case 0:
                    setEnemySword = -1;
                    break;
                case 1:
                    setEnemyStaff = -1;
                    break;
            }


            Enemy enemy = new Enemy("Bandit", setEnemySword, setEnemyStaff, setEnemyArmor, 30 + (difficulty * 5) + rand.Next(0,10), 30 + (difficulty * 5) + rand.Next(0, 10));

            lblLoc.Text = "Wilderness";
            int result = Combat(player, enemy);
            if (result == 1)
            {
                TbMain.Text = "You traversed through the wilderness, defeated a foe, and are now in sight of a town.";
            }
            else if ( result == 2 )
                TbMain.Text = "You ran away from the enemy, and manage to make it to the next town.";
            else
                TbMain.Text = "The foe encountered in the wilderness has defeated you but spared your life. You hang your head low whilst walking towards the nearest town.";

            if (player.Direction)  //true = fowards, false = backwards
                player.progress++;
            else
                player.progress--;
        }

        public int Combat(Player player, Enemy enemy)
        {
            GameScreenMusic.StopMusic(GameScreenMusic.soundplayer);
            Music CombatMusic = new Music();
            CombatMusic.soundplayer = CombatMusic.StartMusic("Battle");
            Hide();
            CombatForm combatF = new CombatForm();
            int result = combatF.StartCombat(player, enemy);
            CombatMusic.StopMusic(CombatMusic.soundplayer);
            if (result == 0)
            {
                GameScreenMusic.soundplayer = GameScreenMusic.StartMusic("GameOver");
                MessageBox.Show("You have died, Game Over.");
                Application.Restart();
            }
            else if (result == 1 || result == 2)
            {
                Show();
                GameScreenMusic.soundplayer = GameScreenMusic.StartMusic("Mellow");
            }
            if(player.XP >= player.MaxXP)
            {
                Levelup();
            }
            progressBarXP.Maximum = player.MaxXP;
            progressBarXP.Value = player.XP;
            return result;
        }

        public void Store(Player player, int townID, int storeType)
        {
            Hide();
            StoreForm Store = new StoreForm();
            Store.EnterStore(player, townID, storeType);
            DialogResult = Store.ShowDialog();
            lblEquippedSword.Text = player.sword.Name.ToString();
            lblEquippedStaff.Text = player.staff.Name.ToString();
            lblEquippedArmor.Text = player.armor.Name.ToString();
            Show();
        }

        public void Levelup()
        {
            player.Level++;
            player.XP -= player.MaxXP;
            switch (player.Level)
            {
                case 1:
                    player.MaxXP = 100;
                    break;
                case 2:
                    player.MaxXP = 400;
                    break;
                case 3:
                    player.MaxXP = 900;
                    break;
                case 4:
                    player.MaxXP = 1600;
                    break;
                case 5:
                    player.MaxXP = 2500;
                    break;
                case 6:
                    player.MaxXP = 3600;
                    break;
                case 7:
                    player.MaxXP = 4900;
                    break;
                case 8:
                    player.MaxXP = 6400;
                    break;
                case 9:
                    player.MaxXP = 8100;
                    break;
                case 10:
                    player.MaxXP = 10000;
                    break;
                case 11:
                    player.MaxXP = 12100;
                    break;
                case 12:
                    player.MaxXP = 14400;
                    break;
                case 13:
                    player.MaxXP = 16900;
                    break;
                case 14:
                    player.MaxXP = 19600;
                    break;
                case 15:
                    player.MaxXP = 22500;
                    break;
                case 16:
                    player.MaxXP = 25600;
                    break;
                case 17:
                    player.MaxXP = 28900;
                    break;
                case 18:
                    player.MaxXP = 32400;
                    break;
                case 19:
                    player.MaxXP = 36100;
                    break;
                default:
                    player.MaxXP = 40000;
                    break;
            }
            player.Level++;
            Hide();
            LevelUpForm LevelUp = new LevelUpForm();
            if (LevelUp.ShowDialog(this) == DialogResult.OK)
            {
                switch (LevelUp.increasedStat)
                {
                    case 1:
                        player.MaxHP += 5;
                        break;
                    case 2:
                        player.Strength += 1;
                        break;
                    case 3:
                        player.Intellect += 1;
                        break;
                    case 4:
                        player.AP += 1;
                        break;
                    case 5:
                        player.MR += 1;
                        break;
                }
            }
            LevelUp.Dispose();
            Show();
        }

        private void listBoxPlayerInventory_DataSourceChanged(object sender, EventArgs e)
        {
            listBoxPlayerInventory.DataSource = null;
            listBoxPlayerInventory.DataSource = player.Inventory;
        }

        public static void WriteXML(Player player, string SaveFileName)
        {
            string pathString = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/Wrath Of The Ruined";
            System.IO.Directory.CreateDirectory(pathString);
            Type[] extratypes = new Type[1];
            extratypes[0] = typeof(Consumable);
            System.Xml.Serialization.XmlSerializer writer =
                new System.Xml.Serialization.XmlSerializer(typeof(Player), extratypes);

            var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/Wrath Of The Ruined//" + SaveFileName + ".xml";
            System.IO.FileStream file = System.IO.File.Create(path);

            writer.Serialize(file, player);
            file.Close();
        }

        private void BtnSaveGame_Click(object sender, EventArgs e)
        {
            InputForm NameInput = new InputForm("Enter Save File Name:");

            if (NameInput.ShowDialog(this) == DialogResult.OK)
            {
                // Read the contents of testDialog's TextBox.
                string filename = NameInput.PlayerNameInputBox.Text;
                WriteXML(player, filename);
            }
            NameInput.Dispose();
        }
    }
}
