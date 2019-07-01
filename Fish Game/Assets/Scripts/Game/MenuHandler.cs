﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Game
{
    class MenuHandler : MonoBehaviour
    {
        [SerializeField]
        private GameObject _catchCanvas;

        [SerializeField]
        private GameObject _battleCanvas;

        [SerializeField]
        private GameObject _cardsCanvas;

        public void OpenCatchFish()
        {
            this._catchCanvas.SetActive(true);
            GameSystem.Instance.CurrentState = GameSystem.GameState.Catching;
        }
        public void OpenBattle()
        {
            this._battleCanvas.SetActive(true);
            GameSystem.Instance.CurrentState = GameSystem.GameState.Battling;
        }
        public void OpenFindCards()
        {
            this._catchCanvas.SetActive(true);
            GameSystem.Instance.CurrentState = GameSystem.GameState.FindCards;
        }

        public void BackToMenu()
        {
            this._catchCanvas.SetActive(false);
            this._battleCanvas.SetActive(false);
            this._cardsCanvas.SetActive(false);
            GameSystem.Instance.CurrentState = GameSystem.GameState.Menu;
        }
    }
}