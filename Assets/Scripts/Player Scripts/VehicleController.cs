using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleController : MonoBehaviour
{
    Rigidbody body;
    public float forwardSpeed = 40f;
    public float HorizontalSpeed = 15f;
    public float RotationSpeed = 8f , RotationOffset = 12f;

    Vector3 speed;
    float default_Y_eularAngles;

    // Start is called before the first frame update
    void Awake()
    {
        speed = new Vector3(HorizontalSpeed, 0, forwardSpeed);
        body = GetComponent<Rigidbody>();
        default_Y_eularAngles = transform.rotation.eulerAngles.y;
    }

    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        CheckInput();

    }

    private void FixedUpdate()
    {


    }

    void CheckInput()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 userInput = new Vector3(horizontalInput, 0, 1);
        Vector3 nextPos = userInput;
        nextPos.Scale(speed);

        body.MovePosition(transform.position + nextPos * Time.deltaTime);
        TurnThePlayer(horizontalInput);

    }

    void TurnThePlayer(float input)
    {
        print("rt : " + transform.rotation.y);
        transform.rotation = Quaternion.Slerp(transform.rotation, 
            Quaternion.Euler(0f,  default_Y_eularAngles + input * RotationOffset, 0f), Time.deltaTime * RotationSpeed);
    }

}
