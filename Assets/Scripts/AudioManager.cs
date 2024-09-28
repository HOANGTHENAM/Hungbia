using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AudioManager : MonoBehaviour
{
    private static AudioManager instance = null;
    public static AudioManager Instance
    {
        get
        {
            if (instance == null)
            {
                if (FindObjectOfType<AudioManager>() != null)
                    instance = FindObjectOfType<AudioManager>();
                else
                    new GameObject().AddComponent<AudioManager>().name = "Singleton_" + typeof(AudioManager).ToString();
            }
            return instance;
        }
    }
    [Space(10), Header("Music")]
    [SerializeField] AudioClip backgroundMusic;

    [SerializeField] AudioSource gameMusicSource;
    [Space(10), Header("Sound effects")]

    [SerializeField] List<AudioSource> channelSource = new List<AudioSource>();
    [SerializeField] int channel;
    [SerializeField] AudioClip sfx;
    [SerializeField] List<AudioClip> sfxList;
    [SerializeField] int index;

    private  void Awake()
    {
        //DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        PlayBackgroundMusic(backgroundMusic);
    }
    public enum Type_Sfx
    {
        SFX1
    }
    public void PlayBackgroundMusic(AudioClip clip)
    {
        gameMusicSource.clip = clip;
        gameMusicSource.Play();
        gameMusicSource.loop = true;
    }
    public void PlaySfx(int index)
    {
        channelSource[channel].PlayOneShot(sfxList[index]);
        channel++;
        if (channel == channelSource.Count)
        {
            channel = 0;
        }
    }
    public void PlaySfx(Type_Sfx typeSfx)
    {
        channelSource[channel].PlayOneShot(sfxList[(int) typeSfx]);
        channel++;
        if (channel == channelSource.Count)
        {
            channel = 0;
        }
    }
    //public void ToggleMusic()
    //{
    //    gameMusicSource.mute = !gameMusicSource.mute;
    //}

    //public void ToggleSfx()
    //{
    //    for (int i = 0; i < channelSource.Count; i++)
    //        channelSource[i].mute = !channelSource[i].mute;
    //}

    //public void MusicVolume(float volume)
    //{
    //    gameMusicSource.volume = volume;
    //}
    //public void SfxVolume(float volume)
    //{
    //    for (int i = 0; i < channelSource.Count; i++)
    //        channelSource[i].volume = volume;
    //}

}

