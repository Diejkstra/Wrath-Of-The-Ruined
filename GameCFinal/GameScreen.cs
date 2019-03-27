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
        public bool[] inQuest = new bool[2];          //Array tracking what quest you are currently in. Used for menu navigation.
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

        private void Game_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void BtnContinue_Click1(object sender, EventArgs e)
        {
            switch (progress)
            {
                case 0:
                    GameTutorial();
                    break;
                case 1:
                    Lancaster();
                    break;
                case 2:
                    Wilderness(0);
                    break;
                case 3:
                    Doveport();
                    break;
                case 4:
                    Wilderness(2);
                    break;
                case 5:
                    RoyalPalace();
                    break;
                case 6:
                    //WIP
                    break;
                case 7:
                    //WIP
                    break;
                default:
                    //never ever get here
                    break;
            }
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

        public int Combat(Player player, Creature enemy)
        {
            CombatForm combatF = new CombatForm();
            GameScreenMusic.StopMusic(GameScreenMusic.soundplayer);
            Music CombatMusic = new Music();
            CombatMusic.soundplayer = CombatMusic.StartMusic("Battle");
            Random rng = new Random();

            player.stance.ChangeStance(player, 2);
            enemy.stance.ChangeStance(enemy, 2);

            MessageBox.Show("An Enemy Approaches, you draw your weapon");
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
                        break; //sorry. its the only way
                    }
                }
                if (player.currentHealth > 0 && enemy.currentHealth <= 0)
                {
                    player.currentHealth = player.Health;
                    player.Gold += enemy.GoldDrop;
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
            return 2; //should not ever return 2; NEVER


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
                        MessageBox.Show("As you ran away you dropped " + GoldLost + " Gold!");
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


        public void Lancaster()
        {
            Town Lancaster = new Town(0);
            BtnContinue.Click -= BtnContinue_Click1;
            BtnContinue.Click += BtnContinue_Click1;

            lblXP.Text = "XP:" + player.ExperiencePoints.ToString();
            lblGold.Text = "Gold:" + player.Gold.ToString();
            lblGBP.Text = "GBP:" + player.GBP.ToString();
            lblLoc.Text = Lancaster.townName;
            TbMain.Text = "You are standing in the small town of Lancaster.";

            ActionBox.Items.Clear();
            ActionBox.Items.Add("Check Quest Board");
            ActionBox.Items.Add("Visit the blacksmith");
            ActionBox.Items.Add("Slaughter the town");
            ActionBox.Items.Add("Leave town");

        }
       
        public void Doveport()
        {
              
            
            if(ActionBox.SelectedIndex == 0 && path < 9) //Quest Board
            {
                ActionBox.Items.Clear();
                ActionBox.Update();
                ActionBox.ResetText();
                TbMain.Text = "You look around....";
                TbMain.Focus();
                path = 10;


                ActionBox.Items.Add("Blacksmith In Need"); //10
                ActionBox.Items.Add("The Future of Doveport"); //11
                ActionBox.Items.Add("I dont feel like questing");//12                                
            }
            else if(ActionBox.SelectedIndex + path == 12)
            {
                path = 0;
                ActionBox.SelectedIndex = -1;
                TbMain.Text = "You decide the quests ahead are not worth the time or effort" + Environment.NewLine + "(Press Continue)";
            }

            else if(ActionBox.SelectedIndex + path == 10)
            {
                if(!questsComplete[2])
                {
                    TbMain.Text = "You see a man being beaten in the middle of the village, what do you do?";
                    ActionBox.Items.Clear();
                    ActionBox.Update();
                    ActionBox.ResetText();
                    TbMain.Focus();
                    path = 13;
                    ActionBox.Items.Add("Help the man"); //13 16,17
                    ActionBox.Items.Add("Ignore the man");//14
                    ActionBox.Items.Add("Join in");//15
                }
                else
                {
                    TbMain.Text = "This quest has already been selected/disabled" + Environment.NewLine + "(Press Continue)";
                    path = -1;
                    ActionBox.SelectedIndex = -1;
                }

            }
            else if (ActionBox.SelectedIndex + path == 13)
            {
                TbMain.Text = "Do you fight to kill? or Incapacitate?";
                ActionBox.Items.Clear();
                ActionBox.Update();
                ActionBox.ResetText();
                TbMain.Focus();
                path = 16;
                ActionBox.Items.Add("Incapacitate them");//16
                ActionBox.Items.Add("Kill them");//17
            }
            else if(ActionBox.SelectedIndex + path == 16)
            {
                TbMain.AppendText("Thanks for helping me, my guy. You earned a discount at my store.'" + Environment.NewLine + "(Press Continue");
                player.GBP += 8;
                lblGBP.Text = "GBP: " + player.GBP.ToString();
                path = -1;
                ActionBox.SelectedIndex = -1;
                questsComplete[2] = true;
            }
            else if (ActionBox.SelectedIndex + path == 17)
            {
                TbMain.AppendText("You didn't have to kill them, but Thanks for saving me" + Environment.NewLine + "(Press Continue");
                player.GBP += 5;
                lblGBP.Text = "GBP: " + player.GBP.ToString();
                path = -1;
                ActionBox.SelectedIndex = -1;
                questsComplete[2] = true;
            }
            else if (ActionBox.SelectedIndex + path == 14)
            {
                TbMain.Text = "Its not your problem. He probably deserved it";
                path = -1;
                ActionBox.SelectedIndex = -1;
                questsComplete[2] = true;
            }
            else if (ActionBox.SelectedIndex + path == 15)
            {
                TbMain.Text = "He must have done something to have angered these people. Do you just beat him up or kill him?";
                ActionBox.Items.Clear();
                ActionBox.Update();
                ActionBox.ResetText();
                TbMain.Focus();
                ActionBox.Items.Add("Beat him up"); //18
                ActionBox.Items.Add("Kill him"); //19
                path = 18;
            }
            else if (ActionBox.SelectedIndex + path == 18)
            {
                TbMain.AppendText("'How could you beat me up like that. Im telling everyone in town you did this'");
                player.GBP += 8;
                lblGBP.Text = "GBP: " + player.GBP.ToString();
                path = -1;
                ActionBox.SelectedIndex = -1;
                questsComplete[2] = true;
            }
            else if (ActionBox.SelectedIndex + path == 19)
            {
                TbMain.AppendText("Oh no. It looks like those guys didn't want him dead. You wanna kill them, or get out");
                ActionBox.Items.Clear();
                ActionBox.Update();
                ActionBox.ResetText();
                ActionBox.Items.Add("Get outta dodge");//20
                ActionBox.Items.Add("Fight 'em");//21
                path = 20;
            }
            else if (ActionBox.SelectedIndex + path == 20)
            {
                TbMain.Text = "You ran away, probably for the better";
                path = -1;
                ActionBox.SelectedIndex = -1;
                questsComplete[2] = true;

            }
            else if (ActionBox.SelectedIndex + path == 21)
            {
                Creature enemy = new Creature(2,2,2,2);
                enemy.GoldDrop += 30;
                if(Combat(player, enemy) == 1)
                {
                    TbMain.Text = "Many people saw you kill them, they become distrusting of you";
                    player.GBP -= 5;
                    lblGBP.Text = "GBP: " + player.GBP.ToString();
                    path = -1;
                    ActionBox.SelectedIndex = -1;
                    questsComplete[2] = true;
                }
                else
                {
                    TbMain.Text = "You ran from the fight, people laugh at your shame";
                    player.GBP -= 10;
                    lblGBP.Text = "GBP: " + player.GBP.ToString();
                    path = -1;
                    ActionBox.SelectedIndex = -1;
                    questsComplete[2] = true;
                }

            }

            else if (ActionBox.SelectedIndex + path == 11)
            {
                if (!questsComplete[3])
                {
                    TbMain.Text = "These bandits are terrorizing the town and someone is offering moeny to stop them. You up for it?";
                    ActionBox.Items.Clear();
                    ActionBox.Update();
                    ActionBox.ResetText();
                    TbMain.Focus();
                    path = 22;
                    ActionBox.Items.Add("Destroy the bandits");//22
                    ActionBox.Items.Add("Maybe the bandits will offer me money to help them"); //23
                }
                else
                {
                    TbMain.Text = "This quest has already been selected/disabled" + Environment.NewLine + "(Press Continue)";
                    path = -1;
                    ActionBox.SelectedIndex = -1;
                }
            }
            else if (ActionBox.SelectedIndex + path == 22)
            {
                Creature bandit = new Creature(2,3,3,4);
                bandit.GoldDrop = 40;
                bandit.currentHealth = bandit.Health = 75;
                if(Combat(player, bandit) == 1)
                {
                    TbMain.Text = "You have defeated the bandits";
                    player.GBP += 10;
                    lblGBP.Text = "GBP: " + player.GBP.ToString();
                    path = -1;
                    ActionBox.SelectedIndex = -1;
                    questsComplete[3] = true;
                }
                else
                {
                    TbMain.Text = "You failed to beat the bandits, but still recieve GBP in compensation";
                    player.GBP += 5;
                    lblGBP.Text = "GBP: " + player.GBP.ToString();
                    path = -1;
                    ActionBox.SelectedIndex = -1;
                    questsComplete[3] = true;
                }

            }
            else if (ActionBox.SelectedIndex + path == 23)
            {
                TbMain.Text = "Nope, now they want to kill you" + Environment.NewLine + "(Press Continue)";
                Creature bandit = new Creature(2, 3, 3, 4);
                bandit.GoldDrop = 40;
                bandit.currentHealth = bandit.Health = 75;
                if (Combat(player, bandit) == 1)
                {
                    TbMain.Text = "You have defeated the bandits" + Environment.NewLine + "(Press Continue";
                    player.GBP += 10;
                    lblGBP.Text = "GBP: " + player.GBP.ToString();
                    path = -1;
                    ActionBox.SelectedIndex = -1;
                    questsComplete[3] = true;
                }
                else
                {
                    TbMain.Text = "You failed to beat the bandits, but still recieve GBP in compensation" + Environment.NewLine + "(Press Continue)";
                    player.GBP += 5;
                    lblGBP.Text = "GBP: " + player.GBP.ToString();
                    path = -1;
                    ActionBox.SelectedIndex = -1;
                    questsComplete[3] = true;
                }

            }



            else if (ActionBox.SelectedIndex == 1)
            {
                MessageBox.Show("WIP :(");
            }
            else if (ActionBox.SelectedIndex == 2)
            {
                if (!townSlaughtered[1])
                {
                    TbMain.Text = "You brace yourself as the town prepares to battle";
                    Creature townDoveport = new Creature(2, 4, 4, 3);
                    townDoveport.currentHealth = townDoveport.Health = 120;
                    townDoveport.GoldDrop = 50;
                    if (Combat(player, townDoveport) == 1)
                    {
                        TbMain.Text = "You chose to kill everyone in sight. They left you with new equipment and some gold";
                        player.sword.AssignSwordStats(7);
                        player.staff.AssignStaffStats(7);
                        player.armor.AssignArmorStats(7);
                        townSlaughtered[1] = true;
                        questsComplete[2] = true;
                        questsComplete[3] = true;

                    }
                    else
                    {
                        TbMain.Text = "You chose to run and the town dislikes you and no longer trusts you, -5 GBP and you can no longer do quests in this town" + Environment.NewLine + "(Press Continue)";
                        questsComplete[2] = true;
                        questsComplete[3] = true;
                        player.GBP -= 5;
                        lblGBP.Text = "GBP: " + player.GBP.ToString();
                    }
                    path = -1;
                    ActionBox.SelectedIndex = -1;
                }
                else
                {
                    TbMain.Text = "You have already killed everyone. There is nothing left";
                    TbMain.AppendText(Environment.NewLine + "You move on as there is no one left to do anything with" + Environment.NewLine + "(Press Continue)");
                    progress++;
                }
            }
            else if (ActionBox.SelectedIndex == 3)
            {
                TbMain.Text = "Doveport has served you nicely, but you decide that you should continue on your journey." + Environment.NewLine + "(Press Continue)";
                //MessageBox.Show(prog.ToString());
                ActionBox.Focus();
                ActionBox.SelectedIndex = -1;
                path = 0;
                progress++;
            }

            else
            {
                ActionBox.SelectedIndex = -1;
                TbMain.Text = "You are standing in downtown Doveport.";
                lblLoc.Text = "Doveport";

                ActionBox.Items.Clear();
                ActionBox.Items.Add("Check out the Quest Board");// 10
                ActionBox.Items.Add("Buy some Equipment"); //11
                ActionBox.Items.Add("Slaughter the Town"); //12
                ActionBox.Items.Add("Leave the town"); //13   
            }


        }

        public void Venzor()
        {

        }

        public void Fallholt()
        {

        }

        public void RoyalPalace()
        {
            ActionBox.SelectedIndex = -1;
            
            lblLoc.Text = "Royal Palace";

            TbMain.Text = "The time is now. You have geared up, gained some cash, and are ready to remove the threat to your family." + Environment.NewLine + "You'll have to fight your way through to the king. Do you still have the strength to manage?";

            Creature noble = new Creature(1, 1, 1, 1);
            if(Combat(player, noble) != 1)
            {
                TbMain.Text = "You have failed your people";
                MessageBox.Show("Thanks for playing");
                Application.Exit();
            }

            Creature knight = new Creature(1, 2, 1, 2);
            if(Combat(player, knight) != 1)
            {
                TbMain.Text = "You have failed your people";
                MessageBox.Show("Thanks for playing");
                Application.Exit();
            }

            Creature protector = new Creature(1, 2, 2, 1);
            if(Combat(player, protector)!=1)
            {
                TbMain.Text = "You have failed your people";
                MessageBox.Show("Thanks for playing");
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
                    MessageBox.Show("GAME OVER" + Environment.NewLine + "Your people have perished because you were weak", "Thanks for playing");

                }
                MessageBox.Show("Thanks for playing!");
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
                    MessageBox.Show("GAME OVER" + Environment.NewLine + "Your people have perished because you were weak", "Thanks for playing");

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
            if (Combat(player, bandit) == 1)
            {
                TbMain.Text = "You traversed through the wilderness, defeated a foe and collected their gear, and are now in sight of a town" + Environment.NewLine + "(Press continue to move on)";

                player.sword.AssignSwordStats(player.sword.SwordID + rng.Next(1, 4));
                player.armor.AssignArmorStats(player.armor.ArmorID + rng.Next(1, 4));
                player.staff.AssignStaffStats(player.staff.StaffID + rng.Next(1, 4));
            }
            else
                TbMain.Text = "The foe encountered in the wilderness defeated you, you hang your head low whilst walking towards the village within eyeshot";
            progress++;
        }

        public int Trader(int Gold)
        {

            return Gold;
        }

    }
}
