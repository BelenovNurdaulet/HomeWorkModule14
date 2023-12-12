using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorkModule14
{
    class Karta
    {
        public string Mast { get; set; }
        public string Type { get; set; }

        public Karta(string mast, string type)
        {
            Mast = mast;
            Type = type;
        }
    }

    class Player
    {
        public List<Karta> Cards { get; set; }

        public Player()
        {
            Cards = new List<Karta>();
        }

        public void DisplayCards()
        {
            Console.WriteLine("Имеющиеся карты:");
            foreach (var card in Cards)
            {
                Console.WriteLine($"{card.Type} {card.Mast}");
            }
            Console.WriteLine();
        }
    }

    class Game
    {
        private List<Karta> deck;
        private Player player1;
        private Player player2;
        private int CompareCards(Karta card1, Karta card2)
        {
            Dictionary<string, int> typeValues = new Dictionary<string, int>
        {
            { "6", 6 },
            { "7", 7 },
            { "8", 8 },
            { "9", 9 },
            { "10", 10 },
            { "Валет", 11 },
            { "Дама", 12 },
            { "Король", 13 },
            { "Туз", 14 }
        };

            int value1 = typeValues[card1.Type];
            int value2 = typeValues[card2.Type];

            return value1.CompareTo(value2);
        }
        public Game()
        {
            InitializeDeck();
            ShuffleDeck();
            DealCards();
        }

        private void InitializeDeck()
        {
            deck = new List<Karta>();
            string[] masts = { "Черви", "Бубны", "Пики", "Трефы" };
            string[] types = { "6", "7", "8", "9", "10", "Валет", "Дама", "Король", "Туз" };

            foreach (var mast in masts)
            {
                foreach (var type in types)
                {
                    deck.Add(new Karta(mast, type));
                }
            }
        }

        private void ShuffleDeck()
        {
            Random random = new Random();
            deck = deck.OrderBy(x => random.Next()).ToList();
        }

        private void DealCards()
        {
            player1 = new Player();
            player2 = new Player();

            for (int i = 0; i < deck.Count; i++)
            {
                if (i % 2 == 0)
                    player1.Cards.Add(deck[i]);
                else
                    player2.Cards.Add(deck[i]);
            }
        }

        public void Play()
        {
            int round = 1;

            while (player1.Cards.Count > 0 && player2.Cards.Count > 0)
            {
                Console.WriteLine($"Раунд {round}:");

                if (ContinueGame())
                {
                    Console.WriteLine("Игрок 1:");
                    player1.DisplayCards();

                    Console.WriteLine("Игрок 2:");
                    player2.DisplayCards();

                    Karta card1 = player1.Cards[0];
                    Karta card2 = player2.Cards[0];

                    Console.WriteLine($"Игрок 1 кладет карту: {card1.Type} {card1.Mast}");
                    Console.WriteLine($"Игрок 2 кладет карту: {card2.Type} {card2.Mast}");

                    if (CompareCards(card1, card2) > 0)
                    {
                        Console.WriteLine("Игрок 1 выигрывает раунд!\n");
                        player1.Cards.AddRange(new[] { card1, card2 });
                    }
                    else
                    {
                        Console.WriteLine("Игрок 2 выигрывает раунд!\n");
                        player2.Cards.AddRange(new[] { card1, card2 });
                    }

                    player1.Cards.RemoveAt(0);
                    player2.Cards.RemoveAt(0);
                    round++;
                }
                else
                {
                    break;
                }
            }

            if (player1.Cards.Count > player2.Cards.Count)
                Console.WriteLine("Игрок 1 выигрывает!");
            else if (player2.Cards.Count > player1.Cards.Count)
                Console.WriteLine("Игрок 2 выигрывает!");
            else
                Console.WriteLine("Ничья!");
        }

        private bool ContinueGame()
        {
            Console.Write("Хотите сыграть еще раз? (да/нет): ");
            string answer = Console.ReadLine().ToLower();

            return answer == "да";
        }
    }

    class Program
    {
        static void Main()
        {
            do
            {
                Game game = new Game();
                game.Play();

            } while (ContinueMainGame());
        }

        private static bool ContinueMainGame()
        {
            Console.Write("Хотите начать новую игру? (да/нет): ");
            string answer = Console.ReadLine().ToLower();

            return answer == "да";
        }
    }

}
