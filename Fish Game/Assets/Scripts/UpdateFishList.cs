using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Game;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class UpdateFishList : MonoBehaviour
    {
        private Dropdown _dropdown;

        void Awake()
        {
            _dropdown = GetComponent<Dropdown>();
            GameSystem.Instance.NewPlayerTurn += Instance_NewPlayerTurn;
        }

        private void Instance_NewPlayerTurn(object sender, FisherPlayer e)
        {
            this.updateList();
        }

        public void onValueChange(Int32 data)
        {
            string fishdata = _dropdown.options[_dropdown.value].text;
            Fish fish = GameSystem.Instance.CurrentPlayer.Fish.First(pair => pair.Item1.ToString() == fishdata).Item1;
            GameSystem.Instance.CurrentPlayer.selectedFish = fish;
        }

        public void updateList()
        {
            List<Fish> fishes = GameSystem.Instance.CurrentPlayer.getAliveFishs().ToList();
            List<Dropdown.OptionData> newItems = new List<Dropdown.OptionData>();
            for (int i = 0; i < fishes.Count; i++)
            {
                newItems.Add(new Dropdown.OptionData(fishes[i].ToString()));
            }

            _dropdown.options = newItems;
        }
    }
}