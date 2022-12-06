using System;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class UIHealthBar : MonoBehaviour
{
    [SerializeField] Slider _slider;
    [SerializeField] AgentHealthSystem _healthSystem;
    [SerializeField] private TextMeshProUGUI _healthLabel;
    
    // Start is called before the first frame update
    void Awake()
    {
        _slider = GetComponent<Slider>();
        if (_healthSystem != null)
        {
            _healthSystem.OnDamaged += HealthSystem_OnDamaged;
            _healthSystem.OnHealed += HealthSystem_OnHealed;
        }
        _healthSystem.OnHealthMaxChange += HealthSystem_OnHealthMaxChange;
        _healthSystem.OnHealthInitialized += HealthSystem_OnHealthInitialized;
        SetSliderValue();
    }

    private void HealthSystem_OnHealthInitialized(object sender, EventArgs eventArgs)
    {
        SetSliderValue();
    }

    private void HealthSystem_OnHealthMaxChange(object sender, EventArgs eventArgs)
    {
        throw new NotImplementedException();
    }
    
    private void HealthSystem_OnDamaged(object sender, int i)
    {
        SetSliderValue();
    }
    
    private void HealthSystem_OnHealed(object sender, int i)
    {
        SetSliderValue();
    }

    private void SetSliderValue()
    {
        _slider.value = _healthSystem.GetHealthAmountNormalized();
        SetLabel();
    }
    
    private void SetBarVisibility(bool show)
    {
        gameObject.SetActive(show);
    }

    private void SetLabel()
    {
        _healthLabel.text = _healthSystem.GetHealthAmount() + " / " + _healthSystem.GetHealthAmountMax();
    }
    
    public void SetHealthSystem(AgentHealthSystem healthSystem)
    {
        _healthSystem = healthSystem;

        if (_healthSystem == null)
        {
            SetBarVisibility(false);
        }
        else
        {
            _healthSystem.OnDamaged += HealthSystem_OnDamaged;
            _healthSystem.OnHealed += HealthSystem_OnHealed;
            SetBarVisibility(true);
            SetSliderValue();
        }
            
    }
}

