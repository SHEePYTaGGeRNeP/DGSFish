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
        public FisherPlayer CurrentPlayer => this._players[this._currentPlayerIndex];

        public Fish startFish;

        public static GameSystem Instance { get; private set; }

        public event EventHandler<FisherPlayer> NewPlayerTurn;

        public enum GameState { Menu, Catching, Battling, FindCards }
        public GameState CurrentState { get; set; }

        private void Awake()
        {
            if (Instance == null)
                Instance = this;
        }

        public void StartGame(int nrOfPlayers)
        {
            Debug.Log($"Starting game with {nrOfPlayers} player(s).");
            this._players.Clear();
            for (int i = 0; i < nrOfPlayers; i++)
                this._players.Add(new FisherPlayer($"Player {i + 1}", startFish));
            this._currentPlayerIndex = 0;
            SceneManager.LoadScene(this._sceneToLoad);
        }

        public void CallNewPlayerTurn()
        {
            Debug.Log($"It's {this.CurrentPlayer}'s turn!");
            ConsoleLog.AddToLog($"It's {this.CurrentPlayer}'s turn!");
            this.NewPlayerTurn?.Invoke(Instance, Instance.CurrentPlayer);
        }
        public void NextPlayer()
        {
            this._currentPlayerIndex = (Instance._currentPlayerIndex + 1) % Instance._players.Count;
            this.CallNewPlayerTurn();
        }
    }
}
