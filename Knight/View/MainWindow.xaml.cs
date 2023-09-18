using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

namespace Knight
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        private Inventory inventory;
        public MainWindow()
        {
            InitializeComponent();
            inventory = new Inventory();
            AddDefaultItems();
            //dgInventory.ItemsSource = inventory.Items;
            FillTab();
        }
       

        public void WriteLine(string txt)
        {
            Console.Text += txt;
            Console.Text += Environment.NewLine;
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            Calculate();
        }

        private void typeField_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {   
            if (otherLabel != null && otherField != null)
            {
                if (typeField.SelectedIndex == 0)
                {
                    otherLabel.Content = "Урон";
                    otherField.Text = "0";
                }
                if (typeField.SelectedIndex == 2)
                {
                    otherLabel.Content = "Материал";
                    otherField.Text = "Неизвестно";
                }
                if (typeField.SelectedIndex == 1)
                {
                    otherLabel.Content = "Сытность";
                    otherField.Text = "0";
                }
            }

        }

        private void FillTab()
        {   
            inventoryTab.Text = string.Empty;
            foreach (var item in inventory.Items)
            {
                inventoryTab.Text += item.ToString() + "\n";
            }
        }

        private void StatikClick(object sender, RoutedEventArgs e)
        {
            try
            {
                Assembly a = Assembly.LoadFrom("DynamicLibrary.dll");
                Type[] types = a.GetTypes();

                Object o = a.CreateInstance("vscode");

                var method = types[2].GetMethod("GetRandomJoke");

                method.Invoke(o, null);
            }
            catch (Exception ex)
            {   
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
