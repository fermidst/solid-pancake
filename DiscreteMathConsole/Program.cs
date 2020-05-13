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
            var (n1Pdnf, n1Pcnf) = Evaluation.GetPdnfPcnf("00010101");
            var (n2Pdnf, n2Pcnf) = Evaluation.GetPdnfPcnf("11101011");
            var (n3Pdnf, n3Pcnf) = Evaluation.GetPdnfPcnf(Console.ReadLine());
            var result = new StringBuilder()
                .AppendLine("n1 (16 + 5) 00010101")
                .AppendLine($"pdnf: {n1Pdnf}")
                .AppendLine($"pcnf: {n1Pcnf}")
                .AppendLine("n2 (256 - (16 + 5) 11101011")
                .AppendLine($"pdnf: {n2Pdnf}")
                .AppendLine($"pcnf: {n2Pcnf}")
                .AppendLine("n3 custom expression")
                .AppendLine($"pdnf: {n3Pdnf}")
                .AppendLine($"pcnf: {n3Pcnf}")
                .ToString();
            Console.WriteLine(result);
            var baseDirectory = AppDomain.CurrentDomain.BaseDirectory ?? throw new InvalidOperationException();

            await File.WriteAllTextAsync(Path.Combine(baseDirectory, "result.txt"), result, Encoding.UTF8);
        }
    }
}