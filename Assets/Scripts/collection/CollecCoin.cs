using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollecCoin : MonoBehaviour
{//播放收集硬币音效，检测和硬币的接触，计数；
    public AudioSource coinmusic;
   // public AudioSource BGM;
    private void OnTriggerEnter(Collider other)
    {
       // BGM.Pause();
        coinmusic.Play();
        collectcontrol.coinCount++;
        this.gameObject.SetActive(false);
    }
    private void OnTriggerExit(Collider other)
    {
        //BGM.Play();
    }
}
