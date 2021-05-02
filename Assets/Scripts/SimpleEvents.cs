using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEvents : MonoBehaviour
{
    public UnityEngine.Events.UnityEvent event1;
    public UnityEngine.Events.UnityEvent event2;
    public Transform obj1;
    public Transform obj2;
    public new AudioSource audio;

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(obj1.position, obj2.position);
        if (distance < 5){
            event1.Invoke();
        }
        
        
    }
}
