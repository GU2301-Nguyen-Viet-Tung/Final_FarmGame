using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayer : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision Enter " + collision);
    }

    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("Collision Exit " + collision);
    }

    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("Collision Stay " + collision);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger Enter " + other);
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Trigger Exit " + other);
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Trigger Stay " + other);
    }

}
