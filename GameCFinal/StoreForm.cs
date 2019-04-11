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

        private void ShowData(Player player)
        {
            listBoxPlayerInv.DataSource = null;
            listBoxPlayerInv.DataSource = player.Inventory;
            listBoxPlayerInv.DisplayMember = "Name";
        }

        public void EnterStore(Player player, int townID, int storeType)
        {
            ShowData(player);

            listBoxStoreInv.Items.Clear();
            lblGold.Text = "Gold:";
            lblGBP.Text = "GBP:";
            lblPlayerGold.Text = player.Gold.ToString();
            lblPlayerGBP.Text = player.GBP.ToString();
            double priceChange = 1 - (player.GBP / 100);    //based on GBP
            if (priceChange <= 0)
                priceChange = .01;
            BindingList<Item> StoreInv = new BindingList<Item>();

            if (storeType == 1) //Blacksmith
            {
                switch (townID)
                {
                    case 0:
                        Sword sword1 = new Sword(20);
                        StoreInv.Add(sword1);
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

            buyButton.Click += BuyButton_Click;
            sellButton.Click += SellButton_Click;
            void BuyButton_Click(object sender, EventArgs e)
            {
                if (listBoxStoreInv.SelectedItem != null)
                {
                    Item item = listBoxStoreInv.SelectedItem as Item;
                    if(player.Gold >= item.Price)
                    {
                        player.Gold -= item.Price;
                        lblPlayerGold.Text = player.Gold.ToString();
                        player.Inventory.Add(item);
                        StoreInv.Remove(item);
                    }
                }
            }

            void SellButton_Click(object sender, EventArgs e)
            {
                if (listBoxPlayerInv.SelectedItem != null)
                {
                    Item item = listBoxPlayerInv.SelectedItem as Item;
                    if (player.sword == item)
                        player.sword = new Sword(-1);
                    if (player.staff == item)
                        player.staff = new Staff(-1);
                    if (player.armor == item)
                        player.armor = new Armor(-1);
                    player.Gold += item.Price;
                    lblPlayerGold.Text = player.Gold.ToString();
                    player.Inventory.Remove(item);
                    StoreInv.Add(item);
                }
            }

            listBoxStoreInv.DataSource = StoreInv;
            listBoxStoreInv.DisplayMember = "Name";
        }

        private void leaveButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void listBoxStoreInv_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxStoreInv.SelectedItem != null)
            {
                double value = 1;
                lblStoreValue.Text = "Item Value: ";
            }
        }
    }
}
