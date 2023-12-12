using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordStatisticsAnalyzer
{
 

    class Program
    {
        static void Main()
        {
            string text = "Вот дом, Который построил Джек. А это пшеница, Которая в темном чулане хранится В доме, Который построил Джек. А это веселая птица­ синица, Которая часто вору­ет пшеницу, Которая в темном чулане хранится В доме, Который построил Джек.";

            // Разделение текста на слова с использованием регулярного выражения
            string[] words = Regex.Split(text, @"\W+");

            // Создание коллекции для хранения статистики
            Dictionary<string, int> wordStatistics = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

            // Подсчет статистики слов
            foreach (string word in words)
            {
                if (!string.IsNullOrEmpty(word))
                {
                    if (wordStatistics.ContainsKey(word))
                    {
                        wordStatistics[word]++;
                    }
                    else
                    {
                        wordStatistics[word] = 1;
                    }
                }
            }

            // Вывод статистики в виде таблицы
            Console.WriteLine("Слово\t\tКоличество");
            Console.WriteLine("------------------------");
            foreach (var kvp in wordStatistics)
            {
                Console.WriteLine($"{kvp.Key}\t\t{kvp.Value}");
            }
        }
    }

}
