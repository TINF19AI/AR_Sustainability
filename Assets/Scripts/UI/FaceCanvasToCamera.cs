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

        //if (Input.GetMouseButtonDown(0))
        //{
        //    Debug.Log("Button down");
        //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //    RaycastHit hit;
        //    if (Physics.Raycast(ray, out hit))
        //    {
        //        Debug.Log("Hit: " + hit.transform.gameObject.name);
        //    }
        //}
    }
}
