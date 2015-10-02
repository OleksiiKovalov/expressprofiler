using System;
using System.Windows.Forms;

namespace ExpressProfiler
{
    public partial class FindForm : Form
    {
        private MainForm m_mainForm;

        public FindForm(MainForm f)
        {
            InitializeComponent();

            m_mainForm = f;

            // Set the control values to the last find performed.
            edPattern.Text = m_mainForm.lastpattern;
            chkCase.Checked = m_mainForm.matchCase;
            chkWholeWord.Checked = m_mainForm.wholeWord;
        }

        private void btnFindNext_Click(object sender, EventArgs e)
        {
            DoFind(true);
        }

        private void btnFindPrevious_Click(object sender, EventArgs e)
        {
            DoFind(false);
        }

        private void DoFind(bool forwards)
        {
            m_mainForm.lastpattern = edPattern.Text;
            m_mainForm.matchCase = chkCase.Checked;
            m_mainForm.wholeWord = chkWholeWord.Checked;
            m_mainForm.PerformFind(forwards, chkWrapAround.Checked);
        }

        private void edPattern_TextChanged(object sender, EventArgs e)
        {
            m_mainForm.lastpos = -1;
        }
    }
}
