using Engine;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace WrathOfTheRuined
{
    public partial class GameScreen : Form
    {
        private Player player;
        private Quest quests;
        public int progress = 0;
        public int townLoc = 0;             //Used to track where you are in town. 0 = Town Square, 1 = Questboard, 2 = Leaving town
        public int path = 0;
        public bool[] townSlaughtered = new bool[4];  //Array tracking which towns are slaughtered. townID matched the array.
        public bool[] questsComplete = new bool[8];   //Array tracking which quests are complete. questID matches the array.

        Music GameScreenMusic = new Music();

        public GameScreen()
        {
            InitializeComponent();
            player = new Player(1, 1, 1, 1);
            quests = new Quest();


            GetNameInput();
            GameScreenMusic.soundplayer = GameScreenMusic.StartMusic("Mellow");
            //actual game code
            TbMain.Text = "Hello " + player.Name + ". You have been asleep for a long time. Have you forgotten who you are? You are a proud member of the Vanin race. I hope you know how to survive." + Environment.NewLine +
            "You awake after a year long hibernation. While it is not unusual for a Vanin to have long slumber periods, a year is unheard of." + Environment.NewLine +
            "Your family is huddled around you, amazed that you have awoken. They break the news that the rest of the Vanins have been slaughtered by order of the King. " + Environment.NewLine +
            "Your kind was feared because of the immense potential you hold. Your race has the ability to absorb part of the skill and wisdom from those you defeat. After several horrific wars, your kind has learned to live peacefully with Humans.";
            TbMain.AppendText(Environment.NewLine + Environment.NewLine + "Or so you thought.");
            TbMain.AppendText(Environment.NewLine + Environment.NewLine + "(Press Continue)");
        }

        private void Game_Load(object sender, EventArgs e)
        {
            lblXP.Text = "XP:" + player.ExperiencePoints.ToString();
            lblGold.Text = "Gold:" + player.Gold.ToString();
            lblGBP.Text = "GBP:" + player.GBP.ToString();
            lblLoc.Text = "Wilderness";
            //lblLoc.Hide();
        }

        public void GetNameInput()
        {
            InputForm NameInput = new InputForm();

            // Show testDialog as a modal dialog and determine if DialogResult = OK.
            if (NameInput.ShowDialog(this) == DialogResult.OK)
            {
                // Read the contents of testDialog's TextBox.
                this.player.Name = NameInput.PlayerNameInputBox.Text;
            }
            NameInput.Dispose();
        }

        private void Game_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void OutsideTownContinueClick(object sender, EventArgs e)
        {
            switch (progress)
            {
                case 0:
                    GameTutorial();
                    break;
                case 1:
                    Town(0);
                    break;
                case 2:
                    Wilderness(0);
                    break;
                case 3:
                    Town(1);
                    break;
                case 4:
                    Wilderness(2);
                    break;
                case 5:
                    Town(2);
                    break;
                case 6:
                    Wilderness(4);
                    break;
                case 7:
                    Town(3);
                    break;
                case 8:
                    RoyalPalace();
                    break;
            }
        }

        public int Combat(Player player, Creature enemy)
        {
            CombatForm combatF = new CombatForm();
            GameScreenMusic.StopMusic(GameScreenMusic.soundplayer);
            Music CombatMusic = new Music();
            CombatMusic.soundplayer = CombatMusic.StartMusic("Battle");
            Random rng = new Random();

            player.stance.ChangeStance(player, 2);
            enemy.stance.ChangeStance(enemy, 2);

            MessageBox.Show("An enemy approaches, you draw your weapon...");
            CombatRefresh();

            combatF.CbPlayerCombat.Items.Add("1. Attack");
            combatF.CbPlayerCombat.Items.Add("2. Change Stance");
            combatF.CbPlayerCombat.Items.Add("3. Magic");
            combatF.CbPlayerCombat.Items.Add("4. Use Item");
            combatF.CbPlayerCombat.Items.Add("5. Run Away");

            while (player.currentHealth > 0 && enemy.currentHealth > 0)
            {
                if (combatF.ShowDialog() == DialogResult.OK)
                {
                    fight();
                    CombatRefresh();
                    if (combatF.CbPlayerCombat.SelectedIndex == 4)
                    {
                        CombatMusic.StopMusic(CombatMusic.soundplayer);
                        GameScreenMusic.soundplayer = GameScreenMusic.StartMusic("Mellow");
                        return 2;
                    }
                }
                if (player.currentHealth > 0 && enemy.currentHealth <= 0)
                {
                    player.currentHealth = player.Health;
                    player.Gold += enemy.GoldDrop;
                    player.Strength +=  (enemy.Strength / 5);
                    player.Intellect += (enemy.Intellect / 5);
                    lblGold.Text = "Gold: " + player.Gold.ToString();
                    CombatMusic.StopMusic(CombatMusic.soundplayer);
                    GameScreenMusic.soundplayer = GameScreenMusic.StartMusic("Mellow");
                    return 1;
                }
                else if (player.currentHealth <= 0 && enemy.currentHealth > 0)
                {
                    CombatMusic.StopMusic(CombatMusic.soundplayer);
                    GameScreenMusic.soundplayer = GameScreenMusic.StartMusic("GameOver");
                    MessageBox.Show("Game Over!");
                    Application.Exit();
                    return 0;
                }
            }
            return -1; //Error if this is returned


            void fight()
            {
                if (player.currentHealth > 0 && enemy.currentHealth > 0)
                {
                    if (combatF.CbPlayerCombat.SelectedIndex == 0)
                    {
                        enemy.currentHealth = enemy.currentHealth - Convert.ToInt32(Math.Round(player.stance.stanceDMG * (100 - enemy.stance.totalArmor) * .01));
                    }
                    else if (combatF.CbPlayerCombat.SelectedIndex == 1)
                    {
                        Change_Stance();
                    }
                    else if (combatF.CbPlayerCombat.SelectedIndex == 2)
                    {
                        enemy.currentHealth = enemy.currentHealth - Convert.ToInt32(Math.Round(player.stance.stanceMGK * (100 - enemy.stance.totalMR) * .01));
                    }
                    else if (combatF.CbPlayerCombat.SelectedIndex == 3)
                    {
                        MessageBox.Show("WIP :(");
                    }
                    else if (combatF.CbPlayerCombat.SelectedIndex == 4)
                    {
                        MessageBox.Show("Only Cowards run away!");
                        int GoldLost = rng.Next(1, 15);
                        MessageBox.Show("As you ran away you dropped " + GoldLost + " Gold.");
                        player.Gold -= GoldLost;
                        lblGold.Text = "Gold: " + player.Gold.ToString();
                        player.currentHealth = player.Health;
                    }
                }
                
                                    
                
                if (enemy.currentHealth > 0 && (combatF.CbPlayerCombat.SelectedIndex == 0 || combatF.CbPlayerCombat.SelectedIndex == 2 ) )
                {
                    if (player.stance.stanceNum == 3)
                    {
                        if (player.Endurance >= 10)
                            player.Endurance -= 10;
                        player.stance.ChangeStance(player, player.stance.stanceNum);
                    }
                    if (player.stance.stanceNum == 1)
                    {
                        if (player.Endurance <= 90)
                            player.Endurance += 10;
                        player.stance.ChangeStance(player, player.stance.stanceNum);
                    }
                    player.currentHealth = player.currentHealth - Convert.ToInt32(Math.Round((enemy.stance.stanceDMG * (100 - player.stance.totalArmor) * .01)));
                    enemy.stance.ChangeStance(enemy, rng.Next(1, 4));
                }
                
                return;
            }

            void CombatRefresh()
            {
                combatF.lblPlayerArmor.Text = player.AP.ToString();
                combatF.lblPlayerDamage.Text = player.PDamage.ToString();
                combatF.lblPlayerHealth.Text = player.currentHealth.ToString();
                combatF.lblEnemyHealth.Text = enemy.currentHealth.ToString();
                combatF.lblEnemyDamage.Text = enemy.PDamage.ToString();
                combatF.lblEnemyArmor.Text = enemy.AP.ToString();
                combatF.lblEnemyStance.Text = enemy.stance.stanceName;
                combatF.lblPlayerStance.Text = player.stance.stanceName;
            }

            void Change_Stance()
            {
                ChangeStanceForm ChangeStance = new ChangeStanceForm();
                if (ChangeStance.ShowDialog(this) == DialogResult.OK)
                {
                    if (ChangeStance.stanceChange == 1)
                        player.stance.ChangeStance(player, 1);
                    else if (ChangeStance.stanceChange == 2)
                        player.stance.ChangeStance(player, 2);
                    else if (ChangeStance.stanceChange == 3)
                        player.stance.ChangeStance(player, 3);
                }
                ChangeStance.Dispose();
            }

            
        }

        public void GameTutorial()
        {
            MessageBox.Show("Welcome to Wrath of the Ruined. This is a tutorial to teach you the basics of of the game.", "Tutorial");
            lblXP.BackColor = Color.GreenYellow;
            lblGold.BackColor = Color.Gold;
            lblGBP.BackColor = Color.SkyBlue;
            MessageBox.Show("Highlighted in Green is your XP counter. As you progress you will gain XP." + Environment.NewLine +
                Environment.NewLine + "Yellow is your amount of Gold. You can use gold to buy items from shops in towns." + Environment.NewLine +
                Environment.NewLine + "Blue is your Good Boy Points counter. The more Good Boy Points you have, the more honorable you are.", "Tutorial");
            lblXP.BackColor = Color.Transparent;
            lblGold.BackColor = Color.Transparent;
            lblGBP.BackColor = Color.Transparent;
            lblLoc.BackColor = Color.Red;
            MessageBox.Show("Highlighted in Red is your current location.", "Tutorial");
            lblLoc.BackColor = Color.Transparent;
            TbMain.Text = "You are walking in the wilderness and an enemy approaches." + Environment.NewLine + "You draw your weapon";
            Creature enemy = new Creature(1, 0, 0, 0);
            Combat(player, enemy);
            progress++;
            TbMain.Text = "Will you protect your family, or will you tremble as your cowardess takes hold of you?" + Environment.NewLine +
                "You arm yourself with what scraps your family has left and you head off to the first town Lancaster. Do you help the locals out of the kindness of your heart, or for power and money?" + Environment.NewLine;
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
                switch (ActionBox.SelectedIndex)
                {
                    case 0:
                        BtnContinue.Click -= InsideTownContinueClick;
                        BtnContinue.Click += QuestBoardContinueClick;

                        TbMain.Text = "You check out the quest board.";

                        ActionBox.Items.Clear();
                        ActionBox.Items.Add(Town.quest1.name);
                        ActionBox.Items.Add(Town.quest2.name);
                        ActionBox.Items.Add("Leave Quest Board");
                        break;
                    case 1:
                        TbMain.Text = "Seems like the blacksmith isn't here right now.";
                        ActionBox.Items.Clear();
                        ActionBox.SelectedIndex = -1;
                        break;
                    case 2:
                        TbMain.Text = "You decide to slaughter the town.";
                        ActionBox.Items.Clear();
                        ActionBox.SelectedIndex = -1;
                        break;
                    case 3:
                        TbMain.Text = Town.departureString;
                        ActionBox.Items.Clear();
                        ActionBox.SelectedIndex = -1;
                        progress++;
                        BtnContinue.Click -= InsideTownContinueClick;
                        BtnContinue.Click += OutsideTownContinueClick;
                        break;
                    default:
                        lblXP.Text = "XP:" + player.ExperiencePoints.ToString();
                        lblGold.Text = "Gold:" + player.Gold.ToString();
                        lblGBP.Text = "GBP:" + player.GBP.ToString();
                        lblLoc.Text = Town.name;
                        TbMain.Text = "You are standing in the " + Town.descriptor + " of " + Town.name + ".";

                        ActionBox.Items.Clear();
                        ActionBox.Items.Add("Check Quest Board");
                        ActionBox.Items.Add("Visit the blacksmith");
                        ActionBox.Items.Add("Slaughter everyone");
                        ActionBox.Items.Add("Leave");
                        break;
                }
            }

            void QuestBoardContinueClick(object sender, EventArgs e)

            {
                switch (ActionBox.SelectedIndex)
                {
                    case 0:
                        if(!questsComplete[Town.quest1.ID])
                        {
                            TbMain.Text = Town.quest1.startString;
                            ActionBox.Items.Clear();
                            BtnContinue.Click -= QuestBoardContinueClick;
                            ActionBox.SelectedIndex = -1;
                            StartQuest(Town.quest1.ID);
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
                        if (!questsComplete[Town.quest2.ID])
                        {
                            TbMain.Text = Town.quest2.startString;
                            ActionBox.Items.Clear();
                            BtnContinue.Click -= QuestBoardContinueClick;
                            ActionBox.SelectedIndex = -1;
                            StartQuest(Town.quest2.ID);
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
                        TbMain.Text = "You decide to leave the quest board, and walk back to center of this " + Town.descriptor + ".";
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
                                                questsComplete[0] = true;
                                                player.Gold += 10;
                                                player.GBP += 5;
                                                BtnContinue.Click -= Quest0Click1;
                                                BtnContinue.Click += InsideTownContinueClick;
                                                break;
                                            case 1:
                                                TbMain.Text = "You pull out your sword, and strike the dog right on his head, killing it nearly instantly." + Environment.NewLine + "-5 GBP" + Environment.NewLine + "Quest Complete";
                                                ActionBox.Items.Clear();
                                                ActionBox.SelectedIndex = -1;
                                                questsComplete[0] = true;
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
                                                questsComplete[0] = true;
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
                                                questsComplete[1] = true;
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
                                                            questsComplete[1] = true;
                                                            player.GBP += 3;
                                                            BtnContinue.Click -= Quest1Click2;
                                                            BtnContinue.Click += InsideTownContinueClick;
                                                            break;
                                                        case 1:
                                                            TbMain.Text = "The father looks at you quizzically, but shortly thereafter, seems to realize that you must have put in some time into searching for the stuffed animal. He pulls out a coin pouch, takes out five gold pieces, and hands them over. You then hand over the teddy bear to the father. He then hands his daughter the teddy bear and you can see she is happy to be reunited, despite the poor shape that the teddy bear is in." + Environment.NewLine + "+5 Gold, +1 GBP" + Environment.NewLine + "Quest Complete";
                                                            ActionBox.Items.Clear();
                                                            ActionBox.SelectedIndex = -1;
                                                            questsComplete[1] = true;
                                                            player.GBP += 1;
                                                            player.Gold += 5;
                                                            BtnContinue.Click -= Quest1Click2;
                                                            BtnContinue.Click += InsideTownContinueClick;
                                                            break;
                                                        case 2:
                                                            TbMain.Text = "After seeing the father and his daughter, you realize the father seems to spoil his daughter, and you reconsider giving the teddy bear back. The father looks appaulled that you even bothered to come back at all. He walks his daughter back into the house, trying to explain to her what just happened. You hope she learned a valuable lesson." + Environment.NewLine + "-4 GBP" + Environment.NewLine + "Quest Complete";
                                                            ActionBox.Items.Clear();
                                                            ActionBox.SelectedIndex = -1;
                                                            questsComplete[1] = true;
                                                            player.GBP -= 4;
                                                            BtnContinue.Click -= Quest1Click2;
                                                            BtnContinue.Click += InsideTownContinueClick;
                                                            break;
                                                        case 3:
                                                            TbMain.Text = "After meeting the father, you can tell what kind of scum he is. His daughter is clearly spoiled, and you know the town would be better off without these two in it. As you pull out your sword, the father screams in fear, but the screams fall on deaf ears." + Environment.NewLine + Environment.NewLine + "The child had no gold, but the father had some, he certainly won't be needing it anytime soon. You leave the house, knowing there is very little time before someone finds the bodies." + Environment.NewLine + "+75 Gold, -25 GPB" + Environment.NewLine + "Quest Complete";
                                                            ActionBox.Items.Clear();
                                                            ActionBox.SelectedIndex = -1;
                                                            questsComplete[1] = true;
                                                            player.Gold += 75;
                                                            player.GBP -= 25;
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
                                                            BtnContinue.Click -= Quest2Click1;
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
                                                                                    TbMain.Text = "";
                                                                                    break;
                                                                                case 1:
                                                                                    TbMain.Text = "";
                                                                                    break;
                                                                                case 2:
                                                                                    BtnContinue.Click -= Quest2Click5;
                                                                                    BtnContinue.Click += Quest2Click3;
                                                                                    ActionBox.SelectedIndex = 1;
                                                                                    BtnContinue.PerformClick();
                                                                                    break;
                                                                            }
                                                                        }
                                                                                    break;
                                                                    case 1:
                                                                        break;
                                                                }
                                                            }
                                                            break;
                                                        case 1:
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
                                    break;
                                case 1:
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
                    case 7:     //Wire Fraud
                        BtnContinue.Click += Quest7Start;
                        ActionBox.Items.Add("Search for Armando De Santo");
                        ActionBox.Items.Add("Ignore the poster");
                        void Quest7Start(object sender, EventArgs e)
                        {
                            switch (ActionBox.SelectedIndex)
                            {
                                case 0:
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
            ActionBox.SelectedIndex = -1;
            
            lblLoc.Text = "Royal Palace";

            TbMain.Text = "The time is now. You have geared up, gained some cash, and are ready to remove the threat to your family." + Environment.NewLine + "You'll have to fight your way through to the king. Do you still have the strength to manage?";

            Creature noble = new Creature(1, 1, 1, 1);
            if(Combat(player, noble) != 1)
            {
                TbMain.Text = "You have failed your people.";
                MessageBox.Show("Thank you for playing!");
                Application.Exit();
            }

            Creature knight = new Creature(1, 2, 1, 2);
            if(Combat(player, knight) != 1)
            {
                TbMain.Text = "You have failed your people";
                MessageBox.Show("Thank you for playing!");
                Application.Exit();
            }

            Creature protector = new Creature(1, 2, 2, 1);
            if(Combat(player, protector)!=1)
            {
                TbMain.Text = "You have failed your people";    
                MessageBox.Show("Thank you for playing!");
                Application.Exit();
            }

            TbMain.Text = "You have arrived at the throne room. Inside you see the king and his royal protector. They king glances at you and speaks." + Environment.NewLine + "'You've made it this far, but I'm afriad this is where your story ends.'";

            if (player.GBP >= 0)
            {
                TbMain.Text = "'Since you have fought honorably in my towns, I shall fight you myself.'" + Environment.NewLine + "Strike against the king and carve your legacy in stone!";

                Creature king = new Creature(1, 8, 8, 9);
                king.currentHealth = king.Health = 75;

                if (Combat(player, king) == 1)
                {
                    TbMain.Text = "You have done it! You have defeated the king and can rule in his stead." + Environment.NewLine + "How will you rule over the people? Will you maintain your honor and generosity, or will you make them pay in blood for the genocide of the Vanins?";
                }
                else
                {
                    MessageBox.Show("Game Over" + Environment.NewLine + "Your people have perished because you were weak.");

                }
                MessageBox.Show("Thank you for playing!");
                Application.Exit();
            }
            else if(player.GBP < 0 && path < 3)
            {
                TbMain.Text = "'You are nothing but scum. I will not give you the gift of fighting me. Royal Protector, Remove him.'" + Environment.NewLine + "Strike against the Protector the King hides behind!";

                Creature royalProtector = new Creature(1, 6, 5, 3);
                royalProtector.currentHealth = royalProtector.Health = 120;
                if (Combat(player, royalProtector) == 1)
                {
                    TbMain.Text = "You have vanquished the royal protector as the king ran away in fear. You can take the crown by force and rule over the people." + Environment.NewLine + "How will you rule over the people? Will your thirst for blood cloud your judgement, or will you bring peace to the land?";
                    path = 3;
                }
                else
                {
                    MessageBox.Show("Game Over" + Environment.NewLine + "Your people have perished because you were weak.");

                }
                MessageBox.Show("Thanks for playing!");
                Application.Exit();
            }        
        }

        public void Wilderness( int difficulty )
        {
            Random rng = new Random();
            Creature bandit = new Creature(3, rng.Next(player.sword.SwordID - 2 + difficulty, player.sword.SwordID + 2 + difficulty), rng.Next(player.staff.StaffID - 2 + difficulty, player.staff.StaffID + 2 + difficulty), player.armor.ArmorID - 2 + difficulty)
            {
                GoldDrop = 30
            };
            lblLoc.Text = "Wilderness";
            int outcome = Combat(player, bandit);
            if (outcome == 1)
            {
                TbMain.Text = "You traversed through the wilderness, defeated a foe and collected their gear, and are now in sight of a town.";

                player.sword.AssignSwordStats(player.sword.SwordID + rng.Next(1, 4));
                player.armor.AssignArmorStats(player.armor.ArmorID + rng.Next(1, 4));
                player.staff.AssignStaffStats(player.staff.StaffID + rng.Next(1, 4));
            }
            else if ( outcome == 2 )
                TbMain.Text = "You ran away from the enemy, and manage to make it to the next town.";
            else
                TbMain.Text = "The foe encountered in the wilderness has defeated you but spared your life. You hang your head low whilst walking towards the nearest town.";
            progress++;
        }

        public int Trader(int Gold)
        {

            return Gold;
        }

    }
}
