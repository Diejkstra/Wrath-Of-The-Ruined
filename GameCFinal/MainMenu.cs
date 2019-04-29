using System;
using System.Drawing;
using System.Windows.Forms;
using Engine;

namespace WrathOfTheRuined
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
            InputForm NameInput = new InputForm("Enter Save File Name:");
            string LoadFileName = "";
            if (NameInput.ShowDialog(this) == DialogResult.OK)
            {
                // Read the contents of testDialog's TextBox.
                LoadFileName = NameInput.PlayerNameInputBox.Text;
            }
            NameInput.Dispose();
            var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/Wrath Of The Ruined//" + LoadFileName + ".xml";
            Type[] extratypes = new Type[1];
            extratypes[0] = typeof(Consumable);
            System.Xml.Serialization.XmlSerializer reader =
                new System.Xml.Serialization.XmlSerializer(typeof(Player), extratypes);
            System.IO.StreamReader file = new System.IO.StreamReader(@path);
            Player player = (Player)reader.Deserialize(file);
            file.Close();
            MenuMusic.StopMusic(MenuMusic.soundplayer);
            GameScreen game = new GameScreen(player);
            Hide();
            game.Show();
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
            Hide();
            game.Show();
        }

        private void BtnCredits_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Martin Erck" + Environment.NewLine +
                "Hunter Lippert" + Environment.NewLine +
                "Michael Moore" + Environment.NewLine +
                "John Prosper", "Credits");
        }
    }
}
