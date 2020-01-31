using System;
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
    public partial class LevelUpForm : Form
    {
        public LevelUpForm()
        {
            InitializeComponent();
        }
        public int increasedStat = 0;

        private void buttonMaxHP_Click(object sender, EventArgs e)
        {
            increasedStat = 1;
            DialogResult = DialogResult.OK;
        }

        private void buttonStrength_Click(object sender, EventArgs e)
        {
            increasedStat = 2;
            DialogResult = DialogResult.OK;
        }

        private void buttonIntellect_Click(object sender, EventArgs e)
        {
            increasedStat = 3;
            DialogResult = DialogResult.OK;
        }

        private void buttonAP_Click(object sender, EventArgs e)
        {
            increasedStat = 4;
            DialogResult = DialogResult.OK;
        }

        private void buttonMR_Click(object sender, EventArgs e)
        {
            increasedStat = 5;
            DialogResult = DialogResult.OK;
        }
    }
}
