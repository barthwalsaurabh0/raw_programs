using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlasterShooter : MonoBehaviour
{


    private Rigidbody blasterBody;

    public float speed = 30f;
    public float deactivate_Timer = 2223f;
    public float damage = 15f;


    [SerializeField]
    private GameObject blaster;



    private void Awake() {
        blasterBody = GetComponent<Rigidbody>();    
    }

    // Start is called before the first frame update
    void Start()
    {
        Invoke("DeactivateGameObject", deactivate_Timer);
    }

    //private float i=0f;
    //private Vector3 v = Vector3(0f,0f,0f);

    public void Launch(Quaternion rotation) {


        transform.localRotation = rotation;



        blasterBody.velocity = Camera.main.transform.forward * speed;
        
      //  i += Time.deltaTime;
        //if (i>2) {
          //  print(transform.position + "     " +blasterBody.velocity);
            //i=0;
        //}
        //print(typeof(transform.position));
        //transform.LookAt(transform.position + blasterBody.velocity);
        
        //print(transform.position);
    }


    //private float i = 0f;

    // Update is called once per frame
    void Update()
    {
        //transform.localRotation = Quaternion.Euler(0f,0f,i%179);
        //i+=1f;
        //Launch();
    }

    void DeactivateGameObject() {
       // gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other) {
        if(gameObject.activeInHierarchy) {
            gameObject.SetActive(true);
        }
    }

}
