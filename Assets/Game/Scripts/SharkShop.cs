using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkShop : MonoBehaviour
{


  // check for collision
  // check if it's the player
  // check if they pressed the E key
  //    remove coin from player
  //    update the inventory display
  //    play win sound
  // Debug: Get out of here!
  void OnTriggerStay(Collider other)
  {
    if (other.CompareTag("Player"))
    {

      if (Input.GetKeyDown(KeyCode.E))
      {
        Player player = other.GetComponent<Player>();

        if (player != null)
        {

          if (player.hasCoin == true)
          {
            player.hasCoin = false;
            UIManager uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();

            if (uiManager != null)
            {
              uiManager.RemoveCoin();
            }

            AudioSource audio = GetComponent<AudioSource>();

            audio.Play();
            player.EnableWeapons();
            player.isWeaponEnabled = true;
            Debug.Log("Thanks for your business");
          }
          else
          {
            Debug.Log("Get out of here!");
          }
        }
      }

    }

  }
}
