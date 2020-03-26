using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Mirror.;

public class PlayerWebCamTexture : NetworkBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        NetworkIdentity identity = GetComponentInParent<NetworkIdentity>();
        if (identity.isLocalPlayer)
        {
            WebCamTexture webcamTexture = new WebCamTexture();
            Texture texture = GetComponent<Renderer>().material.mainTexture;
            texture = webcamTexture;

            webcamTexture.requestedFPS = 30f;
            if (!Application.isEditor)
            {
                webcamTexture.Play();
            }
        }

    }

    private void Update()
    {

    }

}
