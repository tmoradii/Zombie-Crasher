using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleController : MonoBehaviour
{
    Rigidbody body;
    public float forwardSpeed = 40f;
    public float HorizontalSpeed = 15f;
    public float RotationSpeed = 8f , RotationOffset = 12f;
    public GameObject bulletPrefab;
    public Transform bulletStartPos;
    public ParticleSystem shootFX , explosionFX;
    public AudioClip explosionSound;
    public AudioClip shootSound;

    Vector3 speed;
    Vector3 bulletPos;
    float default_Y_eularAngles;
    bool isShooted;
    AudioSource audioSource;


    VoiceController voiceController;

    // Start is called before the first frame update
    void Awake()
    {
        speed = new Vector3(HorizontalSpeed, 0, forwardSpeed);
        body = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        default_Y_eularAngles = transform.rotation.eulerAngles.y;
    }

    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        TakeScreenShot();
        CheckInput();
        CheckIfShooted();
        if (isShooted)
        {
            ShootBullet();
        }
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

        transform.rotation = Quaternion.Slerp(transform.rotation, 
            Quaternion.Euler(0f,  default_Y_eularAngles + input * RotationOffset, 0f), Time.deltaTime * RotationSpeed);
    }

    void CheckIfShooted()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            isShooted = true;
        }
    }

    void ShootBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletStartPos.position, Quaternion.identity);
        shootFX.Play();
        PlaySound(shootSound);
        isShooted = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Obstacle")
        {
            other.gameObject.SetActive(false);
            //decrease health
            PlaySound(explosionSound);          
            explosionFX.Play();
        }
    }

    void PlaySound(AudioClip clip)
    {
        audioSource.clip = explosionSound;
        audioSource.Play();
    }

    void TakeScreenShot()
    {
        if (Input.GetKeyDown(KeyCode.SysReq))
        {
            
            ScreenCapture.CaptureScreenshot("s" + Time.time + ".png");
        }
    }
}
