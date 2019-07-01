using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Game;

namespace Assets.Scripts
{
    [RequireComponent(typeof(TextMesh))]
    public class CurrentPlayerText : MonoBehaviour
    {
        private TextMesh _textMesh;

        private void Awake()
        {
            this._textMesh = this.GetComponent<TextMesh>();
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