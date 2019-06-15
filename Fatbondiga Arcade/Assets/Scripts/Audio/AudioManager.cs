using UnityEngine.Audio;

using UnityEngine;
using System;

public class AudioManager : MonoBehaviour {
    public Sound[] sounds;
    public static AudioManager instance;
    // Start is called before the first frame update
    void Awake()
    {
        if(instance==null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        foreach (Sound s in sounds)
        {
            //igualamos cada parametro creado en script Sound a cada parametro del audiosource que añadimos solo nos interesan estos parametros
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;

            s.source.loop = s.loop;

            s.source.outputAudioMixerGroup = s.mixerTHeme;

            


        }
    }
    private void Start()
    {

        Play("lvl1music");
    }

    public void Play(string name)
    {
      Sound s= Array.Find(sounds, Sound => Sound.name == name);
        s.source.Play();
       
    }
}
