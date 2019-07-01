using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Game.Cards
{
    class CardMainMenuButton
    {
        [SerializeField]
        private CardHolder _holder;
        public void On_Click()
        {
            GameSystem.Instance.CurrentPlayer.AddCard(this._holder.RandomCard());
            GameSystem.Instance.NextPlayer();
        }
    }
}
