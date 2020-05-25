using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocketship : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rigidbody;
    AudioSource thrust_audio;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        thrust_audio = GetComponent<AudioSource>();
        
    }

    void Update()
    {
        ProcessInput();
        
    }

    private void ProcessInput()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rigidbody.AddRelativeForce(Vector3.up);
            if (!thrust_audio.isPlaying)
                thrust_audio.Play();
        }
        else
        {
            thrust_audio.Stop();
        }
        
        
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward);
        }
        else if(Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.forward);
        }
        
    }
}
