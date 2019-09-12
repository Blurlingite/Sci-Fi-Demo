using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

  private CharacterController _controller;
  private float _speed = 3.5f;
  private float _gravity = 9.81f;
  [SerializeField]
  private GameObject _muzzleFlash;
  [SerializeField]
  private GameObject _hitMarkerPrefab;


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

    // when you press and hold the left mouse button (0) we want to shoot a ray from the main camera (since that's what the player is using to look around)
    // We define where the ray's starting position is with rayOrigin
    // Camera.main gets the main camera
    // ViewportPointToRay determines where the ray is fired from the camera. It will be from what your camera views (as opposed to something like ScreenPointToRay). It is more reliable as it can now fire from where the player can actually see. On all axes, it uses a scale of 0 to 1. We want it to be the center (where the crosshair is) so we pass in 0.5f for the x, 0.5f for the y and we aren't concerned with the z so we put 0
    if (Input.GetMouseButton(0))
    {

      // turn on bullet firing animation
      _muzzleFlash.SetActive(true);

      Ray rayOrigin = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

      // used to store info about what the ray hits
      RaycastHit hitInfo;

      // Physics.Raycast() is what actually casts the 3D ray so we can check if we hit any colliders. There are many different versions with different parameters but we will use the one that needs 2 params: the ray's origin and the info on what it hits, which we have declared a variable for above (we need to use the "out" keyword as well). The "out" lets us output whatever we hit into the hitInfo variable
      if (Physics.Raycast(rayOrigin, out hitInfo))
      {
        // since hitInfo stores everything about the object it hits, we can get info from all it's components. Here we get the name of the object by accessing it's transform and then the name
        Debug.Log("Hit " + hitInfo.transform.name);

        // Instantiate a hit marker where you shot at The params are: 
        // 1) the hit marker
        // 2) The point at which you shot (which we can get from the hitInfo variable)
        // 3) The direction the effect should face
        // hitInfo.point is where the ray hit the collider in world space 

        // hitInfo.normal is the normal of the surface the ray hit, which is the perpendicular Vector (the normal will change depending on what kind of surface you hit)
        GameObject hitMarker = Instantiate(_hitMarkerPrefab, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
        // destroy hit marker so it doesn't clutter the hierarchy
        Destroy(hitMarker, 1f);
      }
    }
    else
    {
      _muzzleFlash.SetActive(false);

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
