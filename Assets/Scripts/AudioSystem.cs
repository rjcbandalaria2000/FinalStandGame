using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public enum AudioEnum
{
    SFX_EnemyDeath,
    SFX_Gunshot,
    SFX_PlayerDeath

}

public enum MusicEnum
{
    Music_Battleground
}

public class AudioSystem : MonoBehaviour
{

    public static AudioSystem instance;
    public AudioSource SoundSource;
    public AudioSource MusicSource;

    public List<AudioClip> AudioClips = new List<AudioClip>();
    public List<AudioClip> Music = new List<AudioClip>();

    MusicEnum? lastMusicPlayed;
    

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        
        foreach (string s in System.Enum.GetNames(typeof(AudioEnum)))
        {
            AudioClips.Add(Resources.Load<AudioClip>("SoundEffects/" + s));
        }

        foreach(string m in System.Enum.GetNames(typeof(MusicEnum)))
        {
            Music.Add(Resources.Load<AudioClip>("MusicTracks/" + m));
        }
            
    }

    public void PlaySound(AudioEnum nameOfSound)
    {
        SoundSource.PlayOneShot(AudioClips[(int)nameOfSound]);
    }

    public void PlayMusic(MusicEnum nameOfMusic)
    {

        if(lastMusicPlayed != null)
        {
            if(lastMusicPlayed == nameOfMusic)
            return;
        }
        if (lastMusicPlayed == null)
        {
            lastMusicPlayed = nameOfMusic;
        }

        MusicSource.clip = Music[(int)nameOfMusic];
        MusicSource.Play();

    }

    public void StopMusic()
    {
        lastMusicPlayed = null;
        MusicSource.Stop();
    }
}
