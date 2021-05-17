using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscilater : MonoBehaviour
{

    Vector3 startingPosistion;
    [SerializeField] Vector3 moveVector;
    float moveFactor;
    [SerializeField] float period = 2f;
    // Start is called before the first frame update
    void Start()
    {
        startingPosistion = transform.position;
      
    }

    // Update is called once per frame
    void Update()
    {
        if (period <= Mathf.Epsilon) { return; } // so never dividing by 0
        float cycle = Time.time / period; // Increases over time
        const float tau = Mathf.PI * 2; // constant PI * 2
        float sinWave = Mathf.Sin(cycle*tau); // from -1 to 1
        moveFactor = (sinWave + 1f) / 2f; // change to go from from 0 to 1


        Vector3 offset = moveVector * moveFactor;
        transform.position = startingPosistion + offset;
    }
}
