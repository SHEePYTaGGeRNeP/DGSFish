﻿using System;
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
            this._dropdown = this.GetComponent<Dropdown>();
            GameSystem.Instance.NewPlayerTurn += this.Instance_NewPlayerTurn;
        }

        private void Start()
        {
            this.updateList();
        }

        private void Instance_NewPlayerTurn(object sender, FisherPlayer e)
        {
            this.updateList();
        }

        public void onValueChange(Int32 data)
        {
            string fishdata = this._dropdown.options[this._dropdown.value].text;
            Fish fish = GameSystem.Instance.CurrentPlayer.Fish.First(pair => pair.fish.ToString() == fishdata).fish;
            GameSystem.Instance.CurrentPlayer.SelectFishAsCurrent(fish);
        }

        public void updateList()
        {
            List<Fish> fishes = GameSystem.Instance.CurrentPlayer.GetAliveFishes().ToList();
            List<Dropdown.OptionData> newItems = new List<Dropdown.OptionData>();
            for (int i = 0; i < fishes.Count; i++)
            {
                newItems.Add(new Dropdown.OptionData(fishes[i].ToString()));
            }

            this._dropdown.options = newItems;
        }
    }
}