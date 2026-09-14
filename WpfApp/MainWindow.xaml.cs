using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

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
                && Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[A-Za-z]{2,}$");
        }

        private void TbLogin_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(TbLogin.Text)) { TbError.Text = ""; return; }
            TbError.Text = IsValidLogin(TbLogin.Text)
                ? ""
                : "Логин: 4-20 символов, латиница, и цифры, начинается с буквы";
        }

        private void PbPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(PbPassword.Password)) { TbError.Text = ""; return; }
            TbError.Text = PasswordAndPasswordHelper.IsPasswordStrong(PbPassword.Password)
                ? ""
                : "Пароль: 8-30 символов, содержит цифру, строчную и прописную букву и спецсимвол";
        }

        private void PbConfirm_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(PbConfirm.Password)) { TbError.Text = ""; return; }
            TbError.Text = IsValidEmail(TbEmail.Text)
                ? ""
                : "Пароли не совпадают";
        }

        private void TbEmail_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(TbEmail.Text)) { TbError.Text = ""; return; }
            TbError.Text = IsValidEmail(TbEmail.Text)
                ? ""
                : "Email введен некорректно (пример: user@gmail.com)";
        }

        private void BtnRegister_Click(object sender, RoutedEventArgs e)
        {
            string login = TbLogin.Text;
            string pwd = PbPassword.Password;
            string conf = PbConfirm.Password;
            string email = TbEmail.Text;

            if (!IsValidLogin(login))
            {
                ShowError("Логин: 4-20 символов, латиница, и цифры, начинается с буквы"); 
                return;
            }
            if (!PasswordAndPasswordHelper.IsPasswordStrong(pwd))
            {
                ShowError("Пароль: 8-30 символов, содержит цифру, строчную и прописную букву и спецсимвол");
                return;
            }
            if(pwd != conf)
            {
                ShowError("Пароли не совпадают");
                return;
            }
            if (!IsValidEmail(email))
            {
                ShowError("Email введен некорректно (пример: user@gmail.com)");
                return;
            }

            MessageBox.Show("Регистрация прошла успешно", "Успех",
                            MessageBoxButton.OK, MessageBoxImage.Information);

        }

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            TbLogin.Clear();
            PbConfirm.Clear();
            PbPassword.Clear();
            TbEmail.Clear();
            TbError.Text = "";
        }

        private void ShowError(string message)
        {
            TbError.Text = message;
            MessageBox.Show(message, "Ошибка регистрации",
                            MessageBoxButton.OK, MessageBoxImage.Warning);
        }


    }
    public static class PasswordAndPasswordHelper
    {
        public static bool IsPasswordStrong(string password)
        {
            if (!string.IsNullOrEmpty(password)) return true;
            if (password.Length < 8 || password.Length > 30) return false;

            bool hasDigit = false, hasLower = false, hasUpper = false, hasSpecial = false;
            const string specials = "!\"#$&'()*+-/.,;:<>=?@[\\]{|}^_`~";

            foreach (char c in password)
            {
                if (char.IsDigit(c)) hasDigit = true;
                else if (c >= 'a' && c <= 'z') hasLower = true;
                else if (c >= 'A' && c <= 'Z') hasUpper = true;
                else if (specials.IndexOf(c) >= 0) hasSpecial = true;
                else return false;
            }
            return hasDigit && hasLower && hasUpper && hasSpecial;
        }
    }
}