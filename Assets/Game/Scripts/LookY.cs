using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookY : MonoBehaviour
{
  // WARNING: We can't attach this script to the Player b/c this script changes the Y. The Player uses the Y to move based on where they're looking. If you attached it to the Player it would make the Player move until it falls out of the world or hits something. 

  // Instead, we created an Empty Object (named it LookY) nested in the Player. Then we nested the Main Camera to the LookY oject instead of the Player

  [SerializeField]
  private float _sensitivity = 3f; // how fast the player looks with the mouse

  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {


    float _mouseY = Input.GetAxis("Mouse Y");

    Vector3 newRotation = transform.localEulerAngles;
    // we put -= so the looking up and down isn't inverted (it moved up a little when we looked down)
    newRotation.x -= _mouseY * _sensitivity;
    transform.localEulerAngles = newRotation;

  }
}
