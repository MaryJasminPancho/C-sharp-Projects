using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pancho_SemifinalActivity1
{
    public partial class Form1: Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox7.KeyPress += new KeyPressEventHandler(TextBox7_KeyPress);
            textBox1.KeyPress += new KeyPressEventHandler(textbox1_KeyPress);
            textBox2.KeyPress += new KeyPressEventHandler(textBox2_KeyPress);
            textBox3.KeyPress += new KeyPressEventHandler(textBox3_KeyPress);
            textBox4.KeyPress += new KeyPressEventHandler(textBox4_KeyPress);
            textBox5.KeyPress += new KeyPressEventHandler(textBox5_KeyPress);
            textBox6.KeyPress += new KeyPressEventHandler(textBox6_KeyPress);
            textBox8.KeyPress += new KeyPressEventHandler(textBox8_KeyPress);
            textBox9.KeyPress += new KeyPressEventHandler(textBox9_KeyPress);
        }

        private void TextBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            textBox7.MaxLength = 4;
            textBox7.ForeColor = Color.Black;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.MaxLength = 8;
        }

        private void textbox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.MaxLength = 32;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            /*if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != '-' && e.KeyChar != '_' && e.KeyChar != '@' && e.KeyChar != '.')
            {
                e.Handled = true;
            }*/
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            textBox3.MaxLength = 32;
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            /*if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }*/
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            textBox4.MaxLength = 32;
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            /*if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }*/
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            textBox5.MaxLength = 32;
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)8 && e.KeyChar != (char)32)
            {
                e.Handled = true;
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            textBox6.MaxLength = 1;
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            textBox8.MaxLength = 2;
            textBox8.ForeColor = Color.Black;
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            textBox9.MaxLength = 2;
            textBox9.ForeColor = Color.Black;
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void savebtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text) ||
                string.IsNullOrWhiteSpace(textBox5.Text) || 
                string.IsNullOrWhiteSpace(textBox6.Text) || 
                string.IsNullOrWhiteSpace(textBox8.Text) || 
                string.IsNullOrWhiteSpace(textBox9.Text) || 
                string.IsNullOrWhiteSpace(textBox7.Text))   
            {
                MessageBox.Show("Please fill in all the required fields before saving.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string studentInfo = $"ID: {textBox1.Text}\n" +
                                 $"Name: {textBox2.Text} {textBox4.Text} {textBox3.Text} \n" +
                                 $"Course: {textBox5.Text}\n" +
                                 $"Year: {textBox6.Text}\n" +
                                 $"Birthday: {textBox8.Text}-{textBox9.Text}-{textBox7.Text}\n" +
                                 $"\n";

            File.AppendAllText("student_record.txt", studentInfo);
            MessageBox.Show("Student information saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void textBox5_TextChanged_1(object sender, EventArgs e)
        {
            textBox5.MaxLength = 32;
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Please enter the ID of the record to delete.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string idToDelete = textBox1.Text; // Get the ID to delete
            string filePath = "student_record.txt";

            if (!File.Exists(filePath))
            {
                MessageBox.Show("No records found to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var lines = File.ReadAllLines(filePath).ToList();
            bool recordFound = false;
            for (int i = 0; i < lines.Count; i++)
            {
                if (lines[i].Contains($"ID: {idToDelete}"))
                {
                    recordFound = true;
                    while (i < lines.Count && !string.IsNullOrWhiteSpace(lines[i]))
                    {
                        lines.RemoveAt(i); // Remove the current line
                    }

                    if (i < lines.Count && string.IsNullOrWhiteSpace(lines[i]))
                    {
                        lines.RemoveAt(i);
                    }

                    break;
                }
            }

            if (recordFound)
            {
                File.WriteAllLines(filePath, lines);
                MessageBox.Show("Record deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Record not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
