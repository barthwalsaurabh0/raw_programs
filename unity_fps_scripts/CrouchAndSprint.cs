using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrouchAndSprint : MonoBehaviour
{
    public float crouch_Speed = 8f;   
    public float crouch_Height = -1f;
    public float sprint_Speed = 30f;
    public float move_Speed = 15f;

    private Transform look_Root;
    private Movement player_Movement;
    public float stand_Height = 0f;
    private bool is_Crouching;

    private PlayerFootstep player_Footsteps;
    private float sprint_Volume = 0.2f;
    private float crouch_Volume = 0.02f;
    private float walk_Volume_Min = 0.01f, walk_Volume_Max = 0.2f;
    
    private float walk_Step_Distance = 0.4f;
    private float sprint_Step_Distance = 0.25f;
    private float crouch_Step_Distance = 0.5f;


    //[SerializeField]
    //private Weapons weapon_Handaler;

    private WeaponManager weapon_Manager;


    private void Awake() {

        player_Movement = GetComponent<Movement>();
        look_Root = transform.GetChild(0);
        player_Footsteps = GetComponentInChildren<PlayerFootstep>();

        weapon_Manager  = GetComponent<WeaponManager>();    

    }

    private void Start() {
        player_Footsteps.step_Distance = walk_Step_Distance;
        player_Footsteps.volume_Max = walk_Volume_Max;
        player_Footsteps.volume_Min = walk_Volume_Min;
        
    }


    void Update()
    {
        Sprint();
        Crouch();
    }

    void Sprint() {
        if(Input.GetKeyDown(KeyCode.LeftShift) && !is_Crouching ) {
            player_Movement.speed = sprint_Speed;            
            player_Footsteps.step_Distance = sprint_Step_Distance;
            player_Footsteps.volume_Min = sprint_Volume; 
            //print("Enter Shift");

            //Run Animation
            //weapon_Handaler.Sprint(true);

            if(weapon_Manager.GetCurrentSelectedWeapon().blaster == true) {
                return;
            } 
            print(weapon_Manager.GetCurrentSelectedWeapon().blaster);
            weapon_Manager.GetCurrentSelectedWeapon().SprintAnim(true);

        }

        if(Input.GetKeyUp(KeyCode.LeftShift) && !is_Crouching) {
            player_Movement.speed = move_Speed;

            player_Footsteps.step_Distance = walk_Step_Distance;
            player_Footsteps.volume_Min = walk_Volume_Min; 
            player_Footsteps.volume_Max = walk_Volume_Max;
            //print("Exit Shift");
            
            //Stop Runing
            //weapon_Handaler.Sprint(false);

            if(weapon_Manager.GetCurrentSelectedWeapon().blaster == true ){
                return;
            }
            weapon_Manager.GetCurrentSelectedWeapon().SprintAnim(false);
        }
    }

    void Crouch() {
        if(Input.GetKeyDown(KeyCode.C)) {
            if(is_Crouching) {
                print("Standing");
                look_Root.localPosition = new Vector3(0f,stand_Height,0f);
                player_Movement.speed = move_Speed;
                is_Crouching = false;

                player_Footsteps.step_Distance = walk_Step_Distance;
                player_Footsteps.volume_Min = walk_Volume_Min; 
                player_Footsteps.volume_Min = walk_Volume_Max;
            }
            else {
                print("Crouching");
                look_Root.localPosition = new Vector3(0f,crouch_Height,0f);
                player_Movement.speed = crouch_Speed;
                is_Crouching = true;

                player_Footsteps.step_Distance = crouch_Step_Distance;
                player_Footsteps.volume_Min = crouch_Volume; 
                player_Footsteps.volume_Min = crouch_Volume;
            }
        }
    }

    
}
