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
        GameSystem.Instance.NewPlayerTurn += Instance_NewPlayerTurn;
    }

    private void Instance_NewPlayerTurn(object sender, FisherPlayer e)
    {
        this.updateList();
    }

    public void updateList()
    {
        List<Dropdown.OptionData> newItems = new List<Dropdown.OptionData>();
        newItems.Add(new Dropdown.OptionData("NONE"));
        GameSystem.Instance.CurrentPlayer.Cards.Where(card => card.CanPlay()).ToList().ForEach(card =>
        {
            newItems.Add(new Dropdown.OptionData(card.Name));
            //            card.
        });
        _dropdown.options = newItems;
    }
}
