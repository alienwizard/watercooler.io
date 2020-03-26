using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Mirror;

public class PlayerWebCamTexture : NetworkBehaviour
{
    public Quaternion baseRotation;
    private WebCamTexture webcamTexture;
    public Texture testTexture;

    void Start()
    {
        NetworkIdentity identity = GetComponentInParent<NetworkIdentity>();
        if (identity.isLocalPlayer)
        {
            WebCamTexture webcamTexture = new WebCamTexture();
            Texture texture = GetComponent<Renderer>().material.mainTexture;
            texture = webcamTexture;
            baseRotation = transform.rotation;

            webcamTexture.requestedFPS = 30f;
            if (!Application.isEditor)
            {
                webcamTexture.Play();
            }
            else
            {
                texture = testTexture;
            }
        }

    }
}
