using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentSounds : AudioPlayer
{
    [SerializeField] private AudioClip hitClip = null, deathClip = null, voiceLineClip = null;

    public void PlayHitSound()
    {
        
        PlayClipWithVariablePitch(hitClip);
    }
    
    public void PlayDeathSound()
    {
        Debug.Log("play sound dea");
        PlayClip(deathClip);
    }
    
    public void PlayVoiceSound()
    {
        PlayClipWithVariablePitch(voiceLineClip);
    }
}
