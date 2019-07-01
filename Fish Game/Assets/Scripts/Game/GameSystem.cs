using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Game
{
    public class GameSystem : MonoBehaviour
    {
        private List<FisherPlayer> _players = new List<FisherPlayer>();
        private int _currentPlayerIndex;
        public FisherPlayer CurrentPlayer => this._players[_currentPlayerIndex];
        
        public static GameSystem Instance { get; private set; }

        [SerializeField]
        private int _sceneToLoad = 1;

        private void Awake()
        {
            Instance = this;
        }

        public void StartGame(int nrOfPlayers)
        {
            Debug.Log($"Starting game with {nrOfPlayers} player(s).");
            for (int i = 0; i < nrOfPlayers; i++)
                _players.Add(new FisherPlayer($"Player {i + 1}"));
            this._currentPlayerIndex = 0;
            SceneManager.LoadScene(this._sceneToLoad);
        }

        public void NextPlayer()
        {
            this._currentPlayerIndex = Mathf.Clamp(_currentPlayerIndex + 1, 0, _players.Count);
        }
    }
}
