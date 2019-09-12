using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
  [SerializeField]
  private AudioClip _coinPickup;



  // as long as player is within the coin's collider this method will be called, allowing us to also check if the player pressed the E key to pick up the coin

  void OnTriggerStay(Collider other)
  {
    if (other.CompareTag("Player"))
    {
      if (Input.GetKeyDown(KeyCode.E))
      {
        Player player = other.GetComponent<Player>();
        if (player != null)
        {
          player.hasCoin = true;

          // if you couldn't hear the sound very well, you can instantiate this sound at the Main Camera's position with Camera.main.transform.position
          AudioSource.PlayClipAtPoint(_coinPickup, transform.position, 1f);
          UIManager uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();

          if (uiManager != null)
          {
            uiManager.CollectedCoin();
          }
          Destroy(this.gameObject);
        }
      }

    }
  }
}
