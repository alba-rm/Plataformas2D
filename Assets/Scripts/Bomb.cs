using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    Animator anim;
    CircleCollider2D circleCollider;
    Rigidbody2D rBody;
    SoundManager soundManager;
    
    [SerializeField] private float radio;
    [SerializeField] private float explosionForce;
   
    void Start()
    {
        anim = GetComponent<Animator>();
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
    }

    void OnCollisionEnter2D(Collision2D collision) 
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            anim.SetBool("IsTouch", true);            
            SoundManager.instance.PlayerTouchBomb();
            
        }
    }
    void Explotando() 
    {
        Collider2D[] playerCollider = Physics2D.OverlapCircleAll(transform.position, radio);
        
        foreach (Collider2D colision in playerCollider)
        {
            Player player = colision.GetComponent<Player>();
            if (player != null)
            {
                GameManager.instance.PerderVida(); 
            }

        }
        
        Collider2D[] circleCollider = Physics2D.OverlapCircleAll(transform.position, radio);
        foreach (Collider2D colision in circleCollider)
        {
            Rigidbody2D rb2D = colision.GetComponent<Rigidbody2D>();
            if(rb2D != null)
            {
                Vector2 direction = colision.transform.position -transform.position;
                float distance = 1 + direction.magnitude;
                float finalForce = explosionForce / distance;
                rb2D.AddForce(direction * finalForce);
                
            }
            
        }
        
    }
    void Explosion() 
    {
        anim.SetBool("IsTouch", false);  
        anim.SetBool("Explosion", true);
    }
    void Destroy() 
    {
        Destroy(this.gameObject); 
        
    }
    
    
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radio);

    }

}
