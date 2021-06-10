using Artur.ModelBD;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Artur
{
    public partial class Form1 : Form
    {
        ModelBD.Model1 connect = new ModelBD.Model1();
        public Form1()
        {
            InitializeComponent();
            connect.sto.Load();
            dataGridView1.DataSource = connect.sto.Local.ToBindingList();
        }

        private void Add_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            DialogResult result = form.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                sto client = new sto();
                client.Auto = form.textBox1.Text;
                client.ClientName = form.textBox2.Text;
                client.Phone = form.textBox3.Text;
                client.CenaRemonta = form.textBox4.Text;

                connect.sto.Add(client);
                connect.SaveChanges();
                MessageBox.Show("add");
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int index = dataGridView1.SelectedRows[0].Index;
                int id = 0;
                bool converted = Int32.TryParse(dataGridView1[0, index].Value.ToString(), out id);
                if (converted == true)
                {
                    sto Clientdel = connect.sto.Find(id);
                    connect.sto.Remove(Clientdel);
                    connect.SaveChanges();
                    string buff = Clientdel.Auto;
                    MessageBox.Show("Zapis " + buff + " udalena");
                }

            }
            else
            {
                MessageBox.Show("Zapis ne vybrana!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 formedit = new Form2();
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int index = dataGridView1.SelectedRows[0].Index;
                int id = 0;
                bool converted = Int32.TryParse(dataGridView1[0, index].Value.ToString(), out id);

                sto Clientedit = connect.sto.Find(id);

                formedit.textBox1.Text = Clientedit.Auto;
                formedit.textBox2.Text = Clientedit.ClientName;
                formedit.textBox3.Text = Clientedit.Phone;
                formedit.textBox4.Text = Clientedit.CenaRemonta;
                


                DialogResult resultedit = formedit.ShowDialog(this);
                if (resultedit == DialogResult.OK)
                {
                    Clientedit.Auto = formedit.textBox1.Text;
                    Clientedit.ClientName = formedit.textBox2.Text;
                    Clientedit.Phone = formedit.textBox3.Text;
                    Clientedit.CenaRemonta = formedit.textBox4.Text;
                    
                    connect.SaveChanges();
                    MessageBox.Show("Запись обновлена");
                }

            }
        }
    }
}
