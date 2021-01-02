using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoodosBlackJack
{
    public class Player
    {

        public Player(int playerNo)
        {
            Cards = new List<Card>();
            PlayerNo = playerNo;
        }
        public int PlayerNo { get; set; }
        public List<Card> Cards { get; set; }

        public int TotalNumber
        {
            get
            {
                var totalNumber = 0;
                foreach (var card in Cards.OrderBy(s=>s.GetValues.Length))
                {
                    if (card.GetValues.Length > 1)
                    {
                        if (totalNumber + card.GetValues[1] > 21)
                            totalNumber += card.GetValues[0];
                        else
                            totalNumber += card.GetValues[1];
                    }
                    else
                        totalNumber += card.GetValues[0];
                }
                return totalNumber;
            }
        }
    }
}
