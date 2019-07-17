using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Game
{
    [RequireComponent(typeof(Text))]
    class ConsoleLog : MonoBehaviour
    {
        [SerializeField]
        private int _maxRows = 6;
        [SerializeField]
        private float _refreshRate = 1f;

        private float _lastAdd;

        private Text _text;

        private Queue<string> _log;
        private Queue<string> _queuedItems = new Queue<string>();

        private static ConsoleLog _instance;

        private void Awake()
        {
            if (_instance == null)
                _instance = this;
            this._text = this.GetComponent<Text>();
            this._log = new Queue<string>(this._maxRows);
        }

        public static void AddToLog(string message)
        {
            Debug.Log(message);
            _instance._queuedItems.Enqueue(message);
        }

        private void Update()
        {
            if (Time.time - this._lastAdd < this._refreshRate || this._queuedItems.Count == 0)
                return;
            this._lastAdd = Time.time;
            this._log.Enqueue(this._queuedItems.Dequeue());
            if (this._log.Count > this._maxRows)
                this._log.Dequeue();
            string fullLog = String.Empty;
            foreach (string s in this._log)
                fullLog += s + Environment.NewLine;
            this._text.text = fullLog;
        }
    }
}
