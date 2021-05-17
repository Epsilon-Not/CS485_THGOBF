using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] [Range(0, 10)] float speed = 4.75f;
    public Transform feet;
    public LayerMask ground;
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    private float jumpHeight;
    private Vector3 direction;
    private Rigidbody rBody;
    private float rotationSpeed;
    private float rotationX;
    private float rotationY;
    private new AudioSource audio;
   
    // Start is called before the first frame update
    void Start()
    {
      
        rotationSpeed = 2f;
        rotationX = 0;
        rotationY = 10f;
        jumpHeight = 5.0f;
        rBody = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
        audio.Play();
        Cursor.lockState = CursorLockMode.Confined;
    }

    // Update is called once per frame
    void Update()
    {
        direction = Vector3.zero;
        direction.x = Input.GetAxis("Horizontal");
        direction.z = Input.GetAxis("Vertical");
        direction = direction.normalized;
        if (direction.x != 0)
        {
            rBody.MovePosition(rBody.position + transform.right * direction.x * speed * Time.deltaTime);
        }
        if (direction.z != 0)
        {
            rBody.MovePosition(rBody.position + transform.forward * direction.z * speed * Time.deltaTime);
        }
        rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * rotationSpeed;
        rotationY += Input.GetAxis("Mouse Y") * rotationSpeed;
        transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
        bool isGrounded = Physics.CheckSphere(feet.position, 0.1f, ground);
        if (Input.GetButtonDown("Jump") && isGrounded)
        {           
            rBody.AddForce(Vector3.up * jumpHeight, ForceMode.VelocityChange);
        }

        if (Input.GetButtonDown("Fire1"))
        {
            Fire();
        }

        void Fire()
        {
            var bullet = (GameObject)Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
            bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 100;
            Destroy(bullet, 2.0f);
        }
    }


}
