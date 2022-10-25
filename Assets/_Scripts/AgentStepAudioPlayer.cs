using UnityEngine;

public class AgentStepAudioPlayer : AudioPlayer
{
    [SerializeField] protected AudioClip stepClip;

    public void PlayStepSound()
    {
        PlayClipWithVariablePitch(stepClip);
    }
}
