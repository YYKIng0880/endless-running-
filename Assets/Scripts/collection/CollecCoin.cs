using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollecCoin : MonoBehaviour
{
    public AudioSource coinmusic;
    private void OnTriggerEnter(Collider other)
    {
        coinmusic.Play();
        collectcontrol.coinCount++;
        this.gameObject.SetActive(false);
    }
}
