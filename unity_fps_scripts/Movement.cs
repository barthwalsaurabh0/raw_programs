using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    
    private CharacterController character_contoller;
    private Vector3 move_Direction;

    [SerializeField]
    private AudioClip jump_Sound;

    [SerializeField]
    private AudioClip land_Sound;

    public float speed = 10f;
    public float gravity = 20f;
    public float jump_Force = 10f;
    private float vertical_Velocity;


    public PlayerFootstep player_Footsteps;
    private PlayerFootstep player_Footsteps_TEST;


    [SerializeField]
    private GameObject player_Audio;

    private AudioSource audio_Source;

    private float flightTime;
    public float flightThreshold;

    private void Awake() {
        character_contoller = GetComponent<CharacterController>();
        audio_Source = player_Audio.GetComponent<AudioSource>();
        //audio_Source = transform.Find("Root").transform.Find("Finish").GetComponent<AudioSource>();
        player_Footsteps_TEST = player_Audio.GetComponent<PlayerFootstep>();
    }

    private void Update() {
        MoveThePlayer();
    }

    private void MoveThePlayer() {
        
        move_Direction = new Vector3(Input.GetAxis(Axis.HORIZONTAL),0f,Input.GetAxis(Axis.VERTICAL));
        //print("local  => "+move_Direction);
        move_Direction = transform.TransformDirection(move_Direction);
        //print("global => "+move_Direction);
        move_Direction *= speed * Time.deltaTime;
        ApplyGravity();
        character_contoller.Move(move_Direction); 

    }

    private void ApplyGravity() {
        vertical_Velocity -= gravity * Time.deltaTime ;
        PlayerJump();
         if (vertical_Velocity <= -100f) {
            vertical_Velocity = -100f;
        }
        move_Direction.y = vertical_Velocity * Time.deltaTime;

    }


    void PlayerJump() {
        
        if (character_contoller.isGrounded && Input.GetKeyDown(KeyCode.Space)) {
            vertical_Velocity = jump_Force;
            audio_Source.clip = jump_Sound;
            audio_Source.volume = 0.2f;
            audio_Source.Play();
            //print("Jump");

            flightTime=0;
        }

        flightTime += Time.deltaTime;

        if ( character_contoller.isGrounded ) {
            
            if( flightTime>flightThreshold ) {
                //print("Landed");
                audio_Source.clip = jump_Sound;
                audio_Source.Play();



            }
            flightTime=0;
        }
        else {
            player_Footsteps_TEST.accumulated_Distance = 0f;  
            //player_Footsteps.accumulated_Distance = 0f;
        }
    }

}
