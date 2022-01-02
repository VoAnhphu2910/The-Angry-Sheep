using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class GameController : MonoBehaviour
{
    //public int Enemy;
    public GameObject levelCompleted;

    public GameObject pnlEnd;
    public GameObject pnlWin;

    public bool endGame = false;
    public bool winGame = false;

    public AudioMixer audioSFXMixer;
    public AudioMixer audioMusicMixer;

    AudioSource audioSource;
    public AudioClip audioWin;
    public AudioClip audioEnd;

    public Text totalKill;

    public Text level;

    public static int enemyTotal;
    public static int enemiesAlive = 0; // Số Enemy trên bản đồ
    // Start is called before the first frame update

    private void Start()
    {
        Destroy(level, 5);
        audioSource = gameObject.GetComponent<AudioSource>();
        enemiesAlive = 0;
        enemyTotal = 0;
        PlayerController.speed = 4;
        WaveSpawner.count = 0;
        Time.timeScale = 1;
        winGame = false;
        endGame = false;

    }

    // Hàm chỉnh âm thanh hiệu ứng
    public void SetVolumeSFX(float volume)
    {
        float _volume = volume;
        if(_volume <= -19.5f)
        {
            _volume = -80;
        }
        audioSFXMixer.SetFloat("SFXVolume", _volume);
    }

    // Hàm chỉnh nhạc
    public void SetVolumeMusic(float volume)
    {
        float _volume = volume;
        if (_volume <= -19.5f)
        {
            _volume = -80;
        }
        audioMusicMixer.SetFloat("MusicVolume", _volume);
    }

    public void WinGame()
    {
        totalKill.text += enemyTotal.ToString();

        audioSource.clip = audioWin;
        audioSource.Play();
        audioSource.loop = false;
        pnlWin.SetActive(true);
        Time.timeScale = 0;

    }

    public void EndGame()
    {
        audioSource.clip = audioEnd;
        audioSource.Play();
        audioSource.loop = false;
        endGame = true;
        pnlEnd.SetActive(true);
        Time.timeScale = 0;
    }

}
