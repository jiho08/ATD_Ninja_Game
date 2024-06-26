using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    
    [Header("#BGM")]
    [SerializeField] private AudioClip[] bgmClip;
    [SerializeField] private float _bgmVolume;
    private AudioSource _bgmPlayer;
    
    [Header("#SFX")]
    [SerializeField] private AudioClip[] sfxClip;

    [SerializeField] private float _sfxVolume;
    private AudioSource[] _sfxPlayers;

    [SerializeField] int channels;
    private int _channelIndex;
    
    public enum Sfx { Hit, Btn, Warning, Tower, Level, Victory, Defeat }

    public float BgmVolume
    {
        get => _bgmVolume;
        set
        {
            _bgmVolume = value;
            _bgmPlayer.volume = _bgmVolume;
        }
    }
    
    public float SfxVolume
    {
        get => _sfxVolume;
        set
        {
            _sfxVolume = value;
            foreach (AudioSource item in _sfxPlayers)
            {
                item.volume = _sfxVolume;
            }
        }
    }
    
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        
        Init();
    }

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Init()
    {
        //배경음 플레이어 초기화
        GameObject bgmObj = new GameObject("BgmPlayer");
        bgmObj.transform.parent = transform;

        _bgmPlayer = bgmObj.AddComponent<AudioSource>();
        _bgmPlayer.playOnAwake = false;
        _bgmPlayer.loop = true;
        _bgmPlayer.volume = _bgmVolume;
        _bgmPlayer.clip = bgmClip[0];
        
        //효과음 플레이어 초기화
        GameObject sfxObj = new GameObject("SfxPlayer");
        sfxObj.transform.parent = transform;
        _sfxPlayers = new AudioSource[channels];

        for (int i = 0; i < _sfxPlayers.Length; i++)
        {
            _sfxPlayers[i] = sfxObj.AddComponent<AudioSource>();
            _sfxPlayers[i].playOnAwake = false;
            _sfxPlayers[i].volume = _sfxVolume;
        }
    }

    public void PlayBgm(bool isPlay, int value)
    {
        _bgmPlayer.clip = bgmClip[value];

        if (isPlay)
        {
            _bgmPlayer.Play();
            
        }
        else
        {
            _bgmPlayer.Stop();
        }
    }
    
    //효과음 재생(AudioManager.Instance.PlaySfx(AudioManager.Sfx.실행할 효과음); 형태로 사용)
    public void PlaySfx(Sfx sfx)
    {
        for (int i = 0; i < _sfxPlayers.Length; i++)
        {
            int loopIndex = (i + _channelIndex) % _sfxPlayers.Length;

            if (_sfxPlayers[loopIndex].isPlaying)
            {
                continue;
            }
            
            //여러가지 소리의 효과음을 넣는다면
            /*int ranIndex = 0;
            if (sfx == Sfx.Dead || sfx == Sfx.Hit)
            {
                ranIndex = Random.Range(0, 2);
            }
            */
            
            _channelIndex = loopIndex;
            //_sfxPlayers[loopIndex].clip = sfxClip[(int)sfx + ranIndex];
            _sfxPlayers[loopIndex].clip = sfxClip[(int)sfx];
            _sfxPlayers[loopIndex].Play();
            break;
        }
    }
}
