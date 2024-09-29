using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfAppDemo
{
    /// <summary>
    /// TabControlDemo.xaml 的交互逻辑
    /// </summary>
    public partial class TabControlDemo : Window
    {
        public TabControlDemo()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button element = sender as Button;
            if (element != null && int.TryParse(element.Content.ToString(), out int contentValue))
            {
                this.tab.SelectedIndex = contentValue == 0 ? 1 : 0;
            }
        }
    }
}
