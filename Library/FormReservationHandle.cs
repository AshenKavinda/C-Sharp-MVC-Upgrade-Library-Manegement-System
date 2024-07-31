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
    public partial class FormReservationHandle : Form
    {

        public string data;
        public string bid;
        public FormReservationHandle()
        {
            InitializeComponent();
            new ReservationController(this);
        }

        public void visibleHistory()
        {
            btnHistory.Visible = true;
        }

        public void unVisibleHistory()
        {
            btnHistory.Visible = false;
        }

        public void setGrid(DataTable table)
        {
            dataGrid.DataSource = table;
        }

        public void cleartxt()
        {
            txtData.Clear();
            txtBID.Clear();
        }

        public void clearLbl()
        {
            lblBA.Text = "Status";
            lblBA.ForeColor = Color.Black;
            lblMP.Text = "Status";
            lblMP.ForeColor = Color.Black;
            lblOD.Text = "Status";
            lblOD.ForeColor = Color.Black;
            lblUser.Text = "User Availability";
            lblUser.ForeColor = Color.Black;
            btnHistory.Visible = false;

        }

        public void hideError()
        {
            List<Label> lblList = new List<Label>() { lblEdata,lblEID };
            foreach (var item in lblList)
            {
                item.Visible = false;
            }

        }

        private bool validateInputFild()
        {
            bool status = true;
            List<TextBoxBase> list = new List<TextBoxBase>() { txtData,txtBID };
            List<Label> lblList = new List<Label>() { lblEdata,lblEID };
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
            return status;
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

        public void setEligibilityLable(int[] arr)
        {
            if (arr.Length == 3 && arr != null)
            {
                if (arr[0] == 1)
                {
                    lblBA.Text = "OK";
                    lblBA.ForeColor = Color.Green;
                }
                else
                {
                    lblBA.Text = "NO";
                    lblBA.ForeColor = Color.Red;
                }
                if (arr[1] == 1)
                {
                    lblMP.Text = "OK";
                    lblMP.ForeColor = Color.Green;
                }
                else
                {
                    lblMP.Text = "NO";
                    lblMP.ForeColor = Color.Red;
                }
                if (arr[2] == 1)
                {
                    lblOD.Text = "OK";
                    lblOD.ForeColor = Color.Green;
                }
                else
                {
                    lblOD.Text = "NO";
                    lblOD.ForeColor = Color.Red;
                }
            }
        }

        public event EventHandler Search;
        private void btnSearch_Click(object sender, EventArgs e)
        {
            data = txtData.Text;
            bid = txtBID.Text;
            Search?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler DisplayHistory;
        private void btnHistory_Click(object sender, EventArgs e)
        {
            DisplayHistory?.Invoke(this, EventArgs.Empty);

        }

        public event EventHandler Check;
        private void btnCheck_Click(object sender, EventArgs e)
        {

            if (validateInputFild())
            {
                this.data = txtData.Text;
                this.bid = txtBID.Text;
                Check?.Invoke(this, EventArgs.Empty);
            }
            
        }

        public event EventHandler Confirm;
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (validateInputFild())
            {
                this.data = txtData.Text;
                this.bid = txtBID.Text;

                Confirm?.Invoke(this, EventArgs.Empty);
                clearLbl();
                txtBID.Clear();
            }
        }

        public event EventHandler Clear;

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler FormLoad;
        private void FormReservationHandle_Load(object sender, EventArgs e)
        {
            unVisibleHistory();
            clearLbl();
            cleartxt();
            hideError();
            FormLoad?.Invoke(this, EventArgs.Empty);
        }

        public void showMessage(string message)
        {
            MessageBox.Show(message);
        }
    }
}
