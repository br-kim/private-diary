using System;
using System.Collections.Generic;
using System.IO;
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
        string queryMonthDate = DateTime.Now.ToString("yy_MM");
        public DateTime datetime = DateTime.Now;

        private System.IO.DirectoryInfo createDi(string date)
        {
            System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + @"\diary_data\" + date);
            return di;
        }

        public MainWindow()
        {
            InitializeComponent();
            label1.Content = datetime.ToString("yy년 MM월");
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            postListBox.UnselectAll();
            Window Window1 = new Window1();
            Window1.Show();
        }

        private void Get_Directory_File_Name(String monthDate)
        {
            var di = createDi(monthDate);
            List<String> nameList = new List<string>();
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
            string nowMonthDate = datetime.ToString("yy_MM");
            Get_Directory_File_Name(nowMonthDate);
            
        }

        private void postListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Window Window1 = new Window1();
            Window1.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            datetime = datetime.AddMonths(-1);
            queryMonthDate = datetime.ToString("yy_MM");
            
            if (createDi(queryMonthDate).Exists)
            {
                Get_Directory_File_Name(queryMonthDate);
                label1.Content = datetime.ToString("yy년 MM월");
            }
            else
            {
                datetime = datetime.AddMonths(1);
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            datetime = datetime.AddMonths(1);
            queryMonthDate = datetime.ToString("yy_MM");
            
            if (createDi(queryMonthDate).Exists)
            {
                Get_Directory_File_Name(queryMonthDate);
                label1.Content = datetime.ToString("yy년 MM월");
            }
            else
            {
                datetime = datetime.AddMonths(-1);
            }
        }
    }
}
