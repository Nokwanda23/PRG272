using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Student_Management_System
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add(txtStudentID, Text, txtName, Text, txtAge, Text, txtCourse, Text);
        }
        private void iDelete()
        {
            foreach (DataGridViewRow item in this.dataGridView1.SelectedRows) ;

            {
                dataGridView1.Rows.RemoveAt(item.index);


            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            iDelete();
        }
        private void iReset()
        {
            //CLEARING DATA ON TEXTBOXES
           // for (var c in this.Controls)
           // {
           //     if (c is TextBox) { ((Textbox)c).Text = String.Empty;}
            //dataGridView1.Rows.Clear();
            // clears the data grid view
            int numRows = dataGridView1.Rows.Count;
            for (int i = 0; i < numRows; i++) ;
            {
            
             try 
                { int max = dataGridView1.Rows.Count - 1;
                    dataGridView1.Rows.Remove(dataGridView1.Rows[max]);
                }
                catch (Exception exe) 
                {
                MessageBox.Show("All rows are to be deleted " + exe , "DataGRidView Delete",MessageBoxButtons.OK, MessageBoxIcon.Information);    
                }
            }
        }

        Bitmap bitmap;
        private void button5_Click(object sender, EventArgs e)
        {
            int height = dataGridView1.Height;
            dataGridView1.Height = dataGridView1.RowCount * dataGridView1.RowTemplate.Height *2;
            bitmap = new Bitmap(dataGridView1.Width ,dataGridView1.Height);
            dataGridView1.DrawToBitmap(bitmap , new Rectangle(0 , 0 , dataGridView1.Width , dataGridView1.Height));
            printPreviewDialog1.PrintPreviewControl.Zoom = 1;
            printPreviewDialog1.ShowDialog();
            dataGridView1.Height = height;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            iReset();  
        }
        private void button6_Click(object sender, EventArgs e)
        {
            MeExit();
        }
        private void MeExit()
        {
            DialogResult iExit;

            iExit = MessageBox.Show("Confirm if you want to exit", "Save DataGridView", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
        if (iExit == DialogResult.Yes) 
            { 
            Application.Exit();
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bitmap, 0, 0);
        }
    }
}
