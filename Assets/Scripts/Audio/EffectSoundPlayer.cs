using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "new EffectSoundPlayer", menuName = "GBJam/New EffectSoundPlayer", order = 1)]
public class EffectSoundPlayer : ScriptableObject
{
    [SerializeField]
    private List<AudioClip> _clips;

    public AudioClip GetRandomSound()
    {
        if (_clips.Count == 0) return null;
        var choose = Random.Range(0, _clips.Count);
        return _clips[choose];
    }
}