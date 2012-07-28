using System;
using System.Windows.Forms;
using DiceRoller.Counts;
using DiceRoller.Rollers;

namespace DiceRoller
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnRollClick(object sender, EventArgs e)
        {
            var results = Best.Of(Three.D(6)).Roll(10000);
            txtResults.Text = string.Empty;
            for (var i = results.MinValue; i <= results.MaxValue; i++)
            {
                if (txtResults.Text != string.Empty)
                {
                    txtResults.Text += Environment.NewLine;
                }
                txtResults.Text += i + " - " + results[i];
            }
        }
    }
}
