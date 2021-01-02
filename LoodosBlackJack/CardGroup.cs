using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LoodosBlackJack
{
    public class CardDeck
    {
        private Card[] Cards;
        private int currentCardNumber;
        private const int CardCount = 52;

        public CardDeck()
        {
            Dictionary<string, List<int>> values = new Dictionary<string, List<int>>
            {
                {"AS", new List<int>{ 1,11 } },
                {"İkili", new List<int>{ 2 } },
                {"Üçlü", new List<int>{ 3 } },
                {"Dörtlü", new List<int>{ 4 } },
                {"Beşli", new List<int>{ 5 } },
                {"Altılı", new List<int>{ 6 } },
                {"Yedili", new List<int>{ 7 } },
                {"Sekizli", new List<int>{ 8 } },
                {"Dokuzlu", new List<int>{ 9 } },
                {"Onlu", new List<int>{ 10 } },
                {"Vale", new List<int>{ 10 } },
                {"Kız", new List<int>{ 10 } },
                {"Papaz", new List<int>{ 10 } },
            };

            string[] types = { "Maça", "Sinek", "Karo", "Kupa" };

            Cards = new Card[CardCount];
            currentCardNumber = 0;

            for (int i = 0; i < Cards.Length; i++)
            {
                Cards[i] = new Card(types[i / 13] + " " + values.ElementAt(i % 13).Key, values.ElementAt(i % 13).Value.ToArray());
            }
        }

        public void ShuffleDeck()
        {
            var rng = new Random();
            int n = Cards.Length;
            while (n > 1)
            {
                int k = rng.Next(n--);
                Card temp = Cards[n];
                Cards[n] = Cards[k];
                Cards[k] = temp;
            }
        }


        public Card GiveCard()
        {
            if (currentCardNumber < Cards.Length)
                return Cards[currentCardNumber++];
            else
                return null;
        }
    }
}
