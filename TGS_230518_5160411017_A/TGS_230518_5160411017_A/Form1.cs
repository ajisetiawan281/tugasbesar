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

namespace TGS_230518_5160411017_A
{
    public partial class Form1 : Form
    {
        private BindingSource bindingSourceFC = new BindingSource();
        private BindingSource bindingSourcePizza = new BindingSource();
        private BindingSource bindingSourceHamburger = new BindingSource();
        int selectindex = -1;
        public Form1()
        {
            InitializeComponent();
        }

        private void FriedChicken_CheckedChanged(object sender, EventArgs e)
        {
            gbChicken.Show();
            gbHamburger.Hide();
            gbPizza.Hide();
            tabControl1.SelectedIndex = 0;
        }

        private void Pizza_CheckedChanged(object sender, EventArgs e)
        {
            gbChicken.Hide();
            gbPizza.Show();
            gbHamburger.Hide();

            tabControl1.SelectedIndex = 1;
        }

        private void Hamburger_CheckedChanged(object sender, EventArgs e)
        {
            gbChicken.Hide();
            gbHamburger.Show();
            gbPizza.Hide();
            tabControl1.SelectedIndex = 2;
        }

        private void calculate_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.FriedChicken.Checked)
                {
                    if (this.kaloriFC.Text == string.Empty)
                    {
                        int num1 = (int)MessageBox.Show("Please fill all fields!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        if (int.Parse(this.kaloriFC.Text) < 50)
                        {
                            Exception ex = new Exception("Kalori Kurang dari 50");
                            MessageBox.Show(ex.Message);
                        }
                        else
                        {

                            FriedChicken friedChicken = new FriedChicken(this.cbFC.Text, this.cbSpacy.Checked, Convert.ToInt32(this.kaloriFC.Text));
                            this.menuFC.Text = friedChicken.MenuName;
                            this.hargaFC.Text = friedChicken.Price.ToString();
                        }
                    }
                }
                else if (this.Pizza.Checked)
                {
                    if (this.pizzakalori.Text == string.Empty)
                    {
                        int num2 = (int)MessageBox.Show("Please fill all fields!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        if (int.Parse(this.pizzakalori.Text) < 50)
                        {
                            Exception ex = new Exception("Kalori Kurang dari 50");
                            MessageBox.Show(ex.Message);
                        }
                        else
                        {

                            Pizza pizza = new Pizza(this.pizzanama.Text, this.Pizzatoping.Text, this.cbPizzaCrust.Text, this.cbPizzaSize.Text, Convert.ToInt32(this.pizzakalori.Text));
                            this.PizzaMenuName.Text = pizza.MenuName;
                            this.PizzaHarga.Text = pizza.Price.ToString();


                        }
                    }
                }

                else
                {
                    if (!this.Hamburger.Checked)
                        return;
                    if (this.Hcalory.Text == string.Empty)
                    {
                        int num3 = (int)MessageBox.Show("Please fill all fields!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        if (int.Parse(this.Hcalory.Text) < 50)
                        {
                            Exception ex = new Exception("Kalori Kurang dari 50");
                            MessageBox.Show(ex.Message);
                        }
                        else
                        {
                            Hamburger hamburger = new Hamburger(Convert.ToInt32(this.HPatty.Text), this.HpattyType.Text, this.HExtraFiller.Text, Convert.ToInt32(this.Hcalory.Text));
                            this.HMenuName.Text = hamburger.MenuName;
                            this.Hprice.Text = hamburger.Price.ToString();
                        }
                    }
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Field Harus string");
            }
        }

        private void insert_Click(object sender, EventArgs e)
        {
            if (this.FriedChicken.Checked)
            {

                if (this.hargaFC.Text == string.Empty)
                {
                    int num1 = (int)MessageBox.Show("You must click Calculate Price button first!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    this.InsertFC();
                }
            }
            else if (this.Pizza.Checked)
            {
                if (this.PizzaHarga.Text == string.Empty)
                {
                    int num2 = (int)MessageBox.Show("You must click Calculate Price button first!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    this.InsertPizza();
                }
            }
            else
            {
                if (!this.Hamburger.Checked)
                    return;
                if (this.Hprice.Text == string.Empty)
                {
                    int num3 = (int)MessageBox.Show("You must click Calculate Price button first!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    this.bindingSourceHamburger.Add((object)new Hamburger(Convert.ToInt32(this.HPatty.Text), this.HpattyType.Text, this.HExtraFiller.Text, Convert.ToInt32(this.Hcalory.Text)));
                }
            }
        }

        private void clearall_Click(object sender, EventArgs e)
        {
            this.HapusPizza();
            this.HapusHamburger();
            this.HapusFC();
        }
        private void InsertFC()
        {
            this.bindingSourceFC.Add((object)new FriedChicken(cbFC.Text, Convert.ToBoolean(cbSpacy.Checked), int.Parse(kaloriFC.Text)));

        }

        private void InsertPizza()
        {


            this.bindingSourcePizza.Add((object)new Pizza(this.pizzanama.Text, this.Pizzatoping.Text, this.cbPizzaCrust.Text, this.cbPizzaSize.Text, Convert.ToInt32(this.pizzakalori.Text)));
        }
        private void HapusFC()
        {
            this.cbFC.SelectedIndex = 0;
            this.cbSpacy.Checked = false;
            this.kaloriFC.Clear();
            this.menuFC.Clear();
            this.hargaFC.Clear();
        }
        private void HapusPizza()
        {
            this.cbPizzaSize.SelectedIndex = 0;
            this.cbPizzaCrust.SelectedIndex = 0;
            this.pizzanama.Clear();
            this.pizzakalori.Clear();
            this.Pizzatoping.Clear();
            this.PizzaMenuName.Clear();
            this.PizzaHarga.Clear();
        }
        private void HapusHamburger()
        {
            this.HpattyType.SelectedIndex = 0;
            this.Hcalory.Clear();
            this.HPatty.Text = "1";
            this.HExtraFiller.Clear();
            this.HMenuName.Clear();
            this.Hprice.Clear();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = bindingSourceFC;
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView3.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;

            DataGridViewColumn dataGridViewColumn1 = (DataGridViewColumn)new DataGridViewTextBoxColumn();
            dataGridViewColumn1.DataPropertyName = "PartOfChicken";
            dataGridViewColumn1.Name = "Chicken Part";
            this.dataGridView1.Columns.Add(dataGridViewColumn1);
            DataGridViewColumn dataGridViewColumn2 = (DataGridViewColumn)new DataGridViewTextBoxColumn();
            dataGridViewColumn2.DataPropertyName = "Calory";
            dataGridViewColumn2.Name = "Calory";
            this.dataGridView1.Columns.Add(dataGridViewColumn2);
            DataGridViewColumn dataGridViewColumn3 = (DataGridViewColumn)new DataGridViewTextBoxColumn();
            dataGridViewColumn3.DataPropertyName = "MenuName";
            dataGridViewColumn3.Name = "Menu Name";
            this.dataGridView1.Columns.Add(dataGridViewColumn3);
            DataGridViewColumn dataGridViewColumn4 = (DataGridViewColumn)new DataGridViewTextBoxColumn();
            dataGridViewColumn4.DataPropertyName = "Price";
            dataGridViewColumn4.Name = "Price (Rp)";
            this.dataGridView1.Columns.Add(dataGridViewColumn4);
            DataGridViewColumn dataGridViewColumn5 = (DataGridViewColumn)new DataGridViewCheckBoxColumn();
            dataGridViewColumn5.DataPropertyName = "IsSpicy";
            dataGridViewColumn5.Name = "Spicy";
            this.dataGridView1.Columns.Add(dataGridViewColumn5);
            this.dataGridView2.AutoGenerateColumns = false;
            this.dataGridView2.DataSource = (object)this.bindingSourcePizza;
            DataGridViewColumn dataGridViewColumn6 = (DataGridViewColumn)new DataGridViewTextBoxColumn();
            dataGridViewColumn6.DataPropertyName = "PizzaName";
            dataGridViewColumn6.Name = "Pizza Name";
            this.dataGridView2.Columns.Add(dataGridViewColumn6);
            DataGridViewColumn dataGridViewColumn7 = (DataGridViewColumn)new DataGridViewTextBoxColumn();
            dataGridViewColumn7.DataPropertyName = "Calory";
            dataGridViewColumn7.Name = "Calory";
            this.dataGridView2.Columns.Add(dataGridViewColumn7);
            DataGridViewColumn dataGridViewColumn8 = (DataGridViewColumn)new DataGridViewTextBoxColumn();
            dataGridViewColumn8.DataPropertyName = "MenuName";
            dataGridViewColumn8.Name = "Menu Name";
            this.dataGridView2.Columns.Add(dataGridViewColumn8);
            DataGridViewColumn dataGridViewColumn9 = (DataGridViewColumn)new DataGridViewTextBoxColumn();
            dataGridViewColumn9.DataPropertyName = "Size";
            dataGridViewColumn9.Name = "Pizza Size";
            this.dataGridView2.Columns.Add(dataGridViewColumn9);
            DataGridViewColumn dataGridViewColumn10 = (DataGridViewColumn)new DataGridViewTextBoxColumn();
            dataGridViewColumn10.DataPropertyName = "Crust";
            dataGridViewColumn10.Name = "Crust Type";
            this.dataGridView2.Columns.Add(dataGridViewColumn10);
            DataGridViewColumn dataGridViewColumn11 = (DataGridViewColumn)new DataGridViewTextBoxColumn();
            dataGridViewColumn11.DataPropertyName = "Topping";
            dataGridViewColumn11.Name = "Topping Items";
            this.dataGridView2.Columns.Add(dataGridViewColumn11);
            DataGridViewColumn dataGridViewColumn12 = (DataGridViewColumn)new DataGridViewTextBoxColumn();
            dataGridViewColumn12.DataPropertyName = "Price";
            dataGridViewColumn12.Name = "Price (Rp)";
            this.dataGridView2.Columns.Add(dataGridViewColumn12);
            this.dataGridView3.AutoGenerateColumns = false;
            this.dataGridView3.DataSource = (object)this.bindingSourceHamburger;
            this.dataGridView3.ReadOnly = true;
            DataGridViewColumn dataGridViewColumn13 = (DataGridViewColumn)new DataGridViewTextBoxColumn();
            dataGridViewColumn13.DataPropertyName = "MeatType";
            dataGridViewColumn13.Name = "Patty Type";
            this.dataGridView3.Columns.Add(dataGridViewColumn13);
            DataGridViewColumn dataGridViewColumn14 = (DataGridViewColumn)new DataGridViewTextBoxColumn();
            dataGridViewColumn14.DataPropertyName = "NMeat";
            dataGridViewColumn14.Name = "Number of Patty (pcs)";
            this.dataGridView3.Columns.Add(dataGridViewColumn14);
            DataGridViewColumn dataGridViewColumn15 = (DataGridViewColumn)new DataGridViewTextBoxColumn();
            dataGridViewColumn15.DataPropertyName = "Calory";
            dataGridViewColumn15.Name = "Calory";
            this.dataGridView3.Columns.Add(dataGridViewColumn15);
            DataGridViewColumn dataGridViewColumn16 = (DataGridViewColumn)new DataGridViewTextBoxColumn();
            dataGridViewColumn16.DataPropertyName = "MenuName";
            dataGridViewColumn16.Name = "Menu Name";
            this.dataGridView3.Columns.Add(dataGridViewColumn16);
            DataGridViewColumn dataGridViewColumn17 = (DataGridViewColumn)new DataGridViewTextBoxColumn();
            dataGridViewColumn17.DataPropertyName = "ExtraFiller";
            dataGridViewColumn17.Name = "Extra Filler";
            this.dataGridView3.Columns.Add(dataGridViewColumn17);
            DataGridViewColumn dataGridViewColumn18 = (DataGridViewColumn)new DataGridViewTextBoxColumn();
            dataGridViewColumn18.DataPropertyName = "Price";
            dataGridViewColumn18.Name = "Price (Rp)";
            this.dataGridView3.Columns.Add(dataGridViewColumn18);

            dataGridView1.Rows.Clear();
            System.IO.StreamReader file = new System.IO.StreamReader("fileFC.txt");
            string newline;
            while ((newline = file.ReadLine()) != null)
            {
                string[] values = newline.Split(';');

                FriedChicken dgv1 = new FriedChicken(
                    values[1], Convert.ToBoolean(values[0]), int.Parse(values[3]));
                bindingSourceFC.Add(dgv1);
            }
            file.Close();

            System.IO.StreamReader dg2 = new System.IO.StreamReader("filePizza.txt");

            while ((newline = dg2.ReadLine()) != null)
            {
                string[] data = newline.Split(';');

                Pizza dgv2 = new Pizza(data[0], data[5], data[4], data[3], int.Parse(data[1]));
                bindingSourcePizza.Add(dgv2);
            }
            dg2.Close();

            System.IO.StreamReader dg3 = new System.IO.StreamReader("fileHamburger.txt");

            while ((newline = dg3.ReadLine()) != null)
            {
                string[] data2 = newline.Split(';');
                Hamburger dgv3 = new Hamburger(int.Parse(data2[1]), data2[0], data2[4], int.Parse(data2[2]));
                bindingSourceHamburger.Add(dgv3);
            }
            dg3.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.FriedChicken.Checked)
            {
                TextWriter writer = new StreamWriter("fileFC.txt");
                int rowcount = dataGridView1.Rows.Count;
                for (int i = 0; i < rowcount - 1; i++)
                {
                    for (int j = 0; j <= 4; j++)
                    {
                        writer.Write(dataGridView1.Rows[i].Cells[j].Value.ToString());
                        writer.Write(";");
                        //    writer.Write(dataGridView1.Rows[i].Cells[4].Value.ToString()+";");
                        //}
                    }
                    writer.WriteLine();

                } writer.Close();
                MessageBox.Show("Text file was created.");
            }
            else if (this.Pizza.Checked)
            {
                try
                {
                    TextWriter wr = new StreamWriter("filePizza.txt", append: false);
                    int rc = dataGridView2.Rows.Count - 1;
                    for (int i = 0; i <= rc; i++)
                    {
                        for (int j = 0; j <= 6; j++)
                        {
                            wr.Write(dataGridView2.Rows[i].Cells[j].Value.ToString());
                            wr.Write(";");
                            //    writer.Write(dataGridView1.Rows[i].Cells[4].Value.ToString()+";");
                            //}
                        }
                        wr.WriteLine();


                    }
                    MessageBox.Show("Text file was created.");
                    wr.Close();

                }
                catch (System.IO.IOException exc)
                {
                    MessageBox.Show(exc.Message);
                }
            }
            else
            {
                if (!this.Hamburger.Checked)
                    return;
                TextWriter w = new StreamWriter("fileHamburger.txt");
                int r = dataGridView3.Rows.Count;
                for (int i = 0; i < r; i++)
                {
                    for (int j = 0; j <= 5; j++)
                    {
                        w.Write(dataGridView3.Rows[i].Cells[j].Value.ToString());
                        w.Write(";");
                    }
                    w.WriteLine();
                }
                w.Close();
                MessageBox.Show("Text file was created.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (this.FriedChicken.Checked)
            {
                bindingSourceFC[selectindex] = new FriedChicken(cbFC.Text, Convert.ToBoolean(cbSpacy.Checked), int.Parse(kaloriFC.Text));
            }
            else if (this.Pizza.Checked)
            {
                bindingSourcePizza[selectindex] = new Pizza(this.pizzanama.Text, this.Pizzatoping.Text, this.cbPizzaCrust.Text,
                    this.cbPizzaSize.Text, Convert.ToInt32(this.pizzakalori.Text));

            }
            else
            {
                if (!this.Hamburger.Checked)
                    return;
                bindingSourceHamburger[selectindex] = new Hamburger(Convert.ToInt32(this.HPatty.Text), this.HpattyType.Text,
                    this.HExtraFiller.Text, Convert.ToInt32(this.Hcalory.Text));

            }
            selectindex = -1;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cbFC.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            kaloriFC.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            cbSpacy.Checked = Convert.ToBoolean(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            hargaFC.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            menuFC.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            selectindex = dataGridView1.CurrentRow.Index;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (FriedChicken.Checked)
            {
                bindingSourceFC.RemoveAt(selectindex);
            }
            else if (Hamburger.Checked)
            {
                bindingSourceHamburger.RemoveAt(selectindex);
            }
            else
            {
                bindingSourcePizza.RemoveAt(selectindex);
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            pizzanama.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            pizzakalori.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            cbPizzaSize.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();
            cbPizzaCrust.Text = dataGridView2.CurrentRow.Cells[4].Value.ToString();
            Pizzatoping.Text = dataGridView2.CurrentRow.Cells[5].Value.ToString();
            PizzaMenuName.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
            PizzaHarga.Text = dataGridView2.CurrentRow.Cells[6].Value.ToString();
            selectindex = dataGridView2.CurrentRow.Index;
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            HPatty.Text = dataGridView3.CurrentRow.Cells[1].Value.ToString();
            HpattyType.Text = dataGridView3.CurrentRow.Cells[0].Value.ToString();
            Hcalory.Text = dataGridView3.CurrentRow.Cells[2].Value.ToString();
            HExtraFiller.Text = dataGridView3.CurrentRow.Cells[4].Value.ToString();
            HMenuName.Text = dataGridView3.CurrentRow.Cells[3].Value.ToString();
            Hprice.Text = dataGridView3.CurrentRow.Cells[5].Value.ToString();
            selectindex = dataGridView3.CurrentRow.Index;
        }
    }
}
