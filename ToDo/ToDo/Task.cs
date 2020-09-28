using Xamarin.Forms;

namespace ToDo
{
    class Task : BindableObject
    {
        private string _text;
        private bool _check;

        public string Text
        {
            get { return _text; }
            set { _text = value; OnPropertyChanged(nameof(Text)); }
        }
        public bool Check
        {
            get { return _check; }
            set { _check = value; OnPropertyChanged(nameof(Check)); }
        }
    }
}
