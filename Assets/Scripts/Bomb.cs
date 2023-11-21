using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    Animator anim;
    CircleCollider2D circleCollider;
    Rigidbody2D rBody;
    SoundManager soundManager;
    
    //[Serializefield] private float radio;
    //[Serializefield] private float fuerzaExplosion;
   
    void Start()
    {
        anim = GetComponent<Animator>();
        circleCollider = GetComponent<CircleCollider2D>();
        rBody = GetComponent<Rigidbody2D>();
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
    }
    public void BombExplosion()
    {
        anim.SetBool("IsTouch", true);
        circleCollider.enabled = false;
        //Destroy(this.gameObject, 0.2f);
        //sfxManager.Chest();
        
    }
    
    void OnCollisionEnter2D(Collision2D collision) 
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            //Empezar animacion
            anim.SetBool("IsTouch", true);
            //Comprobacion rango
            
            //Tras un tiempo activar daño
            
            //Destruir objeto
            Destroy(this.gameObject, 0.6f);
            GameManager.instance.PerderVida();
            
            //soundManager.StopBGM();
            //sfxManager.PersonajeDeath();
            //SceneManager.LoadScene(2);

        }
    }
    void OnTriggerStay2D(Collider2D  collider) 
    {
        //CircleCollider2D[] circleCollider = Physics2D.OverLapCircleAll(transform.position, radio);

    }

}
