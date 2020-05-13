using System;
using System.Collections.Generic;
using System.Linq;

namespace DiscreteMathConsole
{
    public static class Evaluation
    {
        public static (string pdnf, string pcnf) GetPdnfPcnf(string functionResults)
        {
            var functionVector = functionResults.Select(f => f == '1').ToArray();

            var variablesCount = (int) Math.Log(functionVector.Length, 2);

            if (functionResults.Length != 1 << variablesCount)
                throw new InvalidOperationException();

            var pcnfValues = new List<string>();
            var pdnfValues = new List<string>();

            for (var i = 0; i < functionVector.Length; i++)
                if (functionVector[i])
                {
                    var expressionVariables = new List<string>();

                    for (int index = variablesCount - 1, charCode = 'a'; index >= 0; index--, charCode++)
                        expressionVariables.Add(
                            ((i >> index) & 1) == 1
                                ? $"{(char) charCode}"
                                : $"!{(char) charCode}"
                        );

                    pdnfValues.Add(string.Join("", expressionVariables));
                }
                else
                {
                    var expressionVariables = new List<string>();

                    for (int index = variablesCount - 1, charCode = 'a'; index >= 0; index--, charCode++)
                        expressionVariables.Add(
                            ((i >> index) & 1) == 0
                                ? $"{(char) charCode}"
                                : $"!{(char) charCode}"
                        );

                    pcnfValues.Add($"({string.Join(" | ", expressionVariables)})");
                }

            return (string.Join(" | ", pdnfValues), string.Join(" & ", pcnfValues));
        }
    }
}