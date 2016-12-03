using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public static int players = 1;
    public int player = 0;
    public float speed = 18;

    private Rigidbody rigidBody;      

    private Material material;

    void Start()
    {

        rigidBody = GetComponent<Rigidbody>();
        //material = GetComponent<Material>();
        material = GetComponent<Renderer>().material;

        player = PlayerController.players;
        PlayerController.players++;

        if (player == 1)
            material.color = Color.red;
        else if (player == 2)
            material.color = Color.green;
        else if (player == 3)
            material.color = Color.yellow;
        else if (player == 4)
            material.color = Color.blue;
        else if (player == 5)
            material.color = Color.black;


    }


    void Update()
    {

        float hAxis = 0;
        float vAxis = 0;
        if (player == 1)
        {
            hAxis = Input.GetAxis("Horizontal1");
            vAxis = Input.GetAxis("Vertical1");
        }
        else if (player == 2)
        {
            hAxis = Input.GetAxis("Horizontal2");
            vAxis = Input.GetAxis("Vertical2");
        }
        else if (player == 3)
        {
            hAxis = Input.GetAxis("Horizontal3");
            vAxis = Input.GetAxis("Vertical3");
        }
        else if (player == 4)
        {
            hAxis = Input.GetAxis("Horizontal4");
            vAxis = Input.GetAxis("Vertical4");
        }
        else if (player == 5)
        {
            hAxis = Input.GetAxis("Horizontal5");
            vAxis = Input.GetAxis("Vertical5");
        }

        Vector3 movment = new Vector3(hAxis, 0, -vAxis) * speed * Time.deltaTime;

        rigidBody.MovePosition(transform.position + movment);
    }
}
