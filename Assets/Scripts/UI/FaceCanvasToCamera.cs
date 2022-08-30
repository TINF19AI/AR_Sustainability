using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCanvasToCamera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("FaceCanvasToCamera Script Started");
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion lookRotation = Camera.main.transform.rotation;
        transform.rotation = lookRotation;
    }
}
