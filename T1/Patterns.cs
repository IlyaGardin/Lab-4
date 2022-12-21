using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T1
{
    internal class Patterns
    {
        public const string Name = @"^(?:[А-ЯЁ][А-Яа-яЁё]*$|[A-Z][A-Za-z]*)$";
        public const string Surname = @"(?:^[А-ЯЁ][А-Яа-яЁё]*(?:-[А-ЯЁ][А-Яа-яЁё]*)*$|^[A-Z][A-Za-z]*(?:-[A-Z][A-Za-z]*)$)";
        public const string Email = @"^[0-9a-zA-Zа-яА-ЯЁё](?:[\w\.\-]*[0-9a-zA-Zа-яА-ЯёЁ])?@(?:[0-9a-zA-Zа-яА-ЯёЁ](?:[\w\-]*[0-9a-zA-Zа-яА-ЯёЁ])?\.)+[a-zA-Zа-яА-Я]{2,6}$";
        public const string Login = @"^[A-Za-z]*$";
    }
}
