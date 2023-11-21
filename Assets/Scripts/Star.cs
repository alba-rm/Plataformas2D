using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    BoxCollider2D boxCollider;
    SoundManager soundManager;
    public int valor = 1;
    public GameManager gameManager; 

    // Start is called before the first frame update
    void Start()
    {    
        boxCollider = GetComponent<BoxCollider2D>(); 
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
    }
    private void OnTriggerEnter2D(Collider2D collider)
    { 
        if(collider.CompareTag("Player"))
        {
        gameManager.SumarPuntos(valor);
        }
        Debug.Log("Star!!");
        SoundManager.instance.PlayerGetStar();
        Destroy(this.gameObject);
    }
   
}
