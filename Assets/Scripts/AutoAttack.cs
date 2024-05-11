using HutongGames.PlayMaker.Actions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoAttack : MonoBehaviour
{
    private Transform target;//攻击对象；
    private float Movespeed = 8f;
    private float Attackdistance = 1.2f;//怪物的攻击距离
    private float Movedistance = 10f;//触发怪物移动追击的范围
    private float Movemaxdistance = 15f;//怪物最大的追击范围
    public Animator animator;
    private float timer;//计时器；
                        // private bool canAttack;//判断是否可以攻击,设置动画
    private GameObject thePlayer;//挂载移动脚本的

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
        if (Vector3.Distance(other.transform.position, transform.position) <= Movedistance)
        {
            if (target == null)
            {
                //print("das");
                target = other.transform;
            }
        }

    }
    private void Update()
    {

        if (target)
        {
            if (Vector3.Distance(target.position, transform.position) > Attackdistance)
            {//当怪物距离大于攻击距离的时候——让怪物向前追击玩家
                animator.SetBool("run", true);
                transform.position += (target.position - transform.position).normalized * Time.deltaTime * Movespeed;
                transform.forward = Vector3.Lerp(transform.forward, target.position - transform.position, 0.1f);
                timer += Time.deltaTime;
            }
            else
            {
                //小于攻击距离——攻击
                animator.SetBool("attack", true);
                //攻击后人物倒地，停止移动，播放相机动画和结束UI
                StartCoroutine(Endset());
            }
            if (Vector3.Distance(target.position, transform.position) > Movemaxdistance || timer > 4.5f)
            {//距离过大||或者追击时间过长，超出仇恨范围——怪物停止追击；
                target = null;
                animator.SetBool("attack", false);
                animator.SetBool("run", false);
            }
        }
    }
    IEnumerator Endset()
    {
        yield return new WaitForSeconds(0.25f);
        thePlayer.GetComponent<PlayerMove>().enabled = false;
        gameObject.GetComponent<BoxCollider>().enabled = false;
        collisionMusic.Play();
        levelControl.GetComponent<LevelDistance>().enabled = false;
        character.GetComponent<Animator>().Play("Stumble Backwards");
        cam.GetComponent<Animator>().enabled = true;
        levelControl.GetComponent<EndingUI>().enabled = true;
    }
}
    
