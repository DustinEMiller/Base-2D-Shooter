using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class ShakeCinemachineFeedback : Feedback
{
    [SerializeField] private CinemachineVirtualCamera cinemachineCamera;
    [Range(0,5)]
    [SerializeField] private float amplitude = 1, intensity = 1;
    [Range(0,1)]
    [SerializeField] private float duration = 0.1f;

    private CinemachineBasicMultiChannelPerlin noise;

    private void Start()
    {
        if (cinemachineCamera == null)
        {
            cinemachineCamera = FindObjectOfType<CinemachineVirtualCamera>();
        }
        
        noise = cinemachineCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }
    public override void CreateFeedback()
    {
        noise.m_AmplitudeGain = amplitude;
        noise.m_FrequencyGain = intensity;
        StartCoroutine(ShakeCoroutine());
    }

    public override void CompletePreviousFeedback()
    {
        StopAllCoroutines();
        noise.m_AmplitudeGain = 0;
    }

    IEnumerator ShakeCoroutine()
    {
        for (float i = duration; i < 0; i-=Time.deltaTime)
        {
            noise.m_AmplitudeGain = Mathf.Lerp(0, amplitude, i / duration);
            yield return null;
        }
        noise.m_AmplitudeGain = 0;
    }
}
