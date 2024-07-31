using Library.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    internal class MonthlyPaymentController
    {
        private readonly FormMonthlyPayment _view;
        private readonly Payment _modelPayment;
        private readonly Customer _modelCustomer;
        private readonly Settings _modelSettings;

        public MonthlyPaymentController(FormMonthlyPayment view)
        {
            _view = view;
            _modelCustomer = new Customer();
            _modelSettings = new Settings();
            _modelPayment = new Payment(_modelCustomer);

            _view.Calculate += OnCalculate;
            _view.formLoad += OnFormLoad;
            _view.Confirm += OnConfirm;
            _view.Clear += OnClear;
            _view.Search += OnSearch;
        }

        private void OnSearch(object sender, EventArgs e)
        {
            if (isUserValied())
            {
                string cid = _modelCustomer.getCIDByCIDorPno(_view.data);
                _view.setGrid(_modelPayment.getMonthlyPaymentTableByCID(cid));
                
            }
        }

        private void OnClear(object sender, EventArgs e)
        {
            DataTable table = _modelPayment.getAllMonthlyPayment();
            _view.clearAll(table);
        }

        private void OnConfirm(object sender, EventArgs e)
        { 
            try
            {
                if (!String.IsNullOrEmpty(_view.data))
                {
                    int[] months = _view.passCheckedMonths();
                    if (months != null)
                    {
                        int total = _view.countSelectedMonth()*_modelSettings.getMonthlyFee();
                        string pid = _modelPayment.addMonthlyPayment(_view.data, total);
                        if (pid != null)
                        {
                            for (int i = 0; i < 12; i++)
                            {
                                if (months[i]==1)
                                {
                                    _modelPayment.setMonthlyPayment(_view.data, i+1, pid);
                                }
                            }
                            _view.showMessage("Payment Successful");
                            _view.setGrid(_modelPayment.getMonthlyPaymentTableByCID(_modelCustomer.getCIDByCIDorPno(_view.data)));
                        }
                        else
                        {
                            _view.showMessage("Payment error");
                        }
                    }
                }
            }
            catch
            {
                _view.showMessage("Error");
            }
        }

        public bool isUserValied()
        {
            string cid = null;
            cid = _modelCustomer.getCIDByCIDorPno(_view.data);
            if (String.IsNullOrEmpty(cid))
            {
                _view.setlblUser("User Not Found");
                return false;
            }
            else
            {
                string name = _modelCustomer.getCNamebyCID(cid);
                _view.setlblUser("User Avilable : " + name);
                return true;
            }
        }

        private void OnFormLoad(object sender, EventArgs e)
        {
            _view.clearAll(_modelPayment.getAllMonthlyPayment());
            _view.setlblMothlyfee(Convert.ToString(_modelSettings.getMonthlyFee()));

        }

        private void OnCalculate(object sender, EventArgs e)
        {
            int count = _view.countSelectedMonth();
            _view.setlblTotalfee(_modelSettings.getMonthlyFee() * count);
        }
    }
}
