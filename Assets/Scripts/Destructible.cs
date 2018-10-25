using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour {
    [SerializeField]
    private GameObject _crateDestroyed;

    [SerializeField]
    private AudioClip _BoxDestroySound;


   
    public void DestroyCrate()
    {
        Instantiate(_crateDestroyed, transform.position, transform.rotation);
        AudioSource.PlayClipAtPoint(_BoxDestroySound, transform.position);
        Destroy(this.gameObject);
      
       
       
    }
}
