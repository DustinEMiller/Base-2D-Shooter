using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

 [CreateAssetMenu(fileName = "New Player Stats Holder", menuName = "Player/Stats Data Holder")]
    public class PlayerStatsDataHolder : SerializedScriptableObject
    {

        [Header("Data Holders")]
        [Required] [SerializeField] private StatsHolder defaultStats = null;

        [Header("On Level Up")]
        [Required] [SerializeField] private Dictionary<StatSO, StatModifier> levelUpStatChanges = new Dictionary<StatSO, StatModifier>();

        private float mana = 0f;

        public StatsHolder StatsHolder { get; private set; } = new StatsHolder();
        public LevelSystem LevelSystem { get; } = new LevelSystem();

        public int LoadPriority { get { return 100; } }
        

        public void Tick()
        {
            RegenerateMana();
        }

        #region Mana
        

        private void RegenerateMana()
        {
            //Mana += Time.deltaTime * StatsHolder.GetStatValue(StatTypes.ManaRegen);
        }

        #endregion

        /*#region Level Up
        private void GiveLevelUpRewards()
        {
            foreach (KeyValuePair<Stat, StatModifier> statChange in levelUpStatChanges)
            {
                StatsHolder.GetStatData(statChange.Key).AddModifier(statChange.Value);
            }
            StatsHolder.ResetHealth();
            ResetMana();
            foreach (KeyValuePair<Currency, int> currencyChange in levelUpCurrencyChanges)
            {
                CurrencyHolder.ChangeCurrencyAmount(currencyChange.Key, currencyChange.Value);
            }
        }

        #endregion*/

        /*public void Save()
        {
            GameSaveHandler.SaveFile("player_stats", StatsHolder);
            GameSaveHandler.SaveFile("player_levelSystem", LevelSystem);
            GameSaveHandler.SaveFile("player_currencies", CurrencyHolder);
        }

        public void Load()
        {
            //Load Level System
            GameSaveHandler.LoadFile("player_levelSystem", LevelSystem);
            onPlayerExperienceChanged.Raise();

            //Load Currencies
            if (!GameSaveHandler.LoadFile("player_currencies", CurrencyHolder))
            {
                JsonUtility.FromJsonOverwrite(JsonUtility.ToJson(defaultCurrencies), CurrencyHolder);
            }
            onPlayerCurrenciesChanged.Raise();

            //Load Stats
            if (!GameSaveHandler.LoadFile("player_stats", StatsHolder))
            {
                JsonUtility.FromJsonOverwrite(JsonUtility.ToJson(defaultStats), StatsHolder);
            }

            StatsHolder.SetAllDirty();
            onPlayerHealthChanged.Raise();
            onPlayerManaChanged.Raise();
            ResetMana();
        }*/
    }
