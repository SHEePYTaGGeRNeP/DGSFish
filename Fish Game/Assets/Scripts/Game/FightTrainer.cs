using System.Collections.Generic;
using Assets.Scripts.Game;
using UnityEngine;

public class FightTrainer : MonoBehaviour
{
    [SerializeField]
    private List<Trainer> _trainers = new List<Trainer>();
    
    public void fightTrainer()
    {
        Trainer opponent = choseRandomTrainer();
        Debug.Log($"Your fighting {opponent.name}.\nHe has a {opponent.fish.name}.");
        
    }

    private Trainer choseRandomTrainer()
    {
        return _trainers[Random.Range(0, _trainers.Count-1)];
    }
}

