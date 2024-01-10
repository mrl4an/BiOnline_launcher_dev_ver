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

namespace BiOnline_launcher_dev_ver
{
    /// <summary>
    /// Логика взаимодействия для w682372.xaml
    /// </summary>
    public partial class w682372 : Window
    {
        public w682372()
        {
            InitializeComponent();
            MainFrame.Content = new choicePlatform_Window();

        }
    }
}
