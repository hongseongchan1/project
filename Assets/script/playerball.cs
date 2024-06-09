using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBall : MonoBehaviour
{
    public int itemCount;
    public float jumpPower;
    public GameManager manager;
    bool isJump;

    AudioSource audio;

    Rigidbody rigid;

    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
        isJump = false; // ������ �ȵ� ���¶�� ���� 
    }

    // Update is called once per frame


    void Update()
    {
        if (Input.GetButtonDown("Jump") && !isJump)
        { //isJump�� false�� ����(1ȸ�� ����)
            isJump = true;
            rigid.AddForce(new Vector3(0, jumpPower, 0), ForceMode.Impulse);
        }
    }

    void FixedUpdate() //���� ������ ���������̹Ƿ� FixedUpdate��� 
    {
        float h = Input.GetAxisRaw("Horizontal"); //GetAxisRaw : 0, 1 ,-1�� ������ 
        float v = Input.GetAxisRaw("Vertical");

        rigid.AddForce(new Vector3(h, 0, v), ForceMode.Impulse);
    }

    void OnCollisionEnter(Collision collision)
    { //���� �ٴڰ� ������ jump���� ���� 

        if (collision.gameObject.name == "Floor") isJump = false;
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Item")
        { //�浹 ������Ʈ�� �������϶�
            itemCount++; // ���� �ø��� 
            audio.Play(); // ���� ��� 
            other.gameObject.SetActive(false); //������ ��Ȱ��ȭ 

        }
        else if (other.tag == "Finish")
        {
            if (itemCount == manager.Totalitemcount)
            {      //game clear!
                SceneManager.LoadScene("1-2");
            }
            else
            {
                //Restart..
                SceneManager.LoadScene("1-1");
            }
        }
    }
}