using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class catActions : MonoBehaviour {

    private void Update()
    {     
    }

    public void Eat()
    {
        GetComponent<Animation>().Play("Eat");
    }

    public void Walk()
    {
        GetComponent<Animation>().Play("Walk");
    }

    public void Jump()
    {
        GetComponent<Animation>().Play("Jump");
    }

    public void Stay()
    {
        GetComponent<Animation>().Play("Idle");
    }

    public void Speak()
    {
        GetComponent<AudioSource>().Play();
        GetComponent<Animation>().Play("sound");
    }
}
