﻿using Knight.Model;
using Knight.Model.FileManagment;
using Microsoft.Win32;
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

using Item = StaticLibrary.Item;
using Food = StaticLibrary.Food;
using Weapon = StaticLibrary.Weapon;
using Cloth = StaticLibrary.Cloth;
using System.Threading;
using System.Globalization;

namespace Knight
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        int selectedIndex = 0;

        private Inventory inventory;

        public MainWindow()
        {
            InitializeComponent();

            App.LanguageChanged += LanguageChanged;
            CultureInfo currLang = App.Language;

            //Заполняем меню смены языка:
            menuLanguage.Items.Clear();
            foreach (var lang in App.Languages)
            {
                MenuItem menuLang = new MenuItem();
                menuLang.Header = lang.DisplayName;
                menuLang.Tag = lang;
                menuLang.IsChecked = lang.Equals(currLang);
                menuLang.Click += ChangeLanguageClick;
                menuLanguage.Items.Add(menuLang);
            }

            inventory = new Inventory();
            AddDefaultItems();
            //dgInventory.ItemsSource = inventory.Items;
            FillTab();
        }

        private void LanguageChanged(Object sender, EventArgs e)
        {
            CultureInfo currLang = App.Language;

            //Отмечаем нужный пункт смены языка как выбранный язык
            foreach (MenuItem i in menuLanguage.Items)
            {
                CultureInfo ci = i.Tag as CultureInfo;
                i.IsChecked = ci != null && ci.Equals(currLang);
            }
        }

        private void ChangeLanguageClick(Object sender, EventArgs e)
        {
            MenuItem mi = sender as MenuItem;
            if (mi != null)
            {
                CultureInfo lang = mi.Tag as CultureInfo;
                if (lang != null)
                {
                    App.Language = lang;
                }
            }

            typeField.SelectedIndex = 1;
            typeField.SelectedIndex = 0;
            AddDefaultItems();
            FillTab();
            Calculate();
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
                    otherLabel.Content = (string)Application.Current.FindResource("damage");
                    otherField.Text = "0";
                }
                if (typeField.SelectedIndex == 2)
                {
                    otherLabel.Content = (string)Application.Current.FindResource("material");
                    otherField.Text = (string)Application.Current.FindResource("unknown");
                }
                if (typeField.SelectedIndex == 1)
                {
                    otherLabel.Content = (string)Application.Current.FindResource("satiety");
                    otherField.Text = "0";
                }
            }

        }

        private void FillTab()
        {   
            inventoryTab.Text = string.Empty;

            //selectedIndex = itemsList.SelectedIndex;
            itemsList.Items.Clear();

            foreach (var item in inventory.Items)
            {
                itemsList.Items.Add(item.Name);
            }
            itemsList.SelectedIndex = itemsList.Items.Count-1;
        }

        private void StatikClick(object sender, RoutedEventArgs e)
        {
            try
            {
                Assembly a = Assembly.LoadFrom("DynamicLibrary.dll");
                Type[] types = a.GetTypes();

                Object o = a.CreateInstance("vscode");

                var method = types[3].GetMethod("GetRandomJoke");

                method.Invoke(o, null);
            }
            catch (Exception ex)
            {   
                MessageBox.Show(ex.Message, "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

  
        private void itemsList_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            int i = itemsList.SelectedIndex;
            if (i < 0)
            {
                i = 0;
            }
            inventoryTab.Text = inventory.Items[i].ToString();
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            string format = cmbFileFormat.SelectedValue.ToString();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = $"Text file|*.{format}";
            if (openFileDialog.ShowDialog() == true)
            {
                FileManagerFactory factory = new FileManagerFactory();
                IFileManager fileManager = factory.CreateFileManager(format, openFileDialog.FileName);

                Item loadedItem = fileManager.Load();
                inventory.Items.Add(loadedItem);
                FillTab();
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            string format = cmbFileFormat.SelectedValue.ToString();
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = $"Text file|*.{format}";
            if (saveFileDialog.ShowDialog() == true)
            {
                FileManagerFactory factory = new FileManagerFactory();
                IFileManager fileManager = factory.CreateFileManager(format, saveFileDialog.FileName);

                int currentIndex = itemsList.SelectedIndex;
                if (currentIndex < 0)
                {
                    MessageBox.Show("В инвентаре нет предметов!");
                    return;
                }

                fileManager.Save(inventory.Items[currentIndex]);
            }
        }
    }
}
