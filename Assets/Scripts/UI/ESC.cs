using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ESC : MonoBehaviour
{
    public GameObject ESCobject;
    private bool EscStaut = true;
    public AudioSource bgm;
    public Slider volumSlider;
    private void Update()
    {
        if (EscStaut)//按下ESC按钮弹出UI，BAckSpace退出，期间暂停音乐和游戏进度；
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                // Debug.Log("BB");
                ESCobject.SetActive(true);
                EscStaut = false;
                Time.timeScale = (0);
                bgm.Pause();
            }
        }
        else if (Input.GetKeyDown(KeyCode.Backspace))
        {
            ESCobject.SetActive(false);
            EscStaut = true;
            Time.timeScale = (1);
            bgm.Play();
        }
        bgm.volume=volumSlider .value;
    }
    public void EscGame()//退出游戏按钮
    {
        SceneManager.LoadScene(1);
    }
    


}


