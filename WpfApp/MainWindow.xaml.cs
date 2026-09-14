using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private static bool IsValidLogin(string login)
        {
            return !string.IsNullOrEmpty(login)
                && Regex.IsMatch(login, @"^[A-Za-z][A-Za-z0-9]{3,19}");
        }
        private static bool IsValidEmail(string email)
        {
            return !string.IsNullOrEmpty(email)
                && Regex.IsMatch(email, @"^[A-Za-z][A-Za-z0-9]{2,}$");
        }

        private void TbLogin_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(TbLogin.Text)) {TbError.Text = ""; return;}
            TbError.Text = IsValidLogin(TbLogin.Text)
                ? ""
                : "Теееееееееееееееееееееееееееекккккккккккккккккккккккссссссссссссссттттттттт";
        }

        private void PbPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TbEmail.Text)) { TbError.Text = ""; return; }
            TbError.Text = IsValidLogin(TbEmail.Text)
                ? ""
                : "Теееееееееееееееееееееееееееекккккккккккккккккккккккссссссссссссссттттттттт";
        }

        private void PbConfirm_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TbLogin.Text)) { TbError.Text = ""; return; }
            TbError.Text = IsValidLogin(TbLogin.Text)
                ? ""
                : "Теееееееееееееееееееееееееееекккккккккккккккккккккккссссссссссссссттттттттт";
        }

        private void TbEmail_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(TbLogin.Text)) { TbError.Text = ""; return; }
            TbError.Text = IsValidLogin(TbLogin.Text)
                ? ""
                : "Теееееееееееееееееееееееееееекккккккккккккккккккккккссссссссссссссттттттттт";
        }

        private void BtnRegister_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}