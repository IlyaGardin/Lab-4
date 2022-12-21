namespace T1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            User obj = new User("Илья", "Гардин", DateTime.Parse("11.09.2003"), "ssss");           
            obj.ExtractingData("ssss, Илья, Гардин, gardinilya@mail.ru, 11.09.2003");
            obj.DateBirth = DateTime.Parse("01.09.2003");
            Console.WriteLine(obj.ToString());
            Console.WriteLine(obj.DateBirth);
        }
    }
}
