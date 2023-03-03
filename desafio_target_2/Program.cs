namespace desafio_target_2;
class Program
{
    public static bool fib(int num)
    {
        int aux, x = 0, y = 1;

        bool flag = false;

        if (num == 0 || num == 1)
            flag = true;
        else
        {
            for (int i = 0; i < num; i++)
            {
                aux = x + y;
                Console.Write(aux + " ");
                if (aux == num)
                    flag = true;
                x = y;
                y = aux;
            }
        }
        return flag;
    }

    static void Main(string[] args)
    {
        Console.WriteLine(fib(8) ? "O num PERTENCE à sequência de fibonacci" : "Num informado NÃO pertence à sequência de fibonacci");
    }
}