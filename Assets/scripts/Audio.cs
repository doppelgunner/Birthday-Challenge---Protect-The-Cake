using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Audio : MonoBehaviour {

    public const string BGM_GAME = "bgmGame",
                    BGM_START = "bgmStart",
                    SND_LOSE = "sndLose",
                    SND_FIRE_BREATH = "sndFireBreath",
                    SND_COLD_BREATH = "sndColdBreath",
                    SND_CLAP = "sndClap",
                    SND_BUTTON = "sndButton";

    [SerializeField]
    private AudioClip bgmGame;
    [SerializeField]
    private AudioClip bgmStart;
    [SerializeField]
    private AudioClip sndLose;
    [SerializeField]
    private AudioClip sndFireBreath;
    [SerializeField]
    private AudioClip sndColdBreath;
    [SerializeField]
    private AudioClip sndClap;
    [SerializeField]
    private AudioClip sndButton;

    private static Audio _instance;

    private static AudioSource _bgmSource;
    private static AudioSource _snd1Source;
    private static AudioSource _snd2Source;

    private static Dictionary<string, AudioClip> audioBank;

    void Awake() {
        if (_instance == null)
        { 
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (_instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        _bgmSource = gameObject.AddComponent<AudioSource>();
        _bgmSource.loop = true;
        _snd1Source = gameObject.AddComponent<AudioSource>();
        _snd1Source.loop = false;

        _snd2Source = gameObject.AddComponent<AudioSource>();
        _snd2Source.loop = false;

        audioBank = new Dictionary<string, AudioClip>();
        audioBank.Add(BGM_GAME, bgmGame);
        audioBank.Add(BGM_START, bgmStart);
        audioBank.Add(SND_LOSE, sndLose);
        audioBank.Add(SND_FIRE_BREATH, sndFireBreath);
        audioBank.Add(SND_COLD_BREATH, sndColdBreath);
        audioBank.Add(SND_CLAP, sndClap);
        audioBank.Add(SND_BUTTON, sndButton);
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public static void PlayBGM(string bgmName, float volume) {
        _bgmSource.clip = audioBank[bgmName];
        _bgmSource.volume = volume;
        _bgmSource.Play();
    }

    public static void PlayBGM(string bgmName)
    {
        PlayBGM(bgmName, 1f);
    }

    public static void PlaySND1(string sndName, float volume) {
        _snd1Source.clip = audioBank[sndName];
        _snd1Source.volume = volume;
        _snd1Source.Play();
    }

    public static void PlaySND1(string sndName)
    {
        PlaySND1(sndName, 1f);
    }

    public static void PlaySND2(string sndName, float volume)
    {
        _snd2Source.clip = audioBank[sndName];
        _snd2Source.volume = volume;
        _snd2Source.Play();
    }

    public static void PlaySND2(string sndName)
    {
        PlaySND2(sndName, 1f);
    }

    public static void StopBGM() {
        _bgmSource.Stop();
    }
    
    public static void StopSND1() {
        _snd1Source.Stop();
    }

    public static void StopSND2() {
        _snd2Source.Stop();
    }
}
