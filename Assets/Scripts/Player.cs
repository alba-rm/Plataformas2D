using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]private float _playerSpeed = 5;
    private float _playerInputHorizontal;
    private float _playerInputVertical;


    void Start()
    {
        
    }
    void Update()
    {
        PlayerMovement();
        
    }
    void PlayerMovement()
    {
        _playerInputHorizontal = Input.GetAxis("Horizontal");
        _playerInputVertical = Input.GetAxis("Vertical");
        transform.Translate(new Vector2(_playerInputHorizontal, _playerInputVertical) * _playerSpeed * Time.deltaTime);
    }
}
