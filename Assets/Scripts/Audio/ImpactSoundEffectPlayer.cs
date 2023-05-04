using UnityEngine;

public class ImpactSoundEffectPlayer : MonoBehaviour
{
    public static ImpactSoundEffectPlayer instance = null;

    [SerializeField]
    AudioSource _audioSource;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void PlayClipOnce(AudioClip clip)
    {
        if (_audioSource.isPlaying)
        {
            _audioSource.Stop();
        }


        _audioSource.PlayOneShot(clip);
    }
}