using System.Text.Json;

namespace desafio_target_4;

class Program
{

    public static Dictionary<string, double> calculaPercentualRepresentacao(List<FaturamentoEstadoModel> faturamentoEstadoModels)
    {
        double valorTotalMensal = 0;
        Dictionary<string, double> result = new Dictionary<string, double>();

        faturamentoEstadoModels.ForEach(x => valorTotalMensal += x.faturamento);

        Console.WriteLine("Valor Total Mensal: {0}", valorTotalMensal);

        faturamentoEstadoModels.ForEach(x => result.Add(x.estado, x.faturamento * 100 / valorTotalMensal));

        return result;
    }

    static void Main(string[] args)
    {
        List<FaturamentoEstadoModel> faturamentoEstadoModels = new List<FaturamentoEstadoModel>();
        
        Dictionary<string, double> result;

        using (StreamReader reader = new StreamReader("data\\faturamento.json"))
        {
            string json = reader.ReadToEnd();
            faturamentoEstadoModels = JsonSerializer.Deserialize<List<FaturamentoEstadoModel>>(json);
        }

        result = calculaPercentualRepresentacao(faturamentoEstadoModels);

        foreach(var item in result)
        {
            Console.WriteLine("Estado: {0}, Porcentagem: {1} %", item.Key, Math.Round(item.Value, 2));
        }
    }
}