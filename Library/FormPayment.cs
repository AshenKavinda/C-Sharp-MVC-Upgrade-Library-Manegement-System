using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library
{
    public partial class FormPayment : Form
    {
        public event EventHandler FormLoad;
        public event EventHandler Go;
        public event EventHandler Clear;
        public FormPayment()
        {
            InitializeComponent();
            new FormPaymentController(this);
        }

        private bool validate()
        {
            bool result = true;
            if (comboMonth.SelectedIndex == 0)
            {
                result = false;
            }
            return result;
            
        }
        public void setComboBoxYear(List<int> list)
        {
            foreach (int year in list)
            {
                comboYear.Items.Add(Convert.ToString(year));
            }
        }
        public int getSelectedYear()
        {
            return Convert.ToInt32(comboYear.SelectedItem);
        }
        public int getSelectedMonth()
        {
            return Convert.ToInt32(comboMonth.SelectedItem);
        }
        public string getSelectedType()
        {
            return Convert.ToString(comboType.SelectedItem);
        }
        public void setTotalLbl(int[] list)
        {
            lblRValue.Text = Convert.ToString(list[0]);
            lblMValue.Text = Convert.ToString(list[1]);
            lblOValue.Text = Convert.ToString(list[2]);
        }
        public void setGrid(DataTable table)
        {
            dataGrid.DataSource = table;
        }
        public void showMessage(string text)
        {
            MessageBox.Show(text);
        }
        public void clearAll(DataTable table)
        {
            comboYear.SelectedIndex = 0;
            comboMonth.SelectedIndex = 0;
            comboType.SelectedIndex = 0;
            lblRValue.Text = ": .........";
            lblMValue.Text = ": .........";
            lblOValue.Text = ": .........";
            setGrid(table);
        }




        private void FormPayment_Load(object sender, EventArgs e)
        {
            FormLoad?.Invoke(this, EventArgs.Empty);
        }
        private void btnGo_Click(object sender, EventArgs e)
        {
            if (validate())
            {
                Go?.Invoke(this, EventArgs.Empty);  
            }
            else
            {
                showMessage("Input Error!");
            }
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear?.Invoke(this, EventArgs.Empty);
        }

    }
}
