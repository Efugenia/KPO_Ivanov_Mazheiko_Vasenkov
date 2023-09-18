using Knight.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

using System.Reflection;

using Item = StaticLibrary.Item;

namespace Knight
{
    public partial class MainWindow : Window
    {
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
                

                if (typeField.SelectedIndex == 0)
                {
                    //Weapon weapon = new Weapon(name, description, weight, cost, Convert.ToInt32(otherField.Text));
                    Weapon weapon = new Weapon(name, description);
                    weapon.Init(weight, cost, Convert.ToInt32(otherField.Text));
                    inventory.AddItem(weapon);
                }
                if (typeField.SelectedIndex == 1)
                {
                    //Food food = new Food(name, description, weight, cost, Convert.ToInt32(otherField.Text));
                    Food food = new Food(name, description);
                    food.Init(weight, cost, Convert.ToInt32(otherField.Text));
                    inventory.AddItem(food);
                }
                if (typeField.SelectedIndex == 2) {
                    //Cloth cloth = new Cloth(name, description, weight, cost, otherField.Text);

                    Cloth cloth = new Cloth(name, description);
                    cloth.Init(weight, cost, otherField.Text);
 
                    inventory.AddItem(cloth);
                }


                //dgInventory.Items.Refresh();
                FillTab();
                Calculate();

            }
            catch
            {
                MessageBox.Show("Всё накрылось медным тазом...");
            }
        }

        private void AddDefaultItems()
        {
            //inventory.AddItem(new Weapon("Стандартный меч",
            //    "Твой первый меч. Бесценен. Нет, буквально, он никому не нужен.", 2f, 0f, 10));

            //inventory.AddItem(new Cloth("Стандартная броня",
            //    "Ты с огромным трудом можешь назвать свою рубашку бронёй, но ладно", 0.5f, 0.1f, "Говно и палки"));

            //inventory.AddItem(new Food("Похлёбка",
            //    "Лучше уж голодать...", 0.1f, 10f, -10));

        }

        public void Calculate()
        {
            Console.Clear();

            WriteLine(String.Format("Стоимость всей амуниции составляет {0} тугр.", inventory.GetOverallPrice().ToString()));

            //конечно, можно обойтись без bufferItem, но тогда мы получим фигово читаемую матрёшку,
            //где мы вызываем метод в методе. Нам это надо? Я считаю нет
            Item bufferItem = inventory.GetCheapestItem();
            WriteLine(String.Format("Самый дешёвый предмет - {0} стоимостью {1} тугр.", bufferItem.Name, bufferItem.Price));
            bufferItem = inventory.GetExpensiveItem();
            WriteLine(String.Format("Самый дорогой предмет - {0} стоимостью {1} тугр.", bufferItem.Name, bufferItem.Price));
        }
    }
}
