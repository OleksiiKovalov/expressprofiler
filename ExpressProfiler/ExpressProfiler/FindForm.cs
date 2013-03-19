using System;
using System.Windows.Forms;

namespace ExpressProfiler
{
    public partial class FindForm : Form
    {
        internal MainForm mainForm;
        public FindForm()
        {
            InitializeComponent();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            mainForm.lastpattern = edPattern.Text;
            mainForm.PerformFind();
        }

        private void edPattern_TextChanged(object sender, EventArgs e)
        {
            mainForm.lastpos = -1;
        }
    }
}
