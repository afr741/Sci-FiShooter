using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private CharacterController _controller;
    [SerializeField]
    private float _speed = 3.5f;
    private float _gravity = 9.81f;
    [SerializeField]
    private GameObject _muzzleFlash;
    [SerializeField]
    private GameObject _hitMarkerPrefab;

    [SerializeField]
    private AudioSource _weaponAudio;
    [SerializeField]
    private int currentAmmo;
    private int maxAmmo = 50;
    private int currentBoxes;
    private int maxNumBoxes = 6;
    private bool _isReloading = false;
    private UIManager _uiManager;
    private bool _isObjectiveViewing = false;
    private bool _controlsViewing = false;

    [SerializeField]
    private AudioClip _gunReloadSound;

    public bool hasCoin = false;
    [SerializeField]
    private GameObject _weapon;

    // Use this for initialization
    void Start() {

        _controller = GetComponent<CharacterController>();
        //hide mouse cursor
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        currentAmmo = maxAmmo;
        currentBoxes = maxNumBoxes;
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentAmmo == 0)
        {
            _uiManager.ReloadWeaponTextActivate();
        }
        else
        {
            _uiManager.ReloadWeaponTextDeactivate();
        }
        //if left click 
        //case ray from center point of main camera

        if (Input.GetMouseButton(0) && currentAmmo > 0)
        {

            Shoot();

        }
        else
        {
            _muzzleFlash.SetActive(false);
            _weaponAudio.Stop();
        }
        if (Input.GetKeyDown(KeyCode.R) && _isReloading == false)
        {
            _isReloading = true;
            StartCoroutine(Reload());
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        CalculateMovement();

        if (Input.GetKeyDown(KeyCode.C) && _controlsViewing == false) { 
        _uiManager.ViewControls();
        _controlsViewing = false;
        StartCoroutine(hideControlsWait());
    }

        if (Input.GetKeyDown(KeyCode.O) && _isObjectiveViewing == false)
        {
            _uiManager.VewGameObjective();
            _isObjectiveViewing = true;
            StartCoroutine(hideObjectiveWait());
        }



       
    }
    
    void Shoot()
    {

        
        _muzzleFlash.SetActive(true);
        currentAmmo--;
        
        _uiManager.UpdateAmmo(currentAmmo);
      
        
        //if audio is not playing
        //play audio
        if (_weaponAudio.isPlaying == false)
        {
            _weaponAudio.Play();
        }

        Ray rayOrigin = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hitInfo;

        if (Physics.Raycast(rayOrigin, out hitInfo))
        {
            Debug.Log("hit: " + hitInfo.transform.name);

            GameObject hitmarker = Instantiate(_hitMarkerPrefab, hitInfo.point, Quaternion.LookRotation(hitInfo.normal)) as GameObject;
            Destroy(hitmarker, 1f);

            //check if we hit the crate
            Destructible crate = hitInfo.transform.GetComponent<Destructible>();
            if (crate != null)
            {
                crate.DestroyCrate();
                currentBoxes--;
                _uiManager.UpdateBoxes(currentBoxes);

            }

            //Destroy Crate
        }
    }
    void CalculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontalInput, 0, verticalInput);
        Vector3 velocity = -direction * _speed;
        velocity.y -= _gravity;
        velocity = transform.transform.TransformDirection(velocity);
        _controller.Move(velocity * Time.deltaTime);
    }
    IEnumerator Reload()
    {
        AudioSource.PlayClipAtPoint(_gunReloadSound, transform.position);
        yield return new WaitForSeconds(1.5f);
        
        currentAmmo = maxAmmo;
        _uiManager.UpdateAmmo(currentAmmo);
        _isReloading = false;
       
    }
    public void EnableWeapons()
    {
        _weapon.SetActive(true);

    }

    IEnumerator hideObjectiveWait()
    {

        yield return new WaitForSeconds(3f);

        _uiManager.HideGameObjective();
        _isObjectiveViewing = false;

    }

    IEnumerator hideControlsWait()
    {

        yield return new WaitForSeconds(4f);

        _uiManager.HideControls();
        _controlsViewing = false;

    }

}
