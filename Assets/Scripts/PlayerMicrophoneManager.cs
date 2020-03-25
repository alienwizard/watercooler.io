using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMicrophoneManager : MonoBehaviour
{
    private string microphone;
    // Start is called before the first frame update
    void Start()
    {
        foreach (var device in Microphone.devices)
        {
            Debug.Log("Name: " + device);
        }

        if (Application.platform == RuntimePlatform.WebGLPlayer)
        {
            // we need to ask for premission when web
            Debug.Log("WebGL");
        }

        AudioSource audioSource = GetComponent<AudioSource>();
        microphone = Microphone.devices[0];
        audioSource.clip = Microphone.Start(microphone, true, 10, 22050);
        while (!(Microphone.GetPosition(microphone) > 0)) { }
        audioSource.Play();
        Debug.Log("start playing... position is " + Microphone.GetPosition(null));
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnDestroy()
    {
        Microphone.End(microphone);
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
