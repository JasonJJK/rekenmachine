using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// Baa
namespace RekenmachineV2
{
    public partial class Rekenmachine : Form
    {
        private bool isDown;
        private Point lastLoc;
        private int bg = 0;

        Color[] clrs = new Color[] {
            Color.Red,
            Color.OrangeRed,
            Color.Orange,
            Color.DarkOrange,
            Color.Yellow,
            Color.YellowGreen,
            Color.LimeGreen,
            Color.MediumSpringGreen,
            Color.Cyan,
            Color.DodgerBlue,
            Color.MidnightBlue,
            Color.DarkSlateBlue,
            Color.Indigo,
            Color.Crimson,
        };

        public Rekenmachine()
        {
            InitializeComponent();
        }

        public void calculateAndUpdate(string parser, int type)
        {
            long v1; long v2;
            long.TryParse(textBox1.Text, out v1); long.TryParse(textBox2.Text, out v2);

            DataTable dt = new DataTable();

            if (type == 1)
            {
                textBox3.Text = dt.Compute($"{v1}{parser}{v2}", "").ToString();
            }
            else if (type == 2)
            {
                if (parser == "0"){
                    textBox3.Text = (v1 + v2).ToString();
                }else if (parser == "1"){
                    textBox3.Text = (v1 - v2).ToString();
                }else if (parser == "2"){
                    textBox3.Text = (v1 * v2).ToString();
                }else if (parser == "3"){
                    textBox3.Text = (v1 / v2).ToString();
                }else if (parser == "4"){
                    textBox3.Text = Math.Sqrt(v1).ToString();
                }else if (parser == "5"){
                    textBox3.Text = Math.Pow(v1,v2).ToString();
                }else if (parser == "6"){
                    textBox3.Text = (Math.Sqrt(Math.Pow(v1, 2) + Math.Pow(v2, 2))).ToString();
                }
            }
        }

        public void tabSwitch(string tab)
        {
            foreach (Control i in Controls)
            {
                if (i.Tag != null && i.Tag != "69")
                {
                    if (i.Tag.ToString()==tab)
                    {
                        i.Visible = true;
                    }
                    else
                    {
                        i.Visible = false;
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            calculateAndUpdate(button3.Text,1);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            calculateAndUpdate(button4.Text,1);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            calculateAndUpdate(button5.Text,1);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            calculateAndUpdate(button6.Text,1);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != "")
            {
                Clipboard.SetText(textBox3.Text);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    
        private void Rekenmachine_MouseDown(object sender, MouseEventArgs e)
        {
            isDown = true;
            lastLoc = e.Location;
        }

        private void Rekenmachine_MouseUp(object sender, MouseEventArgs e)
        {
            isDown = false;
        }

        private void Rekenmachine_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDown)
            {
                this.Location = new Point((this.Location.X - lastLoc.X) + e.X, (this.Location.Y - lastLoc.Y) + e.Y);
                this.Update();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tabSwitch("1");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tabSwitch("2");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            calculateAndUpdate(comboBox1.SelectedIndex.ToString(), 2);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.BackColor = clrs[bg];
            bg += 1;
            if (bg > clrs.Length - 1) {
                bg = 0;
            }
        }








        //\\ Debris //\\
        private void pictureBox1_Click(object sender, EventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void textBox2_TextChanged(object sender, EventArgs e) { }
        private void button1_MouseEnter(object sender, EventArgs e) { }
        private void button1_MouseLeave(object sender, EventArgs e) { }
        private void button2_MouseEnter(object sender, EventArgs e) { }
        private void button2_MouseLeave(object sender, EventArgs e) { }
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e) { }
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e) { }
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e) { }
        private void button8_MouseEnter(object sender, EventArgs e) { }
        private void label5_MouseEnter(object sender, EventArgs e) { }
        private void label5_MouseLeave(object sender, EventArgs e) { }
        private void button8_MouseHover(object sender, EventArgs e) { }
        private void Rekenmachine_Load(object sender, EventArgs e) { }
    }
}
