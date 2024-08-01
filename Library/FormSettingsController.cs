using Library.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    internal class FormSettingsController
    {
        private readonly FormSettings _view;
        private readonly Settings _modelSettings;

        public FormSettingsController(FormSettings view)
        {
            _view = view;
            _modelSettings = new Settings();

            _view.FormLoad += OnFormLoad;
            _view.Save += OnSave;
        }

        private void OnSave(object sender, EventArgs e)
        {
            string[] list = _view.getAllTextBox();
            _modelSettings.updateRegisterFee(list[0]);
            _modelSettings.updateMonthlyFee(list[1]);
            _modelSettings.updateOverDueFee(list[2]);
            _modelSettings.UpdateOverDueLimit(list[3]);
            _modelSettings.UpdateOverDueBookLimit(list[4]);
            _modelSettings.UpdateMinimumBookLimit(list[5]);
        }

        private void OnFormLoad(object sender, EventArgs e)
        {
            int[] arr = new int[6];
            arr[0] = _modelSettings.getRegisterFee();
            arr[1] = _modelSettings.getMonthlyFee();
            arr[2] = _modelSettings.getOverDueFee();
            arr[3] = _modelSettings.getOverDueLimit();
            arr[4] = _modelSettings.getOverDueBookLimit();
            arr[5] = _modelSettings.getMinimumBookLimit();
            _view.setAllTextBox(arr);
        }
    }
}
