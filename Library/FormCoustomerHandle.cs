using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Library
{
    public partial class FormCoustomerHandle : Form
    {

        public event EventHandler AddCustomer;
        public event EventHandler UpdateCustomer;
        public event EventHandler SearchCustomer;
        public event EventHandler formLoad;
        public event EventHandler Clear;

        public string CID;
        public string FName;
        public string LName;
        public string NIC;
        public string Pno;
        public string Email;


        public FormCoustomerHandle()
        {
            InitializeComponent();
            new CustomerController(this);
        }

        public void setCustomerAvilability(string name)
        {
            if (name == "User not Found")
            {
                lblUserAvailability.Text = "User not Found";
                lblUserAvailability.ForeColor = Color.Red;
            }else
            {
                lblUserAvailability.Text = name;
                lblUserAvailability.ForeColor = Color.Green;
            }
            
        }

        private void FormCoustomerHandle_Load(object sender, EventArgs e)
        {
            formLoad?.Invoke(this, EventArgs.Empty);
        }

        public void hideError()
        {
            List<Label> lblList = new List<Label>() { lblEFname, lblELname, lblENic, lblEEmail, lblEPno };
            foreach (var item in lblList)
            {
                item.Visible = false;
            }
            
        }

        public void clearAll(DataTable table)
        {
            txtFname.Clear();
            txtLname.Clear();
            txtNIC.Clear();
            txtPno.Clear();
            txtEmail.Clear();
            txtIndex.Clear();
            lblPayment.ForeColor = Color.Black;
            chPayment.Checked = false;
            lblUserAvailability.Text = "UserAvailability";
            lblUserAvailability.ForeColor = Color.Black;
            txtIndex.Text = CID;
            setCustomerTableToGrid(table);
            hideError();
        }
        
        public void setCustomerTableToGrid(DataTable table)
        {
            gridCustomer.DataSource = table;
        }

        private bool validateInputFild()
        {
            bool status = true;
            List<TextBoxBase> list = new List<TextBoxBase>() { txtFname,txtLname,txtNIC,txtEmail,txtPno};
            List<Label> lblList = new List<Label>() { lblEFname,lblELname,lblENic,lblEEmail,lblEPno };
            int index = 0;
            foreach (var item in list)
            {
                if (String.IsNullOrEmpty(item.Text))
                {
                    lblList[index].Visible = true;
                    status = false;
                }
                else
                {
                    lblList[index].Visible = false;
                }
                index++;
            }
            if (status)
            {
                this.CID = txtIndex.Text;
                this.FName = txtFname.Text;
                this.LName = txtLname.Text;
                this.NIC = txtNIC.Text;
                this.Pno = txtPno.Text;
                this.Email = txtEmail.Text;
            }
            return status;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {         
            if (chPayment.Checked && validateInputFild())
            {
                AddCustomer?.Invoke(this, EventArgs.Empty);                
            }
            else
            {
                lblPayment.ForeColor = Color.Red;
            }

        }


        private void btnEdit_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Confirm Upadate","Sure",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes && validateInputFild())
            {
                UpdateCustomer?.Invoke(this, EventArgs.Empty);
            }
            
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            /*
            */
            this.Pno = txtPno.Text;
            SearchCustomer?.Invoke(this, EventArgs.Empty);
            
        }

        public void btnClear_Click(object sender, EventArgs e)
        {
            Clear?.Invoke(this, EventArgs.Empty);
        }

        private void gridCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (gridCustomer.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    gridCustomer.CurrentRow.Selected = true;
                    txtIndex.Text = gridCustomer.Rows[e.RowIndex].Cells["CID"].FormattedValue.ToString();
                    txtFname.Text = gridCustomer.Rows[e.RowIndex].Cells["FName"].FormattedValue.ToString();
                    txtLname.Text = gridCustomer.Rows[e.RowIndex].Cells["LName"].FormattedValue.ToString();
                    txtNIC.Text = gridCustomer.Rows[e.RowIndex].Cells["NIC"].FormattedValue.ToString();
                    txtPno.Text = gridCustomer.Rows[e.RowIndex].Cells["PNo"].FormattedValue.ToString();
                    txtEmail.Text = gridCustomer.Rows[e.RowIndex].Cells["Email"].FormattedValue.ToString();
                }
            }
        }


        public void showMessage(string message)
        {
            MessageBox.Show(message);
        }

    }
}
