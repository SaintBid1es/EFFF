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
    /// Логика взаимодействия для NewWindow.xaml
    /// </summary>
    public partial class NewWindow : Window
    {
       
        private MAGAZINEEntities context = new MAGAZINEEntities();
        List<Krasivo> krasivos = new List<Krasivo>();
        public NewWindow()
        {
            InitializeComponent();
            CustomersDgr.ItemsSource = context.Customers.ToList();
            foreach (var item in context.Customers.ToList())
            {
                krasivos.Add(new Krasivo(item));
            }
            CustomersDgr.ItemsSource = krasivos;
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
                selected.SurName = NameTbx.Text;
                selected.LastName = NameTbx.Text;
                selected.telephone = NameTbx.Text;
                selected.email = NameTbx.Text;
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
        public class Krasivo
        {
            public int ID;
            public int Customers_ID;

            public string Name { get; private set; }
            public string Product { get; private set; }
            public Krasivo(Customers cast)
            {
                ID = cast.ID;
                Name = cast.Name;

                if (cast.email != null)
                {
                    Customers_ID = cast.ID;
                    Name = cast.Name;
                }

            }
        }
    }
}
