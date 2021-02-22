using System;
using UnityEngine;
using UnityEngine.SceneManagement;



public class Oscilator : MonoBehaviour
{
    [SerializeField] Vector3 movementVector = new Vector3(10f, 10f, 10f);
    [SerializeField] float period = 2f;


    [Range(0,1)] [SerializeField] float movementFactor;
    Vector3 startingPos;
    // Start is called before the first frame update
    void Start()
    {
        startingPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float cycles = Time.time / period;
        const float tau = Mathf.PI * 2f;
        float sinWave = Mathf.Sin(tau * cycles);
        movementFactor = sinWave/2f + 0.5f;
        Vector3 movement = movementVector * movementFactor;
        transform.position = startingPos + movement;
    }
}
