using System.Windows;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestFood()
        {
            Knight.Model.Food food_1 = new Knight.Model.Food("-", "-", 200, 200, 200);
            Knight.Model.Food food_2 = new Knight.Model.Food("-", "-", 100, 100, 100);
            food_1.Use();

            MessageBox.Show("s");

            Assert.AreEqual(food_1.Price, food_2.Price);
            Assert.AreEqual(food_1.Weight, food_2.Weight);
            Assert.AreEqual(food_1.Satiety, food_2.Satiety);

            
        }

        [TestMethod]
        public void TestWeapon()
        {
            Knight.Model.Weapon weapon_1 = new Knight.Model.Weapon("-", "-", 200, 200, 200);
            Knight.Model.Weapon weapon_2 = new Knight.Model.Weapon("-", "-", 200, 200, 198);
            weapon_1.Use();

            Assert.AreEqual(weapon_2.Damage, weapon_1.Damage);
        }


        [TestMethod]
        public void TestCloth()
        {
            Knight.Model.Cloth cloth_1 = new Knight.Model.Cloth("-", "-", 200, 200, "Шерсть");
            Knight.Model.Cloth cloth_2 = new Knight.Model.Cloth("-", "-", 200, 200, "Шерсть");
            cloth_1.Use();

            Assert.AreEqual(cloth_2.ToString(), cloth_1.ToString());
        }
    }
}