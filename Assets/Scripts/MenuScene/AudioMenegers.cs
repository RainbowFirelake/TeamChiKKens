using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class AudioMenegers : MonoBehaviour
{
    public AudioMixer audioMixer; // Переменная микшера для управления

    public void SetMasterVolume(float volume) // Функция для управления мастер-громкостью
    {
        audioMixer.SetFloat("MasterVolume", volume);
        // MasterVolume - параметры Мастера, которые мы выставили
    }

}
