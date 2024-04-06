using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collision : MonoBehaviour
{//�����Ǽ��������ײ�ϰ���ʱ��ײ��������ֹͣ���ź��˶�����������ζ��Ķ���
    public GameObject thePlayer;
    public GameObject charPlayer;
    public AudioSource collisionMusic;
    public GameObject cam;
    private void OnTriggerEnter(Collider other)
    {
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        thePlayer .GetComponent<PlayerMove>().enabled = false;
        charPlayer.GetComponent<Animator>().Play("Stumble Backwards");
        collisionMusic.Play();
        cam.GetComponent<Animator>().enabled = true;
    }
}
