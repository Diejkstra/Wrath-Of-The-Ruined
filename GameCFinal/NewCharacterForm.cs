using System;
using System.Windows.Forms;

namespace WrathOfTheRuined
{
    public partial class NewCharacterForm : Form
    {
        public NewCharacterForm()
        {
            InitializeComponent();
        }

        Decimal OldMaxHP = 150;
        Decimal OldStrength = 5;
        Decimal OldIntellect = 5;
        Decimal OldAP = 10;
        Decimal OldMR = 10;
        int StatPoints = 0;

        private void numMaxHP_ValueChanged(object sender, EventArgs e)
        {
            if (numMaxHP.Value > OldMaxHP)
            {
                if (StatPoints > 0)
                    StatPoints--;
                else
                    numMaxHP.Value = OldMaxHP;
            }
            else if (numMaxHP.Value < OldMaxHP)
            {
                StatPoints++;
            }
            else
            {
                return;
            }
            lblSP.Text = StatPoints.ToString();
            OldMaxHP = numMaxHP.Value;
        }

        private void numStrength_ValueChanged(object sender, EventArgs e)
        {
            if (numStrength.Value > OldStrength)
            {
                if (StatPoints > 0)
                    StatPoints--;
                else
                    numStrength.Value = OldStrength;
            }
            else if (numStrength.Value < OldStrength)
            {
                StatPoints++;
            }
            else
            {
                return;
            }
            lblSP.Text = StatPoints.ToString();
            OldStrength = numStrength.Value;
        }

        private void numIntellect_ValueChanged(object sender, EventArgs e)
        {
            if (numIntellect.Value > OldIntellect)
            {
                if (StatPoints > 0)
                    StatPoints--;
                else
                    numIntellect.Value = OldIntellect;
            }
            else if (numIntellect.Value < OldIntellect)
            {
                StatPoints++;
            }
            else
            {

                return;
            }
            lblSP.Text = StatPoints.ToString();
            OldIntellect = numIntellect.Value;
        }

        private void numAP_ValueChanged(object sender, EventArgs e)
        {
            if (numAP.Value > OldAP)
            {
                if (StatPoints > 0)
                    StatPoints--;
                else
                    numAP.Value = OldAP;
            }
            else if (numAP.Value < OldAP)
            {
                StatPoints++;
            }
            else
            {
                return;
            }
            lblSP.Text = StatPoints.ToString();
            OldAP = numAP.Value;
        }

        private void numMR_ValueChanged(object sender, EventArgs e)
        {
            if (numMR.Value > OldMR)
            {
                if (StatPoints > 0)
                    StatPoints--;
                else
                    numMR.Value = OldMR;
            }
            else if (numMR.Value < OldMR)
            {
                StatPoints++;
            }
            else
            {
                return;
            }
            lblSP.Text = StatPoints.ToString();
            OldMR = numMR.Value;
        }

        private void buttonDone_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
