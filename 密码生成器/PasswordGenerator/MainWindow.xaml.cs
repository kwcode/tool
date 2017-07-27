using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PasswordGenerator
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Generator();
        }

        private void btnPG_Click(object sender, RoutedEventArgs e)
        {
            Generator();
        }
        private void Generator()
        {
            string password1 = Guid.NewGuid().ToString();
            string password2 = Guid.NewGuid().ToString();
            password1 = password1.Replace("-", "");
            password2 = password2.Replace("-", "");
            txtPassword.Text = password1;

            txt48Password.Text = password1 + password2.Substring(0, 16);
            txt64Password.Text = password1 + password2;
        }
    }
}
