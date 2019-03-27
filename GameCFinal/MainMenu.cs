using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameCFinal
{
    public partial class MainMenu : Form
    {
        Music MenuMusic = new Music();
        public MainMenu()
        {
            InitializeComponent();
            Color opac = Color.FromArgb(100, Color.Silver);
            label1.BackColor = opac;
            btnCredits.BackColor = opac;
            btnLoadGame.BackColor = opac;
            btnNewGame.BackColor = opac;
            btnQuit.BackColor = opac;
            MenuMusic.soundplayer = MenuMusic.StartMusic("MainMenu");
            
            
        }

        private void BtnLoadGame_Click(object sender, EventArgs e)
        {
            MessageBox.Show("WIP", "WIP");
        }

        private void BtnQuit_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Thanks for Playing!");
            Application.Exit();
        }

        private void BtnNewGame_Click(object sender, EventArgs e)
        {
            MenuMusic.StopMusic(MenuMusic.soundplayer);
            GameScreen game = new GameScreen();
            this.Hide();
            game.Show();
        }

        private void BtnCredits_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Martin Erck" + Environment.NewLine +
                "Hunter Lippert" + Environment.NewLine +
                "Micheal Moore" + Environment.NewLine +
                "John Prosper", "Credits");
        }
    }
}
