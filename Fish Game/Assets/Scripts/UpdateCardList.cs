using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Game;
using Assets.Scripts.Game.Cards;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Game
{
    public class UpdateCardList : MonoBehaviour
    {
        private Dropdown _dropdown;

        private void Awake()
        {
            this._dropdown = this.GetComponent<Dropdown>();
            GameSystem.Instance.NewPlayerTurn += this.Instance_NewPlayerTurn;
        }

        private void Start()
        {
            this.updateList();
        }

        private void Instance_NewPlayerTurn(object sender, FisherPlayer e)
        {
            Debug.Log("Updating card list");
            this.updateList();
        }

        public void updateList()
        {
            List<Dropdown.OptionData> newItems = new List<Dropdown.OptionData>();
            newItems.Add(new Dropdown.OptionData("NONE"));
            foreach (ICard card in GameSystem.Instance.CurrentPlayer.PlayableCards)
            {
                newItems.Add(new Dropdown.OptionData(card.Name));
            }
            this._dropdown.options = newItems;
        }
    }
}