using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class collision : MonoBehaviour
{//作用是检测遇到碰撞障碍物时，撞击后人物停止播放后退动画，和相机晃动的动画
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
