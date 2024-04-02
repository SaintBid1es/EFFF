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

namespace EFFF
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {

        private MAGAZINEEntities context = new MAGAZINEEntities();
      
        public Window1()
        {
            InitializeComponent();
            CustomersDgr.ItemsSource = context.Customers.ToList();
            
        }
        private void button3_Click(object sender, RoutedEventArgs e)
        {
            MainWindow OneWindow = new MainWindow();
            OneWindow.Show();
            Close();
        }

        private void button3_Click_1(object sender, RoutedEventArgs e)
        {
            Window1 window = new Window1();
            window.Show();
            Close();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Customers c = new Customers();
           
         
            c.Name = NameTbx.Text;
            c.SurName = SurNameTbx.Text;
            c.LastName = LastNameTbx.Text;
            c.email = EmailTbx.Text;
            c.telephone = TelephoneTbx.Text;
            context.Customers.Add(c);
            context.SaveChanges();
            CustomersDgr.ItemsSource = context.Customers.ToList();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (CustomersDgr.SelectedItem != null)
            {
                context.Customers.Remove(CustomersDgr.SelectedItem as Customers);
            }
            context.SaveChanges();
            CustomersDgr.ItemsSource = context.Customers.ToList();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if (CustomersDgr.SelectedItem != null)
            {
                var selected = CustomersDgr.SelectedItem as Customers;
                selected.Name = NameTbx.Text;
                selected.SurName = SurNameTbx.Text;
                selected.LastName = LastNameTbx.Text;
                selected.telephone = TelephoneTbx.Text;
                selected.email = EmailTbx.Text;
            }
        }

        private void CustomersDgr_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CustomersDgr.SelectedItem != null)
            {
                var selected = CustomersDgr.SelectedItem as Customers;
                NameTbx.Text = selected.Name;
                NameTbx.Text = selected.SurName;
                NameTbx.Text = selected.LastName;
                NameTbx.Text = selected.telephone;
                NameTbx.Text = selected.email;
            }
        }

        private void New_windowButton_Click(object sender, RoutedEventArgs e)
        {
            NewWindow newWindow = new NewWindow();
            newWindow.Show();
            Close();
        }
       
        
    }
}
