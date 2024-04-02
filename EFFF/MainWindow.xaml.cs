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

namespace EFFF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MAGAZINEEntities context = new MAGAZINEEntities();
        public MainWindow()
        {
            InitializeComponent();
            ExpensesDgr.ItemsSource = context.Expenses.ToList();
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
        //Добавление
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Expenses E = new Expenses();
            E.date_of_purchase = date_of_purchaseTbx.Text;
            E.Product = ProductTbx.Text;
            E.price = Convert.ToInt32(PriceTbx.Text);
            context.Expenses.Add(E);
            context.SaveChanges();

            ExpensesDgr.ItemsSource = context.Expenses.ToList();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (ExpensesDgr.SelectedItem != null)
            {
                context.Expenses.Remove(ExpensesDgr.SelectedItem as Expenses);
            }
            context.SaveChanges();
            ExpensesDgr.ItemsSource = context.Expenses.ToList();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if (ExpensesDgr.SelectedItem != null)
            {
                var selected = ExpensesDgr.SelectedItem as Expenses;
                selected.date_of_purchase = date_of_purchaseTbx.Text;
                selected.Product = ProductTbx.Text;
                selected.price = Convert.ToInt32(PriceTbx.Text);
                
            }
        }

        private void CustomersDgr_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ExpensesDgr.SelectedItem != null)
            {
                var selected = ExpensesDgr.SelectedItem as Expenses;
                date_of_purchaseTbx.Text = selected.date_of_purchase;
                ProductTbx.Text = selected.Product;
               
                
            }
        }

        private void New_windowButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
