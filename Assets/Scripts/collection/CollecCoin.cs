using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollecCoin : MonoBehaviour
{//�����ռ�Ӳ����Ч������Ӳ�ҵĽӴ���������
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
