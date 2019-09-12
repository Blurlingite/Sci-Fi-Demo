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
    // make mouse cursor invisible
    Cursor.visible = false;
    // lock the cursor to the center of the screen so the player doesn't have to align their mouse to the crosshair to aim
    // This will make it hard to quit out of the Unity editor if the mouse cursor can't move from the center so we have to undo this when the player presses a key in the Update()
    Cursor.lockState = CursorLockMode.Locked;
  }

  // Update is called once per frame
  void Update()
  {

    // when player presses the ESCAPE key, make the mouse cursor visible again and unlock it from the center
    if (Input.GetKeyDown(KeyCode.Escape))
    {
      Cursor.visible = true;
      Cursor.lockState = CursorLockMode.None;
    }
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

    // TransformDirection() converts local space to world(global) space. This will make the main camera we nested in the Player face the right way (the right way being the position of the Player in world space(in relation to all the other objects rather than just itself))
    // We just need to pass in the direction (velocity)
    velocity = transform.transform.TransformDirection(velocity);
    _controller.Move(velocity * _speed * Time.deltaTime);
  }





}
