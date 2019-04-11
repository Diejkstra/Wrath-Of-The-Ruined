using System;
using Engine;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WrathOfTheRuined
{
    public partial class StoreForm : Form
    {
        public StoreForm()
        {
            InitializeComponent();
        }

        public void EnterStore(Player player, int townID, int storeType)
        {

            listBoxPlayerInv.Items.Clear();
            listBoxStoreInv.Items.Clear();
            lblGold.Text = "Gold:";
            lblGBP.Text = "GBP:";
            lblPlayerGold.Text = player.Gold.ToString();
            lblPlayerGBP.Text = player.GBP.ToString();

            listBoxPlayerInv.DataSource = player.Inventory;
            listBoxPlayerInv.DisplayMember = "StoreName";

            List<Item> StoreInv = new List<Item>();
            listBoxStoreInv.DataSource = StoreInv;  
            listBoxStoreInv.DisplayMember = "StoreName";

            if (storeType == 1) //Blacksmith
            {
                switch (townID)
                {
                    case 0: 
                        break;
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                }
            }
            else if (storeType == 2) //Apothecary
            {
                switch (townID)
                {
                    case 0:
                        break;
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                }
            }
        }

        private void leaveButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
