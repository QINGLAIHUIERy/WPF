using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace WPF_LoginUI
{
    public class LoginVM:INotifyPropertyChanged
    {
        private MainWindow _main;
        public LoginVM(MainWindow main) 
        {
            _main = main;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }


        private LoginModel _LoginM = new LoginModel();

        public string UserName
        {
            get { return _LoginM.UserName; }
            set
            { 
                _LoginM.UserName = value;
                RaisePropertyChanged("UserName");
            }
        }

        public string PassWord
        {
            get { return _LoginM.PassWord; }
            set
            { 
                _LoginM.PassWord = value;
                RaisePropertyChanged("PassWord");
            }
        }


        // 登录方法
        void LoginFunc()
        {
            if (UserName == "admin" && PassWord == "123456")
            {
                //弹出新界面
                Index index = new Index();
                index.Show();

                //隐藏界面_mainwindow 
                _main.Close();
            }
            else
            {
                //弹出警告框
                MessageBox.Show("用户名或密码错误");

                //清空文本框内容
                UserName = "";
                PassWord = "";
            }
        }

        bool CanLoginExecute()
        {
            return true;
        }

        public ICommand LoginAction
        {
            get
            {
                return new RelayCommand(LoginFunc, CanLoginExecute);
            }
        }
    }
}
