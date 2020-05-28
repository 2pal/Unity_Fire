using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rocketship : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rigidbody;
    AudioSource thrust_audio;
    [SerializeField] float rcsTrust = 80f;
    [SerializeField] float mainTrust = 50f;
    enum State {Alive, Dying, Transcending };
    State state = State.Alive;


    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        thrust_audio = GetComponent<AudioSource>();
        
    }

    void Update()
    {
        if (state == State.Alive)
        {
            Thrust();
            Rotate();
        }
        else if(state == State.Dying)
        {
            thrust_audio.Stop();
        }
    }


    void OnCollisionEnter(Collision collision)
    {
        if (state != State.Alive)
        {
            return;
        }
        switch (collision.gameObject.tag)
        {
            case "Friendly":
                break;
            case "Finish":
                state = State.Transcending;
                Invoke("NextScene", 1f);
                break;
            default:
                state = State.Dying;
                Invoke("GoFirstScene", 1f);
                break;
        }
    }

    private void GoFirstScene()
    {
        state = State.Alive;
        SceneManager.LoadScene(0);
    }

    private void NextScene()
    {
        SceneManager.LoadScene(1);
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
