using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library
{
    internal class FormPaymentController
    {
        private readonly FormPayment _view;
        private readonly Payment _modelPayment;

        public FormPaymentController(FormPayment view)
        {
            _view = view;
            _modelPayment = new Payment();

            _view.Go += OnGo;
            _view.FormLoad += OnFormLoad;
            _view.Clear += OnClear;
        }
        private List<int> genareteYearList()
        {
            List<int> list = new List<int>();
            int startYear = _modelPayment.getfirstRecordYear();
            int nowYear = Convert.ToInt32(DateTime.Now.Year);
            if (startYear != 0 && startYear != -1)
            {
                for (int i = nowYear; i >= startYear; i--)
                {
                    list.Add(i);
                }
            }
            else
            {
                list.Add(nowYear);
            }
            return list;
        }
        private void OnClear(object sender, EventArgs e)
        {
            _view.clearAll(_modelPayment.getAllPayment());
        }

        private void OnFormLoad(object sender, EventArgs e)
        {
            List<int> list = genareteYearList();
            _view.setComboBoxYear(list);
            _view.clearAll(_modelPayment.getAllPayment());
        }

        private void OnGo(object sender, EventArgs e)
        {
            int year = _view.getSelectedYear();
            int month = _view.getSelectedMonth();
            String type = null;
            switch (_view.getSelectedType())
            {
                case "Register":
                    type = "R";
                    object[] arr = _modelPayment.getPaymentReport(year, month, type);
                    _view.setGrid((DataTable)arr[1]);
                    break;
                case "Monthly":
                    type = "M";
                    object[] arr2 = _modelPayment.getPaymentReport(year, month, type);
                    _view.setGrid((DataTable)arr2[1]);
                    break;
                case "OverDue":
                    type = "O";
                    object[] arr3 = _modelPayment.getPaymentReport(year, month, type);
                    _view.setGrid((DataTable)arr3[1]);
                    break;
                default:
                    _view.setGrid(_modelPayment.getAllPayment());
                    break;
            }

            object[] arrR = _modelPayment.getPaymentReport(year, month, "R");
            object[] arrM = _modelPayment.getPaymentReport(year, month, "M");
            object[] arrO = _modelPayment.getPaymentReport(year, month, "O");

            int[] list = new int[3];
            list[0] = Convert.ToInt32(arrR[0]);
            list[1] = Convert.ToInt32(arrM[0]);
            list[2] = Convert.ToInt32(arrO[0]);

            _view.setTotalLbl(list);
        }

        
    }
}
