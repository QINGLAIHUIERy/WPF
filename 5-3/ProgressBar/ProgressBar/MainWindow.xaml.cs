using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProgressBar
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this; // 将当前窗口实例设置为DataContext，以便于进行数据绑定  
            slider.ValueChanged += Slider_ValueChanged; // 添加值变化事件处理程序来更新TextBox的值  
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // 将slider的新值格式化为字符串，并设置为textbox中的text值,精确至一位小数
            textbox.Text = e.NewValue.ToString("F1");
        }
    }
}