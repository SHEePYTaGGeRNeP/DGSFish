using System.Collections.Generic;
using Assets.Scripts.Game;
using Assets.Scripts.Game.Cards;
using UnityEngine;
using System.Linq;

public class FightTrainer : MonoBehaviour
{
    [SerializeField]
    private List<Trainer> _trainers = new List<Trainer>();
    public Trainer Opponent { get; private set; }


    public void fightTrainer()
    {
        Opponent = choseRandomTrainer();
        Debug.Log(Opponent.name);
        Debug.Log(Opponent.fish);
        ConsoleLog.AddToLog($"You're fighting {Opponent.name} with a {Opponent.fish.name}.");
        resolveFight(rollPlayer(), new DamageCard[0]);
    }

    public void resolveFight(uint playerDamage, IEnumerable<DamageCard> playedCards)
    {
        foreach (DamageCard card in playedCards)
            GameSystem.Instance.CurrentPlayer.RemoveCard(card);
        uint extraPlayerDamage = (uint)playedCards.Sum(x => x.Damage);
        uint finalPlayerDamage = playerDamage + extraPlayerDamage;
        uint opponentDamage = Opponent.fish.RollDamage();
        ConsoleLog.AddToLog($"{Opponent.name}'s {Opponent.fish.name} has an attack of {opponentDamage}.");
        ConsoleLog.AddToLog($"{Opponent.fish.name} uses {Opponent.fish.AttackName}");
        ConsoleLog.AddToLog($"{GameSystem.Instance.CurrentPlayer}'s {GameSystem.Instance.CurrentPlayer.selectedFish.name} has an attack of {finalPlayerDamage}.");
        if (opponentDamage > finalPlayerDamage)
        {
            ConsoleLog.AddToLog($"{GameSystem.Instance.CurrentPlayer}'s {GameSystem.Instance.CurrentPlayer.selectedFish.name} has been KO'd.");
            GameSystem.Instance.CurrentPlayer.LostFight();
        }
        else
            ConsoleLog.AddToLog($"{GameSystem.Instance.CurrentPlayer.Name} has won the game!");
        GameSystem.Instance.NextPlayer();
    }

    private uint rollPlayer()
    {
        return GameSystem.Instance.CurrentPlayer.selectedFish.RollDamage();
    }

    private Trainer choseRandomTrainer()
    {
        return _trainers[Random.Range(0, _trainers.Count - 1)];
    }
}

