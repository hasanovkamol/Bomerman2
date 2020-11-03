using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bomerman2
{
    public partial class Mani : Form
    {
        public Mani()
        {
            InitializeComponent();
        }

        private void Mani_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 game = new Form1();
            game.timer1.Start();
            game.Show();
            this.Hide();

        }
    }
}
