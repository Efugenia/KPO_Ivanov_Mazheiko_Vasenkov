using Knight.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

using System.Reflection;

using Item = StaticLibrary.Item;
using Food = StaticLibrary.Food;
using Weapon = StaticLibrary.Weapon;
using Cloth = StaticLibrary.Cloth;

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
                    Item weapon = new Weapon(name, description);
                    ((Weapon)weapon).Init(weight, cost, Convert.ToInt32(otherField.Text));

                    //weapon = new FeatherlikeItem(weapon, weapon.Description);
                    //weapon = new InfiniteItem(weapon, weapon.Description);
                    //FeatherlikeItem fo = new FeatherlikeItem(weapon, io.Description);

                    inventory.Items.Add(weapon);
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
            catch (Exception ex)
            {
                //MessageBox.Show("Всё накрылось медным тазом...\n\n" + ex.Message);
                throw;
            }
        }

        private void AddDefaultItems()
        {
            Random rnd = new Random();
            int type = rnd.Next(0, 3);
            Item randomItem;
            switch(type)
            {
                case 0:
                    randomItem = new Food("Случайная еда", "Кто знает съедобно ли это...");
                    break;
                case 1:
                    randomItem = new Cloth("Случайная одежда", "Зато не надо думать, что надеть");
                    break; 
                case 2:
                    randomItem = new Weapon("Случайное оружие", "Вроде им можно бить");
                    break;
                default:
                    randomItem = new Food("Тебе повезло всё сломать", "Не то чтобы на это нужно было везение");
                    break;
            }

            inventory.AddItem(randomItem);
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
            
            if (inventory.Items.Count > 0)
            {
                Item bufferItem = inventory.GetCheapestItem();
                WriteLine(String.Format("Самый дешёвый предмет - {0} стоимостью {1} тугр.", bufferItem.Name, bufferItem.Price));
                bufferItem = inventory.GetExpensiveItem();
                WriteLine(String.Format("Самый дорогой предмет - {0} стоимостью {1} тугр.", bufferItem.Name, bufferItem.Price));
            }


        }
    }
}
