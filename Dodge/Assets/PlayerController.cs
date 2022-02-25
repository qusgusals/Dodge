using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // 이동에 사용할 리지드바디 컴포넌트
    public Rigidbody playerRigidbody;
    // 이동 속력
    public float speed = 3f;

    // 내 자신을 담을 변수
    public GameObject my;

    private void Start()
    {
        // 게임 오브젝트에서 Rigidbody 컴포넌트를 찾아
        // playerRigidbody에 할당
        playerRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // 수평축과 수직축의 입력값을 감지해서 저장
        float xInput = Input.GetAxis("Horizontal");
        // 키보드 : 'A', <- : 음의방향 : -1.0f
        // 키보드 : 'D', -> : 양의방향 : +1.0f
        float zInput = Input.GetAxis("Vertical");
        // 키보드 : 'W', ^ : 양의방향 : +1.0f
        // 키보드 : 'S', ▼ : 음의방향 : -1.0f

        // 실제 이동 속도를 입력값과
        // 이동 속력을 사용해 결정
        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        // Vector3 속도를 (xSpeed, 0f, zSpeed) 생성
        Vector3 newVelocity = new Vector3(xSpeed, 0, zSpeed);
        // 리지디바디의 속도에 newVelocity 할당
        playerRigidbody.velocity = newVelocity;

    }

    void DirectInput()
    {
        if (Input.GetKey(KeyCode.UpArrow) == true)
        {
            // 위쪽 방향키 입력이 감지된 경우
            playerRigidbody
                .AddForce(0f, 0f, speed);
        }
        if (Input.GetKey(KeyCode.DownArrow) == true)
        {
            // 아래쪽 방향키 입력이 감지된 경우
            // -z 방향 힘 주기
            playerRigidbody
                .AddForce(0f, 0f, -speed);
        }
        if (Input.GetKey(KeyCode.RightArrow) == true)
        {
            // 오른쪽 방향키 입력이 감지된 경우
            // x 방향 힘 주기
            playerRigidbody
                .AddForce(speed, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.LeftArrow) == true)
        {
            // 왼쪽 방향키 입력이 감지된 경우
            // -x 방향 힘 주기
            playerRigidbody
                .AddForce(-speed, 0f, 0f);
        }
    }

    public void Die()
    {
        my.SetActive(false);
    }
}
