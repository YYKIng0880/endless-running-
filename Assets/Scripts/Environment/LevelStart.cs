using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStart : MonoBehaviour
{//���ſ���3,2,1GO��������BGM��
    public GameObject countDown3;
    public GameObject countDown2;
    public GameObject countDown1;
    public GameObject countDownGo;
    public GameObject fadeIn;
    public AudioSource BeginBGM;
    private void Start()
    {
        StartCoroutine(CountSequence());
    }
    IEnumerator CountSequence()
    {
        fadeIn.SetActive(true);
        yield return new WaitForSeconds(1f);
        countDown3.SetActive(true);
        BeginBGM.Play();
        yield return new WaitForSeconds(1f);
        countDown2.SetActive(true);
        yield return new WaitForSeconds(1f);
        countDown1.SetActive(true);
        yield return new WaitForSeconds(1f);
        countDownGo.SetActive(true);
        PlayerMove.canMove = true;//��ʼ����ǰ�����������ƶ���ֻ������ǰ��
    }
}
