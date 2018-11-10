using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChampSimBuilder
{
    public partial class ChampSimBuilder : Form
    {
        public ChampSimBuilder()
        {
            InitializeComponent();
        }

        private void cbm_num_cpu_DropDownClosed(object sender, EventArgs e)
        {
            if (cbm_num_cpu.SelectedIndex == 0)
            {
                lbl_cpu_2.Hide();
                txt_cpu_2.Hide();
                btn_cpu_2.Hide();

                lbl_cpu_3.Hide();
                txt_cpu_3.Hide();
                btn_cpu_3.Hide();

                lbl_cpu_4.Hide();
                txt_cpu_4.Hide();
                btn_cpu_4.Hide();

                lbl_cpu_5.Hide();
                txt_cpu_5.Hide();
                btn_cpu_5.Hide();

                lbl_cpu_6.Hide();
                txt_cpu_6.Hide();
                btn_cpu_6.Hide();

                lbl_cpu_7.Hide();
                txt_cpu_7.Hide();
                btn_cpu_7.Hide();

                lbl_cpu_8.Hide(); 
                txt_cpu_8.Hide();
                btn_cpu_8.Hide();
            }
            else if(cbm_num_cpu.SelectedIndex == 1)
            {
                lbl_cpu_2.Show();
                txt_cpu_2.Show();
                btn_cpu_2.Show();

                lbl_cpu_3.Show();
                txt_cpu_3.Show();
                btn_cpu_3.Show();

                lbl_cpu_4.Show();
                txt_cpu_4.Show();
                btn_cpu_4.Show();

                lbl_cpu_5.Hide();
                txt_cpu_5.Hide();
                btn_cpu_5.Hide();

                lbl_cpu_6.Hide();
                txt_cpu_6.Hide();
                btn_cpu_6.Hide();

                lbl_cpu_7.Hide();
                txt_cpu_7.Hide();
                btn_cpu_7.Hide();

                lbl_cpu_8.Hide();
                txt_cpu_8.Hide();
                btn_cpu_8.Hide();
            }
            else
            {
                lbl_cpu_2.Show();
                txt_cpu_2.Show();
                btn_cpu_2.Show();

                lbl_cpu_3.Show();
                txt_cpu_3.Show();
                btn_cpu_3.Show();

                lbl_cpu_4.Show();
                txt_cpu_4.Show();
                btn_cpu_4.Show();

                lbl_cpu_5.Show();
                txt_cpu_5.Show();
                btn_cpu_5.Show();

                lbl_cpu_6.Show();
                txt_cpu_6.Show();
                btn_cpu_6.Show();

                lbl_cpu_7.Show();
                txt_cpu_7.Show();
                btn_cpu_7.Show();

                lbl_cpu_8.Show();
                txt_cpu_8.Show();
                btn_cpu_8.Show();
            }
        }

        /*private void btn_cpu_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
        }*/
    }
}