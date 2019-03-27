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
    public partial class ChangeStanceForm : Form
    {
        public ChangeStanceForm()
        {
            InitializeComponent();
        }
        public int stanceChange;
        private void Defensive_Click(object sender, EventArgs e)
        {
            stanceChange = 1;
            this.DialogResult = DialogResult.OK;
        }

        private void Neutral_Click(object sender, EventArgs e)
        {
            stanceChange = 2;
            this.DialogResult = DialogResult.OK;
        }

        private void Aggressive_Click(object sender, EventArgs e)
        {
            stanceChange = 3;
            this.DialogResult = DialogResult.OK;
        }

        private void ChangeStanceForm_Load(object sender, EventArgs e)
        {

        }
    }
}
