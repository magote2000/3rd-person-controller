using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Unit Stats")]
public class Stats : ScriptableObject
{
    public Dictionary<Stat, float> stats = new Dictionary<Stat, float>();
    public List<StatInfo> statInfo = new List<StatInfo>();

    public void Initialize()
    {
        foreach (StatInfo s in statInfo)
        {
            stats.Add(s.statType, s.statValue);
        }
    }
    public float GetStat(Stat stat)
    {
        if (stats.TryGetValue(stat, out float value))
        {
            return value;
        }
        else
        {
            Debug.LogError($"No stat value found for {stat} on {this}");
            return 0f;
        }
    }
}
