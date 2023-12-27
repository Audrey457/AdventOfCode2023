using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using AdventOfCode2023.Day3;
using System.Reflection.Metadata.Ecma335;

namespace AdventOfCode2023.Day4
{
    public class WiningCards
    {
        private readonly Dictionary<int, List<int>> winningNumbers;
        private readonly Dictionary<int, List<int>> cards;

        public WiningCards(Dictionary<int, List<int>> winningNumbers, Dictionary<int, List<int>> cards)
        {
            this.winningNumbers = winningNumbers;
            this.cards = cards;
        }

        public WiningCards(TransformFile transformFile)
        {
            this.cards = transformFile.ToIntDictionnary(0);
            this.winningNumbers = transformFile.ToIntDictionnary(1);
        }

        public int GetPilePoints()
        {
            int pilePoints = 0;
            for(int i = 0; i < this.cards.Count; i++)
            {
                pilePoints += GetCardPoints(i);
            }
            return pilePoints;
        }

        public int GetPileScratchCards()
        {
            Dictionary<int, List<List<int>>>  pileScratchCards = new Dictionary<int, List<List<int>>>();
            
            
            for(int i = 0; i < this.cards.Count; i++)
            {
                pileScratchCards = GetScratchCards(i, pileScratchCards);
            }
            return pileScratchCards.Sum(e => e.Value.Count);
        }

        public Dictionary<int, List<List<int>>> GetScratchCards(int cardIdentifier, Dictionary<int, List<List<int>>> list)
        {
            List<int> winningNumbersInCard = cards[cardIdentifier].Intersect(winningNumbers[cardIdentifier]).ToList();
            if (list.ContainsKey(cardIdentifier))
            {
                list[cardIdentifier].Add(cards[cardIdentifier]);
            }
            else
            {
                list[cardIdentifier] = new List<List<int>>();
                list[cardIdentifier].Add(cards[cardIdentifier]);
            }
            for (int i = cardIdentifier+1; i <= cardIdentifier + winningNumbersInCard.Count; i++)
            {
                if (list.ContainsKey(i))
                {
                    for (int j = 0; j < list[cardIdentifier].Count; j++)
                        list[i].Add(cards[i]);
                }
                else
                {
                    list[i] = new List<List<int>>();
                    for (int j = 0; j < list[cardIdentifier].Count; j++)
                        list[i].Add(cards[i]);

                }
            }
            
            return list;
        }

        private int GetCardPoints(int cardIdentifier) 
        { 
            List<int> winningNumbersInCard = cards[cardIdentifier].Intersect(winningNumbers[cardIdentifier]).ToList();
            return GetCardPoints(winningNumbersInCard.Count, 1);
        }

        private int GetCardPoints(int matches, int points)
        {
            if (matches == 1) return points;
            if (matches == 0) return 0;
            return GetCardPoints(matches - 1, 2 * points);
        }
    }
}
