using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AgentDamagePopup : MonoBehaviour
{
    [SerializeField] private static Transform healthPopup;
    [SerializeField] AgentHealthSystem _healthSystem;

    private TextMeshPro _damageText;
    private float moveYSpeed = 20f;
    private float disappearTimer;

    private void Awake()
    {
        _healthSystem = GetComponentInParent<AgentHealthSystem>();
        
        if (_healthSystem != null)
        {
            _healthSystem.OnDamaged += HealthSystem_OnDamaged;
            _healthSystem.OnHealed += HealthSystem_OnHealed;
        }
    }

    private void HealthSystem_OnDamaged(object sender, int e)
    {
        CreatePopup(e, false);
    }
    
    private void HealthSystem_OnHealed(object sender, int e)
    {
        CreatePopup(e, true);
    }
    
    public void CreatePopup(int amount, bool heal = false, bool crit = false)
    {
        healthPopup = Instantiate(GameAssets.Instance.damagePopup, Vector3.zero, Quaternion.identity);
        _damageText = healthPopup.GetComponent<TextMeshPro>();
        _damageText.text = amount.ToString();
        if (heal)
        {
            _damageText.color = Color.green;
        }
        else
        {
            if (crit)
            {
                _damageText.color = Color.yellow;
                _damageText.fontSize = 8;
            }
            else
            {
                _damageText.color = Color.red;
            }
        }

    }
}


