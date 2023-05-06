using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public static MusicPlayer instance;

    [SerializeField]
    private AudioSource _source;
    [SerializeField]
    private AudioClip _defaultMusic;
    [SerializeField]
    private AudioClip _battleMusic;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void PlayMusic(MusicType type)
    {
        if (type == MusicType.Default)
        {
            _source.clip = _defaultMusic;
        }

        if (type == MusicType.Battle)
        {
            _source.clip = _battleMusic;
        }

        _source.Play();
    }
}
