using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Mirror;

public class PlayerWebCamTexture : NetworkBehaviour
{
    public Quaternion baseRotation;
    private WebCamTexture webcamTexture;
    private GameObject head;
    // Start is called before the first frame update
    void Start()
    {
        if (!isLocalPlayer)
        {
            return;
        }

        head = GameObject.Find("Head");
        Debug.Log("Start");


        webcamTexture = new WebCamTexture();
        head.GetComponent<Renderer>().material.mainTexture = webcamTexture;
        baseRotation = transform.rotation;
        webcamTexture.requestedFPS = 30f;

        if (!Application.isEditor)
        {
            webcamTexture.Play();
        }


    }

    public override void OnStartLocalPlayer()
    {
        head = GameObject.Find("Head");


        webcamTexture = new WebCamTexture();
        head.GetComponent<Renderer>().material.mainTexture = webcamTexture;
        baseRotation = transform.rotation;
        webcamTexture.requestedFPS = 30f;

        if (!Application.isEditor)
        {
            webcamTexture.Play();
        }
    }

    void OnConnectedToServer()
    {
        if (!isLocalPlayer)
        {
            return;
        }

        head = GameObject.Find("Head");


        webcamTexture = new WebCamTexture();
        head.GetComponent<Renderer>().material.mainTexture = webcamTexture;
        baseRotation = transform.rotation;
        webcamTexture.requestedFPS = 30f;

        if (!Application.isEditor)
        {
            webcamTexture.Play();
        }
    }


    void OnServerInitialized()
    {
        Debug.Log("Server initialized and ready");
    }

}
