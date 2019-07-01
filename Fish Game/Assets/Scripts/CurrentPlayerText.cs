using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Game;
using UnityEngine.UI;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Text))]
    public class CurrentPlayerText : MonoBehaviour
    {
        private Text _textMesh;

        private void Awake()
        {
            this._textMesh = this.GetComponent<Text>();
        }

        private void Start()
        {
            this.UpdateText();
        }

        public void UpdateText()
        {
            this._textMesh.text = "Current player: " + GameSystem.Instance.CurrentPlayer;
        }
    }
}