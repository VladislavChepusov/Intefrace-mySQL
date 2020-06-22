using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test
{
   
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            using (lab17Entities1 db= new lab17Entities1())
            {
                var производитель = db.производитель;

                foreach (производитель s in производитель)
                {
                    listView1.Items.Add(s.ID_Prod.ToString()); //+ "\n " + s.Name_Prod.ToString() + ' ' + s.Type.ToString() + ' '+s.Data_creature.ToString());
                    listView1.Items.Add(s.Name_Prod.ToString());
                    listView1.Items.Add(s.Data_creature.ToString());
                    listView1.Items.Add(s.Type.ToString());

                }
            }
        }
        private ADO db = new ADO();
        private void button2_Click(object sender, EventArgs e)
        {
            //   dataGrid view        
            dataGridView1.DataSource = db.ForDataGrid();

            //   SqlCommand     
            listView2.Items.Clear();
            listView2.BeginUpdate();
            foreach (var wall in db.mySqlCommand())
            {
                var item = new ListViewItem();
                item.Text = wall;
                listView2.Items.Add(item);
            }
            listView2.EndUpdate();


        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
