﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerMicrophoneManager : NetworkBehaviour
{
    private string microphone;
    private NetworkIdentity networkIdentity;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        networkIdentity = GetComponentInParent<NetworkIdentity>();
        if (Application.platform == RuntimePlatform.WebGLPlayer)
        {
            // we need to ask for premission when web
            yield return Application.RequestUserAuthorization(UserAuthorization.Microphone);
            if (Application.HasUserAuthorization(UserAuthorization.Microphone))
            {
                Debug.Log("webcam found");
                startBroadCast();

            }
            Debug.Log("WebGL");
        }
        else
        {
            if (isLocalPlayer)
            {

                startBroadCast();
            }
        }
    }

    void startBroadCast()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        microphone = Microphone.devices[0];
        audioSource.clip = Microphone.Start(microphone, true, 10, 22050);
        while (!(Microphone.GetPosition(microphone) > 0)) { }
        audioSource.Play();
        Debug.Log("start playing... position is " + Microphone.GetPosition(microphone));
    }

    // Update is called once per frame
    void Update()
    {

    }
    /*
        void FixedUpdate()
        {
            if (Network.connections.Length > 0)
            {

            }


        }
        */
}
