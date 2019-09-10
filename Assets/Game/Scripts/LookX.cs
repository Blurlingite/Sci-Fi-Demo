using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookX : MonoBehaviour
{
  [SerializeField]
  private float _sensitivity = 3f; // how fast the player looks with the mouse
  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    // get the mouse's x value
    float _mouseX = Input.GetAxis("Mouse X");



    // To make the player look left & right by using the mouse, we need to add the _mouseX to the player's Y rotation. We need to access it's local euler angles b/c those hold the values that describe the rotation
    // We cannot just specify the y euler angles, we have to include the x and z euler angles. We can just use a temporary Vector3 variable(newRotation) that gets the current euler angles (which have the x & z euler angles included)
    // We only need to add _mouseX to the Y euler angles
    // Then we assign this object's localEulerAngles to be the newRotation
    Vector3 newRotation = transform.localEulerAngles;
    newRotation.y += _mouseX * _sensitivity;
    transform.localEulerAngles = newRotation;



  }
}
