using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerMicrophoneManager : NetworkBehaviour
{
    private string microphone;
    private NetworkIdentity networkIdentity;

    private AudioSource audioSource;

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
        audioSource = GetComponent<AudioSource>();
        microphone = Microphone.devices[0];
        audioSource.clip = Microphone.Start(microphone, true, 5, 22050);
        while (!(Microphone.GetPosition(microphone) > 0)) { }
        // audioSource.Play();
        AudioClip clip = audioSource.clip;
        // RpcplaySound();
        CmdSendServerSound();
        Debug.Log("start playing... position is " + Microphone.GetPosition(microphone));
    }

    [Command]
    void CmdSendServerSound()
    {
        // RpcplaySound(audio);
        audioSource.Play();

    }

    [ClientRpc]
    void RpcplaySound()
    {
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Microphone.IsRecording(microphone))
        {
            audioSource.clip = Microphone.Start(microphone, true, 5, 22050);
            CmdSendServerSound();
        }

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
