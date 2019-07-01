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
        //resolveFight(rollPlayer(), opponent);
    }

    public void resolveFight(uint playerDamage, Trainer opp)
    {
        uint opponentDmg = opp.fish.RollDamage();


        GameSystem.Instance.NextPlayer();
    }

    private uint rollPlayer()
    {
        return GameSystem.Instance.CurrentPlayer.selectedFish.RollDamage();
    }
    
    private Trainer choseRandomTrainer()
    {
        return _trainers[Random.Range(0, _trainers.Count-1)];
    }
}

