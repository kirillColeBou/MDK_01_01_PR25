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

namespace Shop_Тепляков.Elements
{
    /// <summary>
    /// Логика взаимодействия для item.xaml
    /// </summary>
    public partial class item : UserControl
    {
        public item(object ItemData)
        {
            InitializeComponent();
            Models.Shop ShopData = ItemData as Models.Shop;
            tb_Name.Content = ShopData.Name;
            tb_Price.Content = "Цена: " + ShopData.Price;
            if (ItemData is Models.Children)
            {
                Models.Children ChildrenData = ItemData as Models.Children;
                tb_Characteristic.Content = "Возраст: " + ChildrenData.Age;
            }
            if (ItemData is Models.Sport)
            {
                Models.Sport SportData = ItemData as Models.Sport;
                tb_Characteristic.Content = "Размер: " + SportData.Size;
            }
            if (ItemData is Models.Electronics)
            {
                Models.Electronics ElectronicsData = ItemData as Models.Electronics;
                tb_Characteristic.Content = $"Ёмкость: {ElectronicsData.Capacity}\nСкорость езды: {ElectronicsData.drivingSpeed}";
            }
        }
    }
}
