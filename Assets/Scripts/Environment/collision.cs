using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class collision : MonoBehaviour
{//作用是检测遇到碰撞障碍物时，撞击后人物停止播放后退动画，和相机晃动的动画
    private GameObject thePlayer;
    
    private GameObject character; //人物受撞击后，播放受撞击动画，结束游戏；
    
    public AudioSource collisionMusic;
    private GameObject cam;//受撞击后开始播放相机动画；
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
