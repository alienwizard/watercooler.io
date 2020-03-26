using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Mirror;

public class PlayerWebCamTexture : NetworkBehaviour
{
    public WebCamTexture webcamTexture;
    public Quaternion baseRotation;
    // Start is called before the first frame update
    void Start()
    {
        NetworkIdentity identity = GetComponentInParent<NetworkIdentity>();
        if (identity.isLocalPlayer)
        {
            webcamTexture = new WebCamTexture();
            GetComponent<Renderer>().material.mainTexture = webcamTexture;
            baseRotation = transform.rotation;
            webcamTexture.requestedFPS = 30f;

            if (!Application.isEditor)
            {
                webcamTexture.Play();
            }
        }

    }

    private void Update()
    {
        transform.rotation = baseRotation * Quaternion.AngleAxis(webcamTexture.videoRotationAngle, Vector3.up);
    }

}
