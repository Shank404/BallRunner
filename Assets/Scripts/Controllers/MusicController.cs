using System;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    private AudioSource _audio;

    public static MusicController MusicInstance = null;
    
    [SerializeField] private AudioClip powerUpClip;
    [SerializeField] private AudioClip coinClip;
    [SerializeField] private AudioClip switchClip;
    [SerializeField] private AudioClip shootClip;
    [SerializeField] private AudioClip bombExplosionClip;
    [SerializeField] private AudioClip sawClip;
    [SerializeField] private AudioClip teleportClip;
    [SerializeField] private AudioClip landingClip;
    [SerializeField] private AudioClip damageClip;
    private float _volume = 1f;

    private void Awake()
    {
        if (MusicInstance == null)
        {
            MusicInstance = this;
        }
    }

    void Start()
    {
        _audio = GetComponent<AudioSource>();
        _audio.volume = _volume;
    }
    
    public void PlayClip(String clip, Vector3 position)
    {
        switch (clip)
        {
            case "PowerUp":
                AudioSource.PlayClipAtPoint(powerUpClip, position, _volume);
                break;
            case "Coin":
                AudioSource.PlayClipAtPoint(coinClip, position, _volume);
                break;
            case "Switch":
                AudioSource.PlayClipAtPoint(switchClip, position, _volume);
                break;
            case "Shoot":
                AudioSource.PlayClipAtPoint(shootClip, position, _volume);
                break;
            case "BombExplosion":
                AudioSource.PlayClipAtPoint(bombExplosionClip, position, _volume);
                break;
            case "Saw":
                AudioSource.PlayClipAtPoint(sawClip, position, _volume);
                break;
            case "Teleport":
                AudioSource.PlayClipAtPoint(teleportClip, position, _volume);
                break;
            case "Landing":
                AudioSource.PlayClipAtPoint(landingClip, position, _volume);
                break;
            case "Damage":
                AudioSource.PlayClipAtPoint(damageClip, position, _volume);
                break;
        }
    }

    public void SetAudioVolume(float value)
    {
        _audio.volume = value;
        _volume = value;
    }

    public float GetAudioVolume()
    {
        return _audio.volume;
    }

    public void SetAudioMute(bool value, float slider)
    {
        if (value)
        {
            _audio.volume = 0f;
            _volume = 0f;
        }
        else
        {
            _audio.volume = slider;
            _volume = slider;
        }
        
    }
}
