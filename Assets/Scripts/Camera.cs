using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTransition : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        Camera camBeginning = GetComponent<Camera>();

        if (camBeginning != null)
        {
            camBeginning.orthographic = false;
            camBeginning.fieldOfView = 90;

            camBeginning.transform.position = new Vector3(4.2f, -6.86f, -10f);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
