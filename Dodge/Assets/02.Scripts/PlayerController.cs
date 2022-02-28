using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // �̵��� ����� ������ٵ� ������Ʈ
    public Rigidbody playerRigidbody;
    // �̵� �ӷ�
    public float speed = 3f;

    // �� �ڽ��� ���� ����
    public GameObject my;

    private void Start()
    {
        // ���� ������Ʈ���� Rigidbody ������Ʈ�� ã��
        // playerRigidbody�� �Ҵ�
        playerRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // ������� �������� �Է°��� �����ؼ� ����
        float xInput = Input.GetAxis("Horizontal");
        // Ű���� : 'A', <- : ���ǹ��� : -1.0f
        // Ű���� : 'D', -> : ���ǹ��� : +1.0f
        float zInput = Input.GetAxis("Vertical");
        // Ű���� : 'W', ^ : ���ǹ��� : +1.0f
        // Ű���� : 'S', �� : ���ǹ��� : -1.0f

        // ���� �̵� �ӵ��� �Է°���
        // �̵� �ӷ��� ����� ����
        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        // Vector3 �ӵ��� (xSpeed, 0f, zSpeed) ����
        Vector3 newVelocity = new Vector3(xSpeed, 0, zSpeed);
        // ������ٵ��� �ӵ��� newVelocity �Ҵ�
        playerRigidbody.velocity = newVelocity;

    }

    void DirectInput()
    {
        if (Input.GetKey(KeyCode.UpArrow) == true)
        {
            // ���� ����Ű �Է��� ������ ���
            playerRigidbody
                .AddForce(0f, 0f, speed);
        }
        if (Input.GetKey(KeyCode.DownArrow) == true)
        {
            // �Ʒ��� ����Ű �Է��� ������ ���
            // -z ���� �� �ֱ�
            playerRigidbody
                .AddForce(0f, 0f, -speed);
        }
        if (Input.GetKey(KeyCode.RightArrow) == true)
        {
            // ������ ����Ű �Է��� ������ ���
            // x ���� �� �ֱ�
            playerRigidbody
                .AddForce(speed, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.LeftArrow) == true)
        {
            // ���� ����Ű �Է��� ������ ���
            // -x ���� �� �ֱ�
            playerRigidbody
                .AddForce(-speed, 0f, 0f);
        }
    }

    public void Die()
    {
        my.SetActive(false);

        //���� �����ϴ� GameManager Ÿ����
        //������Ʈ�� ã�Ƽ� ��������
        GameManager gameManager =
             FindObjectOfType<GameManager>();
        gameManager.EndGame();
    }
}
