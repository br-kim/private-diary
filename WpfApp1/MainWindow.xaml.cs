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

namespace WpfApp1
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
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            postListBox.UnselectAll();
            Window Window1 = new Window1();
            Window1.Show();
        }

        private void Get_Directory_File_Name()
        {
            List<String> nameList = new List<string>();
            System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + @"\diary_data");
            if (!di.Exists)
            {
                di.Create();
            }
            foreach (var item in di.GetFiles())
            {
                nameList.Add(item.Name);
            }
            postListBox.ItemsSource = nameList;
        }

        private void Activated_Window(object sender, EventArgs e)
        {
            Get_Directory_File_Name();
        }

        private void postListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Window Window1 = new Window1();
            Window1.Show();
        }
     
    }
}
