using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMove: MonoBehaviour
{
   //人物的移动；
    public float moveSpeed = 3;
    public float leftRightSpeed = 4;
    public static bool canMove = false;
    public bool isJumping=false;
    public bool comingdown=false;
    public GameObject playerObject;
    public float upSpeed = 8f;
    private void Update()
    {
        transform.Translate(Vector3.forward * moveSpeed,Space.World);
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
            if(Input.GetKey(KeyCode.Space))
            {
                if(isJumping==false)
                {
                    isJumping = true;
                    playerObject.GetComponent<Animator>().Play("Jump");
                    StartCoroutine(JumpSequence()); 
                }
            }
            if(isJumping == true) 
            {
                if (comingdown == false)
                {
                    transform.Translate(Vector3.up*Time.deltaTime*upSpeed,Space.World);
                }
                if(comingdown == true)
                {
                    transform.Translate(Vector3.up*Time.deltaTime*-upSpeed,Space.World);
                }
            }
        }

    }
    IEnumerator JumpSequence()
    {
        yield return new WaitForSeconds(0.45f);
        comingdown = true;
        yield return new WaitForSeconds(0.45f);
        isJumping=false;
        comingdown = false;
        playerObject.GetComponent<Animator>().Play("Standard Run");
    }
}
