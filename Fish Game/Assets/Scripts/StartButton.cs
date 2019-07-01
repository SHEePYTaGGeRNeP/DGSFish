using Assets.Scripts.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Button))]
    class StartButton : MonoBehaviour
    {
        [SerializeField]
        private Dropdown _dropDownNrOfPlayers;

        public void Start_Click()
        {
            string selectedOption = this._dropDownNrOfPlayers.options[this._dropDownNrOfPlayers.value].text;
            GameSystem.Instance.StartGame(Int32.Parse(selectedOption));
        }
    }
}
