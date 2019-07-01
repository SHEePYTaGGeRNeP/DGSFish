using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;
using Assets.Scripts.Game;

public class CatchFish : MonoBehaviour
{
    public FisherPlayer fisher;
    public FishHolder fishHolder;

    public void TryCatchFish()
    {
        Fish fish = fishHolder.RandomFish();

        Debug.Log("You tried cathing a fish!");

        if (fish.CatchSuccess(Die.Roll(fish.CatchDie)))
        {
            Debug.Log("You caught " + fish.Name + "!");
            fisher.AddFish(fish);
        }
        else
        {
            Debug.Log("Despite your best efforts, you suck!");
        }
    }
}
