using ContentTemplate.DB;
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

namespace ContentTemplate
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Services.StudentService studentService;
        public MainWindow()
        {
            InitializeComponent();
            RunContent();
        }

        private void RunContent()
        {
            try
            {
                studentService = new Services.StudentService();
                listBoxContent.ItemsSource = studentService.GetStudents();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bthChange_Click(object sender, RoutedEventArgs e)
        {
            var b = sender as Button;
            var s = b.DataContext as Student;
            MyForms.StudentChangeWindow window = new MyForms.StudentChangeWindow(s);
            window.Show();
        }
        private void addGroup_Click(object sender, RoutedEventArgs e)
        {
            MyForms.AddGroupWindow window = new MyForms.AddGroupWindow();
            window.Show();
        }
        private void addStudent_Click(object sender, RoutedEventArgs e)
        {
            MyForms.AddSudentWindow window = new MyForms.AddSudentWindow();
            window.Show();
        }

        /// <summary>
        /// Обновить список
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btbRefresh_Click(object sender, RoutedEventArgs e)
        {
            RunContent();
        }

        private void bthDell_Click(object sender, RoutedEventArgs e)
        {
            var b = sender as Button;
            var s = b.DataContext as Student;
            var res = MessageBox.Show($" Удаление студента {s.Name}, Вы уверены?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) ;

            if (res == MessageBoxResult.Yes)
            {
                try
                {
                    Services.StudentService service = new Services.StudentService();
                    service.Remove(s);
                    MessageBox.Show("Студент  удален, обновите список");
                }
                catch (Exception ex)
                {
                   MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
