using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client.ViewModels
{
    public class RegistrationPageViewModel : ViewModelBase
    {

        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string PasswordRepeat { get; set; }
        public string Warning { get; set; } // Сообщения для вывода под полями пароля и логина (аля Введен неверный логин или пароль)
    }
}
