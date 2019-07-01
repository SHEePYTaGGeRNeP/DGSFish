using Assets.Scripts.Game.Cards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Game
{
    public class FisherPlayer
    {
        /// <summary>Fish/IsKO</summary>
        public List<KeyValuePair<Fish, bool>> Fish = new List<KeyValuePair<Fish, bool>>();

        public Fish selectedFish;

        public string Name { get; }

        private List<ICard> _cards;
        public IReadOnlyCollection<ICard> Cards => this._cards;

        public FisherPlayer(string name, Fish startFish)
        {
            this.Name = name;
            selectedFish = startFish;
            AddFish(startFish);
            this._cards = new List<ICard>();
        }

        public void AddFish(Fish fish)
        {
            this.Fish.Add(new KeyValuePair<Fish, bool>(fish, false));
        }

        public void AddCard(ICard card)
        {
            this._cards.Add(card);
        }

        public void RemoveCard(ICard card)
        {
            this._cards.Remove(card);
        }

        public IEnumerable<Fish> getAliveFishs()
        {
            List<Fish> fishes = new List<Fish>();
            return Fish.FindAll(fish => !fish.Value).Select(pair  => pair.Key);
        }
    }
}
