using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DateTimeChecker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.MinimizeBox = false;
            this.MaximizeBox = false;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Are you sure to exit?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.No)
                e.Cancel = true;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            foreach (var c in this.Controls)
            {
                if (c is TextBox)
                {
                    ((TextBox)c).Text = String.Empty;
                }
            }
        }

        public int checkDayInMonth(short y, byte m)
        {
            if (m == 1 || m == 3 || m == 5 || m == 7 || m == 8 || m == 10 || m == 12)
                return 31;
            else if (m == 4 || m == 6 || m == 9 || m == 11)
                return 30;
            else if (m == 2)
            {
                if (y % 400 == 0)
                    return 29;
                else
                {
                    if (y % 100 == 0)
                        return 28;
                    else
                    {
                        if (y % 4 == 0)
                            return 29;
                        else return 28;
                    }
                }
            }
            else
                return 0;


        }

        public bool isValidDate(short year, byte month, byte day)
        {
            if (month >= 1 && month <= 12)
            {
                if (day >= 1)
                {
                    if (day <= checkDayInMonth(year, month))
                        return true;
                    else
                        return false;
                }
                else
                    return false;
            }
            else
                return false;
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            string day = txtDay.Text.ToString();
            string month = txtMonth.Text.ToString();
            string year = txtYear.Text.ToString();

            int num = 0;
            
            //if (String.IsNullOrEmpty(day) || String.IsNullOrEmpty(month) || String.IsNullOrEmpty(year) || String.IsNullOrWhiteSpace(day) || String.IsNullOrWhiteSpace(month) || String.IsNullOrWhiteSpace(year))
            //{
            //    MessageBox.Show("Please fill full information!!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
            //else
            //{
                if (!int.TryParse(day, out num))
                {
                    MessageBox.Show("Input data for Day is incorrect format", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (int.Parse(day) < 1 || int.Parse(day) > 31)
                {
                    MessageBox.Show("Input data for Day is out of range", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }



                if (!int.TryParse(month, out num))
                {
                    MessageBox.Show("Input data for Month is incorrect format", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (int.Parse(month) < 1 || int.Parse(month) > 12)
                {
                    MessageBox.Show("Input data for Month is out of range", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }



                if (!int.TryParse(year, out num))
                {
                    MessageBox.Show("Input data for Year is incorrect format", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (int.Parse(year) < 1000 || int.Parse(year) > 3000)
                {
                    MessageBox.Show("Input data for Year is out of range", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                if (isValidDate(short.Parse(year), byte.Parse(month), byte.Parse(day)))
                {
                    MessageBox.Show("dd//mm/yy is correct datetime!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
                else
                {
                    MessageBox.Show("dd//mm/yy is incorrect datetime!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }

            //}





        }

        private void txtDay_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMonth_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
