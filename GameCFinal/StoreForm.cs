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
            if (priceChange < .5)
                priceChange = .5;
            BindingList<Item> StoreInv = new BindingList<Item>();

            if (storeType == 1) //Blacksmith
            {
                switch (townID)
                {
                    case 0:
                        StoreInv.Add(new Sword(0));
                        StoreInv.Add(new Sword(1));
                        StoreInv.Add(new Sword(2));
                        StoreInv.Add(new Sword(6));
                        StoreInv.Add(new Sword(7));
                        StoreInv.Add(new Sword(8));
                        StoreInv.Add(new Sword(12));
                        StoreInv.Add(new Armor(0));
                        StoreInv.Add(new Armor(1));
                        break;
                    case 1:
                        StoreInv.Add(new Sword(3));
                        StoreInv.Add(new Sword(4));
                        StoreInv.Add(new Sword(5));
                        StoreInv.Add(new Sword(9));
                        StoreInv.Add(new Sword(10));
                        StoreInv.Add(new Sword(11));
                        StoreInv.Add(new Sword(18));
                        StoreInv.Add(new Armor(2));
                        StoreInv.Add(new Armor(3));
                        break;
                    case 2:
                        StoreInv.Add(new Sword(13));
                        StoreInv.Add(new Sword(14));
                        StoreInv.Add(new Sword(15));
                        StoreInv.Add(new Sword(19));
                        StoreInv.Add(new Sword(20));
                        StoreInv.Add(new Sword(21));
                        StoreInv.Add(new Sword(22));
                        StoreInv.Add(new Armor(4));
                        break;
                    case 3:
                        StoreInv.Add(new Sword(23));
                        StoreInv.Add(new Sword(24));
                        StoreInv.Add(new Sword(25));
                        StoreInv.Add(new Sword(26));
                        StoreInv.Add(new Sword(27));
                        StoreInv.Add(new Sword(28));
                        StoreInv.Add(new Sword(29));
                        StoreInv.Add(new Armor(5));
                        break;
                }
            }
            else if (storeType == 2) //Apothecary
            {
                switch (townID)
                {
                    case 0:
                        StoreInv.Add(new Staff(0));
                        StoreInv.Add(new Staff(1));
                        StoreInv.Add(new Staff(2));
                        StoreInv.Add(new Staff(6));
                        StoreInv.Add(new Staff(7));
                        StoreInv.Add(new Staff(8));
                        StoreInv.Add(new Staff(12));
                        StoreInv.Add(new Consumable(1));
                        break;
                    case 1:
                        StoreInv.Add(new Staff(3));
                        StoreInv.Add(new Staff(4));
                        StoreInv.Add(new Staff(5));
                        StoreInv.Add(new Staff(9));
                        StoreInv.Add(new Staff(10));
                        StoreInv.Add(new Staff(11));
                        StoreInv.Add(new Staff(18));
                        StoreInv.Add(new Consumable(2));
                        break;
                    case 2:
                        StoreInv.Add(new Staff(13));
                        StoreInv.Add(new Staff(14));
                        StoreInv.Add(new Staff(15));
                        StoreInv.Add(new Staff(19));
                        StoreInv.Add(new Staff(20));
                        StoreInv.Add(new Staff(21));
                        StoreInv.Add(new Staff(22));
                        StoreInv.Add(new Consumable(3));
                        break;
                    case 3:
                        StoreInv.Add(new Staff(23));
                        StoreInv.Add(new Staff(24));
                        StoreInv.Add(new Staff(25));
                        StoreInv.Add(new Staff(26));
                        StoreInv.Add(new Staff(27));
                        StoreInv.Add(new Staff(28));
                        StoreInv.Add(new Staff(29));
                        StoreInv.Add(new Consumable(4));
                        break;
                }
            }

            buyButton.Click += BuyButton_Click;
            sellButton.Click += SellButton_Click;
            listBoxStoreInv.SelectedIndexChanged += listBoxStoreInv_SelectedIndexChanged;
            listBoxPlayerInv.SelectedIndexChanged += listBoxPlayerInv_SelectedIndexChanged;
            void BuyButton_Click(object sender, EventArgs e)
            {
                if (listBoxStoreInv.SelectedItem != null)
                {
                    Item item = listBoxStoreInv.SelectedItem as Item;
                    int price = Convert.ToInt32(item.Price * 1.5);
                    if (player.Gold >= price)
                    {
                        player.Gold -= price;
                        lblPlayerGold.Text = player.Gold.ToString();
                        player.Inventory.Add(item);
                        StoreInv.Remove(item);
                    }
                    listBoxStoreInv_SelectedIndexChanged(null, null);
                    listBoxPlayerInv_SelectedIndexChanged(null, null);
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
                    int price = Convert.ToInt32(item.Price * .5 / priceChange);
                    player.Gold += price;
                    lblPlayerGold.Text = player.Gold.ToString();
                    player.Inventory.Remove(item);
                    StoreInv.Add(item);
                    listBoxStoreInv_SelectedIndexChanged(null, null);
                    listBoxPlayerInv_SelectedIndexChanged(null, null);
                }
            }

            void listBoxStoreInv_SelectedIndexChanged(object sender, EventArgs e)
            {
                if (listBoxStoreInv.SelectedItem != null)
                {
                    Item item = listBoxStoreInv.SelectedItem as Item;
                    int value = Convert.ToInt32(item.Price * 1.5);
                    lblStoreValue.Text = "Item Value: " + value + " gp";
                }
            }

            void listBoxPlayerInv_SelectedIndexChanged(object sender, EventArgs e)
            {
                if (listBoxPlayerInv.SelectedItem != null)
                {
                    Item item = listBoxPlayerInv.SelectedItem as Item;
                    int value = Convert.ToInt32(item.Price * .5 / priceChange);
                    lblPlayerValue.Text = "Item Value: " + value + " gp";
                }

            }

            listBoxStoreInv.DataSource = StoreInv;
            listBoxStoreInv.DisplayMember = "Name";
        }

        private void leaveButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
