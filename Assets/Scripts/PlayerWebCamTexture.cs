using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Mirror;

public class PlayerWebCamTexture : NetworkBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        WebCamTexture webcamTexture = new WebCamTexture();
        GetComponent<Renderer>().material.mainTexture = webcamTexture;
        webcamTexture.requestedFPS = 30f;
        if (!Application.isEditor)
        {
            webcamTexture.Play();
        }
    }

    private void Update()
    {

    }

}
