using System;
using System.Threading;
using Engine;
using System.Windows.Forms;
using System.Drawing;
using Interface.Properties;

namespace WrathOfTheRuined
{
    public partial class CombatForm : Form
    {
        private Player player;
        private Enemy enemy;
        public int result = 3;
        private System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();
        readonly Music CombatMusic = new Music();
        private string typePlayerText;
        private string typeEnemyText;
        private int letterCount = 0;
        private bool playerTextDone = false;

        public CombatForm(Player player, Enemy enemy)
        {
            InitializeComponent();
            this.player = player;
            this.enemy = enemy;
            timer1.Interval = 20;
            timer1.Enabled = false;
            timer1.Tick += timer1_Tick;
            StartCombat();
        }

        private void StartCombat()
        {
            Random rand = new Random();

            player.stance.ChangeStance(player, 2);
            enemy.stance.ChangeStance(enemy, 2);
            player.CurrentHP = player.MaxHP;
            MessageBox.Show("An enemy approaches, you draw your weapon...");
            CombatRefresh();

            lblPlayerName.Text = player.Name;
            lblEnemyName.Text = enemy.Name;
            lblActions.Text = "";
            CbPlayerCombat.SelectedIndex = 0;

            SizeLabelFont(lblPlayerName);
            SizeLabelFont(lblEnemyName);
            CombatMusic.soundplayer = CombatMusic.StartMusic(Resources.Battle);
        }

        private void Fight()
        {
            Random rand = new Random();
            int damageDelt;

            if (player.CurrentHP > 0 && enemy.CurrentHP > 0)
            {
                if (CbPlayerCombat.SelectedIndex == 0)
                {
                    damageDelt = Convert.ToInt32(Math.Round(rand.Next(player.stance.stanceMinP_DMG, player.stance.stanceMaxP_DMG + 1) * (100 - enemy.stance.totalArmor) * .01));
                    if (damageDelt < 0)
                        damageDelt = 0;
                    enemy.CurrentHP -= damageDelt;
                    typePlayerText = "You attacked the enemy for " + damageDelt + " damage.";
                }
                else if (CbPlayerCombat.SelectedIndex == 1)
                {
                    Change_Stance();
                }
                else if (CbPlayerCombat.SelectedIndex == 2)
                {
                    damageDelt = Convert.ToInt32(Math.Round(rand.Next(player.stance.stanceMinM_DMG, player.stance.stanceMaxM_DMG + 1) * (100 - enemy.stance.totalMR) * .01));
                    if (damageDelt < 0)
                        damageDelt = 0;
                    enemy.CurrentHP -= damageDelt;
                    typePlayerText = "You attacked the enemy for " + damageDelt + " damage.";
                }
                else if (CbPlayerCombat.SelectedIndex == 3)
                {
                    Hide();
                    UseItemForm UseItem = new UseItemForm();
                    UseItem.ChooseItem(player);
                    if (UseItem.ShowDialog(this) == DialogResult.OK && UseItem.UseThisItem != null)
                    {
                        player.CurrentHP += UseItem.UseThisItem.HealthGain;
                        int healed = 0;
                        if (player.CurrentHP > player.MaxHP)
                        {
                            healed = UseItem.UseThisItem.HealthGain - (player.CurrentHP - player.MaxHP);
                            player.CurrentHP = player.MaxHP;
                        }
                        else
                            healed = UseItem.UseThisItem.HealthGain;
                        typePlayerText = "You used the " + UseItem.UseThisItem.Name + " and healed " + healed + " health.";
                        typeEnemyText = "";
                        Show();
                        Typewrite();
                        player.Inventory.Remove(UseItem.UseThisItem);
                    }
                    UseItem.Dispose();
                }
                else if (CbPlayerCombat.SelectedIndex == 4)
                {
                    int GoldLost = rand.Next(1, 15);
                    if (GoldLost > player.Gold)
                        GoldLost = player.Gold;
                    MessageBox.Show("As you ran away you dropped " + GoldLost + " Gold.");
                    player.Gold -= GoldLost;
                    result = 2;
                    Close();
                }
            }

            if (enemy.CurrentHP > 0 && (CbPlayerCombat.SelectedIndex == 0 || CbPlayerCombat.SelectedIndex == 2))
            {
                if (player.stance.stanceNum == 1 || player.stance.stanceNum == 3)
                {
                    if (player.Endurance >= 10)
                        player.Endurance -= 10;
                    player.stance.ChangeStance(player, player.stance.stanceNum);
                }
                if (player.stance.stanceNum == 2)
                {
                    if (player.Endurance <= 90)
                        player.Endurance += 10;
                    player.stance.ChangeStance(player, player.stance.stanceNum);
                }
                damageDelt = Convert.ToInt32(Math.Round(rand.Next(enemy.stance.stanceMinP_DMG, enemy.stance.stanceMaxP_DMG + 1) * (100 - player.stance.totalArmor) * .01));
                if (damageDelt < 0)
                    damageDelt = 0;
                player.CurrentHP -= damageDelt;
                typeEnemyText = "The enemy attacked you for " + damageDelt + " damage.";
                Typewrite();
                enemy.stance.ChangeStance(enemy, rand.Next(1, 4));
            }
            if (player.CurrentHP > 0 && enemy.CurrentHP > 0)
            {
                CombatRefresh();
            }
            else if (player.CurrentHP > 0 && enemy.CurrentHP <= 0)
            {
                MessageBox.Show("You have defeated the enemy and found " + enemy.GoldDrop + " gp.");
                player.Gold += enemy.GoldDrop;
                player.XP += enemy.XPValue;
                player.Strength += (enemy.Strength / 5);
                player.Intellect += (enemy.Intellect / 5);
                result = 1;
                Close();
            }
            else if (player.CurrentHP <= 0 && enemy.CurrentHP > 0)
            {
                result = 0;
                Close();
            }
        }

        private void CombatRefresh()
        {
            lblPlayerHealth.Text = player.CurrentHP.ToString();
            lblPlayerWeapon.Text = player.sword.Name.ToString();
            lblPlayerStaff.Text = player.staff.Name.ToString();
            lblPlayerArmor.Text = player.armor.Name.ToString();
            lblPlayerStance.Text = player.stance.stanceName;
            lblEnemyHealth.Text = enemy.CurrentHP.ToString();
            lblEnemyWeapon.Text = enemy.sword.Name.ToString();
            lblEnemyStaff.Text = enemy.staff.Name.ToString();
            lblEnemyArmor.Text = enemy.armor.Name.ToString();
            lblEnemyStance.Text = enemy.stance.stanceName;
        }

        private void Change_Stance()
        {
            Hide();
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
            Show();
        }

        private void Typewrite()
        {
            actionButton.Enabled = false;
            CbPlayerCombat.Enabled = false;
            timer1.Start();
        }

        private void SizeLabelFont(Label lbl)
        {
            // Only bother if there's text.
            string txt = lbl.Text;
            if (txt.Length > 0)
            {
                int best_size = 100;

                // See how much room we have, allowing a bit
                // for the Label's internal margin.
                int wid = lbl.DisplayRectangle.Width - 3;
                int hgt = lbl.DisplayRectangle.Height - 3;

                // Make a Graphics object to measure the text.
                using (Graphics gr = lbl.CreateGraphics())
                {
                    for (int i = 1; i <= 100; i++)
                    {
                        using (Font test_font =
                            new Font(lbl.Font.FontFamily, i))
                        {
                            // See how much space the text would
                            // need, specifying a maximum width.
                            SizeF text_size =
                                gr.MeasureString(txt, test_font);
                            if ((text_size.Width > wid) ||
                                (text_size.Height > hgt))
                            {
                                best_size = i - 1;
                                break;
                            }
                        }
                    }
                }
                // Use that font size.
                lbl.Font = new Font(lbl.Font.FontFamily, best_size);
            }
        }

        private void actionButton_Click(object sender, EventArgs e)
        {
            Fight();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!playerTextDone)
            {
                if (letterCount != typePlayerText.Length) // stop the timer once the message finishes to avoid getting an error
                {
                    lblActions.Text += typePlayerText[letterCount]; // add the letter to the title bar
                    letterCount++; // increment the count
                }
                else
                {
                    Thread.Sleep(600);
                    letterCount = 0;
                    lblActions.Text = "";
                    playerTextDone = true;
                }
            }
            else
            {
                if (letterCount != typeEnemyText.Length) // stop the timer once the message finishes to avoid getting an error
                {
                    lblActions.Text += typeEnemyText[letterCount]; // add the letter to the title bar
                    letterCount++; // increment the count
                }
                else
                {
                    timer1.Stop(); // use this to stop after once

                    // use this to clear and restart
                    if (CbPlayerCombat.SelectedIndex == 0 || CbPlayerCombat.SelectedIndex == 2)
                        Thread.Sleep(600);
                    letterCount = 0;
                    lblActions.Text = "";
                    playerTextDone = false;
                    actionButton.Enabled = true;
                    CbPlayerCombat.Enabled = true;
                }
            }
        }
    }
}
