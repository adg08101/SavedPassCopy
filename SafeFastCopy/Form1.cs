using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace SafeFastCopy
{
    public partial class Form1 : Form
    {
        String line;
        String path;
        String labels;
        String values;
        List<String> labelsList;
        List<String> valuesList;
        public Form1()
        {
            InitializeComponent();
            labelsList = new List<string>();
            valuesList = new List<string>();
            path = @"C:\\PassCopy";
            labels = @"C:\\PassCopy\\labels.txt";
            values = @"C:\\PassCopy\\values.txt";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                Clipboard.SetText(textBox1.Text);
                button1.Enabled = true;
            }
            else
                button1.Enabled = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            button1_Click(sender, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                Clipboard.SetText(textBox2.Text);
                button2.Enabled = true;
            }
                else
                    button2.Enabled = false;
            }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != "")
            {
                Clipboard.SetText(textBox3.Text);
                button3.Enabled = true;
            }
                else
                    button3.Enabled = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox4.Text != "")
            {
                Clipboard.SetText(textBox4.Text);
                button4.Enabled = true;
            }
                else
                    button4.Enabled = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox5.Text != "")
            {
                Clipboard.SetText(textBox5.Text);
                button5.Enabled = true;
            }
            else
                button5.Enabled = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox6.Text != "")
            {
                Clipboard.SetText(textBox6.Text);
                button6.Enabled = true;
            }
            else
                button6.Enabled = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox7.Text != "")
            {
                Clipboard.SetText(textBox7.Text);
                button7.Enabled = true;
            }
            else
                button7.Enabled = false;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (textBox8.Text != "")
            {
                Clipboard.SetText(textBox8.Text);
                button8.Enabled = true;
            }
            else
                button8.Enabled = false;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (textBox9.Text != "")
            {
                Clipboard.SetText(textBox9.Text);
                button9.Enabled = true;
            }
            else
                button9.Enabled = false;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (textBox10.Text != "")
            {
                Clipboard.SetText(textBox10.Text);
                button10.Enabled = true;
            }
            else
                button10.Enabled = false;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            button2_Click(sender, e);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            button3_Click(sender, e);
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            button4_Click(sender, e);
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            button5_Click(sender, e);
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            button6_Click(sender, e);
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            button7_Click(sender, e);
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            button8_Click(sender, e);
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            button9_Click(sender, e);
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            button10_Click(sender, e);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1_Click(sender, e);
            button2_Click(sender, e);
            button3_Click(sender, e);
            button4_Click(sender, e);
            button5_Click(sender, e);
            button6_Click(sender, e);
            button7_Click(sender, e);
            button8_Click(sender, e);
            button9_Click(sender, e);
            button10_Click(sender, e);
            try
            {
                Directory.CreateDirectory(path);
                StreamReader srl = new StreamReader(labels);
                line = srl.ReadLine();
                while (line != null)
                {
                    labelsList.Add(line);
                    line = srl.ReadLine();
                }
                srl.Close();
                StreamReader srv = new StreamReader(values);
                line = srv.ReadLine();
                while (line != null)
                {
                    valuesList.Add(line);
                    line = srv.ReadLine();
                }
                srv.Close();
                int labelIndex = 20;
                foreach (String label in labelsList)
                {
                    foreach (Control control in groupBox1.Controls.OfType<TextBox>())
                    {
                        if (labelIndex < 11)
                            break;
                        if (control.Name == "textBox" + labelIndex)
                        {
                            control.Text = label;
                            labelIndex--;
                        }
                    }
                }
                int valueIndex = 1;
                foreach (String value in valuesList)
                {
                    foreach (Control control in groupBox1.Controls.OfType<TextBox>())
                    {
                        if (valueIndex > 10)
                            break;
                        if (control.Name == "textBox" + valueIndex)
                        {
                            control.Text = value;
                            valueIndex++;
                        }
                    }
                }
            }
            catch (FileNotFoundException)
            {
                File.CreateText(labels);
                File.CreateText(values);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void SaveValues(object sender, EventArgs e)
        {
            try
            {
                labelsList.Clear();
                valuesList.Clear();
                StreamWriter swl = new StreamWriter(labels);
                for (int i = 20; i > 10; i--)
                    swl.WriteLine(groupBox1.Controls.Find("textBox" + i.ToString(), false).First().Text);
                swl.Close();
                StreamWriter swv = new StreamWriter(values);
                for (int i = 1; i < 11; i++)
                    if (groupBox1.Controls.Find("textBox" + i.ToString(), false).First().Text != "")
                        swv.WriteLine(groupBox1.Controls.Find("textBox" + i.ToString(), false).First().Text);
                swv.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reached" + ex.Message);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            SaveValues(sender, e);
        }
    }
}
