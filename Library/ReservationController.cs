using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library
{
    internal class ReservationController
    {
        private readonly FormReservationHandle _view;
        private readonly Customer _modelCustomer;
        private readonly Reservation _modelReservation;
        public ReservationController(FormReservationHandle view) 
        {
            _view = view;
            _modelCustomer = new Customer();
            _modelReservation = new Reservation();

            _view.Confirm += OnConfirm;
            _view.Check += OnCheck;
            _view.FormLoad += OnFormLoad;
            _view.Search += OnSearch;
            _view.DisplayHistory += OnDisplayHistory;
            _view.Clear += OnClear;
        }

        private void OnClear(object sender, EventArgs e)
        {
            _view.clearLbl();
            _view.cleartxt();
            _view.hideError();
            _view.setGrid(_modelReservation.getAll());
        }

        private void OnDisplayHistory(object sender, EventArgs e)
        {
            String CID = _modelCustomer.getCIDByCIDorPno(_view.data);
            if (!String.IsNullOrEmpty(CID))
            {
                Form form = new FormRHistory(CID);
                form.Show();
            }
        }

        private void OnSearch(object sender, EventArgs e)
        {
            if (isUserValied())
            {
                DataTable table = _modelReservation.getReservationTableByCID(_modelCustomer.getCIDByCIDorPno(_view.data));
                _view.setGrid(table);
            }

        }

        private void OnFormLoad(object sender, EventArgs e)
        {
            _view.setGrid(_modelCustomer.getAll());
        }

        public bool isUserValied()
        {
            string cid = null;
            cid = _modelCustomer.getCIDByCIDorPno(_view.data);
            if (String.IsNullOrEmpty(cid))
            {
                _view.setlblUser("User Not Found");
                _view.unVisibleHistory();
                return false;
            }
            else
            {
                string name = _modelCustomer.getCNamebyCID(cid);
                _view.setlblUser("User Avilable : " + name);
                _view.visibleHistory();
                return true;
            }
        }

        public void setGridByCID()
        {
            _view.setGrid(_modelReservation.getAllReservationByCID(_modelCustomer.getCIDByCIDorPno(_view.data)));
        }

        private void OnCheck(object sender, EventArgs e)
        {
            if (isUserValied())
            {
                setGridByCID();
                int[] arr = _modelReservation.checkEligibilityOfCustomerByCIDandBID(_modelCustomer.getCIDByCIDorPno(_view.data), _view.bid);
                if (arr != null)
                {
                    _view.setEligibilityLable(arr);
                }
            }
        }

        
        public void OnConfirm(object sender, EventArgs e)
        {
            String CID = _modelCustomer.getCIDByCIDorPno(_view.data);
            int result = _modelReservation.addReservation(CID, _view.bid);
            if (result == 1)
            {
                _view.showMessage("Record added");
            }
            else if (result == 2)
            {
                _view.showMessage("Unsucess!(Not Eligible)");
            }
            else
            {
                _view.showMessage("Unsucess!");
            }
            _view.setGrid(_modelReservation.getReservationTableByCID(CID));
        }
    }
}
