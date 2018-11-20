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
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ChampSimBuilder
{
    public partial class ChampSimBuilder : Form
    {
        Parameters defaults = new Parameters();

        public string new_branch_predictor;
        public string new_l1d_prefetcher;
        public string new_l2c_prefetcher;
        public string new_llc_replacement;
        public string solution = Directory.GetCurrentDirectory();
        public string name = "ChampSim";

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
            defaults.ITLB_MSHR_SIZE = 8;
            defaults.ITLB_LATENCY = 1;

            //DATA TLB
            defaults.DTLB_SET = 16;
            defaults.DTLB_WAY = 4;
            defaults.DTLB_RQ_SIZE = 16;
            defaults.DTLB_WQ_SIZE = 16;
            defaults.DTLB_MSHR_SIZE = 8;
            defaults.DTLB_LATENCY = 1;

            //SECOND LEVEL TLB
            defaults.STLB_SET = 128;
            defaults.STLB_WAY = 12;
            defaults.STLB_RQ_SIZE = 32;
            defaults.STLB_WQ_SIZE = 32;
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

            defaults.WARMUP_INST = 1000000;
            defaults.SIM_INST = 10000000;
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

                txt_cpu_1.Text = "Choose trace file";
                txt_cpu_2.Text = "Choose trace file";
                txt_cpu_3.Text = "Choose trace file";
                txt_cpu_4.Text = "Choose trace file";
                txt_cpu_5.Text = "Choose trace file";
                txt_cpu_6.Text = "Choose trace file";
                txt_cpu_7.Text = "Choose trace file";
                txt_cpu_8.Text = "Choose trace file";

                txt_set_llc.Text = (2048 * 1).ToString();
                if (!(String.IsNullOrEmpty(txt_mshr_size_l2c.Text)))
                {
                    txt_rq_size_llc.Text = (1 * int.Parse(txt_mshr_size_l2c.Text)).ToString();
                    txt_wq_size_llc.Text = (1 * int.Parse(txt_mshr_size_l2c.Text)).ToString();
                    txt_pq_size_llc.Text = (1 * int.Parse(txt_mshr_size_l2c.Text)).ToString();
                }
                else
                {
                    txt_rq_size_llc.Text = "0";
                    txt_wq_size_llc.Text = "0";
                    txt_pq_size_llc.Text = "0";
                }
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

                txt_cpu_1.Text = "Choose trace file";
                txt_cpu_2.Text = "Choose trace file";
                txt_cpu_3.Text = "Choose trace file";
                txt_cpu_4.Text = "Choose trace file";
                txt_cpu_5.Text = "Choose trace file";
                txt_cpu_6.Text = "Choose trace file";
                txt_cpu_7.Text = "Choose trace file";
                txt_cpu_8.Text = "Choose trace file";

                txt_set_llc.Text = (2048 * 4).ToString();
                if (!(String.IsNullOrEmpty(txt_mshr_size_l2c.Text)))
                {
                    txt_rq_size_llc.Text = (4 * int.Parse(txt_mshr_size_l2c.Text)).ToString();
                    txt_wq_size_llc.Text = (4 * int.Parse(txt_mshr_size_l2c.Text)).ToString();
                    txt_pq_size_llc.Text = (4 * int.Parse(txt_mshr_size_l2c.Text)).ToString();
                }
                else
                {
                    txt_rq_size_llc.Text = "0";
                    txt_wq_size_llc.Text = "0";
                    txt_pq_size_llc.Text = "0";
                }
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

                txt_cpu_1.Text = "Choose trace file";
                txt_cpu_2.Text = "Choose trace file";
                txt_cpu_3.Text = "Choose trace file";
                txt_cpu_4.Text = "Choose trace file";
                txt_cpu_5.Text = "Choose trace file";
                txt_cpu_6.Text = "Choose trace file";
                txt_cpu_7.Text = "Choose trace file";
                txt_cpu_8.Text = "Choose trace file";

                txt_set_llc.Text = (2048 * 8).ToString();
                if (!(String.IsNullOrEmpty(txt_mshr_size_l2c.Text)))
                {
                    txt_rq_size_llc.Text = (8 * int.Parse(txt_mshr_size_l2c.Text)).ToString();
                    txt_wq_size_llc.Text = (8 * int.Parse(txt_mshr_size_l2c.Text)).ToString();
                    txt_pq_size_llc.Text = (8 * int.Parse(txt_mshr_size_l2c.Text)).ToString();
                }
                else
                {
                    txt_rq_size_llc.Text = "0";
                    txt_wq_size_llc.Text = "0";
                    txt_pq_size_llc.Text = "0";
                }
            }
        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btn_defaults_Click(object sender, EventArgs e)
        {
            reset_to_defaults();
        }

        private void reset_to_defaults()
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

            txt_cpu_1.Text = "Choose trace file";
            txt_cpu_2.Text = "Choose trace file";
            txt_cpu_3.Text = "Choose trace file";
            txt_cpu_4.Text = "Choose trace file";
            txt_cpu_5.Text = "Choose trace file";
            txt_cpu_6.Text = "Choose trace file";
            txt_cpu_7.Text = "Choose trace file";
            txt_cpu_8.Text = "Choose trace file";

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
            txt_mshr_size_itlb.Text = defaults.ITLB_MSHR_SIZE.ToString();
            txt_latency_itlb.Text = defaults.ITLB_LATENCY.ToString();

            txt_set_dtlb.Text = defaults.DTLB_SET.ToString();
            txt_way_dtlb.Text = defaults.DTLB_WAY.ToString();
            txt_rq_size_dtlb.Text = defaults.DTLB_RQ_SIZE.ToString();
            txt_wq_size_dtlb.Text = defaults.DTLB_WQ_SIZE.ToString();
            txt_mshr_size_dtlb.Text = defaults.DTLB_MSHR_SIZE.ToString();
            txt_latency_dtlb.Text = defaults.DTLB_LATENCY.ToString();

            txt_set_stlb.Text = defaults.STLB_SET.ToString();
            txt_way_stlb.Text = defaults.STLB_WAY.ToString();
            txt_rq_size_stlb.Text = defaults.STLB_RQ_SIZE.ToString();
            txt_wq_size_stlb.Text = defaults.STLB_WQ_SIZE.ToString();
            txt_mshr_size_stlb.Text = defaults.STLB_MSHR_SIZE.ToString();
            txt_latency_stlb.Text = defaults.STLB_LATENCY.ToString();

            txt_set_l1ic.Text = defaults.L1I_SET.ToString();
            txt_way_l1ic.Text = defaults.L1I_WAY.ToString();
            txt_rq_size_l1ic.Text = defaults.L1I_RQ_SIZE.ToString();
            txt_wq_size_l1ic.Text = defaults.L1I_WQ_SIZE.ToString();
            txt_pq_size_l1ic.Text = defaults.L1I_PQ_SIZE.ToString();
            txt_mshr_size_l1ic.Text = defaults.L1I_MSHR_SIZE.ToString();
            txt_latency_l1ic.Text = defaults.L1I_LATENCY.ToString();

            txt_set_l1dc.Text = defaults.L1D_SET.ToString();
            txt_way_l1dc.Text = defaults.L1D_WAY.ToString();
            txt_rq_size_l1dc.Text = defaults.L1D_RQ_SIZE.ToString();
            txt_wq_size_l1dc.Text = defaults.L1D_WQ_SIZE.ToString();
            txt_pq_size_l1dc.Text = defaults.L1D_PQ_SIZE.ToString();
            txt_mshr_size_l1dc.Text = defaults.L1D_MSHR_SIZE.ToString();
            txt_latency_l1dc.Text = defaults.L1D_LATENCY.ToString();

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

            txt_warmup_instr.Text = defaults.WARMUP_INST.ToString();
            txt_sim_instr.Text = defaults.SIM_INST.ToString();
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
                        using (OpenFileDialog openFileDialog = new OpenFileDialog())
                        {
                            openFileDialog.Filter = "C# Source File (*.cs)|*.cs";

                            if (openFileDialog.ShowDialog() == DialogResult.OK)
                            {
                                new_branch_predictor = openFileDialog.FileName;
                                cmb_branch_predictor.Items[3] = new_branch_predictor.Substring(new_branch_predictor.LastIndexOf('\\') + 1, new_branch_predictor.IndexOf(".") - new_branch_predictor.LastIndexOf("\\") - 1);
                            }
                        }
                    }
                    break;
                case "cmb_l1d_prefetcher":
                    if (cmb_l1d_prefetcher.SelectedIndex == 2)
                    {
                        using (OpenFileDialog openFileDialog = new OpenFileDialog())
                        {
                            openFileDialog.Filter = "C# Source File (*.cs)|*.cs";

                            if (openFileDialog.ShowDialog() == DialogResult.OK)
                            {
                                new_l1d_prefetcher = openFileDialog.FileName;
                                cmb_l1d_prefetcher.Items[2] = new_l1d_prefetcher.Substring(new_l1d_prefetcher.LastIndexOf('\\') + 1, new_l1d_prefetcher.IndexOf(".") - new_l1d_prefetcher.LastIndexOf("\\") - 1);
                            }
                        }
                    }
                    break;
                case "cmb_l2c_prefetcher":
                    if (cmb_l2c_prefetcher.SelectedIndex == 5)
                    {
                        using (OpenFileDialog openFileDialog = new OpenFileDialog())
                        {
                            openFileDialog.Filter = "C# Source File (*.cs)|*.cs";

                            if (openFileDialog.ShowDialog() == DialogResult.OK)
                            {
                                new_l2c_prefetcher = openFileDialog.FileName;
                                cmb_l2c_prefetcher.Items[5] = new_l2c_prefetcher.Substring(new_l2c_prefetcher.LastIndexOf('\\') + 1, new_l2c_prefetcher.IndexOf(".") - new_l2c_prefetcher.LastIndexOf("\\") - 1);
                            }
                        }
                    }
                    break;
                case "cmb_llc_replacement":
                    if (cmb_llc_replacement.SelectedIndex == 4)
                    {
                        using (OpenFileDialog openFileDialog = new OpenFileDialog())
                        {
                            openFileDialog.Filter = "C# Source File (*.cs)|*.cs";

                            if (openFileDialog.ShowDialog() == DialogResult.OK)
                            {
                                new_llc_replacement = openFileDialog.FileName;
                                cmb_llc_replacement.Items[5] = new_llc_replacement.Substring(new_llc_replacement.LastIndexOf('\\') + 1, new_llc_replacement.IndexOf(".") - new_llc_replacement.LastIndexOf("\\") - 1);
                            }
                        }
                    }
                    break;
            }
        }

        private void cmb_DropDown(object sender, EventArgs e)
        {
            cmb_branch_predictor.Items[3] = "Custom";
            cmb_l1d_prefetcher.Items[2] = "Custom";
            cmb_l2c_prefetcher.Items[5] = "Custom";
            cmb_llc_replacement.Items[4] = "Custom";
        }

        private void btn_compile_Click(object sender, EventArgs e)
        {
            if (cmb_num_cpu.SelectedIndex == 0)
            {
                if (txt_cpu_1.Text.Equals("Choose trace file"))
                {
                    MessageBox.Show("Please select a trace file!", "Error");
                    return;
                }
            }
            else if (cmb_num_cpu.SelectedIndex == 1)
            {
                if (txt_cpu_1.Text.Equals("Choose trace file") || txt_cpu_2.Text.Equals("Choose trace file") || txt_cpu_3.Text.Equals("Choose trace file") || txt_cpu_4.Text.Equals("Choose trace file"))
                {
                    MessageBox.Show("Please select a trace file!", "Error");
                    return;
                }
            }
            else if (cmb_num_cpu.SelectedIndex == 2)
            {
                if (txt_cpu_1.Text.Equals("Choose trace file") || txt_cpu_2.Text.Equals("Choose trace file") || txt_cpu_3.Text.Equals("Choose trace file") || txt_cpu_4.Text.Equals("Choose trace file") || txt_cpu_5.Text.Equals("Choose trace file") || txt_cpu_6.Text.Equals("Choose trace file") || txt_cpu_7.Text.Equals("Choose trace file") || txt_cpu_8.Text.Equals("Choose trace file"))
                {
                    MessageBox.Show("Please select a trace file!", "Error");
                    return;
                }
            }

            foreach (Control x in tlp_cpu2.Controls)
            {
                if (x is TextBox & String.IsNullOrEmpty(x.Text))
                {
                    MessageBox.Show("Please fill all parameters!", "Error");
                    return;
                }
            }

            foreach (Control x in tlp_tlb_cache.Controls)
            {
                if (x is TextBox & String.IsNullOrEmpty(x.Text))
                {
                    MessageBox.Show("Please fill all parameters!", "Error");
                    return;
                }
            }

            foreach (Control x in tlp_dram.Controls)
            {
                if (x is TextBox & String.IsNullOrEmpty(x.Text))
                {
                    MessageBox.Show("Please fill all parameters!", "Error");
                    return;
                }
            }

            string branch_predictor = Directory.GetCurrentDirectory() + "\\Branch Predictors\\";
            string l1d_prefetcher = Directory.GetCurrentDirectory() + "\\L1D Prefetchers\\";
            string l2c_prefetcher = Directory.GetCurrentDirectory() + "\\L2C Prefetchers\\";
            string llc_replacement = Directory.GetCurrentDirectory() + "\\LLC Replacements\\";

            switch (cmb_branch_predictor.SelectedIndex)
            {
                case 1:
                    branch_predictor += "Gshare.cs";
                    break;
                case 2:
                    branch_predictor += "Perceptron.cs";
                    break;
                case 3:
                    branch_predictor = new_branch_predictor;
                    break;
                default:
                    branch_predictor += "Bimodal.cs";
                    break;
            }

            switch (cmb_l1d_prefetcher.SelectedIndex)
            {
                case 1:
                    l1d_prefetcher += "New line.cs";
                    break;
                case 2:
                    l1d_prefetcher = new_l1d_prefetcher;
                    break;
                default:
                    l1d_prefetcher += "Empty.cs";
                    break;
            }

            switch (cmb_l2c_prefetcher.SelectedIndex)
            {
                case 1:
                    l2c_prefetcher += "Ip stride.cs";
                    break;
                case 2:
                    l2c_prefetcher += "Kpcp.cs";
                    break;
                case 3:
                    l2c_prefetcher += "Next line.cs";
                    break;
                case 4:
                    l2c_prefetcher += "Spp dev.cs";
                    break;
                case 5:
                    l2c_prefetcher = new_l2c_prefetcher;
                    break;
                default:
                    l2c_prefetcher += "Empty.cs";
                    break;
            }

            switch (cmb_llc_replacement.SelectedIndex)
            {
                case 0:
                    llc_replacement += "Drrip.cs";
                    break;
                case 2:
                    llc_replacement += "Ship.cs";
                    break;
                case 3:
                    l2c_prefetcher += "Srrip.cs";
                    break;
                case 4:
                    l2c_prefetcher = new_l2c_prefetcher;
                    break;
                default:
                    l2c_prefetcher += "Lru.cs";
                    break;
            }

            try
            {
                string OriginalBranch = branch_predictor;
                string OriginalL1D = l1d_prefetcher;
                string OriginalL2C = l2c_prefetcher;
                string OriginalLLC = llc_replacement;


                string OriginalMain = Directory.GetCurrentDirectory() + "\\MainPr.cs";
                string OriginalGlobals = Directory.GetCurrentDirectory() + "\\Globals.cs";

                string BacMain = Directory.GetCurrentDirectory() + "\\MainPr.cs.bac";
                string BacGlobals = Directory.GetCurrentDirectory() + "\\Globals.cs.bac";

                string ReplaceBranch = Directory.GetCurrentDirectory() + "\\Branch_Predictor.cs";
                string ReplaceL1D = Directory.GetCurrentDirectory() + "\\L1d_prefetcher.cs";
                string ReplaceL2C = Directory.GetCurrentDirectory() + "\\L2c_prefetcher.cs";
                string ReplaceLLC = Directory.GetCurrentDirectory() + "\\llc_replacement.cs";

                File.Copy(OriginalBranch, ReplaceBranch, true);
                File.Copy(OriginalL1D, ReplaceL1D, true);
                File.Copy(OriginalL2C, ReplaceL2C, true);
                File.Copy(OriginalLLC, ReplaceLLC, true);

                File.Copy(OriginalMain, BacMain, true);
                string text = File.ReadAllText(OriginalMain);

                if (cmb_num_cpu.SelectedIndex == 0)
                {
                    text = text.Replace("Globals.ooo_cpu[0].filePath = @\"\";", "Globals.ooo_cpu[0].filePath = @\"" + txt_cpu_1.Text + "\"" + ";");
                    File.WriteAllText(OriginalMain, text);
                }
                else if (cmb_num_cpu.SelectedIndex == 1)
                {
                    text = text.Replace("Globals.ooo_cpu[0].filePath = @\"\";", "Globals.ooo_cpu[0].filePath = @\"" + txt_cpu_1.Text + "\"" + ";");
                    text = text.Replace("Globals.ooo_cpu[1].filePath = @\"\";", "Globals.ooo_cpu[1].filePath = @\"" + txt_cpu_2.Text + "\"" + ";");
                    text = text.Replace("Globals.ooo_cpu[2].filePath = @\"\";", "Globals.ooo_cpu[2].filePath = @\"" + txt_cpu_3.Text + "\"" + ";");
                    text = text.Replace("Globals.ooo_cpu[3].filePath = @\"\";", "Globals.ooo_cpu[3].filePath = @\"" + txt_cpu_4.Text + "\"" + ";");
                    File.WriteAllText(OriginalMain, text);
                }
                else if (cmb_num_cpu.SelectedIndex == 2)
                {
                    text = text.Replace("Globals.ooo_cpu[0].filePath = @\"\";", "Globals.ooo_cpu[0].filePath = @\"" + txt_cpu_1.Text + "\"" + ";");
                    text = text.Replace("Globals.ooo_cpu[1].filePath = @\"\";", "Globals.ooo_cpu[1].filePath = @\"" + txt_cpu_2.Text + "\"" + ";");
                    text = text.Replace("Globals.ooo_cpu[2].filePath = @\"\";", "Globals.ooo_cpu[2].filePath = @\"" + txt_cpu_3.Text + "\"" + ";");
                    text = text.Replace("Globals.ooo_cpu[3].filePath = @\"\";", "Globals.ooo_cpu[3].filePath = @\"" + txt_cpu_4.Text + "\"" + ";");
                    text = text.Replace("Globals.ooo_cpu[4].filePath = @\"\";", "Globals.ooo_cpu[4].filePath = @\"" + txt_cpu_5.Text + "\"" + ";");
                    text = text.Replace("Globals.ooo_cpu[5].filePath = @\"\";", "Globals.ooo_cpu[5].filePath = @\"" + txt_cpu_6.Text + "\"" + ";");
                    text = text.Replace("Globals.ooo_cpu[6].filePath = @\"\";", "Globals.ooo_cpu[6].filePath = @\"" + txt_cpu_7.Text + "\"" + ";");
                    text = text.Replace("Globals.ooo_cpu[7].filePath = @\"\";", "Globals.ooo_cpu[7].filePath = @\"" + txt_cpu_8.Text + "\"" + ";");
                    File.WriteAllText(OriginalMain, text);
                }

                File.Copy(OriginalGlobals, BacGlobals, true);
                text = File.ReadAllText(OriginalGlobals);

                text = text.Replace("public const int NUM_CPUS = 1;", "public const int NUM_CPUS = " + cmb_num_cpu.SelectedValue + ";");

                text = text.Replace("public static ulong warmup_instructions = 1000000, simulation_instructions = 10000000;", "public static ulong warmup_instructions = " + txt_warmup_instr.Text + ", simulation_instructions = " + txt_sim_instr.Text + ";");

                text = text.Replace("public const int CPU_FREQ = 4000;", "public const int CPU_FREQ = " + txt_cpu_frequency.Text + ";");
                text = text.Replace("public const int DRAM_IO_FREQ = 800;", "public const int DRAM_IO_FREQ = " + txt_dram_io_frequency.Text + ";");

                text = text.Replace("public const int ROB_SIZE = 256;", "public const int ROB_SIZE = " + txt_rob_size.Text + ";");
                text = text.Replace("public const int PAGE_SIZE = 4096;", "public const int PAGE_SIZE = " + txt_page_size.Text + ";");

                text = text.Replace("public const int LQ_SIZE = 56;", "public const int LQ_SIZE = " + txt_lq_size.Text + ";");
                text = text.Replace("public const int SQ_SIZE = 56;", "public const int SQ_SIZE = " + txt_sq_size.Text + ";");

                text = text.Replace("public const int LQ_WIDTH = 2;", "public const int LQ_WIDTH = " + txt_lq_width.Text + ";");
                text = text.Replace("public const int SQ_WIDTH = 1;", "public const int SQ_WIDTH = " + txt_sq_width.Text + ";");

                text = text.Replace("public const int FETCH_WIDTH = 4;", "public const int FETCH_WIDTH = " + txt_fetch_width.Text + ";");
                text = text.Replace("public const int DECODE_WIDTH = 4;", "public const int DECODE_WIDTH = " + txt_decode_width.Text + ";");

                text = text.Replace("public const int EXEC_WIDTH = 6;", "public const int EXEC_WIDTH = " + txt_execude_width.Text + ";");
                text = text.Replace("public const int RETIRE_WIDTH = 4;", "public const int RETIRE_WIDTH = " + txt_retire_width.Text + ";");

                text = text.Replace("public const int BLOCK_SIZE = 64;", "public const int BLOCK_SIZE = " + txt_block_size.Text + ";");
                text = text.Replace("public const int MAX_READ_PER_CYCLE = 4;", "public const int MAX_READ_PER_CYCLE = " + txt_max_read_per_cycle.Text + ";");

                text = text.Replace("public const int ITLB_SET = 16;", "public const int ITLB_SET = " + txt_set_itlb.Text + ";");
                text = text.Replace("public const int ITLB_WAY = 4;", "public const int ITLB_WAY = " + txt_way_itlb.Text + ";");
                text = text.Replace("public const int ITLB_RQ_SIZE = 16;", "public const int ITLB_RQ_SIZE = " + txt_rq_size_itlb.Text + ";");
                text = text.Replace("public const int ITLB_WQ_SIZE = 16;", "public const int ITLB_WQ_SIZE = " + txt_wq_size_itlb.Text + ";");
                text = text.Replace("public const int ITLB_MSHR_SIZE = 8;", "public const int ITLB_MSHR_SIZE = " + txt_mshr_size_itlb.Text + ";");
                text = text.Replace("public const int ITLB_LATENCY = 1;", "public const int ITLB_LATENCY = " + txt_latency_itlb.Text + ";");

                text = text.Replace("public const int DTLB_SET = 16;", "public const int DTLB_SET = " + txt_set_dtlb.Text + ";");
                text = text.Replace("public const int DTLB_WAY = 4;", "public const int DTLB_WAY = " + txt_way_dtlb.Text + ";");
                text = text.Replace("public const int DTLB_RQ_SIZE = 16;", "public const int DTLB_RQ_SIZE = " + txt_rq_size_dtlb.Text + ";");
                text = text.Replace("public const int DTLB_WQ_SIZE = 16;", "public const int DTLB_WQ_SIZE = " + txt_wq_size_dtlb.Text + ";");
                text = text.Replace("public const int DTLB_MSHR_SIZE = 8;", "public const int DTLB_MSHR_SIZE = " + txt_mshr_size_dtlb.Text + ";");
                text = text.Replace("public const int DTLB_LATENCY = 1;", "public const int DTLB_LATENCY = " + txt_latency_dtlb.Text + ";");

                text = text.Replace("public const int STLB_SET = 128;", "public const int STLB_SET = " + txt_set_stlb.Text + ";");
                text = text.Replace("public const int STLB_WAY = 12;", "public const int STLB_WAY = " + txt_way_stlb.Text + ";");
                text = text.Replace("public const int STLB_RQ_SIZE = 32;", "public const int STLB_RQ_SIZE = " + txt_rq_size_stlb.Text + ";");
                text = text.Replace("public const int STLB_WQ_SIZE = 32;", "public const int STLB_WQ_SIZE = " + txt_wq_size_stlb.Text + ";");
                text = text.Replace("public const int STLB_MSHR_SIZE = 16;", "public const int STLB_MSHR_SIZE = " + txt_mshr_size_stlb.Text + ";");
                text = text.Replace("public const int STLB_LATENCY = 8;", "public const int STLB_LATENCY = " + txt_latency_stlb.Text + ";");

                text = text.Replace("public const int L1I_SET = 64;", "public const int L1I_SET = " + txt_set_l1ic.Text + ";");
                text = text.Replace("public const int L1I_WAY = 8;", "public const int L1I_WAY = " + txt_way_l1ic.Text + ";");
                text = text.Replace("public const int L1I_RQ_SIZE = 64;", "public const int L1I_RQ_SIZE = " + txt_rq_size_l1ic.Text + ";");
                text = text.Replace("public const int L1I_WQ_SIZE = 64;", "public const int L1I_WQ_SIZE = " + txt_wq_size_l1ic.Text + ";");
                text = text.Replace("public const int L1I_PQ_SIZE = 64;", "public const int L1I_PQ_SIZE = " + txt_pq_size_l1ic.Text + ";");
                text = text.Replace("public const int L1I_MSHR_SIZE = 8;", "public const int L1I_MSHR_SIZE = " + txt_mshr_size_l1ic.Text + ";");
                text = text.Replace("public const int L1I_LATENCY = 1;", "public const int L1I_LATENCY = " + txt_latency_l1ic.Text + ";");

                text = text.Replace("public const int L1D_SET = 64;", "public const int L1D_SET = " + txt_set_l1dc.Text + ";");
                text = text.Replace("public const int L1D_WAY = 8;", "public const int L1D_WAY = " + txt_way_l1dc.Text + ";");
                text = text.Replace("public const int L1D_RQ_SIZE = 64;", "public const int L1D_RQ_SIZE = " + txt_rq_size_l1dc.Text + ";");
                text = text.Replace("public const int L1D_WQ_SIZE = 64;", "public const int L1D_WQ_SIZE = " + txt_wq_size_l1dc.Text + ";");
                text = text.Replace("public const int L1D_PQ_SIZE = 64;", "public const int L1D_PQ_SIZE = " + txt_pq_size_l1dc.Text + ";");
                text = text.Replace("public const int L1D_MSHR_SIZE = 8;", "public const int L1D_MSHR_SIZE = " + txt_mshr_size_l1dc.Text + ";");
                text = text.Replace("public const int L1D_LATENCY = 1;", "public const int L1D_LATENCY = " + txt_latency_l1dc.Text + ";");

                text = text.Replace("public const int L2C_SET = 512;", "public const int L2C_SET = " + txt_set_l2c.Text + ";");
                text = text.Replace("public const int L2C_WAY = 8;", "public const int L2C_WAY = " + txt_way_l2c.Text + ";");
                text = text.Replace("public const int L2C_RQ_SIZE = 32;", "public const int L2C_RQ_SIZE = " + txt_rq_size_l2c.Text + ";");
                text = text.Replace("public const int L2C_WQ_SIZE = 32;", "public const int L2C_WQ_SIZE = " + txt_wq_size_l2c.Text + ";");
                text = text.Replace("public const int L2C_PQ_SIZE = 32;", "public const int L2C_PQ_SIZE = " + txt_pq_size_l2c.Text + ";");
                text = text.Replace("public const int L2C_MSHR_SIZE = 16;", "public const int L2C_MSHR_SIZE = " + txt_mshr_size_l2c.Text + ";");
                text = text.Replace("public const int L2C_LATENCY = 8;", "public const int L2C_LATENCY = " + txt_latency_l2c.Text + ";");

                text = text.Replace("public const int LLC_WAY = 16;", "public const int LLC_WAY = " + txt_way_llc.Text + ";");
                text = text.Replace("public const int LLC_MSHR_SIZE = 32;", "public const int LLC_MSHR_SIZE = " + txt_mshr_size_llc.Text + ";");
                text = text.Replace("public const int LLC_LATENCY = 20;", "public const int LLC_LATENCY = " + txt_latency_llc.Text + ";");

                text = text.Replace("public const int DRAM_CHANNELS = 1;", "public const int DRAM_CHANNELS = " + txt_channels.Text + ";");
                text = text.Replace("public const int DRAM_BANKS = 8;", "public const int DRAM_BANKS = " + txt_banks.Text + ";");

                text = text.Replace("public const int DRAM_RANKS = 8;", "public const int DRAM_RANKS = " + txt_ranks.Text + ";");
                text = text.Replace("public const int DRAM_ROWS = 32768;", "public const int DRAM_ROWS = " + txt_rows.Text + ";");

                text = text.Replace("public const int DRAM_COLUMNS = 32;", "public const int DRAM_COLUMNS = " + txt_columns.Text + ";");
                text = text.Replace("public const int DRAM_CHANNEL_WIDTH = 8;", "public const int DRAM_CHANNEL_WIDTH = " + txt_channel_width.Text + ";");

                text = text.Replace("public const int DRAM_RQ_SIZE = 48;", "public const int DRAM_RQ_SIZE = " + txt_dram_rq_size.Text + ";");
                text = text.Replace("public const int DRAM_WQ_SIZE = 48;", "public const int DRAM_WQ_SIZE = " + txt_dram_wq_size.Text + ";");

                text = text.Replace("public const int tRP_DRAM_CYCLE = 11;", "public const int tRP_DRAM_CYCLE = " + txt_trp.Text + ";");
                text = text.Replace("public const int tRCD_DRAM_CYCLE = 11;", "public const int tRCD_DRAM_CYCLE = " + txt_trcd.Text + ";");
                text = text.Replace("public const int tCAS_DRAM_CYCLE = 11;", "public const int tCAS_DRAM_CYCLE = " + txt_tcas.Text + ";");

                File.WriteAllText(OriginalGlobals, text);

                var p = new Process();
                p.StartInfo = new ProcessStartInfo(@"C:\Windows\Microsoft.NET\Framework\v4.0.30319\msbuild.exe");
                p.StartInfo.Arguments = string.Format(@"{0}\{1}.csproj /t:Build /p:Configuration=Release", solution, name);
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.CreateNoWindow = true;
                p.Start();
                p.WaitForExit();

                if (p.ExitCode == 0)
                {
                    btn_run.Enabled = true;
                }
                else
                {
                    btn_run.Enabled = false;
                    MessageBox.Show("Error on compile", "Error");
                }
                File.Copy(BacGlobals, OriginalGlobals, true);
                File.Copy(BacMain, OriginalMain, true);
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ChampSimBuilder_Load(object sender, EventArgs e)
        {
          reset_to_defaults();
        }

        private void btn_run_Click(object sender, EventArgs e)
        {
            Process.Start(solution + @"\bin\Release\" + name + ".exe");
        }

        private void txt_mshr_size_l2c_TextChanged(object sender, EventArgs e)
        {
            int cpu = 1;
            switch (cmb_num_cpu.SelectedIndex)
            {
                case 1:
                    cpu = 4;
                    break;
                case 2:
                    cpu = 8;
                    break;
            }

            if (!(String.IsNullOrEmpty(txt_mshr_size_l2c.Text)))
            {
                txt_rq_size_llc.Text = (cpu * int.Parse(txt_mshr_size_l2c.Text)).ToString();
                txt_wq_size_llc.Text = (cpu * int.Parse(txt_mshr_size_l2c.Text)).ToString();
                txt_pq_size_llc.Text = (cpu * int.Parse(txt_mshr_size_l2c.Text)).ToString();
            }
            else
            {
                txt_rq_size_llc.Text = "0";
                txt_wq_size_llc.Text = "0";
                txt_pq_size_llc.Text = "0";
            }
        }
    }
}