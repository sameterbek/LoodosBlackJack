using System;
using System.Collections.Generic;
using System.Text;

namespace LoodosBlackJack
{
    public class Card
    {
        private string CardName;
        private int[] CardValues;

        public Card(string cardName, int[] cardValues)
        {
            CardName = cardName;
            CardValues = cardValues;
        }

        public override string ToString()
        {
            return CardName;
        }

        public int[] GetValues
        {
            get
            {
                return CardValues;
            }
        }
    }
}
