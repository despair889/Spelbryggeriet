using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DroneController : MonoBehaviour
{
    public static int players = 0;
    public int player = 0;
    //values that controlls the drone
    public float acceleration;
    public float rotationRate;

    //values that fakes a nice turning motion
    public float turnRotationAngle;
    public float turnRoationSeekSpeed;

    //Reference variables not directly used
    private float rotationVelocity;
    private float groundAngleVelocity;

    private Rigidbody rBody;

    //public float fireTime = .05f;
    //public GameObject bullet;

    //public int pooledAmount = 20;
    //List<GameObject> bullets;
    //AudioSource myAudio;
    BulletFire lbulletFire;
    BulletFire rbulletFire;
    void Awake()
    {
        rbulletFire = this.gameObject.transform.GetChild(0).GetChild(0).GetChild(0).gameObject.GetComponent<BulletFire>();
        lbulletFire = this.gameObject.transform.GetChild(0).GetChild(0).GetChild(2).gameObject.GetComponent<BulletFire>();
        // bulletFire =   this.transform.root.gameObject.GetComponent<BulletFire>();
        //bulletFire = gameObject.GetComponent<BulletFire>();
        // bulletFire =  (BulletFire)GetComponent("BulletFire");
        //Debug.Log(PlayerController.players.ToString());
        DroneController.players++;
        player = DroneController.players;
 

        rBody = GetComponent<Rigidbody>();

        //myAudio = GetComponent<AudioSource>();
      
    }
    //void Start()
    //{

    //    bullets = new List<GameObject>();
    //    for (int i = 0; i < pooledAmount; i++)
    //    {
    //        GameObject obj = (GameObject)Instantiate(bullet);
    //        obj.SetActive(false);
    //        bullets.Add(obj);
    //    }

    //}

    void FixedUpdate()
    {
       
      //  bulletFire = this.transform.root.gameObject.GetComponent<BulletFire>();
        //    bulletFire = this.gameObject.GetComponent<BulletFire>();
        //  gameObject.GetComponent<BulletFire>().Fire();
        // bulletFire =  (BulletFire)GetComponent(BulletFire);
     //   bulletFire.Fire();
        // DroneSteering("Vertical3", "Horizontal3");
        if (player == 1)
        {
            DroneSteering("Vertical1", "Horizontal1", "rVertical1", "rHorizontal1","aButton1");
            if (Input.GetButtonUp("rBumper1"))
            {
                rbulletFire.Fire();
            }
            if (Input.GetButtonUp("lBumper1"))
            {
                lbulletFire.Fire();
            }
        }
        else if (player == 2)
        {
            DroneSteering("Vertical2", "Horizontal2", "rVertical2", "rHorizontal2", "aButton2");
            if (Input.GetButtonUp("rBumper2"))
            {
                rbulletFire.Fire();
            }
            if (Input.GetButtonUp("lBumper2"))
            {
                lbulletFire.Fire();
            }
        }
        else if (player == 3)
        {
            DroneSteering("Vertical3", "Horizontal3", "rVertical3", "rHorizontal3", "aButton3");
            if (Input.GetButtonUp("rBumper3"))
            {
                rbulletFire.Fire();
            }
            if (Input.GetButtonUp("lBumper3"))
            {
                lbulletFire.Fire();
            }
        }
        else if (player == 4)
        {
            DroneSteering("Vertical4", "Horizontal4", "rVertical4", "rHorizontal4", "aButton4");
            if (Input.GetButtonUp("rBumper4"))
            {
                rbulletFire.Fire();
            }
            if (Input.GetButtonUp("lBumper4"))
            {
                lbulletFire.Fire();
            }
        }
  


    }

    void DroneSteering(string lVerticalAxis, string lHorizontalAxis,string rVertical,string rHorizontal, string aButton)
    {
       
      

        //Check to see if we are touching the ground
        if (Physics.Raycast(transform.position, transform.up * -1, 3f))
        {
            //we are on ground, enable the accelerator and increase drag
            rBody.drag = 2;
            
            //calculate forward force
            Vector3 forwardForce = transform.forward * acceleration * -Input.GetAxis(rVertical);

            //Correct force for the deltatime and drone mass
            forwardForce = forwardForce * Time.deltaTime * rBody.mass;

            rBody.AddForce(forwardForce);

            //jump
            if (Input.GetButton(aButton))
            {
                Vector3 upwardForce = transform.up * acceleration/20;
                rBody.AddForce(upwardForce);
            }
        }
        else
        {
            //We aren't on the ground and we dont want to jusy halt in mid-air, reduce drag
            rBody.drag = 0;
        }

        //Drone can turn in the air or ground
        Vector3 turnTorgue = Vector3.up * rotationRate * Input.GetAxis(lHorizontalAxis);
        //Correct force for deltatime and drone mass
        turnTorgue = turnTorgue * Time.deltaTime * rBody.mass;
        rBody.AddTorque(turnTorgue);

        //"fake" rotate when the drone is turning
        Vector3 newRotation = transform.eulerAngles;
        newRotation.z = Mathf.SmoothDampAngle(newRotation.z, Input.GetAxis(lHorizontalAxis) * -turnRotationAngle, ref rotationVelocity, turnRoationSeekSpeed);
        transform.eulerAngles = newRotation;
    }


}
