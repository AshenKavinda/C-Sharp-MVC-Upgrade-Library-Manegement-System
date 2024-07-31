using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Library
{
    public partial class FormMonthlyPayment : Form
    {

        public event EventHandler Search;
        public event EventHandler Calculate;
        public event EventHandler Confirm;
        public event EventHandler Clear;
        public event EventHandler formLoad;

        public string data;

        public FormMonthlyPayment()
        {
            InitializeComponent();
            new MonthlyPaymentController(this);
            
        }

        private int validateInputFild()
        {
            int status = 1;
            List<TextBoxBase> list = new List<TextBoxBase>() { txtInput };
            List<Label> lblList = new List<Label>() { lblEdata };
            int index = 0;
            foreach (var item in list)
            {
                if (String.IsNullOrEmpty(item.Text))
                {
                    lblList[index].Visible = true;
                    status = 0;
                }
                else
                {
                    lblList[index].Visible = false;
                }
                index++;
            }
            return status;
        }
        public int countSelectedMonth()
        {
            int count = 0;
            CheckBox[] checkboxes = { ch01, ch02, ch03, ch04, ch05, ch06, ch07, ch08, ch09, ch10, ch11, ch12 };
            foreach (CheckBox checkbox in checkboxes)
            {
                if (checkbox.Checked)
                {
                    count++;
                }
            }
            return count;
        }
        public int[] passCheckedMonths()
        {
            int[] checkedMonths = new int[12];
            CheckBox[] checkboxes = { ch01, ch02, ch03, ch04, ch05, ch06, ch07, ch08, ch09, ch10, ch11, ch12 };
            for (int i = 0; i < 12; i++)
            {
                if (checkboxes[i].Checked)
                {
                    checkedMonths[i] = 1;
                }
            }
            return checkedMonths;
        }
        public void clearAll(DataTable table)
        {
            CheckBox[] checkboxes = { ch01, ch02, ch03, ch04, ch05, ch06, ch07, ch08, ch09, ch10, ch11, ch12 };
            foreach (CheckBox checkbox in checkboxes)
            {
                checkbox.Checked = false;
            }
            txtInput.Clear();
            lblTotal.Text = "0";
            lblUser.Text = "User Availability";
            lblEdata.Visible = false;
            lblUser.ForeColor = Color.Black;
            setGrid(table);
        }
        public void setGrid(DataTable table)
        {
            gridOutput.DataSource = table;
        }
        public void setlblMothlyfee(string fee)
        {
            lblMonthlyFee.Text = fee;
        }
        public void setlblTotalfee(int total)
        {
            lblTotal.Text = Convert.ToString(total);
        }
        public void setlblUser(string text)
        {
            if (text == "User Not Found")
            {
                lblUser.Text = "User Not Found";
                lblUser.ForeColor = Color.Red;
            }
            else
            {
                lblUser.Text = text;
                lblUser.ForeColor = Color.Green;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            int validation = validateInputFild();
            if (validation == 1)
            {
                data = txtInput.Text;
                Search?.Invoke(this, EventArgs.Empty);
                
            }
        }
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            Calculate?.Invoke(this, EventArgs.Empty);
            
        }
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (validateInputFild() == 1)
            {
                if (lblTotal.Text != "0" && !String.IsNullOrEmpty(txtInput.Text))
                {
                    this.data = txtInput.Text;
                    Confirm?.Invoke(this, EventArgs.Empty);
                }
                
            }
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear?.Invoke(this, EventArgs.Empty);
        }
        private void FormMonthlyPayment_Load(object sender, EventArgs e)
        {
            formLoad?.Invoke(this, EventArgs.Empty);
        }
        public void showMessage(string message)
        {
            MessageBox.Show(message);
        }
    }
}
