using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace WPF.models
{
    internal class ToDoModel: INotyfyPropertyChanged 
    {
        public DateTime CreationDate { get; set; } = DateTime.Now;

		private bool _isDone;
		public bool IsDone
		{
			get { return _isDone; }
			set
			{
				if( _isDone == value )
					return;
				_isDone= value;
				OnPropertyChanged("IsDone");
			}
		}

		private string _text;
		public string Text
		{
			get { return _text; }
			set 
			{ 
				if (_text == value) 
					return;
				_text = value;
				OnPropertyChanged("Text");
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged(string propertyName = "")
		{
			if (PropertyChanged != null) 
			{ 
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName)); 
			}
			
		}
	}
}
