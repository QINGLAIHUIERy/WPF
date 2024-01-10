using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;

namespace _8_2memo
{
    public class memoModel:INotifyPropertyChanged
    {
        //分别对ID等进行定义
        public int ID { get; set; }
        public string _event { get; set; }

        public string _type { get; set; }
        public string _reminder_time { get; set; }

        private bool _completed;
        public  bool Completed
        {
            get { return _completed; }
            set { _completed = value;
                OnPropertyChanged("Completed");
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        //public bool isSelect { get; set; }

    }


}
