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
        public List<(Fish fish, bool isKO)> Fish = new List<(Fish, bool)>();

        public Fish SelectedFish { get; private set; }

        public string Name { get; }

        private List<ICard> _cards;
        public IReadOnlyCollection<ICard> Cards => this._cards;
        public IEnumerable<ICard> PlayableCards => this._cards.Where(x => x.CanPlay());

        public FisherPlayer(string name, Fish startFish)
        {
            this.Name = name;
            this.SelectedFish = startFish;
            this.AddFish(startFish);
            this._cards = new List<ICard>();
        }

        public void AddFish(Fish fish) => this.Fish.Add((fish, false));

        public void SelectFishAsCurrent(Fish fish)
        {
            if (!this.Fish.Any(x => x.fish == fish))
                throw new ApplicationException("Can't select a fish that the player does not posses");
            this.SelectedFish = fish;
        }

        public void AddCard(ICard card) => this._cards.Add(card);

        public void RemoveCard(ICard card) => this._cards.Remove(card);

        public IEnumerable<Fish> GetAliveFishes()
        {
            List<Fish> fishes = new List<Fish>();
            return this.Fish.FindAll(fish => !fish.isKO).Select(pair  => pair.fish);
        }

        public void LostFight()
        {
            (Fish, bool isKO) item = this.Fish.Find(x => x.fish == this.SelectedFish);
            item.isKO = true;
        }

        public override string ToString() => this.Name;
    }
}
