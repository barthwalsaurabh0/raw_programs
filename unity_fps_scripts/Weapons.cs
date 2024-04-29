using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    private Animator anim;
    public GameObject attack_Point;

    public bool assault;
    public bool pistol;
    public bool blaster;


    [HideInInspector]
    public bool isAiming;

    [SerializeField]
    private Animator zoomAnimator;

    [SerializeField]
    private AudioSource shootSound, reloadSound;

    private void Awake() {
       anim = GetComponent<Animator>();
    }

    public void Shoot() {
        anim.SetTrigger("Shoot");
        //anim.Play("Fire");
        //print("Shoot");
    }

    public void GrenadeThrow() {
        print("GrenadeThrow");
        //GrenadeThrow
    }

    public void Play_ShootSound() {
        shootSound.Play();
    }

    public void Play_ReloadSound() {
        reloadSound.Play();
    }

    public void AimAndShoot() {
        print("Aim and Shoot");
    }

    public void SprintAnim(bool canSprint) {
        anim.SetBool("Run",canSprint);
    }

    public void Aim(bool canAim) {
        isAiming = canAim;    
        //zoomAnimator.SetBool("Zoom",canAim);
        anim.SetBool("Aim",canAim);
        //print(isAiming);
    }

    public void Turn_Off_AtTackPoint() {
        if(attack_Point.activeInHierarchy) {
            attack_Point.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
