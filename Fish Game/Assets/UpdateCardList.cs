using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Game;
using UnityEngine;
using UnityEngine.UI;

public class UpdateCardList : MonoBehaviour
{
    private Dropdown _dropdown;
    
    private void Awake()
    {
        _dropdown = GetComponent<Dropdown>();
    }

    public void updateList()
    {
        GameSystem.Instance.CurrentPlayer.Cards.Where(card => card.CanPlay()).ToList().ForEach(card =>
        {
//            card.
        });
    }
}
