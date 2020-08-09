using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Window1.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Window1 : Window
    {
        static DateTime datetime = ((MainWindow)Application.Current.MainWindow).datetime;
        private System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + @"\diary_data\" + datetime.ToString("yy_MM"));
        

        public Window1()
        {
            InitializeComponent();
            datetime = ((MainWindow)Application.Current.MainWindow).datetime;
        }


        private void Save_Button_Click(object sender, RoutedEventArgs e)
        {
            datetime = ((MainWindow)Application.Current.MainWindow).datetime;
            System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + @"\diary_data\" + datetime.ToString("yy_MM"));
            string titleContent = titleBox.Text;
            string savePath = di.FullName +@"\" +titleBox.Text+".txt";
            if (!di.Exists)
            {
                di.Create();
            }
            string nowDate = DateTime.Now.ToString("yyyy_MM_dd-");
            foreach (char c in System.IO.Path.GetInvalidFileNameChars())
            {
                titleContent = titleContent.Replace(c, '_');
            }

            if (titleBox.IsEnabled)
            {
                savePath = di.FullName + @"\" + nowDate + titleContent + ".txt";
            }

            System.IO.File.WriteAllText(savePath, contentBox.Text, Encoding.UTF8);
            Window.GetWindow(this).Close();
        }

        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Close();
        }

        private void Activated_Window(object sender, EventArgs e)
        {
            if (((MainWindow)Application.Current.MainWindow).postListBox.SelectedItem != null)
            {
                datetime = ((MainWindow)Application.Current.MainWindow).datetime;
                System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + @"\diary_data\" + datetime.ToString("yy_MM"));
                var item = ((MainWindow)Application.Current.MainWindow).postListBox.SelectedItem;
                string path = di.FullName+ @"\" + item.ToString();
                string content = System.IO.File.ReadAllText(path);
                titleBox.Text = item.ToString().Replace(".txt","");
                titleBox.IsEnabled = false;
                contentBox.Text = content;
            }
        }

    }
}
