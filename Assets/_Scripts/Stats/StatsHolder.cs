using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

[Serializable]
    public class StatsHolder
    {
        [SerializeField] private int health = 0;
        [Required] [SerializeField] private List<StatData> statData = new List<StatData>();

        public void SetAllDirty()
        {
            //Set all of our stats to dirty (to be recalculated).
            foreach (StatData data in statData)
            {
                data.SetDirty();
            }
        }

        public StatData GetStatData(StatTypes statType)
        {
            foreach (StatData data in statData)
            {
                if (data.Stat.StatType == statType)
                {
                    return data;
                }
            }
            return null;
        }
        public StatData GetStatData(StatSO stat)
        {
            foreach (StatData data in statData)
            {
                if (data.Stat == stat)
                {
                    return data;
                }
            }
            return null;
        }

        public int GetStatValue(StatTypes statType)
        {
            foreach (StatData data in statData)
            {
                if (data.Stat.StatType == statType)
                {
                    return data.Value;
                }
            }
            return 0;
        }
        public int GetStatValue(StatSO stat)
        {
            foreach (StatData data in statData)
            {
                if (data.Stat == stat)
                {
                    return data.Value;
                }
            }
            return 0;
        }
    }
