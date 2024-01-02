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

namespace Btn
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

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            // 实例化随机函数
            Random random = new Random();

            // random 为int类型，在此处进行强转为byte类型
            Byte r = (Byte)random.Next(255);
            Byte g = (Byte)random.Next(255);
            Byte b = (Byte)random.Next(255);

            // 将btn2的背景颜色进行赋值——改变
            btn2.Background = new SolidColorBrush(Color.FromRgb(r, g, b));
        }
    }
}