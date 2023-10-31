using Knight.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

using System.Reflection;
using NLog;

using Item = StaticLibrary.Item;
using Food = StaticLibrary.Food;
using Weapon = StaticLibrary.Weapon;
using Cloth = StaticLibrary.Cloth;
using StaticLibrary;
using System.Diagnostics;
using System.IO;
using System.Threading;
using Knight.Model.FileManagment;

namespace Knight
{
    public partial class MainWindow : Window
    {   
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public Inventory Inventory
        {
            get => default;
            set
            {
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string name = nameField.Text;
                string description = descriptionField.Text;
                float weight = float.Parse(weightField.Text);
                float cost = float.Parse(costField.Text);


                Item? item = null;
                if (typeField.SelectedIndex == 0)
                {
                    item = new Weapon(name, description);
                    ((Weapon)item).Init(weight, cost, Convert.ToInt32(otherField.Text));

                    inventory.Items.Add(item);
                }
                if (typeField.SelectedIndex == 1)
                {
                    item = new Food(name, description);
                    ((Food)item).Init(weight, cost, Convert.ToInt32(otherField.Text));

                    inventory.AddItem(item);
                }
                if (typeField.SelectedIndex == 2) {
                    item = new Cloth(name, description);
                    ((Cloth)item).Init(weight, cost, otherField.Text);
 
                    inventory.AddItem(item);
                }

                if (item != null)
                {
                    string txt = "[ NEW ITEM ] " + item.ToString() + "\n";
                    logger.Info(txt);
                }

                //dgInventory.Items.Refresh();
                FillTab();
                Calculate();

            }
            catch (Exception ex)
            {
                //MessageBox.Show("Всё накрылось медным тазом...\n\n" + ex.Message);
                string txt = "[ ITEM CREATION ERROR ]\n" + ex.Message + "\n";
                logger.Warn(txt);
            }
        }

        private void AddDefaultItems()
        {
            Random rnd = new Random();
            int type = rnd.Next(0, 3);

            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            var file = Directory.GetFiles($"{projectDirectory}\\Resources\\{Thread.CurrentThread.CurrentUICulture}\\randomItems")[rnd.Next(3)];
            JsonManager jsonManager = new JsonManager(file);
            var randomItem = jsonManager.Load();

            inventory.AddItem(randomItem);
        }

        public void Calculate()
        {
            Console.Clear();

            Application app = Application.Current;
            WriteLine($"{app.FindResource("overallPriceMessage")}" +
                $" {inventory.GetOverallPrice()} {Application.Current.FindResource("priceUnit")}");
            
            if (inventory.Items.Count > 0)
            {
                Item bufferItem = inventory.GetCheapestItem();
                WriteLine($"{app.FindResource("minPriceMessage")} {bufferItem.Name} ({bufferItem.Price} {app.FindResource("priceUnit")})");
                string txt = "[ ITEMS STATISTICS ] " + bufferItem.Name + ", " + bufferItem.Price + " | ";


                bufferItem = inventory.GetExpensiveItem();
                WriteLine($"{app.FindResource("maxPriceMessage")} {bufferItem.Name} ({bufferItem.Price} {app.FindResource("priceUnit")})");
                txt += bufferItem.Name + ", " + bufferItem.Price + "\n";

                logger.Info(txt);
            }



        }

        private void enchantButton_Click(object sender, RoutedEventArgs e)
        {
            int i = itemsList.SelectedIndex;
            if (i < 0)
            {
                i = 0;
            }
            Item item = inventory.Items[i];

            if (enchantmentField.SelectedIndex == 0)
            {
                item = new InfiniteItem(item, item.Description);
            }
            if (enchantmentField.SelectedIndex == 1)
            {
                item = new FeatherlikeItem(item, item.Description);
            }
            if (enchantmentField.SelectedIndex == 2)
            {
                item = new GoldenItem(item, item.Description);
            }

            inventory.Items[i] = item;
            FillTab();

            string txt = "[ ITEM ENCHANTED ] \n" + item.ToString() + "\n";
            logger.Info(txt);


        }
    }
}
