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
    public GameObject Coinscount;
    public GameObject Distancecount;
    public GameObject endScreen;
    public GameObject fadeOut;
    private void OnTriggerEnter(Collider other)
    {
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        thePlayer .GetComponent<PlayerMove>().enabled = false;
        charPlayer.GetComponent<Animator>().Play("Stumble Backwards");
        collisionMusic.Play();
        cam.GetComponent<Animator>().enabled = true;
        StartCoroutine(EndGame()); 
    }
    IEnumerator EndGame()
    {
        yield return new WaitForSeconds(3);
        Coinscount.SetActive(false);
        Distancecount.SetActive(false);
        endScreen.SetActive(true);
        yield return new WaitForSeconds(3);
        fadeOut.SetActive(true);
        endScreen.SetActive(false);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(1);

    }
}
