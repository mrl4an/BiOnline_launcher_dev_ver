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

namespace BiOnline_launcher_dev_ver
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region trigger visual button
        public bool choice_Play_Label;
        public bool choice_News_Label;
        public bool choice_Links_Label;
        public bool choice_Options_Label;
        #endregion 
        public MainWindow()
        {
            InitializeComponent();
            ContentFrame.Content = new PlayPage();
            choice_Play_Label = true;

        }

        #region controls
        private void Main_Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void closeGrid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Environment.Exit(0);
        }

        private void minGrid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
        #endregion

        #region visual buttons
        private void Play_Label_MouseEnter(object sender, MouseEventArgs e)
        {
            if (choice_Play_Label == false)
                Play_Label.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
        }

        private void Play_Label_MouseLeave(object sender, MouseEventArgs e)
        {
            if(choice_Play_Label==false)
                Play_Label.Foreground = new SolidColorBrush(Color.FromRgb(105, 105, 106));
        }

        private void PlayGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(!choice_Play_Label)
                ContentFrame.Content = new PlayPage();
            choice_Play_Label = true;
            Play_Label.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));


            choice_News_Label = false;
            choice_Links_Label = false;
            choice_Options_Label = false;
            News_Label.Foreground = new SolidColorBrush(Color.FromRgb(105, 105, 106));
            Links_Label.Foreground = new SolidColorBrush(Color.FromRgb(105, 105, 106));
            Options_Label.Foreground = new SolidColorBrush(Color.FromRgb(105, 105, 106));
        }

        private void News_Label_MouseEnter(object sender, MouseEventArgs e)
        {
            if( choice_News_Label == false)
                News_Label.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
        }

        private void News_Label_MouseLeave(object sender, MouseEventArgs e)
        {
            if (choice_News_Label == false)
                News_Label.Foreground = new SolidColorBrush(Color.FromRgb(105, 105, 106));
        }

        private void News_Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            choice_News_Label = true;
            News_Label.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));


            choice_Play_Label = false;
            choice_Links_Label = false;
            choice_Options_Label = false;
            Play_Label.Foreground = new SolidColorBrush(Color.FromRgb(105, 105, 106));
            Links_Label.Foreground = new SolidColorBrush(Color.FromRgb(105, 105, 106));
            Options_Label.Foreground = new SolidColorBrush(Color.FromRgb(105, 105, 106));

        }

        private void Links_Label_MouseEnter(object sender, MouseEventArgs e)
        {
            if (!choice_Links_Label)
                Links_Label.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));

        }

        private void Links_Label_MouseLeave(object sender, MouseEventArgs e)
        {
            if (!choice_Links_Label)
                Links_Label.Foreground = new SolidColorBrush(Color.FromRgb(105, 105, 106));
        }

        private void Links_Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (!choice_Links_Label)
                ContentFrame.Content = new LinksPage();
            choice_Links_Label = true;
            Links_Label.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));

            choice_Play_Label = false;
            choice_News_Label = false;
            choice_Options_Label = false;
            Play_Label.Foreground = new SolidColorBrush(Color.FromRgb(105, 105, 106));
            News_Label.Foreground = new SolidColorBrush(Color.FromRgb(105, 105, 106));
            Options_Label.Foreground = new SolidColorBrush(Color.FromRgb(105, 105, 106));
        }

        private void OptionsGrid_MouseEnter(object sender, MouseEventArgs e)
        {
            if (!choice_Options_Label)
               Options_Label.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
        }

        private void OptionsGrid_MouseLeave(object sender, MouseEventArgs e)
        {
            if (!choice_Options_Label)
                Options_Label.Foreground = new SolidColorBrush(Color.FromRgb(105, 105, 106));
        }

        private void OptionsGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            choice_Options_Label = true;
            Options_Label.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));

            choice_Play_Label = false;
            choice_News_Label = false;
            choice_Links_Label = false;
            Play_Label.Foreground = new SolidColorBrush(Color.FromRgb(105, 105, 106));
            News_Label.Foreground = new SolidColorBrush(Color.FromRgb(105, 105, 106));
            Links_Label.Foreground = new SolidColorBrush(Color.FromRgb(105, 105, 106));
        }
        #endregion

    }
}
