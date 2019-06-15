using UnityEngine.Audio;
using UnityEngine;


public class Options : MonoBehaviour
{
    public AudioMixer audioMixerT;
    public AudioMixer audioMixerE;
    public void SetVolumeT(float volume)
    {
        audioMixerT.SetFloat("volume",volume);
    }
    public void SetVolumeE(float volume)
    {
        audioMixerE.SetFloat("volumeE", volume);
    }

}
