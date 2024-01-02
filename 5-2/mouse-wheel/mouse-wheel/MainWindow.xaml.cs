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

namespace mouse_wheel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        
        // 设置全局变量
        private double currentvalue;
        // 定义增量
        private double step;
        private void textbox_1_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            textbox_1.Focus();
            // 获取当前的textbox_1中的数值
            currentvalue = double.Parse(textbox_1.Text);
            // 步长
            step = 1;
            if (e.Delta > 0)
            {
                // 向上滚动时
                // 实现增加1
                currentvalue += step;
            }
            else if (e.Delta < 0)
            {
                currentvalue -= step;
            }

            // 设置TextBox的新值
            textbox_1.Text = currentvalue.ToString();
        }
    }
}