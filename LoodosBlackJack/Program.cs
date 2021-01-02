using System;
using System.Collections.Generic;
using System.Linq;

namespace LoodosBlackJack
{
    class Program
    {
        static void Main(string[] args)
        {
            CardDeck cardDeck = new CardDeck();
            cardDeck.ShuffleDeck();

            List<Player> players = new List<Player>(Enumerable.Range(1, 4).Select(x => new Player(x)));

            for (int i = 0; i < 2; i++)
            {
                foreach (var player in players)
                {
                    player.Cards.Add(cardDeck.GiveCard());
                }
            }

            List<Player> passedPlayers = new List<Player>();
            while (true)
            {
                foreach (var player in players.Where(x=>!passedPlayers.Contains(x)))
                {
                    Console.WriteLine($"{player.PlayerNo}. Oyuncu Kartları :");
                    Console.WriteLine($"{String.Join(",", player.Cards.Select(s => s.ToString()))}");

                    Console.WriteLine("Kart Almak için 1e bas, Pas için herhangi bir tuşa bas.");
                    var key = Console.ReadLine();
                    if (key != "1")
                        passedPlayers.Add(player);
                    else
                        player.Cards.Add(cardDeck.GiveCard());
                }
                if (passedPlayers.Count == players.Count)
                    break;
            }

            var winnerPlayer = players.Where(s => s.TotalNumber <= 21).OrderByDescending(s => s.TotalNumber).FirstOrDefault();
            Console.WriteLine($"Kazanan Oyuncu : {winnerPlayer.PlayerNo}. Oyuncu");

        }
    }


    

    
}
