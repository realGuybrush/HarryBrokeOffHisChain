using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StatsController : MonoBehaviour
{
    [SerializeField]
    private List<StatID> statIDs = Enum.GetValues(typeof(StatID)).Cast<StatID>().ToList();
    [SerializeField]
    private List<Stat> statValues = new List<Stat>(new Stat[Enum.GetNames(typeof(StatID)).Length]);
    private Dictionary<StatID, Stat> stats = new Dictionary<StatID, Stat>();

    /*[SerializeField]
    private float baseDamage = 10;
    [SerializeField]
    private float damageMultiplier = 1.0f;
    
    [SerializeField]
    private float baseStrongAttackDamage = 25;
    [SerializeField]
    private float strongAttackDamageMultiplier = 1.0f;

    [SerializeField]
    private float baseDefense;
    [SerializeField]
    private float defenseMultiplier = 1.0f;
    
    [SerializeField]
    private float baseWalkSpeed = 3.0f;
    [SerializeField]
    private float movementMultiplier = 1.0f;
    [SerializeField]
    private float baseRunMultiplier = 2.0f;
    [SerializeField]
    private float runMultiplierMultiplier = 2.0f;

    [SerializeField]
    private float jumpSpeedY = 5.0f;*/

    private void Awake()
    {
        for (int i = 0; i < statIDs.Count; i++)
        {
            statValues[i].Init();
            stats.Add(statIDs[i], statValues[i]);
        }
    }

    public void ModifyStat(StatID id, bool isFlat, float value)
    {
        if(isFlat)
            stats[id].FlatIncrease += value;
        else
            stats[id].PercentIncrease += value;
    }

    public float Speed(bool running)
    {
        return stats[StatID.walkSpeed].Value;
    }

}