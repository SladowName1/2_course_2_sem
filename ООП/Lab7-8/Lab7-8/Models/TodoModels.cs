using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Lab7_8.Models
{
    public class TodoModels:INotifyPropertyChanged
    {
        public DateTime CreationDate { get; set; } = DateTime.Now;

		private bool _isDone;
		public string _text;
		public string _pereodicaly;
		public int _priorety;


		public bool IsDone
		{
			get { return _isDone; }
			set 
			{
				if (_isDone == value)
					return;
				_isDone = value;
				OnPropertyChanged("IsDone");
			}
		}
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
		public int Priorety
		{
			get { return _priorety; }
			set 
			{
				if (_priorety == value)
					return;
				_priorety = value;
				OnPropertyChanged("Priorety");
			}
		}
		public string Pereodicaly
		{
			get { return _pereodicaly; }
			set 
			{
				if (_pereodicaly == value)
					return;
				_pereodicaly = value;
				OnPropertyChanged("Pereodicaly");
			}
		}


		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged(string propertyName="")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

	}
}
