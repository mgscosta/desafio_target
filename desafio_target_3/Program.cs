using System.Text.Json;

namespace desafio_target_3;
class Program
{
    public static void operacoesFaturamento(List<FaturamentoDto> faturamentoDtos)
    {
        int count = 0;
        FaturamentoDto menor = faturamentoDtos[0], maior = faturamentoDtos[0];

        double media = 0;

        foreach(var item in faturamentoDtos)
        {
            if(item.valor != 0)
            {
                media = item.valor + media;
                count++;

                if (item.valor < menor.valor)
                {
                    menor = item;
                }

                if (item.valor > maior.valor)
                {
                    maior = item;
                }
            }           
        }

        media = media / count;
        count = 0;

        foreach(var item in faturamentoDtos)
        {
            if(item.valor > media)
            {
                count++;
            }
        }

        Console.WriteLine("O menor valor de faturamento ocorrido em um mês foi: {0} no dia {1} ", menor.valor, menor.dia);
        Console.WriteLine("O maior valor de faturamento ocorrido em um mês foi: {0} no dia {1} ", maior.valor, maior.dia);
        Console.WriteLine("O número de dias no mês em que o valor de faturamento diário foi superior à media mensal é de: {0}", count);
    }

    static void Main(string[] args)
    {
        List<FaturamentoDto> faturamentoDtos = new List<FaturamentoDto>();

        using (StreamReader reader = new StreamReader("data\\dados.json"))
        {
            string json = reader.ReadToEnd();
            faturamentoDtos = JsonSerializer.Deserialize<List<FaturamentoDto>>(json);
        }

        operacoesFaturamento(faturamentoDtos);

    }
}