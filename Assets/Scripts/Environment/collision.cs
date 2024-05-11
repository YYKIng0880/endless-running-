using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class collision : MonoBehaviour
{//�����Ǽ��������ײ�ϰ���ʱ��ײ��������ֹͣ���ź��˶�����������ζ��Ķ���
    private GameObject thePlayer;
    
    private GameObject character; //������ײ���󣬲�����ײ��������������Ϸ��
    
    public AudioSource collisionMusic;
    private GameObject cam;//��ײ����ʼ�������������
    public GameObject levelControl;

    private void Start()
    {
        thePlayer = GameObject.FindWithTag("Moveplayer");
        character = GameObject.FindWithTag("Player");
        cam = GameObject.FindWithTag("Camera");
    }
    private void OnTriggerEnter(Collider other)
    {
        thePlayer.GetComponent<PlayerMove>().enabled = false;
        gameObject.GetComponent<BoxCollider>().enabled = false;
        collisionMusic.Play();
        levelControl.GetComponent<LevelDistance>().enabled = false;

        character.GetComponent<Animator>().Play("Stumble Backwards");
        
        
        cam.GetComponent<Animator>().enabled = true;
        levelControl.GetComponent<EndingUI>().enabled = true;       
    }
    
}
