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
        GameSystem.Instance.NewPlayerTurn += updateList;
    }

    private void updateList(object sender, FisherPlayer e)
    {
        updateList();
    }

    public void updateList()
    {
        
        List<Dropdown.OptionData> newItems = new List<Dropdown.OptionData>();
        newItems.Add(new Dropdown.OptionData("NONE"));
        GameSystem.Instance.CurrentPlayer.Cards.Where(card => card.CanPlay()).ToList().ForEach(card =>
        {
            newItems.Add(new Dropdown.OptionData(card.Name));
        });
        _dropdown.options = newItems;
    }
}
