using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance {get; private set;}
    AudioSource _sfxSource;
    [SerializeField]private AudioClip playerDeath;
    [SerializeField]private AudioClip playerJump;
    [SerializeField]private AudioClip star;
    [SerializeField]private AudioClip bomb;

    
    // Start is called before the first frame update
    void Awake()
    {
        _sfxSource = GetComponent<AudioSource>();
        if(instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }
    public void PlayerDeath()
    {
        _sfxSource.PlayOneShot(playerDeath);
    }
    public void PlayerJump()
    {
        _sfxSource.PlayOneShot(playerJump);
    }
    public void PlayerGetStar()
    {
        _sfxSource.PlayOneShot(star);
    }
      public void PlayerTouchBomb()
    {
        _sfxSource.PlayOneShot(bomb);
    }

}
