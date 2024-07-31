using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    internal class BookController
    {
        private readonly Book _model;
        private readonly FormBook _view;

        public BookController(FormBook book)
        {
            _view = book;
            _model = new Book();

            _view.addBook += OnAddBook;
            _view.editBook += OnEditBook;
            _view.searchBook += OnSearchBook;
            _view.formLoad += OnFormLoad;
            _view.clear += OnClear;

        }

        

        private bool updateProperty()
        {
            try
            {
                _model.bID = _view.bID;
                _model.name = _view.name;
                _model.price = _view.price;
                _model.copy = _view.copy;
                return true;
            }
            catch { return false; }
        }

        private void OnFormLoad(object sender, EventArgs e)
        {
            _view.clearAll(_model.getAllData());
        }

        private void OnAddBook(object sender, EventArgs e)
        {
            if (updateProperty())
            {
                int result = _model.addBook();
                if (result == 1)
                {
                    _view.showMessage("Book added successful.");
                    _view.clearAll(_model.getAllData());
                }
                else
                {
                    _view.showMessage("Book added unsuccessful!");
                }
            }

        }

        private void OnEditBook(object sender, EventArgs e)
        {
            if (updateProperty())
            {
                int result = _model.updateBook();
                if (result == 1)
                {
                    _view.showMessage("Update Successful.");
                    _view.clearAll(_model.getAllData());
                }
                else
                {
                    _view.showMessage("Update Unsuccessful!");
                }
            }
        }

        private void OnSearchBook(object sender, EventArgs e)
        {
            DataTable table = _model.searchByName(_view.name);
            _view.setGrid(table);
        }

        private void OnClear(object sender, EventArgs e)
        {
            _view.clearAll(_model.getAllData());
        }
    }
}
