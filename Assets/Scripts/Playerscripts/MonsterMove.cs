using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMove: MonoBehaviour
{
    public GameObject Monstercharacter;

    private float MoveSpeed=10f;
    public float Turntime = 1.4f;
    private bool canmovetoleft=true;
    private bool canmovetoright=false;

   private bool rotateleft=false;
   private bool rotateright=false;
    private Animator animator;
    private void Start()
    {
        animator = Monstercharacter.GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        animator.Play("Attack");
    }
    private void Update()
    {
        if (canmovetoleft)
        {
            animator.SetBool("change",true);
            rotateleft = true;
            Monstercharacter .transform.Translate(Vector3.left*Time.deltaTime* MoveSpeed,Space.World);
            StartCoroutine(Movechange());
        }
        if (canmovetoright)
        {
            animator.SetBool("change", true);
            rotateright = true;
            Monstercharacter.transform.Translate(Vector3.right *Time.deltaTime *MoveSpeed, Space.World);
        }
    }
   
    IEnumerator Movechange()
    {
        yield return new WaitForSeconds(Turntime);
        canmovetoleft = false;
        animator.SetBool("change", false);
       if (rotateleft)
        {
            Monstercharacter.transform.Rotate(0, 180f, 0f, Space.World);
            rotateleft = false;
        }
        canmovetoright = true;
        yield return new WaitForSeconds(Turntime);
        canmovetoright = false;
        animator.SetBool("change",false);
       if(rotateright) 
       {
            Monstercharacter.transform.Rotate(0, -180f, 0f, Space.World);
            rotateright = false;
       }
        canmovetoleft = true;
    }
}
