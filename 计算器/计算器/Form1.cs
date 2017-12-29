using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 计算器
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_qumo_Click(object sender, EventArgs e)
        {
            try
            {
                int A = Convert.ToInt32(txtA.Text);
                int B = Convert.ToInt32(txtB.Text);
                int qumo = A % B;
                lbResult.Text = qumo.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
