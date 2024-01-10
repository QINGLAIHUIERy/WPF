using System.ComponentModel;
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
using System.Windows.Threading;

namespace light
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer _timer;
        private bool _isFlashing; // 控制闪烁状态的变量  
        private bool a = false;
        public MainWindow()
        {
            InitializeComponent();
            // 初始化定时器并设置为null，因为我们稍后会根据需要创建或销毁它。  
            _timer = null;
        }

        public void button_click(object sender, RoutedEventArgs e)
        {
            a = !a;
            // 创建或重置定时器  
            if (_timer == null && a)
            {
                _timer = new DispatcherTimer();
                _timer.Interval = TimeSpan.FromMilliseconds(500); // 设置为半秒（500毫秒）的间隔时间来控制闪烁效果。  
                _timer.Tick += Timer_Tick; // 绑定Tick事件处理程序。  
                _timer.Start(); // 启动定时器。
            }
            else
            {
                // 关闭并重置定时器
                _timer.Stop();
                _timer = null;
                // 将指示灯置为白色
                signal_light.Fill = new SolidColorBrush(Colors.White);
            }

        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // 如果指示灯处于闪烁状态，则交替改变图片的可见性来模拟闪烁效果。  
            if (_isFlashing)
            {
                signal_light.Fill = new SolidColorBrush(Colors.Red);
            }
            else
            {
                signal_light.Fill = new SolidColorBrush(Colors.White);
            }
            // 切换指示灯的状态以触发闪烁。这里通过一个简单的布尔值来实现开/关切换效果。  
            _isFlashing = !_isFlashing; // 切换 _isFlashing 的状态来开启或关闭闪烁效果。 
        }

    }
}