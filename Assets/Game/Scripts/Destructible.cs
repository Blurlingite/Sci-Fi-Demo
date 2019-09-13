using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
  [SerializeField]
  private GameObject _crateDestroyed;

  public void DestroyCrate()
  {
    // instantiate the destroyed crate at this crate's postion and use this crate's rotation so the 2 crates don't overlap. You want to take the rotation of the regular crate (transform.rotation)
    Instantiate(_crateDestroyed, transform.position, transform.rotation);

    Destroy(this.gameObject); // destroy the original crate
  }
}
