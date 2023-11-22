using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;


public class Player : MonoBehaviour
{
    [Header("Player Stats")]
    [Tooltip("Controla la velocidad de movimiento del personaje")]
    //examen
    [SerializeField]private float _playerSpeed = 5;
    [Tooltip("Controla la fuerza de salto del personaje")]
    //examen
    [SerializeField]private float _jumpForce = 5;
    //examen
    private float _playerInputHorizontal;
    //private float _playerInputVertical;
    //examen
    private Rigidbody2D _rBody2D;
    //private GroundSensor _sensor;
    [SerializeField]private Animator _animator;
    [SerializeField]private PlayableDirector _director;
    

    void Start()
    {
        _rBody2D = GetComponent<Rigidbody2D>();
        //_sensor = GetComponentInChildren<GroundSensor>();
        //_animator = GetComponentInChildren<Animator>();
        //Debug.Log(GameManager.instance.vidas);

    }
    //examen
    void Update()
    {
        //examen
        PlayerMovement();
        //examen
        if(Input.GetButtonDown("Jump") && GroundSensor._isGrounded)
        {
            Jump();
        }     

        if(Input.GetButtonDown("Fire2"))
        {
            _director.Play();
        }
        //examen
        _animator.SetBool("IsJumping", !GroundSensor._isGrounded);

    }
    void Jump()
    {
        //examen
        _rBody2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        SoundManager.instance.PlayerJump();
        
    }
    void FixedUpdate()
    {
        //_rBody2D.AddForce(new Vector2(_playerInputHorizontal * _playerSpeed, 0), ForceMode2D.Impulse);
        //examen
        _rBody2D.velocity = new Vector2(_playerInputHorizontal * _playerSpeed, _rBody2D.velocity.y);
    }
    void PlayerMovement()
    {
        /*examen
        _playerInputHorizontal = Input.GetAxis("Horizontal");
        */
        _playerInputHorizontal = Input.GetAxis("Horizontal");
        /*_playerInputVertical = Input.GetAxis("Vertical");
        transform.Translate(new Vector2(_playerInputHorizontal, _playerInputVertical) * _playerSpeed * Time.deltaTime);*/
        //examen
        if(_playerInputHorizontal < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            _animator.SetBool("IsRunning", true);
        }
        else if(_playerInputHorizontal > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            _animator.SetBool("IsRunning", true);
        }
        else 
        {
            _animator.SetBool("IsRunning", false);
        }

    }
    public void SignalTest()
    {
        Debug.Log("Señal recibida");
    }

     void OnTriggerExit2D(Collider2D collider) 
    {
        if (collider.gameObject.layer == 7)
        {
            GameManager.instance.GameOver();
            SoundManager.instance.PlayerDeath();
          
        }
        
    }
}
