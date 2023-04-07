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
using System.Windows.Shapes;

namespace ContentTemplate.MyForms
{
    /// <summary>
    /// Логика взаимодействия для AddGroupWindow.xaml
    /// </summary>
    public partial class AddGroupWindow : Window
    {
        public AddGroupWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Services.GroupService groupService = new Services.GroupService();
                groupService.AddGroup(tbName.Text);

                MessageBox.Show("Группа добавленна в базу!");
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
          
        }
    }
}
