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
        public List<(Fish, bool isKO)> Fish = new List<(Fish, bool)>();

        public Fish selectedFish;

        public string Name { get; }

        private List<ICard> _cards;
        public IReadOnlyCollection<ICard> Cards => this._cards;
        public IEnumerable<ICard> PlayableCards => this._cards.Where(x => x.CanPlay());

        public FisherPlayer(string name, Fish startFish)
        {
            this.Name = name;
            selectedFish = startFish;
            AddFish(startFish);
            this._cards = new List<ICard>();
        }

        public void AddFish(Fish fish)
        {
            this.Fish.Add((fish, false));
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
            return Fish.FindAll(fish => !fish.isKO).Select(pair  => pair.Item1);
        }

        public void LostFight()
        {
            (Fish, bool isKO) item = this.Fish.Find(x => x.Item1 == this.selectedFish);
            item.isKO = true;
        }

        public override string ToString() => this.Name;
    }
}
