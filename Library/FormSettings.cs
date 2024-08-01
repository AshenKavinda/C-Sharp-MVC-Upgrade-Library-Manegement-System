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
    public partial class FormSettings : Form
    {
        public FormSettings()
        {
            InitializeComponent();
            new FormSettingsController(this);
        }

        public event EventHandler Save;
        public event EventHandler FormLoad;

        public void setAllTextBox(int[] list)
        {
            TextBox[] txtList = { txtRegister, txtMonthly, txtOverDue, txtLimit, txtOverDueBoolLimit, txtMinimumBookLimit };
            if (list.Length == 6)
            {
                for (int i = 0; i < 6; i++)
                {
                    txtList[i].Text = Convert.ToString(list[i]);
                }
            }
        }

        public string[] getAllTextBox()
        {
            TextBox[] txtList = {txtRegister,txtMonthly,txtOverDue,txtLimit,txtOverDueBoolLimit,txtMinimumBookLimit};
            string[] list = new string[6];
            for (int i = 0; i < 6; i++)
            {
                list[i] = txtList[i].Text;
            }
            return list;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Confirm", "Sure", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            if (result == DialogResult.OK) 
            {
                Save?.Invoke(this, new EventArgs());
            }
        }

        private void FormSettings_Load(object sender, EventArgs e)
        {
            FormLoad?.Invoke(this, EventArgs.Empty);
        }
    }
}
