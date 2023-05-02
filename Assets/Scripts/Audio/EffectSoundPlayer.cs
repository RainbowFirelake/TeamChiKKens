using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "new EffectSoundPlayer", menuName = "GBJam/New EffectSoundPlayer", order = 1)]
public class EffectSoundPlayer : ScriptableObject
{
    [SerializeField]
    private List<AudioClip> _clips;

    public void PlayRandomSound(AudioSource source)
    {
        if (_clips.Count == 0) return;
        var choose = Random.Range(0, _clips.Count);
        source.PlayOneShot(_clips[choose]);
    }
}