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
    public partial class Form1 : Form
    {
        public Button[] buttonArray = new Button[8];
        public Label[] labelArray = new Label[8];
        public TextBox[] textBoxArray = new TextBox[8];
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }

        private void btn_cpu_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            int index = int.Parse(button.Name[button.Name.Length - 1].ToString());
            DialogResult result = openFileDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                textBoxArray[index].Text = openFileDialog1.FileName;
                //fileName = fileName.Substring(openFileDialog1.FileName.LastIndexOf("\\") + 1);
                //text = File.ReadAllText(openFileDialog1.FileName);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < 8; i++)
            {
                Controls.Remove(buttonArray[i]);
                Controls.Remove(labelArray[i]);
                Controls.Remove(textBoxArray[i]);
            }

            for (int i = 0; i < int.Parse(comboBox1.SelectedItem.ToString()); i++)
            {

                labelArray[i] = new Label();
                buttonArray[i] = new Button();
                textBoxArray[i] = new TextBox();


                labelArray[i].Size = new Size(40, 15);
                buttonArray[i].Size = new Size(70, 20);
                textBoxArray[i].Size = new Size(170, 10);
                
                labelArray[i].Name = "lbl_cpu_" + i;
                buttonArray[i].Name = "btn_cpu_" + i;
                textBoxArray[i].Name = "txt_cpu_" + i;

                labelArray[i].Text = "CPU" + i + ":";
                buttonArray[i].Text = "Browse..";
                textBoxArray[i].Text = "File location for trace file of CPU" + i;

                labelArray[i].Location = new Point(125, 10 + (i * 25));
                textBoxArray[i].Location = new Point(175, 5 + (i * 25));
                buttonArray[i].Location = new Point(350, 5 + (i * 25));

                buttonArray[i].Click += btn_cpu_Click;

                Controls.Add(labelArray[i]);
                Controls.Add(buttonArray[i]);
                Controls.Add(textBoxArray[i]);
            }
        }
    }
}