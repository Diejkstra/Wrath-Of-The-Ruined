using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using Engine;

namespace WrathOfTheRuined
{
    public partial class GameScreen : Form
    {
        private Player player;
        private Quest quests;
        public int progress = 0;
        public int path = 0;
        public bool slaughter = false;
        public bool LQ1 = false;
        public bool LQ2 = false;
        public bool DQ1 = false;
        public bool DQ2 = false;
        public bool VQ1 = false;
        public bool VQ2 = false;
        public bool FQ1 = false;
        public bool FQ2 = false;

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

        private void BtnContinue_Click(object sender, EventArgs e)
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
            Town(progress);
        }

        public void Town(int progress)
        {

        }

        public void Lancaster()
        {
            
            if (CbChoice.SelectedIndex == 0 && path < 9) //Quest Board
            {
                CbChoice.Items.Clear();
                CbChoice.Update();
                CbChoice.ResetText();
                TbMain.Text = "You look around....";
                TbMain.Focus();
                path = 10;
                

                CbChoice.Items.Add("The Case of the Lost Teddy"); //10
                CbChoice.Items.Add("Abandoned Dog"); //11
                CbChoice.Items.Add("I dont feel like questing");//12                                
            }
            else if (path + CbChoice.SelectedIndex == 12)
            {
                path = 0;
                CbChoice.SelectedIndex = -1;
                TbMain.Text = "You decide the quests ahead are not worth the time or effort" + Environment.NewLine + "(Press Continue)";
            }
            
            else if(path + CbChoice.SelectedIndex == 11)
            {
                if (!LQ2)
                {


                    TbMain.Text = "You find a dog in the middle of the road. It looks abandoned";
                    CbChoice.Items.Clear();
                    CbChoice.Update();
                    CbChoice.ResetText();
                    TbMain.Focus();
                    path = 17;
                    CbChoice.Items.Add("See if you can return it to its owner.");//17
                    CbChoice.Items.Add("...You are a little hungry");//18
                    CbChoice.Items.Add("Who cares. It's just a dog");//19
                }
                else
                {
                    TbMain.Text = "This quest has already been completed/disabled" + Environment.NewLine + "(Press continue)";
                    path = -1;
                    CbChoice.SelectedIndex = -1;
                    CbChoice.Enabled = false;
                }
            }
            else if(path + CbChoice.SelectedIndex == 17)
            {
                TbMain.Text = "You found the owner and he gave you some gold. +5 Gold, +2 GBP" + Environment.NewLine + "(Press Continue)";
                path = -1;
                CbChoice.SelectedIndex = -1;
                player.GBP += 2;
                lblGBP.Text = "GBP: " + player.GBP.ToString();
                player.Gold += 5;
                lblGold.Text = "Gold: " + player.Gold.ToString();
                LQ2 = true;
            }
            else if(path +CbChoice.SelectedIndex == 18)
            {
                path = -1;
                CbChoice.SelectedIndex = -1;
                TbMain.Text = "You really ate someones dog.... -5 GBP" + Environment.NewLine + "(Press Continue)";
                player.GBP -= 5;
                lblGBP.Text = "GBP: " + player.GBP.ToString();
                LQ2 = true;
            }
            else if(path + CbChoice.SelectedIndex == 19)
            {
                path = -1;
                CbChoice.SelectedIndex = -1;
                TbMain.Text = "You don't have time for stray dogs." + Environment.NewLine + "(Press Continue)";
                LQ2 = true;
            }

            else if (path + CbChoice.SelectedIndex == 10)
            {
                if (!LQ1)
                {


                    TbMain.Text = "Hey, there is this little girl crying because she lost her teddy bear, what do you do?";
                    CbChoice.Items.Clear();
                    CbChoice.Update();
                    CbChoice.ResetText();
                    TbMain.Focus();
                    path = 13;
                    CbChoice.Items.Add("Help her look for it"); //13
                    CbChoice.Items.Add("Ignore her, its not your problem");//14
                    CbChoice.Items.Add("Only look if she gives you gold");//15
                    CbChoice.Items.Add(".........kill her?!?");//16

                }
                else
                {
                    TbMain.Text = "This quest has already been selected/disabled" + Environment.NewLine + "(Press Continue)";
                    path = -1;
                    CbChoice.SelectedIndex = -1;
                }
            }

            else if (path + CbChoice.SelectedIndex == 13)
            {
                TbMain.Text = "Thanks Mister." + Environment.NewLine + " You find the teddy bear in town. What do you do now?";
                CbChoice.Items.Clear();
                CbChoice.Update();
                CbChoice.ResetText();
                TbMain.Focus();
                path = 20;
                CbChoice.Items.Add("Return the bear.");//20
                CbChoice.Items.Add("Keep the bear.");//21
            }
            else if(path + CbChoice.SelectedIndex == 20)
            {
                path = -1;
                LQ1 = !LQ1;
                CbChoice.SelectedIndex = -1;
                TbMain.Text = "You return the bear to the little girl and her dad slips you five gold for making his daughter happy. +1 GBP, +5 Gold" + Environment.NewLine + "(Press Continue)";
                player.Gold += 5;
                player.GBP += 1;
                lblGBP.Text = "GBP: " + player.GBP.ToString();
                lblGold.Text = "Gold: " + player.Gold.ToString();
            }
            else if( path + CbChoice.SelectedIndex == 21)
            {
                path = -1;
                CbChoice.SelectedIndex = -1;
                TbMain.Text = "You kept the bear you selfish man. -1 GBP" + Environment.NewLine + "(Press Continue)";
                player.GBP -= 1;
                lblGBP.Text = "GBP: " + player.GBP.ToString();
                LQ1 = !LQ1;
            }

            else if(path + CbChoice.SelectedIndex == 14)
            {
                player.GBP -= 1;
                TbMain.AppendText(Environment.NewLine + "People notice you didnt help the girl. -1 GBP" + Environment.NewLine + "(Press Continue)");
                lblGBP.Text = "GBP: "+player.GBP.ToString();
                path = -1;
                CbChoice.SelectedIndex = -1;
                LQ1 = !LQ1;
            }

            else if (path + CbChoice.SelectedIndex == 15)
            {
                TbMain.Text = "She only has 2 gold and is saving to buy her dad a present." + Environment.NewLine + "Are you sure you want to extort her?";
                path = 22;
                CbChoice.Items.Clear();
                CbChoice.Update();
                CbChoice.ResetText();
                TbMain.Focus();
                CbChoice.Items.Add("Take the gold for the teddy bear anyway");//22
                CbChoice.Items.Add("Give her the teddy bear for free");//23
            }
            else if(path + CbChoice.SelectedIndex == 22)
            {
                TbMain.Text = "You trade the teddy bear for two gold. This is how the real world works, and you have taught her a valuable lesson." + Environment.NewLine + "(Press Continue)";
                path = -1;
                LQ1 = !LQ1;
                CbChoice.SelectedIndex = -1;
                player.Gold += 2;
                lblGold.Text = "Gold: " + player.Gold.ToString();
            }
            else if(path + CbChoice.SelectedIndex == 23)
            {
                TbMain.Text = "You give her the teddy bear for free. +1 GBP" + Environment.NewLine + "(Press Continue)";
                path = -1;
                CbChoice.SelectedIndex = -1;
                LQ1 = !LQ1;
                player.GBP += 1;
                lblGBP.Text = "GBP :" + player.Gold.ToString();
            }

            else if (path + CbChoice.SelectedIndex == 16)
            {
                TbMain.AppendText(Environment.NewLine + "Her Parents come to protect her!" +Environment.NewLine + "What do you do?");
                CbChoice.Items.Clear();
                CbChoice.Update();
                CbChoice.ResetText();
                TbMain.Focus();
                CbChoice.Items.Add("Kill them too");//24
                CbChoice.Items.Add("Run away");//25
                path = 24;

            }
            else if (path + CbChoice.SelectedIndex == 24)
            {
                Creature parent = new Creature(2,2,1,1);
                parent.Health = parent.currentHealth = 50;
                parent.GoldDrop = 10;
                if (Combat(player, parent) == 1)
                    TbMain.Text = "You manage to fend off the parents." + Environment.NewLine + "(Press Continue)";
                else
                    TbMain.Text = "You ran away from some parents..." + Environment.NewLine + "This does not bode well...";

                path = -1;
                CbChoice.SelectedIndex = -1;
                LQ1 = !LQ1;
            }
            else if (path + CbChoice.SelectedIndex == 25)
            {
                TbMain.Text = "You tried to kill a kid and ran. Really...";
                player.GBP -= 3;
                path = -1;
                CbChoice.SelectedIndex = -1;
                LQ1 = !LQ1;
                lblGBP.Text = "GBP: " + player.GBP.ToString();
            }

            else if(CbChoice.SelectedIndex == 1)
            {
                MessageBox.Show("WIP :(");
            }
            else if (CbChoice.SelectedIndex == 2)
            {
                if (!slaughter)
                {
                    TbMain.Text = "You brace yourself as the town prepares to battle.";
                    Creature town = new Creature(1, 1, 1, 1);
                    town.currentHealth = town.Health = 120;
                    town.GoldDrop = 50;
                    if (Combat(player, town) == 1)
                    {
                        TbMain.Text = "You chose to kill everyone in sight. They left you with new equipment and some gold.";
                        player.sword.AssignSwordStats(4);
                        player.staff.AssignStaffStats(4);
                        player.armor.AssignArmorStats(4);
                        slaughter = true;
                        LQ1 = !LQ1;
                        LQ2 = !LQ2;
                        
                    }
                    else
                    {
                        TbMain.Text = "You chose to run, the town now dislikes you and no longer trusts you. You can no longer do quests in this town. -5 GBP" + Environment.NewLine + "(Press Continue)";
                        LQ1 = !LQ1;
                        LQ2 = !LQ2;
                        player.GBP -= 5;
                        lblGBP.Text = "GBP: " + player.GBP.ToString();
                    }
                    path = -1;
                    CbChoice.SelectedIndex = -1;
                }
                else
                {
                    TbMain.Text = "You have already killed everyone. There is nothing left.";
                    TbMain.AppendText(Environment.NewLine + "You move on as there is no one left to do anything with." + Environment.NewLine + "(Press Continue");
                    slaughter = false;
                    progress++;
                }          
            }
            else if (CbChoice.SelectedIndex == 3)
            {
                TbMain.Text = "Lancaster was but one step on your journey, so you decide to continue on your quest." + Environment.NewLine + "(Press Continue)";
                //MessageBox.Show(prog.ToString());
                CbChoice.Focus();
                CbChoice.SelectedIndex = -1;
                slaughter = false;
                progress++;
            }

            else
            {
                TbMain.Text = "You are in the main square of Lancaster." + Environment.NewLine;
                lblLoc.Show();
                lblLoc.Text = "Lancaster";
                TbMain.AppendText("Your oppurtunites are vast, what shall you decide to do?");
                CbChoice.Items.Clear();
                CbChoice.Items.Add("Check out the Quest Board");// 10
                CbChoice.Items.Add("Buy some Equipment"); //11
                CbChoice.Items.Add("Slaughter the Town"); //12
                CbChoice.Items.Add("Leave the town"); //13                   
            }
            
        }
       
        public void Doveport()
        {
              
            
            if(CbChoice.SelectedIndex == 0 && path < 9) //Quest Board
            {
                CbChoice.Items.Clear();
                CbChoice.Update();
                CbChoice.ResetText();
                TbMain.Text = "You look around....";
                TbMain.Focus();
                path = 10;


                CbChoice.Items.Add("Blacksmith In Need"); //10
                CbChoice.Items.Add("The Future of Doveport"); //11
                CbChoice.Items.Add("I dont feel like questing");//12                                
            }
            else if(CbChoice.SelectedIndex + path == 12)
            {
                path = 0;
                CbChoice.SelectedIndex = -1;
                TbMain.Text = "You decide the quests ahead are not worth the time or effort" + Environment.NewLine + "(Press Continue)";
            }

            else if(CbChoice.SelectedIndex + path == 10)
            {
                if(!DQ1)
                {
                    TbMain.Text = "You see a man being beaten in the middle of the village, what do you do?";
                    CbChoice.Items.Clear();
                    CbChoice.Update();
                    CbChoice.ResetText();
                    TbMain.Focus();
                    path = 13;
                    CbChoice.Items.Add("Help the man"); //13 16,17
                    CbChoice.Items.Add("Ignore the man");//14
                    CbChoice.Items.Add("Join in");//15
                }
                else
                {
                    TbMain.Text = "This quest has already been selected/disabled" + Environment.NewLine + "(Press Continue)";
                    path = -1;
                    CbChoice.SelectedIndex = -1;
                }

            }
            else if (CbChoice.SelectedIndex + path == 13)
            {
                TbMain.Text = "Do you fight to kill? or Incapacitate?";
                CbChoice.Items.Clear();
                CbChoice.Update();
                CbChoice.ResetText();
                TbMain.Focus();
                path = 16;
                CbChoice.Items.Add("Incapacitate them");//16
                CbChoice.Items.Add("Kill them");//17
            }
            else if(CbChoice.SelectedIndex + path == 16)
            {
                TbMain.AppendText("Thanks for helping me, my guy. You earned a discount at my store.'" + Environment.NewLine + "(Press Continue");
                player.GBP += 8;
                lblGBP.Text = "GBP: " + player.GBP.ToString();
                path = -1;
                CbChoice.SelectedIndex = -1;
                DQ1 = true;
            }
            else if (CbChoice.SelectedIndex + path == 17)
            {
                TbMain.AppendText("You didn't have to kill them, but Thanks for saving me" + Environment.NewLine + "(Press Continue");
                player.GBP += 5;
                lblGBP.Text = "GBP: " + player.GBP.ToString();
                path = -1;
                CbChoice.SelectedIndex = -1;
                DQ1 = true;
            }
            else if (CbChoice.SelectedIndex + path == 14)
            {
                TbMain.Text = "Its not your problem. He probably deserved it";
                path = -1;
                CbChoice.SelectedIndex = -1;
                DQ1 = true;
            }
            else if (CbChoice.SelectedIndex + path == 15)
            {
                TbMain.Text = "He must have done something to have angered these people. Do you just beat him up or kill him?";
                CbChoice.Items.Clear();
                CbChoice.Update();
                CbChoice.ResetText();
                TbMain.Focus();
                CbChoice.Items.Add("Beat him up"); //18
                CbChoice.Items.Add("Kill him"); //19
                path = 18;
            }
            else if (CbChoice.SelectedIndex + path == 18)
            {
                TbMain.AppendText("'How could you beat me up like that. Im telling everyone in town you did this'");
                player.GBP += 8;
                lblGBP.Text = "GBP: " + player.GBP.ToString();
                path = -1;
                CbChoice.SelectedIndex = -1;
                DQ1 = true;
            }
            else if (CbChoice.SelectedIndex + path == 19)
            {
                TbMain.AppendText("Oh no. It looks like those guys didn't want him dead. You wanna kill them, or get out");
                CbChoice.Items.Clear();
                CbChoice.Update();
                CbChoice.ResetText();
                CbChoice.Items.Add("Get outta dodge");//20
                CbChoice.Items.Add("Fight 'em");//21
                path = 20;
            }
            else if (CbChoice.SelectedIndex + path == 20)
            {
                TbMain.Text = "You ran away, probably for the better";
                path = -1;
                CbChoice.SelectedIndex = -1;
                DQ1 = true;

            }
            else if (CbChoice.SelectedIndex + path == 21)
            {
                Creature enemy = new Creature(2,2,2,2);
                enemy.GoldDrop += 30;
                if(Combat(player, enemy) == 1)
                {
                    TbMain.Text = "Many people saw you kill them, they become distrusting of you";
                    player.GBP -= 5;
                    lblGBP.Text = "GBP: " + player.GBP.ToString();
                    path = -1;
                    CbChoice.SelectedIndex = -1;
                    DQ1 = true;
                }
                else
                {
                    TbMain.Text = "You ran from the fight, people laugh at your shame";
                    player.GBP -= 10;
                    lblGBP.Text = "GBP: " + player.GBP.ToString();
                    path = -1;
                    CbChoice.SelectedIndex = -1;
                    DQ1 = true;
                }

            }

            else if (CbChoice.SelectedIndex + path == 11)
            {
                if (!DQ2)
                {
                    TbMain.Text = "These bandits are terrorizing the town and someone is offering moeny to stop them. You up for it?";
                    CbChoice.Items.Clear();
                    CbChoice.Update();
                    CbChoice.ResetText();
                    TbMain.Focus();
                    path = 22;
                    CbChoice.Items.Add("Destroy the bandits");//22
                    CbChoice.Items.Add("Maybe the bandits will offer me money to help them"); //23
                }
                else
                {
                    TbMain.Text = "This quest has already been selected/disabled" + Environment.NewLine + "(Press Continue)";
                    path = -1;
                    CbChoice.SelectedIndex = -1;
                }
            }
            else if (CbChoice.SelectedIndex + path == 22)
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
                    CbChoice.SelectedIndex = -1;
                    DQ2 = true;
                }
                else
                {
                    TbMain.Text = "You failed to beat the bandits, but still recieve GBP in compensation";
                    player.GBP += 5;
                    lblGBP.Text = "GBP: " + player.GBP.ToString();
                    path = -1;
                    CbChoice.SelectedIndex = -1;
                    DQ2 = true;
                }

            }
            else if (CbChoice.SelectedIndex + path == 23)
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
                    CbChoice.SelectedIndex = -1;
                    DQ2 = true;
                }
                else
                {
                    TbMain.Text = "You failed to beat the bandits, but still recieve GBP in compensation" + Environment.NewLine + "(Press Continue)";
                    player.GBP += 5;
                    lblGBP.Text = "GBP: " + player.GBP.ToString();
                    path = -1;
                    CbChoice.SelectedIndex = -1;
                    DQ2 = true;
                }

            }



            else if (CbChoice.SelectedIndex == 1)
            {
                MessageBox.Show("WIP :(");
            }
            else if (CbChoice.SelectedIndex == 2)
            {
                if (!slaughter)
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
                        slaughter = true;
                        DQ1 = !DQ1;
                        DQ2 = !DQ2;

                    }
                    else
                    {
                        TbMain.Text = "You chose to run and the town dislikes you and no longer trusts you, -5 GBP and you can no longer do quests in this town" + Environment.NewLine + "(Press Continue)";
                        DQ1 = !DQ1;
                        DQ2 = !DQ2;
                        player.GBP -= 5;
                        lblGBP.Text = "GBP: " + player.GBP.ToString();
                    }
                    path = -1;
                    CbChoice.SelectedIndex = -1;
                }
                else
                {
                    TbMain.Text = "You have already killed everyone. There is nothing left";
                    TbMain.AppendText(Environment.NewLine + "You move on as there is no one left to do anything with" + Environment.NewLine + "(Press Continue)");
                    progress++;
                }
            }
            else if (CbChoice.SelectedIndex == 3)
            {
                TbMain.Text = "Doveport has served you nicely, but you decide that you should continue on your journey." + Environment.NewLine + "(Press Continue)";
                //MessageBox.Show(prog.ToString());
                CbChoice.Focus();
                CbChoice.SelectedIndex = -1;
                path = 0;
                progress++;
            }

            else
            {
                CbChoice.SelectedIndex = -1;
                TbMain.Text = "You are standing in downtown Doveport.";
                lblLoc.Text = "Doveport";

                CbChoice.Items.Clear();
                CbChoice.Items.Add("Check out the Quest Board");// 10
                CbChoice.Items.Add("Buy some Equipment"); //11
                CbChoice.Items.Add("Slaughter the Town"); //12
                CbChoice.Items.Add("Leave the town"); //13   
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
            CbChoice.SelectedIndex = -1;
            
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
