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
            Parameters defaults = new Parameters();

            defaults.NUM_CPUS = 1;

            defaults.CPU_FREQ = 4000;
            defaults.DRAM_IO_FREQ = 800;

            defaults.ROB_SIZE = 256;
            defaults.PAGE_SIZE = 4096;

            defaults.LQ_SIZE = 72;
            defaults.SQ_SIZE = 56;

            defaults.LQ_WIDTH = 2;
            defaults.SQ_WIDTH = 1;

            defaults.FETCH_WIDTH = 4;
            defaults.DECODE_WIDTH = 4;

            defaults.EXEC_WIDTH = 6;
            defaults.RETIRE_WIDTH = 4;

            defaults.SCHEDULER_SIZE = 100;

            //TLB/CACHE
            defaults.BLOCK_SIZE = 64;
            defaults.MAX_READ_PER_CYCLE = 4;

            //INSTRUCTION TLB
            defaults.ITLB_SET = 16;
            defaults.ITLB_WAY = 4;
            defaults.ITLB_RQ_SIZE = 16;
            defaults.ITLB_WQ_SIZE = 16;
            defaults.ITLB_PQ_SIZE = 0;
            defaults.ITLB_MSHR_SIZE = 8;
            defaults.ITLB_LATENCY = 1;

            //DATA TLB
            defaults.DTLB_SET = 16;
            defaults.DTLB_WAY = 4;
            defaults.DTLB_RQ_SIZE = 16;
            defaults.DTLB_WQ_SIZE = 16;
            defaults.DTLB_PQ_SIZE = 0;
            defaults.DTLB_MSHR_SIZE = 8;
            defaults.DTLB_LATENCY = 1;

            //SECOND LEVEL TLB
            defaults.STLB_SET = 128;
            defaults.STLB_WAY = 12;
            defaults.STLB_RQ_SIZE = 32;
            defaults.STLB_WQ_SIZE = 32;
            defaults.STLB_PQ_SIZE = 0;
            defaults.STLB_MSHR_SIZE = 16;
            defaults.STLB_LATENCY = 8;

            //L1 INSTRUCTION CACHE
            defaults.L1I_SET = 64;
            defaults.L1I_WAY = 8;
            defaults.L1I_RQ_SIZE = 64;
            defaults.L1I_WQ_SIZE = 64;
            defaults.L1I_PQ_SIZE = 64;
            defaults.L1I_MSHR_SIZE = 8;
            defaults.L1I_LATENCY = 1;

            //L1 DATA CACHE
            defaults.L1D_SET = 64;
            defaults.L1D_WAY = 8;
            defaults.L1D_RQ_SIZE = 64;
            defaults.L1D_WQ_SIZE = 64;
            defaults.L1D_PQ_SIZE = 64;
            defaults.L1D_MSHR_SIZE = 8;
            defaults.L1D_LATENCY = 4;

            //L2 CACHE
            defaults.L2C_SET = 512;
            defaults.L2C_WAY = 8;
            defaults.L2C_RQ_SIZE = 32;
            defaults.L2C_WQ_SIZE = 32;
            defaults.L2C_PQ_SIZE = 32;
            defaults.L2C_MSHR_SIZE = 16;
            defaults.L2C_LATENCY = 8;

            //LAST LEVEL CACHE
            defaults.LLC_SET = defaults.NUM_CPUS * 2048;
            defaults.LLC_WAY = 16;
            defaults.LLC_RQ_SIZE = defaults.NUM_CPUS * defaults.L2C_MSHR_SIZE;
            defaults.LLC_WQ_SIZE = defaults.NUM_CPUS * defaults.L2C_MSHR_SIZE;
            defaults.LLC_PQ_SIZE = defaults.NUM_CPUS * defaults.L2C_MSHR_SIZE;
            defaults.LLC_MSHR_SIZE = 32;
            defaults.LLC_LATENCY = 20;

            //DRAM
            defaults.DRAM_CHANNELS = 1;
            defaults.DRAM_BANKS = 8;

            defaults.DRAM_RANKS = 8;
            defaults.DRAM_ROWS = 32768;

            defaults.DRAM_COLUMNS = 32;
            defaults.DRAM_CHANNEL_WIDTH = 8;

            defaults.DRAM_RQ_SIZE = 48;
            defaults.DRAM_WQ_SIZE = 48;

            defaults.tRP_DRAM_CYCLE = 11;
            defaults.tCAS_DRAM_CYCLE = 11;
            defaults.tRCD_DRAM_CYCLE = 11;

            textBox1.Text = defaults.CPU_FREQ.ToString();
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

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        /*private void btn_cpu_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
        }*/
    }
}