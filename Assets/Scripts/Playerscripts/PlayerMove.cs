using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMove: MonoBehaviour
{
   //人物的移动；
    private float moveSpeed = 7f;//正常人物速度；
    private float supermovespeed = 9.5f;//按下shift加速
    public float leftRightSpeed = 4;
    public static bool canMove = false;
    private bool isJumping=false;
    private bool comingdown=false;
    public GameObject playerObject;
    public float upSpeed = 8f;
    private bool canmovechoice=false;//防止选择人物界面时人物移动，要按下W人物才一直向前run；
   // private bool canmove=false;//按下esc后是否能继续向前；

    //协程里跳跃的上升时间和下降时间；
    private float UpTime = 0.45f;
    private float DownTime = 0.45f;
   
    private void Update()
    {
        //按下ECS键后暂停人物向前移动
        if(Input.GetKeyDown(KeyCode.Escape))
        {
           // canmove = false;
            canmovechoice = false;
        }
        if(Input.GetKeyDown(KeyCode.Backspace))
        {
            canmovechoice = true;
        }
       
        //一开始要按W键才开始向前跑，防止在人物选择界面就移动
        if(Input.GetKey(KeyCode.W))
        {
            canmovechoice= true;
        }
        if(canmovechoice)
        {
            if((Input.GetKey(KeyCode.LeftShift))||(Input.GetKey(KeyCode.RightShift)))
            {
               // print("asd");
                transform.Translate(Vector3.forward * Time.deltaTime * supermovespeed, Space.World);
            }
            else
            {
                transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);
            }
        }
        //在开始倒计时的时候，不能左右移动；
        if(canMove)
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                if (this.gameObject.transform.position.x > LevelBoundary.leftSide)
                {
                    transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed);
                }
            }
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                if (this.gameObject.transform.position.x < LevelBoundary.rightSide)
                {
                    transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed * -1);
                }
            }
            if(Input.GetKeyDown(KeyCode.Space))
            {
                if(isJumping==false)
                {
                    isJumping = true;
                    playerObject.GetComponent<Animator>().Play("Jump");
                    StartCoroutine(JumpSequence()); 
                }
            }
            //跳跃动画是向后的；
            if(isJumping == true) 
            {
                if (comingdown == false)
                {//在协程里控制状态，0.45f前都是上升的时候
                    transform.Translate(Vector3.up*Time.deltaTime*upSpeed,Space.World);
                }
                //0.45f后向下，
                if(comingdown == true)
                {
                    transform.Translate(Vector3.up*Time.deltaTime*-upSpeed,Space.World);
                }
            }
        }

    }
    IEnumerator JumpSequence()
    {
        yield return new WaitForSeconds(UpTime);
        comingdown = true;
        yield return new WaitForSeconds(DownTime);
        isJumping=false;
        comingdown = false;
        //0.45f后结束跳跃动画开始向前奔跑；
        playerObject.GetComponent<Animator>().Play("Standard Run");
    }
}
