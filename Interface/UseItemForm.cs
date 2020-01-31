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
    public partial class UseItemForm : Form
    {
        public UseItemForm()
        {
            InitializeComponent();
        }

        private void ShowData(Player player)
        {
            listBoxPlayerInv.DataSource = null;
            listBoxPlayerInv.DataSource = player.Inventory;
            listBoxPlayerInv.DisplayMember = "Name";
        }

        public Consumable UseThisItem = null;

        public void ChooseItem(Player player)
        {
            buttonUseItem.Enabled = false;
            ShowData(player);
            BindingList<Item> StoreInv = new BindingList<Item>();
            listBoxPlayerInv.SelectedIndexChanged += listBoxPlayerInv_SelectedIndexChanged;

            void listBoxPlayerInv_SelectedIndexChanged(object sender, EventArgs e)
            {
                if (listBoxPlayerInv.SelectedItem != null)
                {
                    Item item = listBoxPlayerInv.SelectedItem as Item;
                    if(item is Consumable)
                    {
                        Consumable useItem = item as Consumable;
                        buttonUseItem.Enabled = true;
                        UseThisItem = useItem;
                    }
                    else
                    {
                        UseThisItem = null;
                        buttonUseItem.Enabled = false;
                    }
                }
            }
        }

        private void buttonUseItem_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            UseThisItem = null;
            DialogResult = DialogResult.OK;
        }
    }
}
