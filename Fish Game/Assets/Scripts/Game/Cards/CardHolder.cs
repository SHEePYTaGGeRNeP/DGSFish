using UnityEngine;

namespace Assets.Scripts.Game.Cards
{
    [CreateAssetMenu(fileName = "CardHolder", menuName = "Cards/CreateCardHolder", order = 0)]
    class CardHolder : ScriptableObject
    {
        [SerializeField]
        private Card[] _cards;

        public Card RandomCard() => this._cards[Random.Range(0, this._cards.Length)];
    }
}
