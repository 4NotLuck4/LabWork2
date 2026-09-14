namespace ClassLibrary
{
    public class Class
    {
        public static double Power(double a, int n)
        {
            return Math.Round(Math.Pow(a, n), 3);
        }

        public static bool IsPasswordStrong(string password)
        {
            if (string.IsNullOrEmpty(password)) return false;

            if(password.Length < 8 || password.Length > 30) return false;
            
            bool hasDigit = false;
            bool hasLower = false;
            bool hasUpper = false;
            bool hasSpecial = false;

            string specials = "!\"#$)({}[].?/*-+";
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
