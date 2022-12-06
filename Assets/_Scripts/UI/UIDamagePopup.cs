using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIDamagePopup : MonoBehaviour
{
    [SerializeField]private TextMeshPro _damageText;
    private float moveYSpeed = 1.5f;
    private float disappearTimer = 1f;
    
    private void Update()
    {
        _damageText.transform.position += new Vector3(0, moveYSpeed) * Time.deltaTime;
        disappearTimer -= Time.deltaTime;
        
        if (disappearTimer < 0)
        {
            float disappearSpeed = 1.5f;
            Color currentColor = _damageText.color;
            currentColor.a = disappearSpeed * Time.deltaTime;
            _damageText.color = currentColor;
            if (currentColor.a < 0)
            {
                Destroy(_damageText.gameObject);
            }
        }
        
    }
}
