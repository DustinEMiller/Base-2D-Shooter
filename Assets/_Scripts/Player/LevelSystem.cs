﻿using System;
using UnityEngine;

public class LevelSystem {

    public event EventHandler OnExperienceChanged;
    public event EventHandler OnLevelChanged;

    private static readonly int[] experiencePerLevel = new[] { 50, 70, 100, 120, 150, 170, 200, 230, 250, 280 };

    private int level;
    private int experience;

    public LevelSystem() {
        level = 0;
        experience = 0;
    }

    public void AddExperience(int amount) {
        if (!IsMaxLevel()) {
            experience += amount;
            while (!IsMaxLevel() && experience >= GetExperienceToNextLevel(level)) {
                // Enough experience to level up
                experience -= GetExperienceToNextLevel(level);
                level++;
                if (OnLevelChanged != null) OnLevelChanged(this, EventArgs.Empty);
            }
            if (OnExperienceChanged != null) OnExperienceChanged(this, EventArgs.Empty);
        }
    }

    public int GetLevelNumber() {
        return level;
    }

    public float GetExperienceNormalized() {
        if (IsMaxLevel()) {
            return 1f;
        } else {
            return (float)experience / GetExperienceToNextLevel(level);
        }
    }

    public int GetExperience() {
        return experience;
    }

    public int GetExperienceToNextLevel(int level) {
        if (level < experiencePerLevel.Length) {
            return experiencePerLevel[level];
        } else {
            // Level Invalid
            Debug.LogError("Level invalid: " + level);
            return 100;
        }
    }

    public bool IsMaxLevel() {
        return IsMaxLevel(level);
    }

    public bool IsMaxLevel(int level) {
        return level == experiencePerLevel.Length - 1;
    }

}
