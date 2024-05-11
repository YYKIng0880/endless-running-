using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMove: MonoBehaviour
{
   //������ƶ���
    private float moveSpeed = 7f;//���������ٶȣ�
    private float supermovespeed = 9.5f;//����shift����
    public float leftRightSpeed = 4;
    public static bool canMove = false;
    private bool isJumping=false;
    private bool comingdown=false;
    public GameObject playerObject;
    public float upSpeed = 8f;
    private bool canmovechoice=false;//��ֹѡ���������ʱ�����ƶ���Ҫ����W�����һֱ��ǰrun��
   // private bool canmove=false;//����esc���Ƿ��ܼ�����ǰ��

    //Э������Ծ������ʱ����½�ʱ�䣻
    private float UpTime = 0.45f;
    private float DownTime = 0.45f;
   
    private void Update()
    {
        //����ECS������ͣ������ǰ�ƶ�
        if(Input.GetKeyDown(KeyCode.Escape))
        {
           // canmove = false;
            canmovechoice = false;
        }
        if(Input.GetKeyDown(KeyCode.Backspace))
        {
            canmovechoice = true;
        }
       
        //һ��ʼҪ��W���ſ�ʼ��ǰ�ܣ���ֹ������ѡ�������ƶ�
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
        //�ڿ�ʼ����ʱ��ʱ�򣬲��������ƶ���
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
            //��Ծ���������ģ�
            if(isJumping == true) 
            {
                if (comingdown == false)
                {//��Э�������״̬��0.45fǰ����������ʱ��
                    transform.Translate(Vector3.up*Time.deltaTime*upSpeed,Space.World);
                }
                //0.45f�����£�
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
        //0.45f�������Ծ������ʼ��ǰ���ܣ�
        playerObject.GetComponent<Animator>().Play("Standard Run");
    }
}
