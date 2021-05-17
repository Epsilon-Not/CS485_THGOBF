using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEvents : MonoBehaviour
{
    
    public UnityEngine.Events.UnityEvent event1;
    public Transform obj1;
    public Transform obj2;
   
    // Update is called once per frame
    void Update()
    {
       if (obj2 != null)
        {
            float distance = Vector3.Distance(obj1.position, obj2.position);
            if (distance < 5)
            {
                event1.Invoke();
            }
        }
           
    }
}
