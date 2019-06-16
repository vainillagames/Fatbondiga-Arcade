using UnityEngine.Audio;
using UnityEngine;


public class Options : MonoBehaviour
{
    public AudioMixer audioMixerT;
    public AudioMixer audioMixerE;
    //public static Options instance;
     void Awake()
    {
       /*if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            Debug.Log("sesta destruin");
            return;
        }
        DontDestroyOnLoad(gameObject);*/
       
    }
    public void SetVolumeT(float volume)
    {
        audioMixerT.SetFloat("volume",volume);
    }
    public void SetVolumeE(float volume)
    {
        audioMixerE.SetFloat("volumeE", volume);
    }

}
