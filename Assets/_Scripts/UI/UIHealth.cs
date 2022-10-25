using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealth : MonoBehaviour
{
    [SerializeField] private GameObject heartPrefab = null, healthPanel;
    [SerializeField] private Sprite heartFull = null, heartEmpty = null, heartHalf = null;

    private int heartCount = 0;

    private List<Image> hearts = new List<Image>();

    public void Initialize(int livesCount)
    {
        heartCount = (livesCount % 2) + (livesCount / 2);

        foreach (Transform child in healthPanel.transform)
        {       
            Destroy(child.gameObject);
        }

        for (int i = 0; i < heartCount; i++)
        {
            hearts.Add(Instantiate(heartPrefab, healthPanel.transform).GetComponent<Image>());
            hearts[i].enabled = true;
        }
        
        UpdateUI(livesCount);
    }

    public void UpdateUI(int health)
    {
        int currentIndex = 1;
        for (int i = 0; i < heartCount; i++)
        {
            if ((currentIndex * 2) <= health)
            {
                hearts[i].sprite = heartFull;
            }
            else if ((currentIndex * 2 - 1) == health)
            {
                hearts[i].sprite = heartHalf;
            } 
            else
            {
                hearts[i].sprite = heartEmpty;
            }
            currentIndex++;
        }
    }
}
