using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;
using Assets.Scripts.Game;

public class CatchFish : MonoBehaviour
{
    public FishHolder fishHolder;

    public void TryCatchFish()
    {
        Fish fish = fishHolder.RandomFish();
        uint RollNumber = Die.Roll(fish.CatchDie);

        Debug.Log("Your roll:" + RollNumber);
        string required = "Required roll: ";
        for (int i = 0; i < fish.CatchValues.Length; i++)
        {
            required += fish.CatchValues[i] + "/";
        }
        Debug.Log(required);

        if (fish.CatchSuccess(RollNumber))
        {
            Debug.Log("<color=blue>You caught " + fish.Name + "!</color>");
            GameSystem.Instance.CurrentPlayer.AddFish(fish);
        }
        else
        {
            Debug.Log("<color=maroon>Despite your best efforts " + fish.Name + " got away!</color>");
        }
    }
}
