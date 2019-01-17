using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;
using HoloToolkit.Unity;
using System;

public class LaserPointer : MonoBehaviour, IInputHandler
{
    LineRenderer line;
    public GameObject cat;
    public GameObject catChild;

    Ray ray;


    private void Start()
    {
        line = gameObject.GetComponent<LineRenderer>();
        line.enabled = false;
        InputManager.Instance.PushFallbackInputHandler(this.gameObject);

        catChild.GetComponent<Animation>().Play("Idle");
    }

    private void Update()
    {

        if (line.enabled == true)
        {
            cat.transform.LookAt(ray.GetPoint(5));
            cat.transform.position += cat.transform.forward * 0.075f;

            if (!catChild.GetComponent<Animation>().Play("Walk")) catChild.GetComponent<Animation>().Play("Walk");

        }
    }

    void IInputHandler.OnInputUp(InputEventData eventData)
    {
        Debug.Log("Laser Pointer Released");
        line.enabled = false;
        catChild.GetComponent<Animation>().Play("Idle");
    }

    void IInputHandler.OnInputDown(InputEventData eventData)
    {
        Debug.Log("Laser Pointer fired!");
        line.enabled = true;

        ray = new Ray(transform.position, transform.forward);
        line.SetPosition(0, ray.origin - new Vector3(0, 0.1f, 0));
        line.SetPosition(1, ray.GetPoint(5));

    }

}
