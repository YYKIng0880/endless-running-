using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class collision : MonoBehaviour
{//�����Ǽ��������ײ�ϰ���ʱ��ײ��������ֹͣ���ź��˶�����������ζ��Ķ���
    public GameObject thePlayer;
    public GameObject charPlayer;
    public AudioSource collisionMusic;
    public GameObject cam;
    public GameObject levelControl;
    
    private void OnTriggerEnter(Collider other)
    {
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        thePlayer .GetComponent<PlayerMove>().enabled = false;
        collisionMusic.Play();
        levelControl.GetComponent<LevelDistance>().enabled = false;
        charPlayer.GetComponent<Animator>().Play("Stumble Backwards");
        cam.GetComponent<Animator>().enabled = true;
       
    }
    
}
