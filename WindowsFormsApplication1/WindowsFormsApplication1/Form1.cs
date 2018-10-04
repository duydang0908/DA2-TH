using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.FormClosing += Form1_Closing;
        }
        private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to quit?", "My Application", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
        /*private void Form1_Closing(Object sender, FormClosingEventArgs e)
        {
            //In case windows is trying to shut down, don't hold the process up
            if (e.CloseReason == CloseReason.WindowsShutDown) return;

            if (this.DialogResult == DialogResult.Cancel)
            {
                // Assume that X has been clicked and act accordingly.
                // Confirm user wants to close
                switch (MessageBox.Show(this, "Are you sure?", "Do you still want ... ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    //Stay on this form
                    case DialogResult.No:
                        e.Cancel = true;
                        break;
                    default:
                        break;
                }
            }
        }*/
        /*private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // Determine if text has changed in the textbox by comparing to original text.
            if (textBox1.Text != strMyOriginalText)
            {
                if (MessageBox.Show("Do you want to save changes to your text?", "My Application",
                   MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    e.Cancel = true;
                    // Call method to save file...
                }
            }
        }*/
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Clearbtn_Click(object sender, EventArgs e)
        {
            ClearAllText(this);
        }
        void ClearAllText(Control con)
        {
            foreach (Control c in con.Controls)
            {
                if (c is TextBox)
                    ((TextBox)c).Clear();
                else
                    ClearAllText(c);
            }
        }
    }
}
