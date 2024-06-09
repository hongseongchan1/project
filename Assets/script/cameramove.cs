using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoving : MonoBehaviour
{

    Transform playerTransform; //플레이어의 위치정보 변수 
    Vector3 Offset;//고정값 ( 플레이어와 카메라 사이의 떨어진 정도 ) 

    // Start is called before the first frame update
    void Awake()
    {//초기화

        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        //플레이어의 위치정보를 Tag를 이용해 가져옴


        Offset = transform.position - playerTransform.position;
        //자신의 위치 - 플레이어의 위치 = 플레이어와 자신의 떨어진 벡터값 
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //카메라의 위치 = 플레이어의 위치 + 플레이어와 자신의 떨어진 고정값 
        transform.position = playerTransform.position + Offset;
    }
}