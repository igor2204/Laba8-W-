class MyArray<T>
{
    private T[] array;

    public MyArray(int capacity = 0)
    {
        array = new T[capacity];
    }

    public int Length
    {
        get { return array.Length; }
    }

    public void Add(T item)
    {
        T[] newArray = new T[array.Length + 1];
        Array.Copy(array, newArray, array.Length);
        newArray[array.Length] = item;
        array = newArray;
    }

    public void RemoveAt(int index)
    {
        if (index < 0 || index >= array.Length)
        {
            throw new ArgumentOutOfRangeException("index");
        }

        T[] newArray = new T[array.Length - 1];
        Array.Copy(array, 0, newArray, 0, index);
        Array.Copy(array, index + 1, newArray, index, array.Length - index - 1);
        array = newArray;
    }

    public T Get(int index)
    {
        if (index < 0 || index >= array.Length)
        {
            throw new ArgumentOutOfRangeException("index");
        }

        return array[index];
    }
}
class User
{
    public string Login { get; set; }
    public string Password { get; set; }
}

class UserLogins : MyArray<string>
{
    // Здесь можно добавить специфичные методы для работы с логинами
}

class UserPasswords : MyArray<string>
{
    // Здесь можно добавить специфичные методы для работы с паролями
}

class Program
{
    static void Main()
    {
        UserLogins logins = new UserLogins();
        UserPasswords passwords = new UserPasswords();

        // Регистрация пользователя
        Console.Write("Введите логин: ");
        string login = Console.ReadLine();
        Console.Write("Введите пароль: ");
        string password = Console.ReadLine();

        logins.Add(login);
        passwords.Add(password);

        // ... (дальнейшая работа с логинами и паролями) ...
    }
}