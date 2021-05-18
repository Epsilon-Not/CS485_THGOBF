using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject explosion;
    public Transform target;
    public float speed;
    public AudioSource audioSource;
    public AudioClip clip1;
    public AudioClip clip2;
    private float distance;

    private IEnumerator coroutine;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        coroutine = Wait(2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(target.position, gameObject.transform.position);
        if (distance < 10)
        {
           
            audioSource.PlayOneShot(clip1);
            transform.LookAt(target);
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        
        
    }

    void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag == "Bullet")
        {
            StartCoroutine(coroutine);
            audioSource.PlayOneShot(clip2);
            Destroy(collision.gameObject);
            Instantiate(explosion, transform.position, transform.rotation);
            
            Destroy(this);
            Destroy(gameObject);
            

        }
    }
    private IEnumerator Wait(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        
    }

}
