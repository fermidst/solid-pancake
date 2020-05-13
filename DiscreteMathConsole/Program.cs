using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace DiscreteMathConsole
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            while (true)
            {
                var (n1Pdnf, n1Pcnf) = Evaluation.GetPdnfPcnf("00010101");
                var (n2Pdnf, n2Pcnf) = Evaluation.GetPdnfPcnf("11101011");
                var n3 = Console.ReadLine();
                var (n3Pdnf, n3Pcnf) = Evaluation.GetPdnfPcnf(n3);
                var result = new StringBuilder()
                    .AppendLine("n1 (16 + 5) 00010101")
                    .AppendLine($"pdnf: {n1Pdnf}")
                    .AppendLine($"pcnf: {n1Pcnf}")
                    .AppendLine("n2 (256 - (16 + 5) 11101011")
                    .AppendLine($"pdnf: {n2Pdnf}")
                    .AppendLine($"pcnf: {n2Pcnf}")
                    .AppendLine($"n3 custom expression {n3}")
                    .AppendLine($"pdnf: {n3Pdnf}")
                    .AppendLine($"pcnf: {n3Pcnf}")
                    .ToString();
                Console.WriteLine(result);
                var baseDirectory = AppDomain.CurrentDomain.BaseDirectory ?? throw new InvalidOperationException();

                Console.WriteLine("result will be saved to file result.txt in the same folder as the executable");
                await File.WriteAllTextAsync(Path.Combine(baseDirectory, "result.txt"), result, Encoding.UTF8);
            }
        }
    }
}