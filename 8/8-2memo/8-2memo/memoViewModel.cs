using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media.TextFormatting;

namespace _8_2memo
{
    #region 属性更改通知
    /// <summary>
    /// ViewModelUtil用于通知属性发生更改
    /// </summary>
    public class ViewModelUtil : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string propertyName)
        {
            if (propertyName != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
    #endregion

    
    public class memoViewModel : ViewModelUtil
    {

        #region 数据部分
        /// <summary>
        /// 保存信息的集合
        /// </summary>
        public ObservableCollection<memoModel> MemoCollection { get; set; }

        /// <summary>
        /// 展示信息的集合
        /// </summary>
        // 双向绑定，当列表发生更改时，进行通知
        ObservableCollection<memoModel> memoData;

        public ObservableCollection<memoModel> MemoData
        {

            get { return memoData; }
            set
            {
                memoData = value;
                RaisePropertyChanged(nameof(memoData));
            }
        }

        public memoViewModel()
        {
            // 数据备份
            MemoCollection =
            [
                new memoModel() { ID = 1, _event = "学习WPF", _type = "学习", _reminder_time = "2024-1-20"},
                new memoModel() { ID = 2, _event = "出门拍照", _type = "娱乐", _reminder_time = "2024-1-20",Completed=true},
                new memoModel() { ID = 3, _event = "完成练手项目8-2", _type = "工作", _reminder_time = "2024-1-20"},
            ];
            memoData = MemoCollection;
        }
        #endregion

        #region 添加、删除和修改部分
        /// <summary>
        /// 添加和删除命令
        /// </summary>
        bool isCanExec = true;
        public ICommand MyCommand => new MyCommand(MyAction,MyCanExec);

        //计数器
        private int myID = 3;
        private void MyAction(object pramparameter)
        {
            if (bool.Parse(pramparameter.ToString()))
            {
                myID++;
                // 点击添加按钮后增加一行新数据，ID自增长
                memoData.Add(new memoModel() { ID = myID });
            }
            else if (!bool.Parse(pramparameter.ToString()))
            {
                // 需实现删除选定行
                // 目前为删除第一行
                memoData.RemoveAt(0);
            }
        }
        private bool MyCanExec(object arg)
        {
            return isCanExec;
        }
        #endregion

        #region 查找部分
        /// <summary>
        /// 查找功能
        /// </summary>

        public ICommand SearchCommand => new SearchCommand(SearchAction, MyCanExec);

        private string text_Filter;

        public string Text_Filter 
        {
            get { return text_Filter; }
            set {  text_Filter = value; }
        }


        private void SearchAction(object obj)
        {
            memoData = new ObservableCollection<memoModel>(MemoCollection);
            RaisePropertyChanged(nameof(memoData));
            if (text_Filter is not null)
            {
                //item.Completed = true;
                var temp = memoData.Where(p => p._event.Contains(text_Filter) || p._type.Contains(text_Filter) || p._reminder_time.Contains(text_Filter));
                memoData = new ObservableCollection<memoModel>(temp);
                RaisePropertyChanged(nameof(memoData));
            }               
        }
        #endregion

        #region 筛选是否完成功能
        // 定义变量，表征复选框当前已勾选
        bool _select = true;
        public ICommand SelectCommand => new SearchCommand(SelectAction, MyCanExec);
        private void SelectAction(object obj)
        {
            // 重新绑定原始数据
            memoData = new ObservableCollection<memoModel>(MemoCollection);
            RaisePropertyChanged(nameof(memoData));
            if (_select)
            {
                // 临时变量，获取所有已完成的数据
                var temp = memoData.Where(p=>p.Completed == true);
                // 将已完成的数据赋值给memoData
                memoData = new ObservableCollection<memoModel>(temp);
                // 通知UI，memoData数据已经更新
                RaisePropertyChanged(nameof(memoData));
                // 将复选框状态置反，使得下次点击时进行不同操作
                _select = !_select;
            }
            else
            {
                var temp = memoData.Where(p => p.Completed == false);
                memoData = new ObservableCollection<memoModel>(temp);
                RaisePropertyChanged(nameof(memoData));
                _select = !_select;
            }
        }
        #endregion

    }
}
