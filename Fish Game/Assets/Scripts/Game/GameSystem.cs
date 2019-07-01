using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Game
{
    public class GameSystem : MonoBehaviour
    {
        [SerializeField]
        private int _sceneToLoad = 1;

        private List<FisherPlayer> _players = new List<FisherPlayer>();
        private int _currentPlayerIndex;
        public FisherPlayer CurrentPlayer => this._players[_currentPlayerIndex];

        public static GameSystem Instance { get; private set; }

        public event EventHandler<FisherPlayer> NewPlayerTurn;

        public enum GameState { Menu, Catching, Battling}
        public GameState CurrentState { get; set; }

        private void Awake()
        {
            if (Instance != null)
                Instance = this;
        }

        public void StartGame(int nrOfPlayers)
        {
            Debug.Log($"Starting game with {nrOfPlayers} player(s).");
            Instance._players.Clear();
            for (int i = 0; i < nrOfPlayers; i++)
                Instance._players.Add(new FisherPlayer($"Player {i + 1}"));
            Instance._currentPlayerIndex = -1;
            SceneManager.LoadScene(Instance._sceneToLoad);
            Instance.NextPlayer();
        }

        public void NextPlayer()
        {
            Instance._currentPlayerIndex = Mathf.Clamp(_currentPlayerIndex + 1, 0, _players.Count);
            Debug.Log($"It's {Instance.CurrentPlayer}'s turn!");
            Instance.NewPlayerTurn?.Invoke(Instance, Instance.CurrentPlayer);
        }
    }
}
