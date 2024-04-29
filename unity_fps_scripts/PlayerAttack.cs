using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    // Start is called before the first frame update

    private WeaponManager weapon_Manager;

    public float fireRate = 15f;
    private float nextTimeToFire;
    public float damage = 20f;



    public AudioClip shoot;
    private AudioSource audio_Source;
    public GameObject player_Audio;


    [SerializeField]
    private GameObject blaster;

    [SerializeField]
    private Transform throwWeaponStartPosition;

    private Transform rotationX;

    private void Awake() {
        weapon_Manager = GetComponent<WeaponManager>();
        audio_Source = player_Audio.GetComponents<AudioSource>()[1];

        rotationX = transform.Find("Look Root");
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        WeaponAim();
        WeaponShoot();
    }

    void WeaponAim() {
        
        if (weapon_Manager.GetCurrentSelectedWeapon().blaster == true) {
            return;
        }

        if (Input.GetMouseButtonDown(1)) {
            //print("blast debug");
            weapon_Manager.GetCurrentSelectedWeapon().Aim(true);
        }

        if (Input.GetMouseButtonUp(1)) {
            weapon_Manager.GetCurrentSelectedWeapon().Aim(false);
        }
    
    }

    void WeaponShoot() {

        // assault rifle
        if(weapon_Manager.GetCurrentSelectedWeapon().assault == true) {
            if (Input.GetMouseButton(0) && Time.time > nextTimeToFire ) {
                nextTimeToFire = Time.time + 1f / fireRate;

                // Aiming & Shooting
                //if (weapon_Manager.GetCurrentSelectedWeapon().isAiming) {
                //    weapon_Manager.GetCurrentSelectedWeapon().AimAndShoot();
                //}
                //
                //else {
                //    print("assault Shoot");
                //    weapon_Manager.GetCurrentSelectedWeapon().Shoot();
                //}
                audio_Source.clip = shoot;
                audio_Source.volume = 0.04f;
                audio_Source.Play();
                weapon_Manager.GetCurrentSelectedWeapon().Shoot();
            }
        }

        else {
            if (Input.GetMouseButtonDown(0)) {
                print(weapon_Manager.GetCurrentSelectedWeapon().pistol);
                if (weapon_Manager.GetCurrentSelectedWeapon().pistol == true) {
                    //if (weapon_Manager.GetCurrentSelectedWeapon().isAiming) {
                    //    weapon_Manager.GetCurrentSelectedWeapon().AimAndShoot();
                    //}
                    //else {
                    //    weapon_Manager.GetCurrentSelectedWeapon().Shoot();
                    //}
                    print("pistol");
                    audio_Source.clip = shoot;
                    audio_Source.volume = 0.4f;
                    audio_Source.Play();
                    weapon_Manager.GetCurrentSelectedWeapon().Shoot();
                }

                if (weapon_Manager.GetCurrentSelectedWeapon().blaster == true) {
                    print("blast");
                    ThrowWeapon(blaster);
                    
                }
            }
        }
    }

    void ThrowWeapon(GameObject weaponPrefab) {
        GameObject weaponInstance = Instantiate(weaponPrefab);
        weaponInstance.transform.position = throwWeaponStartPosition.position;
        //print(transform.localRotation.y*128+"    "+rotationX.localRotation.x*128);
        weaponInstance.GetComponent<BlasterShooter>().Launch(Quaternion.Euler(rotationX.localRotation.x*128+90,transform.localRotation.y*128,0f));
    }

}
