using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Game
{
    [RequireComponent(typeof(Text))]
    class ConsoleLog : MonoBehaviour
    {
        [SerializeField]
        private int _maxRows = 6;

        private Text _text;

        private Queue<string> _log;

        private void Awake()
        {
            this._text = this.GetComponent<Text>();
            this._log = new Queue<string>(this._maxRows);
        }

        public void AddToLog(string message)
        {
            this._log.Enqueue(message);
            string fullLog= String.Empty;
            foreach (string s in this._log)
                fullLog += s + Environment.NewLine;
            this._text.text = fullLog;
        }
    }
}
