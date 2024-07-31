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
    public partial class FormBook : Form
    {
        Book book;

        public event EventHandler addBook;
        public event EventHandler editBook;
        public event EventHandler searchBook;
        public event EventHandler formLoad;
        public event EventHandler clear;

        public string bID;
        public string name;
        public string price;
        public string copy;

        public FormBook()
        {
            InitializeComponent();
            book = new Book();
            
        }

        public void setGrid(DataTable table)
        {
            dataGrid.DataSource = table;
        }

        public void clearAll(DataTable table)
        {
            txtBID.Clear();
            txtName.Clear();
            txtNoOfCopys.Clear();
            txtPrice.Clear();
            setGrid(table);
            hideError();
        }

        private void hideError()
        {
            List<Label> lblList = new List<Label>() { lblEName, lblEPrice, lblECopys,lblEBID };
            foreach (var item in lblList)
            {
                item.Visible = false;
            }

        }

        private bool validateInputFild()
        {
            bool status = true;
            List<TextBoxBase> list = new List<TextBoxBase>() { txtName,txtPrice,txtNoOfCopys,txtBID };
            List<Label> lblList = new List<Label>() { lblEName, lblEPrice, lblECopys, lblEBID };
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
                this.bID = txtBID.Text;
                this.name = txtName.Text;
                this.price = txtPrice.Text;
                this.copy = txtNoOfCopys.Text;
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public void btnAdd_Click(object sender, EventArgs e)
        {
            if (validateInputFild())
            {
                addBook?.Invoke(this, EventArgs.Empty);
            }
                
        }

        public void btnEdit_Click(object sender, EventArgs e)
        {
            if (validateInputFild())
            { 
                DialogResult result = MessageBox.Show("Confirm Details", "Sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    editBook?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        public void dataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (dataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    dataGrid.CurrentRow.Selected = true;
                    txtBID.Text = dataGrid.Rows[e.RowIndex].Cells["BID"].FormattedValue.ToString();
                    txtName.Text = dataGrid.Rows[e.RowIndex].Cells["Name"].FormattedValue.ToString();
                    txtPrice.Text = dataGrid.Rows[e.RowIndex].Cells["Price"].FormattedValue.ToString();
                    txtNoOfCopys.Text = dataGrid.Rows[e.RowIndex].Cells["NoCopy"].FormattedValue.ToString();
                }
            }
        }

        public void btnSearch_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtName.Text))
            {
                this.name = txtName.Text;
                searchBook?.Invoke(this, EventArgs.Empty);
            }
            
        }

        public void btnClear_Click(object sender, EventArgs e)
        {
            clear?.Invoke(this, EventArgs.Empty);
        }

        private void FormBook_Load(object sender, EventArgs e)
        {
            formLoad?.Invoke(this, EventArgs.Empty);
        }

        public void showMessage(string message)
        {
            MessageBox.Show(message);
        }
    }
}
