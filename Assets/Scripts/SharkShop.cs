using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkShop : MonoBehaviour
{
    private UIManager _uiManager;
    private bool _isSharkTextOut = false;

    IEnumerator hideSharkTextWait()
    {

        yield return new WaitForSeconds(3f);

        _uiManager.SharkTextYesCoin();
        _isSharkTextOut = false;

    }

    //check for collision
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")   // check if the player

        {
            _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
            if (Input.GetKeyDown(KeyCode.E)) // check for E key is pressed

            {
                Player player = other.GetComponent<Player>();
                if (player != null)
                {
                    if (player.hasCoin == true)  //check if player has coin
                    {
                        _uiManager.SharkTextYesCoin();

                        player.hasCoin = false;  //remove coin from player  
                        UIManager uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
                        if (uiManager != null)
                        {

                            uiManager.RemoveCoin();  //update the inventory display
                            _uiManager.SharkTextYesCoin();
                        }

                        AudioSource audio = GetComponent<AudioSource>();
                        audio.Play();
                        player.EnableWeapons();
                        _uiManager.SharkTextYesCoin();

                        //play win sound
                    }
                    else
                    {

                        _uiManager.SharkTextNoCoin();

                        _isSharkTextOut = true;
                        StartCoroutine(hideSharkTextWait());



                        Debug.Log("Get out of here!"); //Play Get out of here! if no COIN
                    }
                    
                }
            }
        }
        
    }

}


