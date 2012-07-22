using System;
using System.Windows.Forms;
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
            var roller = new Roller();
            roller.AddRollable(new BestOf((Die)20,2));
            var results = roller.Roll(1000000);
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
