using System;
using System.IO;
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
        Parameters defaults = new Parameters();

        public ChampSimBuilder()
        {
            InitializeComponent();

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
    }

        private void cmb_num_cpu_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmb_num_cpu.SelectedIndex == 0)
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

                txt_cpu_1.Text = "";
                txt_cpu_2.Text = "";
                txt_cpu_3.Text = "";
                txt_cpu_4.Text = "";
                txt_cpu_5.Text = "";
                txt_cpu_6.Text = "";
                txt_cpu_7.Text = "";
                txt_cpu_8.Text = "";
            }
            else if(cmb_num_cpu.SelectedIndex == 1)
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

                txt_cpu_1.Text = "";
                txt_cpu_2.Text = "";
                txt_cpu_3.Text = "";
                txt_cpu_4.Text = "";
                txt_cpu_5.Text = "";
                txt_cpu_6.Text = "";
                txt_cpu_7.Text = "";
                txt_cpu_8.Text = "";
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

                txt_cpu_1.Text = "";
                txt_cpu_2.Text = "";
                txt_cpu_3.Text = "";
                txt_cpu_4.Text = "";
                txt_cpu_5.Text = "";
                txt_cpu_6.Text = "";
                txt_cpu_7.Text = "";
                txt_cpu_8.Text = "";
            }
        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btn_defaults_Click(object sender, EventArgs e)
        {
            cmb_num_cpu.SelectedIndex = 0;

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

            txt_cpu_1.Text = "";
            txt_cpu_2.Text = "";
            txt_cpu_3.Text = "";
            txt_cpu_4.Text = "";
            txt_cpu_5.Text = "";
            txt_cpu_6.Text = "";
            txt_cpu_7.Text = "";
            txt_cpu_8.Text = "";

            cmb_branch_predictor.SelectedIndex = 0;
            cmb_l1d_prefetcher.SelectedIndex = 0;
            cmb_l2c_prefetcher.SelectedIndex = 0;
            cmb_llc_replacement.SelectedIndex = 2;

            txt_cpu_frequency.Text = defaults.CPU_FREQ.ToString();
            txt_dram_io_frequency.Text = defaults.DRAM_IO_FREQ.ToString();

            txt_rob_size.Text = defaults.ROB_SIZE.ToString();
            txt_page_size.Text = defaults.PAGE_SIZE.ToString();

            txt_lq_size.Text = defaults.LQ_SIZE.ToString();
            txt_sq_size.Text = defaults.SQ_SIZE.ToString();

            txt_lq_width.Text = defaults.LQ_WIDTH.ToString();
            txt_sq_width.Text = defaults.SQ_WIDTH.ToString();

            txt_fetch_width.Text = defaults.FETCH_WIDTH.ToString();
            txt_decode_width.Text = defaults.DECODE_WIDTH.ToString();

            txt_execude_width.Text = defaults.EXEC_WIDTH.ToString();
            txt_retire_width.Text = defaults.RETIRE_WIDTH.ToString();

            txt_scheduler_size.Text = defaults.SCHEDULER_SIZE.ToString();

            txt_block_size.Text = defaults.BLOCK_SIZE.ToString();
            txt_max_read_per_cycle.Text = defaults.MAX_READ_PER_CYCLE.ToString();

            txt_set_itlb.Text = defaults.ITLB_SET.ToString();
            txt_way_itlb.Text = defaults.ITLB_WAY.ToString();
            txt_rq_size_itlb.Text = defaults.ITLB_RQ_SIZE.ToString();
            txt_wq_size_itlb.Text = defaults.ITLB_WQ_SIZE.ToString();
            txt_pq_size_itlb.Text = defaults.ITLB_PQ_SIZE.ToString();
            txt_mshr_size_itlb.Text = defaults.ITLB_MSHR_SIZE.ToString();
            txt_latency_itlb.Text = defaults.ITLB_LATENCY.ToString();

            txt_set_dtlb.Text = defaults.DTLB_SET.ToString();
            txt_way_dtlb.Text = defaults.DTLB_WAY.ToString();
            txt_rq_size_dtlb.Text = defaults.DTLB_RQ_SIZE.ToString();
            txt_wq_size_dtlb.Text = defaults.DTLB_WQ_SIZE.ToString();
            txt_pq_size_dtlb.Text = defaults.DTLB_PQ_SIZE.ToString();
            txt_mshr_size_dtlb.Text = defaults.DTLB_MSHR_SIZE.ToString();
            txt_latency_dtlb.Text = defaults.DTLB_LATENCY.ToString();

            txt_set_stlb.Text = defaults.STLB_SET.ToString();
            txt_way_stlb.Text = defaults.STLB_WAY.ToString();
            txt_rq_size_stlb.Text = defaults.STLB_RQ_SIZE.ToString();
            txt_wq_size_stlb.Text = defaults.STLB_WQ_SIZE.ToString();
            txt_pq_size_stlb.Text = defaults.STLB_PQ_SIZE.ToString();
            txt_mshr_size_stlb.Text = defaults.STLB_MSHR_SIZE.ToString();
            txt_latency_stlb.Text = defaults.STLB_LATENCY.ToString();

            txt_set_l1ic.Text = defaults.L1I_SET.ToString();
            txt_way_l1ic.Text = defaults.L1I_WAY.ToString();
            txt_rq_size_l1ic.Text = defaults.L1I_RQ_SIZE.ToString();
            txt_wq_size_l1ic.Text = defaults.L1I_WQ_SIZE.ToString();
            txt_pq_size_l1ic.Text = defaults.L1I_PQ_SIZE.ToString();
            txt_mshr_size_l1ic.Text = defaults.L1I_MSHR_SIZE.ToString();
            txt_latency_l1ic.Text = defaults.L1I_LATENCY.ToString();

            txt_set_l2c.Text = defaults.L2C_SET.ToString();
            txt_way_l2c.Text = defaults.L2C_WAY.ToString();
            txt_rq_size_l2c.Text = defaults.L2C_RQ_SIZE.ToString();
            txt_wq_size_l2c.Text = defaults.L2C_WQ_SIZE.ToString();
            txt_pq_size_l2c.Text = defaults.L2C_PQ_SIZE.ToString();
            txt_mshr_size_l2c.Text = defaults.L2C_MSHR_SIZE.ToString();
            txt_latency_l2c.Text = defaults.L2C_LATENCY.ToString();

            txt_set_llc.Text = defaults.LLC_SET.ToString();
            txt_way_llc.Text = defaults.LLC_WAY.ToString();
            txt_rq_size_llc.Text = defaults.LLC_RQ_SIZE.ToString();
            txt_wq_size_llc.Text = defaults.LLC_WQ_SIZE.ToString();
            txt_pq_size_llc.Text = defaults.LLC_PQ_SIZE.ToString();
            txt_mshr_size_llc.Text = defaults.LLC_MSHR_SIZE.ToString();
            txt_latency_llc.Text = defaults.LLC_LATENCY.ToString();

            txt_channels.Text = defaults.DRAM_CHANNELS.ToString();
            txt_banks.Text = defaults.DRAM_BANKS.ToString();

            txt_ranks.Text = defaults.DRAM_RANKS.ToString();
            txt_rows.Text = defaults.DRAM_ROWS.ToString();

            txt_columns.Text = defaults.DRAM_COLUMNS.ToString();
            txt_channel_width.Text = defaults.DRAM_CHANNEL_WIDTH.ToString();

            txt_dram_rq_size.Text = defaults.DRAM_RQ_SIZE.ToString();
            txt_dram_wq_size.Text = defaults.DRAM_WQ_SIZE.ToString();

            txt_trp.Text = defaults.tRP_DRAM_CYCLE.ToString();
            txt_tcas.Text = defaults.tCAS_DRAM_CYCLE.ToString();
            txt_trcd.Text = defaults.tRCD_DRAM_CYCLE.ToString();
        }

        private void btn_cpu_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Trace File (*.trace.gz)|*.trace.gz";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;
                    var fileStream = openFileDialog.OpenFile();

                    switch (button.Name)
                    {
                        case "btn_cpu_1":
                            txt_cpu_1.Text = filePath;
                            break;
                        case "btn_cpu_2":
                            txt_cpu_2.Text = filePath;
                            break;
                        case "btn_cpu_3":
                            txt_cpu_3.Text = filePath;
                            break;
                        case "btn_cpu_4":
                            txt_cpu_4.Text = filePath;
                            break;
                        case "btn_cpu_5":
                            txt_cpu_5.Text = filePath;
                            break;
                        case "btn_cpu_6":
                            txt_cpu_6.Text = filePath;
                            break;
                        case "btn_cpu_7":
                            txt_cpu_7.Text = filePath;
                            break;
                        case "btn_cpu_8":
                            txt_cpu_8.Text = filePath;
                            break;
                    }
                }
            }
        }

        private void cmb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var comboBox = sender as ComboBox;

            switch (comboBox.Name)
            {
                case "cmb_branch_predictor":
                    if (cmb_branch_predictor.SelectedIndex == 3)
                    {
                        var fileContent = string.Empty;
                        var filePath = string.Empty;

                        using (OpenFileDialog openFileDialog = new OpenFileDialog())
                        {
                            openFileDialog.Filter = "C# Source File (*.cs)|*.cs";

                            if (openFileDialog.ShowDialog() == DialogResult.OK)
                            {
                                filePath = openFileDialog.FileName;
                                var fileStream = openFileDialog.OpenFile();
                                using (StreamReader reader = new StreamReader(fileStream))
                                {
                                    fileContent = reader.ReadToEnd();
                                }
                                cmb_branch_predictor.Items[3] = filePath.Substring(filePath.LastIndexOf('\\') + 1, filePath.IndexOf(".") - filePath.LastIndexOf("\\") - 1);
                            }
                        }
                    }
                    break;
                case "cmb_l1d_prefetcher":
                    if (cmb_l1d_prefetcher.SelectedIndex == 2)
                    {
                        var fileContent = string.Empty;
                        var filePath = string.Empty;

                        using (OpenFileDialog openFileDialog = new OpenFileDialog())
                        {
                            openFileDialog.Filter = "C# Source File (*.cs)|*.cs";

                            if (openFileDialog.ShowDialog() == DialogResult.OK)
                            {
                                filePath = openFileDialog.FileName;
                                var fileStream = openFileDialog.OpenFile();
                                using (StreamReader reader = new StreamReader(fileStream))
                                {
                                    fileContent = reader.ReadToEnd();
                                }
                                cmb_l1d_prefetcher.Items[2] = filePath.Substring(filePath.LastIndexOf('\\') + 1, filePath.IndexOf(".") - filePath.LastIndexOf("\\") - 1);
                            }
                        }
                    }
                    break;
                case "cmb_l2c_prefetcher":
                    if (cmb_l2c_prefetcher.SelectedIndex == 5)
                    {
                        var fileContent = string.Empty;
                        var filePath = string.Empty;

                        using (OpenFileDialog openFileDialog = new OpenFileDialog())
                        {
                            openFileDialog.Filter = "C# Source File (*.cs)|*.cs";

                            if (openFileDialog.ShowDialog() == DialogResult.OK)
                            {
                                filePath = openFileDialog.FileName;
                                var fileStream = openFileDialog.OpenFile();
                                using (StreamReader reader = new StreamReader(fileStream))
                                {
                                    fileContent = reader.ReadToEnd();
                                }
                                cmb_l2c_prefetcher.Items[5] = filePath.Substring(filePath.LastIndexOf('\\') + 1, filePath.IndexOf(".") - filePath.LastIndexOf("\\") - 1);
                            }
                        }
                    }
                    break;
                case "cmb_llc_replacement":
                    if (cmb_llc_replacement.SelectedIndex == 5)
                    {
                        var fileContent = string.Empty;
                        var filePath = string.Empty;

                        using (OpenFileDialog openFileDialog = new OpenFileDialog())
                        {
                            openFileDialog.Filter = "C# Source File (*.cs)|*.cs";

                            if (openFileDialog.ShowDialog() == DialogResult.OK)
                            {
                                filePath = openFileDialog.FileName;
                                var fileStream = openFileDialog.OpenFile();
                                using (StreamReader reader = new StreamReader(fileStream))
                                {
                                    fileContent = reader.ReadToEnd();
                                }
                                cmb_llc_replacement.Items[5] = filePath.Substring(filePath.LastIndexOf('\\') + 1, filePath.IndexOf(".") - filePath.LastIndexOf("\\") - 1);
                            }
                        }
                    }
                    break;
            }
        }

        private void cmb_DropDown(object sender, EventArgs e)
        {
            cmb_branch_predictor.Items[3] = "<New>";
            cmb_l1d_prefetcher.Items[2] = "<New>";
            cmb_l2c_prefetcher.Items[5] = "<New>";
            cmb_llc_replacement.Items[5] = "<New>";
        }

        private void btn_compile_Click(object sender, EventArgs e)
        {
            string branch_predictor = @"C:\Users\chris\source\repos\ChampSim\Branch Predictors\";

            switch (cmb_branch_predictor.SelectedIndex)
            {
                case 0:
                    branch_predictor += "Bimodal.cs";
                    break;
                case 1:
                    branch_predictor += "Gshare.cs";
                    break;
                case 2:
                    branch_predictor += "Perceptron.cs";
                    break;
                case 3:
                    branch_predictor += "Bimodal.cs";
                    break;
                default:
                    MessageBox.Show("Please select one Branch predictor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }

            var fileContent = string.Empty;

            using (StreamReader reader = new StreamReader(branch_predictor))
            {
                fileContent = reader.ReadToEnd();
            }
        }
    }
}