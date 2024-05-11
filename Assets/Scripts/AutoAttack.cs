using HutongGames.PlayMaker.Actions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoAttack : MonoBehaviour
{
    private Transform target;//��������
    private float Movespeed = 8f;
    private float Attackdistance = 1.2f;//����Ĺ�������
    private float Movedistance = 10f;//���������ƶ�׷���ķ�Χ
    private float Movemaxdistance = 15f;//��������׷����Χ
    public Animator animator;
    private float timer;//��ʱ����
                        // private bool canAttack;//�ж��Ƿ���Թ���,���ö���
    private GameObject thePlayer;//�����ƶ��ű���

    private GameObject character; //������ײ���󣬲�����ײ��������������Ϸ��

    public AudioSource collisionMusic;
    private GameObject cam;//��ײ����ʼ�������������
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
            {//�����������ڹ��������ʱ�򡪡��ù�����ǰ׷�����
                animator.SetBool("run", true);
                transform.position += (target.position - transform.position).normalized * Time.deltaTime * Movespeed;
                transform.forward = Vector3.Lerp(transform.forward, target.position - transform.position, 0.1f);
                timer += Time.deltaTime;
            }
            else
            {
                //С�ڹ������롪������
                animator.SetBool("attack", true);
                //���������ﵹ�أ�ֹͣ�ƶ���������������ͽ���UI
                StartCoroutine(Endset());
            }
            if (Vector3.Distance(target.position, transform.position) > Movemaxdistance || timer > 4.5f)
            {//�������||����׷��ʱ�������������޷�Χ��������ֹͣ׷����
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
    
