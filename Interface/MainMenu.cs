using System;
using System.Drawing;
using System.Windows.Forms;
using Engine;
using Interface.Properties;

namespace WrathOfTheRuined
{
    public partial class MainMenu : Form
    {
        readonly Music MenuMusic = new Music();
        public MainMenu()
        {
            InitializeComponent();
            Color opac = Color.FromArgb(100, Color.Silver);
            label1.BackColor = opac;
            btnCredits.BackColor = opac;
            btnLoadGame.BackColor = opac;
            btnNewGame.BackColor = opac;
            btnQuit.BackColor = opac;
            MenuMusic.soundplayer = MenuMusic.StartMusic(Resources.MainMenu);
        }

        private void BtnLoadGame_Click(object sender, EventArgs e)
        {
            InputForm NameInput = new InputForm("Enter Save File Name:");
            if (NameInput.ShowDialog(this) == DialogResult.OK)
            {
                // Read the contents of testDialog's TextBox.
                string LoadFileName = NameInput.PlayerNameInputBox.Text;
                NameInput.Dispose();
                var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/Wrath of the Ruined//" + LoadFileName + ".xml";
                if (System.IO.File.Exists(path))
                {
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
                else
                {
                    MessageBox.Show("That file does not exist.", "Load Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnQuit_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Thanks for Playing!"); 
            Application.Exit();
        }

        private void BtnNewGame_Click(object sender, EventArgs e)
        {
            Hide();
            GameScreen game = new GameScreen();
            MenuMusic.StopMusic(MenuMusic.soundplayer);
            game.Show();
        }

        private void BtnCredits_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Martin Erck" + Environment.NewLine +
                "Hunter Lippert" + Environment.NewLine +
                "Michael Moore" + Environment.NewLine +
                "John Prosper", "Credits");
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {

        }
    }
}
