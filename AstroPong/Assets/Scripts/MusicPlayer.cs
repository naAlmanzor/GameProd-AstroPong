using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    [Header("Background Music")]
    [SerializeField] AudioSource _bgmSource;

    [Header("Music Selection")]
    [SerializeField] AudioClip _bgm;

    public static MusicPlayer _instance;

    void Awake()
    {
        // Keeps audio playing when changing scenes
        if(_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }

        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        _bgmSource.GetComponent<AudioSource>();
        _bgmSource.clip = _bgm;
        _bgmSource.Play();
    }
}
