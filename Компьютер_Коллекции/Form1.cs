using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Компьютер_Коллекции
{
    public partial class Form1 : Form
    {
        private SortedDictionary<string, PC> PCDictionary = new SortedDictionary<string, PC>();
        public List<string> famil = new List<string>();
        bool check = true;

        public void ShowListInGrid()
        {
            dataGridView1.Rows.Clear();
            foreach (KeyValuePair<string, PC> pc1 in PCDictionary)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dataGridView1);
                row.Cells[0].Value = pc1.Value.Get_surname();          
                row.Cells[1].Value = pc1.Value.Get_proc();                
                row.Cells[2].Value = pc1.Value.Get_kard();            
                row.Cells[3].Value = pc1.Value.Get_oper();
                dataGridView1.Rows.Add(row);
            }
        }


        public void AddPC(string surname, string proc,string kard, int oper)
        {
            PC pc = new PC(surname,proc,kard,oper);
            PCDictionary.Add(surname,pc);
            ShowListInGrid();
            famil.Add(surname);

        }

        private DataGridViewColumn dataGridViewColumn1 = null;
        private DataGridViewColumn dataGridViewColumn2 = null;
        private DataGridViewColumn dataGridViewColumn3 = null;
        private DataGridViewColumn dataGridViewColumn4 = null;

        public DataGridViewColumn GetdataGridViewColumn1()
        {
            if (dataGridViewColumn1 == null)
            {
                dataGridViewColumn1 = new DataGridViewTextBoxColumn();
                dataGridViewColumn1.Name = "";
                dataGridViewColumn1.HeaderText = "Фамилия";
                dataGridViewColumn1.ValueType = typeof(string);
                dataGridViewColumn1.Width = dataGridView1.Width / 4;
            }
            return dataGridViewColumn1;
        }

        public DataGridViewColumn GetdataGridViewColumn2()
        {
            if (dataGridViewColumn2 == null)
            {
                dataGridViewColumn2 = new DataGridViewTextBoxColumn();
                dataGridViewColumn2.Name = "";
                dataGridViewColumn2.HeaderText = "Процессор";
                dataGridViewColumn2.ValueType = typeof(string);
                dataGridViewColumn2.Width = dataGridView1.Width / 4;
            }
            return dataGridViewColumn2;
        }

        public DataGridViewColumn GetdataGridViewColumn3()
        {
            if (dataGridViewColumn3 == null)
            {
                dataGridViewColumn3 = new DataGridViewTextBoxColumn();
                dataGridViewColumn3.Name = "";
                dataGridViewColumn3.HeaderText = "Видеокарта";
                dataGridViewColumn3.ValueType = typeof(string);
                dataGridViewColumn3.Width = dataGridView1.Width / 4;
            }
            return dataGridViewColumn3;
        }

        public DataGridViewColumn GetdataGridViewColumn4()
        {
            if (dataGridViewColumn4 == null)
            {
                dataGridViewColumn4 = new DataGridViewTextBoxColumn();
                dataGridViewColumn4.Name = "";
                dataGridViewColumn4.HeaderText = "Оперативная память";
                dataGridViewColumn4.ValueType = typeof(int);
                dataGridViewColumn4.Width = dataGridView1.Width / 4;
            }
            return dataGridViewColumn4;
        }

        public Form1()
        {
            InitializeComponent();
            InitDataGridView();
        }

        private void InitDataGridView()
        {

            dataGridView1.DataSource = null;
            dataGridView1.Columns.Add(GetdataGridViewColumn1());
            dataGridView1.Columns.Add(GetdataGridViewColumn2());
            dataGridView1.Columns.Add(GetdataGridViewColumn3());
            dataGridView1.Columns.Add(GetdataGridViewColumn4());
            dataGridView1.AutoResizeColumns();

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            check = true;
            if (textBox1.Text == "")
            {
                MessageBox.Show("Поле фамилия не должно быть пустым");
            }
            else
            {

                if (textBox2.Text == "")
                {
                    MessageBox.Show("Поле процессор не должно быть пустым");

                }
                else
                {
                    for (int i = 0; i < textBox1.TextLength; i++)
                    {
                        if (!char.IsLetter(textBox1.Text[i]))
                        {

                            MessageBox.Show("поле фамилия не должно содержать цифры");
                            check = false;
                            break;
                        }

                    }
                    if (textBox3.Text == "")
                    {
                        MessageBox.Show("Поле фамилия не должно быть пустым");
                    }

                    if (!famil.Contains(textBox1.Text))
                    {

                        if (check == true)
                        {

                            AddPC(textBox1.Text, textBox2.Text, textBox3.Text, Convert.ToInt32(numericUpDown1.Value));
                          
                        }


                    }
                    else { MessageBox.Show("Такая фамилия уже есть"); }
                }
    }
        }



        public void RemovePC(int ElementIndex)
        {
            if (ElementIndex >= 0 && ElementIndex < PCDictionary.Count)
            {
                var key = PCDictionary.FirstOrDefault().Key;
                PCDictionary.Remove(key);
            } 
            ShowListInGrid();
        }



        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void удалитьToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            DialogResult prov = MessageBox.Show("Удалить студента?", "Удаление студента", MessageBoxButtons.YesNo);
            if (prov == DialogResult.Yes)
            {

                RemovePC(dataGridView1.SelectedCells[0].RowIndex);

            }
        }

        private void изменитьToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (!famil.Contains(textBox3.Text))
            {

                if (check == true)
                {

                    int i = dataGridView1.CurrentRow.Index;
                    dataGridView1.Rows[i].Cells[0].Value = textBox1.Text;
                    dataGridView1.Rows[i].Cells[1].Value = textBox3.Text;


                }


            }
            else { MessageBox.Show("Такая фамилия уже есть"); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Ascending);

            button2.Visible = false;
            button3.Visible = true;
            ShowListInGrid();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Descending);

            button3.Visible = false;
            button2.Visible = true;
            ShowListInGrid();
        }
    }
}
