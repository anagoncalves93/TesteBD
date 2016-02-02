using DomainModel;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibrary1;

namespace TesteBD
{
    public partial class Form1 : Form
    {
        int idDesc;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<Descricao> listDescricao = DescricaoBL.getDescricoes();
            int id = 0;
            

            string descricao = null;
            string obervacao = null;

            foreach (Descricao d in listDescricao)
            {
                id = d.Id;
                descricao = d.Descricao1;
                obervacao = d.Observacao;
                ListViewItem itemUm = new ListViewItem(id.ToString());
                itemUm.SubItems.Add(descricao);
                itemUm.SubItems.Add(obervacao);



                listView1.Items.Add(itemUm);
            }    

                
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int id = 0;
            label4.Text = id.ToString();
            int id2 = 0;
            string idUpdate = id2.ToString();
            if (listView1.SelectedIndices.Count>0)
            {
                idUpdate = listView1.SelectedItems[0].Text;
                label4.Text = idUpdate;
            }
            if (idUpdate != id.ToString())
            {         

                Descricao d = new Descricao(textBox1.Text, textBox2.Text);
                DescricaoBL.verificarUpdateDescricao(d, Convert.ToInt32(idUpdate));
                MessageBox.Show("Dados alterados com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                
            }
            else if (label4.Text==id.ToString())
            {
                Descricao d = new Descricao(textBox1.Text, textBox2.Text);
                DescricaoBL.verificarAddDescricao(d);
                MessageBox.Show("Dados inseridos com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            textBox1.Text = "";
            textBox2.Text = "";
            label4.Text = "";
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            string id = listView1.SelectedItems[0].Text;
            idDesc = Convert.ToInt32(id);

            List<Descricao> des = DescricaoBL.getDescEspecifico(idDesc);
            foreach (Descricao d in des)
            {
                textBox1.Text = d.Descricao1;
                textBox2.Text = d.Observacao;
            }        
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
           // int id = 0;
           string  idUpdate = listView1.SelectedItems[0].Text;

            Descricao d = new Descricao(textBox1.Text, textBox2.Text);
            DescricaoBL.verificarDeleteDescricao(d, Convert.ToInt32(idUpdate));
            MessageBox.Show("Dados eliminado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            textBox1.Text = "";
            textBox2.Text = "";
            label4.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
