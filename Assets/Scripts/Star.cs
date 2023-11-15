using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    BoxCollider2D boxCollider;
    SoundManager soundManager;

    // Start is called before the first frame update
    void Start()
    {    
        boxCollider = GetComponent<BoxCollider2D>(); 
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
    }
    public void Get()
    { 
        boxCollider.enabled = false;
        Destroy(this.gameObject, 0.1f);
        //sfxManager.GetCoin();
    }
}
