using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Highlight : MonoBehaviour {

    public GameObject LeftHighlight;
    public AudioClip LeftAudio;
    public GameObject CenterHighlight;
    public AudioClip CenterAudio;
    public GameObject RightHighlight;
    public AudioClip RightAudio;

    private AudioSource audioSrc;

    public void Start()
    {
        audioSrc = gameObject.GetComponent<AudioSource>();
    }

    public void OnActiveRegionReceived(OscMessage msg)
    {
        OSCReceiveCVInfo.ActiveRegion activeRegion = (OSCReceiveCVInfo.ActiveRegion)msg.GetInt(0);

        switch (activeRegion)
        {
            case OSCReceiveCVInfo.ActiveRegion.left:
                LeftHighlight.SetActive(true);
                CenterHighlight.SetActive(false);
                RightHighlight.SetActive(false);
                audioSrc.PlayOneShot(LeftAudio);
                break;

            case OSCReceiveCVInfo.ActiveRegion.center:
                LeftHighlight.SetActive(false);
                CenterHighlight.SetActive(true);
                RightHighlight.SetActive(false);
                audioSrc.PlayOneShot(CenterAudio);
                break;

            case OSCReceiveCVInfo.ActiveRegion.right:
                LeftHighlight.SetActive(false);
                CenterHighlight.SetActive(false);
                RightHighlight.SetActive(true);
                audioSrc.PlayOneShot(RightAudio);
                break;

            case OSCReceiveCVInfo.ActiveRegion.nothing:
                LeftHighlight.SetActive(false);
                CenterHighlight.SetActive(false);
                RightHighlight.SetActive(false);
                break;

            default:
                LeftHighlight.SetActive(false);
                CenterHighlight.SetActive(false);
                RightHighlight.SetActive(false);
                break;
        }
    }

}
