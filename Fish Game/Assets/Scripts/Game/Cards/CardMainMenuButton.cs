using UnityEngine;

namespace Assets.Scripts.Game.Cards
{
    class CardMainMenuButton : MonoBehaviour
    {
        [SerializeField]
        private CardHolder _holder;

        [SerializeField]
        private float _percChanceToFindCard = 0.33f;

        public void On_Click()
        {
            if (Random.Range(0, 1) > _percChanceToFindCard)
            {
                ConsoleLog.AddToLog($"{GameSystem.Instance.CurrentPlayer.Name} found no card.");
                GameSystem.Instance.NextPlayer();
                return;
            }
            Card c = this._holder.RandomCard();
            GameSystem.Instance.CurrentPlayer.AddCard(c);
            ConsoleLog.AddToLog($"{GameSystem.Instance.CurrentPlayer.Name} found {c.Name}.");
            GameSystem.Instance.NextPlayer();
        }
    }
}
