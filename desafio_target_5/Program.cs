namespace desafio_target_5;
class Program
{
    public static string inverteString(string str)
    {
        char [] arr = str.ToArray();

        List<char> aux = new List<char>();
        
        for(int i = str.Length - 1; i >= 0; i--)
        {
            aux.Add(str[i]);
        }

        return String.Join("", aux);
    }

    static void Main(string[] args)
    {
        Console.WriteLine(inverteString("hello world"));
    }
}