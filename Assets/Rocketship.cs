using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocketship : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rigidbody;
    AudioSource thrust_audio;
    [SerializeField] float rcsTrust = 80f;
    [SerializeField] float mainTrust = 50f;


    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        thrust_audio = GetComponent<AudioSource>();
        
    }

    void Update()
    {
        Thrust();
        Rotate();
    }


    void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Friendly":
                break;
            default :
                print("DEATH!");
                break;
        }
    }

    private void Rotate()
    {
        rigidbody.freezeRotation = true;
        float RotationForFrame = rcsTrust * Time.deltaTime;
        if (Input.GetKey(KeyCode.A))
        {
           
            transform.Rotate(Vector3.forward* RotationForFrame);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.forward * RotationForFrame);
        }

        rigidbody.freezeRotation = false;

    }

    private void Thrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            float thrustForFrame = mainTrust * Time.deltaTime;
            rigidbody.AddRelativeForce(Vector3.up * thrustForFrame);
            if (!thrust_audio.isPlaying)
                thrust_audio.Play();
        }
        else
        {
            thrust_audio.Stop();
        }
    }
}
