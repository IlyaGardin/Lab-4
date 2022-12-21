using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace T1
{
    internal class User
    {
        private string _name;
        private string _surname;
        private string? _email;
        private DateTime? _dateBirth;
        private DateTime _dateRegistration;
        private string _login;

        private const int NameLength = 50;
        private const int SurnameLength = 200;
        private const int LoginLength = 20;


        public User(string name, string surname, DateTime dateRegistration, string login)
        {
            Name = name;
            Surname = surname;
            Login = login;
            DateRegistration = dateRegistration;
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new UserException($"Строка {nameof(_name)} не может быть Пустой");
                }
                if (value?.Length > NameLength)
                {
                    throw new UserException($"Длина строки превышает {NameLength} символов");
                }
                if (!Regex.IsMatch(value, Patterns.Name))
                {
                    throw new UserException(ExceptionInformation.Name);
                }
                _name = value;
            }
        }

        public string Surname
        {
            get
            {
                return _surname;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new UserException($"Строка {nameof(_surname)} не может быть Пустой");
                }
                if (value.Length > SurnameLength)
                {
                    throw new UserException($"Длинна строки превышает {SurnameLength} символов.");
                }
                if (!Regex.IsMatch(value, Patterns.Surname))
                {
                    throw new UserException(ExceptionInformation.Surname);
                }
                _surname = value;
            }
        }

        public string? Email
        {
            get
            {
                return _email;
            }
            set
            {
                if (!Regex.IsMatch(value, Patterns.Email))
                {
                    throw new UserException(ExceptionInformation.Email);
                }
                _email = value;
            }
        }

        public DateTime? DateBirth
        {
            get
            {
                return _dateBirth;
            }
            set
            {
                if (value > DateRegistration)
                {
                    throw new UserException("Дата Рождения не может быть больше Даты Регистрации");
                }
                _dateBirth = value;
            }
        }

        public DateTime DateRegistration
        {
            get
            {
                return _dateRegistration;
            }
            set
            {
                if (value < DateBirth)
                {
                    throw new UserException("Дата Регистрации не может быть меньше Даты Рождения");
                }
                _dateRegistration = value;
            }
        }

        public string Login
        {
            get
            {
                return _login;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new UserException($"Строка {nameof(_login)} не может быть Пустой");
                }
                if (value.Length > LoginLength)
                {
                    throw new UserException($"Длина строки превышает {LoginLength} символов.");
                }
                if (!Regex.IsMatch(value, Patterns.Login))
                {
                    throw new UserException(ExceptionInformation.Login);
                }
                _login = value;
            }
        }

        public override string ToString()
        {
            return $"{Login}, {Name}, {Surname}, {Email}, {DateRegistration.ToString("dd-MM-yyyy")}";
        }

        public void ExtractingData(string line)
        {
            string pattern = @"(?<login>.*), (?<name>.*), (?<surname>.*), (?<email>.*), (?<dateRegistration>.*)";
            InstallingData(Regex.Match(line, pattern));
        }

        private void InstallingData(Match collection)
        {
            Login = collection.Groups["login"].Value;
            Name = collection.Groups["name"].Value;
            Surname = collection.Groups["surname"].Value;
            Email = collection.Groups["email"].Value;
            DateRegistration = GetDateTime(collection.Groups["dateRegistration"].Value);
        }

        private DateTime GetDateTime(string date)
        {
            if (!DateTime.TryParse(date, out DateTime result))
            {
                throw new UserException($"{date}");
            }
            return result;
        }

    }


}

