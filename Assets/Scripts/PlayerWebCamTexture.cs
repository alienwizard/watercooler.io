using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PlayerWebCamTexture : MonoBehaviour
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
