using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace BiOnline_launcher_dev_ver
{
    /// <summary>
    /// Логика взаимодействия для choicePlatform_Window.xaml
    /// </summary>
    public partial class choicePlatform_Window : Page
    {
        static bool ContainsRussianCharacters(string input)
        {
            Regex regex = new Regex(@"[\p{IsCyrillic}]");
            return regex.IsMatch(input);
        }

        public static bool CheckCirilicAppData()
        {
            bool result = false;
            if (Directory.Exists(config.AppDataPath))
                if (!ContainsRussianCharacters(config.AppDataPath))
                    result = true;

            return result;
        }
        public static bool CheckCirilicPirate()
        {
            bool result = false;
            result = CheckCirilicAppData();

            return result;
        }
        public static bool CheckCirilicSteam()
        {
            bool result = false;
            if(CheckCirilicAppData())
            {
                if (Directory.Exists(config.DefaultSteamPath))
                {
                    result = true;
                    return result;
                }
            }

            return result;
        }
        public static List<string> CheckInstallMode()
        {
            List<string> result = new List<string>();
            if (!Directory.Exists(config.DefaultSteamPath + @"\Data\Biotech"))
                result.Add("Biotech");
            if (!Directory.Exists(config.DefaultSteamPath + @"\Data\Ideology"))
                result.Add("Ideology");
            if (!Directory.Exists(config.DefaultSteamPath + @"\Data\Royalty"))
                result.Add("Royalty");


            return result;
        }
        public choicePlatform_Window()
        {
            InitializeComponent();
        }

        private void Pirate_Version_MouseDown(object sender, MouseButtonEventArgs e)
        {
            config.DefaultStartGame = @"C:\bionline\Rimworld\RimWorld\RimWorldWin64.exe";
            if (CheckCirilicPirate())
            {
                config.IsPirate = true;
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                Window.GetWindow(this).Close();
            }
            else
            {
                NavigationService.Navigate(new CirilicError("Пользователь windows имеет кириллицу"));
            }
        }

        private void Steam_Version_MouseDown(object sender, MouseButtonEventArgs e)
        {
            
            if (CheckCirilicSteam())
            {
                if (CheckInstallMode().Count == 0)
                {
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    Window.GetWindow(this).Close();
                }
                else
                {
                    string errortext = "Отсутствуют следующие DLC:";
                    List<string> noDLC = CheckInstallMode();
                    foreach(var a in noDLC)
                        errortext += $"\n{a}"; 
                    NavigationService.Navigate(new CirilicError(errortext));
                }
            }
            else
            {
                NavigationService.Navigate(new CirilicError("Пользователь windows имеет кириллицу"));
            }

        }
    }
}
