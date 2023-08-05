using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindmillBehavior : MonoBehaviour
{
    [SerializeField] private GameObject blade;
    private void Update()
    {
        blade.transform.Rotate(0, 1, 0, Space.Self);
    }
}
