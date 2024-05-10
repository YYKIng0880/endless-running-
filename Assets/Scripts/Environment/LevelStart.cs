using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStart : MonoBehaviour
{//播放开局3,2,1GO动画，和BGM；
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
        PlayerMove.canMove = true;//开始动画前不允许左右移动，只允许向前；
    }
}
