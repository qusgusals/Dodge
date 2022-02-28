using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float rotationSpeed = 60f;

    // Update is called once per frame
    //
    void Update()
    {
        //Rotate 메서드는 입력값(매개변수)로 x,y,z축에
        //대한 회전값을 받고, 현재 회전 상태에서 입력된
        //값만큼 상대적으로 더 회전합니다.
        transform.Rotate(0f, rotationSpeed*Time.deltaTime, 0f);
    }
}
