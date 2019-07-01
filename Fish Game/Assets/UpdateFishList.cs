using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Game;
using UnityEngine;
using UnityEngine.UI;

public class UpdateFishList : MonoBehaviour
{
    private Dropdown _dropdown;

    void Start()
    {
        _dropdown = GetComponent<Dropdown>();
    }

    public void onValueChange(Int32 data)
    {
        string fishdata = _dropdown.options[_dropdown.value].text;
        Fish fish = GameSystem.Instance.CurrentPlayer.Fish.First(pair => pair.Key.ToString() == fishdata).Key;
        GameSystem.Instance.CurrentPlayer.selectedFish = fish;
    }

    public void updateList()
    {
        List<Fish> fishes = GameSystem.Instance.CurrentPlayer.getAliveFishs().ToList();
        List<Dropdown.OptionData> newItems = new List<Dropdown.OptionData>();
        for (int i = 0; i < fishes.Count; i++)
        {
            newItems.Add(new Dropdown.OptionData(fishes[i].ToString()));
        }

        _dropdown.options = newItems;
    }
}