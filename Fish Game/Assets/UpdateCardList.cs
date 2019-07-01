using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Game;
using Assets.Scripts.Game.Cards;
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
        Debug.Log("Updating card list");
        this.updateList();
    }

    public void updateList()
    {
        List<Dropdown.OptionData> newItems = new List<Dropdown.OptionData>();
        newItems.Add(new Dropdown.OptionData("NONE"));
        foreach (ICard card in GameSystem.Instance.CurrentPlayer.PlayableCards)
        {
            newItems.Add(new Dropdown.OptionData(card.Name));
        }
        _dropdown.options = newItems;
    }
}
