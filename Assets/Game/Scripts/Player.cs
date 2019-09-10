using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

  private CharacterController _controller;
  private float _speed = 3.5f;
  private float _gravity = 9.81f;

  // Start is called before the first frame update
  void Start()
  {
    _controller = GetComponent<CharacterController>();
  }

  // Update is called once per frame
  void Update()
  {
    CalculateMovement();

  }



  void CalculateMovement()
  {
    float horizontalInput = Input.GetAxis("Horizontal");
    float verticalInput = Input.GetAxis("Vertical");

    // Get horizontal axis for left & right movement. (for x axis)
    // Get vertical axis for up and down movement (for z axis)
    Vector3 direction = new Vector3(horizontalInput, 0, verticalInput);

    Vector3 velocity = direction * _speed;
    velocity.y -= _gravity; // subtract gravity from y to make player drop to the ground instead of hovering
    _controller.Move(velocity * _speed * Time.deltaTime);
  }





}
