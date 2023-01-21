using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIDamagePopup : MonoBehaviour
{
    private const float DISAPPEAR_TIMER_MAX = 1.5F;
    
    [SerializeField]private TextMeshPro _damageText;
    private float moveYSpeed = 1.5f;
    private float disappearTimer;
    private float disappearSpeed = DISAPPEAR_TIMER_MAX;
    private float scaleAmount = 1f;
    private Color textColor;
    

    private void Update()
    {
        _damageText.transform.position += new Vector3(0, moveYSpeed) * Time.deltaTime;
        
        if (disappearTimer > DISAPPEAR_TIMER_MAX * (DISAPPEAR_TIMER_MAX / 2))
        {
            transform.localScale += Vector3.one * scaleAmount * Time.deltaTime;
        }
        else
        {
            transform.localScale -= Vector3.one * scaleAmount * Time.deltaTime;
        }
        
        disappearTimer -= Time.deltaTime;
        if (disappearTimer < 0.0f)
        {
            textColor = _damageText.color;
            textColor.a -= disappearSpeed * Time.deltaTime;
            _damageText.color = textColor;
            if (disappearSpeed < 0)
            {
                Destroy(gameObject);
            }
        }
        
    }
}
