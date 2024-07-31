using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library
{
    internal class CustomerController
    {
        private readonly Customer _model;
        private readonly FormCoustomerHandle _view;

        public CustomerController(FormCoustomerHandle view)
        {
            _view = view;
            _model = new Customer();

            _view.AddCustomer += OnAddCustomer;
            _view.UpdateCustomer += OnUpdateCustomer;
            _view.SearchCustomer += OnSearchCustomer;
            _view.formLoad += OnFormLoad;
            _view.Clear += OnClear;
         
        }

        private void OnClear(object sender, EventArgs e)
        {
            _view.clearAll(_model.getAll());
        }

        private void OnFormLoad(object sender, EventArgs e)
        {
            _view.CID = _model.getNextCID();
            _view.clearAll(_model.getAll());
            _view.hideError();
        }

        private void OnSearchCustomer(object sender, EventArgs e)
        {
            if (_model.validateCustomerByCIDorPno(_view.Pno) == 2)
            {
                DataTable dataTable = _model.searchCustomerByPno(_view.Pno);
                _view.setCustomerTableToGrid(dataTable);
                string id = _model.getCIDByCIDorPno(_view.Pno);
                string name = _model.getCNamebyCID(id);
                _view.setCustomerAvilability(name);
            }
            else
            {
                _view.setCustomerAvilability("User not Found");
            }
        }

        private void OnUpdateCustomer(object sender, EventArgs e)
        {
            _model.CID = _view.CID;
            _model.FName = _view.FName;
            _model.LName = _view.LName;
            _model.NIC = _view.NIC;
            _model.Pno = _view.Pno;
            _model.Email = _view.Email;

            _view.showMessage(_model.Pno);
            _view.showMessage(_model.CID);

            int result = _model.updateCustomerByCID();
            if (result == 1)
            {
                _view.showMessage("Customer updated successfully!");
                _view.CID = _model.getNextCID();
                _view.clearAll(_model.getAll());
            }
            else
            {
                _view.showMessage("Error updating customer.");
            }
        }

        private void OnAddCustomer(object sender, EventArgs e)
        {
            _model.FName = _view.FName;
            _model.LName = _view.LName;
            _model.NIC = _view.NIC;
            _model.Pno = _view.Pno;
            _model.Email = _view.Email;

            int result = _model.addCustomer();
            if (result == 1)
            {
                _view.showMessage("Customer added successfully!");
                _view.CID = _model.getNextCID();
                _view.clearAll(_model.getAll());
            }
            else
            {
                _view.showMessage("Error adding customer.");
            }

        }
    }
}
