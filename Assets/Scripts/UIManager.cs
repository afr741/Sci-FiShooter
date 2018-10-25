using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class UIManager : MonoBehaviour {
    [SerializeField]
    private Text _ammoText;
    [SerializeField]
    private Text _boxText;
    float timer;
    int waitingTime = 5;
    [SerializeField]
    private GameObject _coin;
    [SerializeField]
    private GameObject _gameObjectiveText;


    [SerializeField]
    private GameObject _weaponReloadText;
    [SerializeField]
    private GameObject _youWinText;
    [SerializeField]
    private GameObject _SharkText;

    [SerializeField]
    private GameObject _viewControls;
  
    //updates Ammo
    public void UpdateAmmo(int count)
    {
        if (count == 0)
        {
            ReloadWeaponTextActivate();
        }
        else
        {

            ReloadWeaponTextDeactivate();
        }
        _ammoText.text = "Ammo: " + count; //displays ammo count on screen

    }


    //updates number of boxes left
    public void UpdateBoxes(int boxCount)
    {
        _boxText.text = "Boxes left: " + boxCount;
        if (boxCount == 0)
        {
            GameOver();
        }
    }

    public void CollectedCoin()

    {

        _coin.SetActive(true);
    }
    public void RemoveCoin()
    {
        _coin.SetActive(false);
       
    }

    public void ReloadWeaponTextActivate()
    {
        _weaponReloadText.SetActive(true);
    }

    public void ReloadWeaponTextDeactivate()
    {
        _weaponReloadText.SetActive(false);
    }

    public void GameOver()
    {
        _youWinText.SetActive(true);
    }

    public void SharkTextYesCoin()
    {
        _SharkText.SetActive(false);

    }
    public void SharkTextNoCoin()
    {
        _SharkText.SetActive(true);
       
        
        
    }

    public void VewGameObjective()
    {
        _gameObjectiveText.SetActive(true);
    }

    public void HideGameObjective()
    {
        _gameObjectiveText.SetActive(false);
    }

    public void ViewControls()
    {
        _viewControls.SetActive(true);
    }

    public void HideControls()
    {
        _viewControls.SetActive(false);
    }


}
