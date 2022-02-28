using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{

    // ������ ź���� ���� ������
    public GameObject bulletPrefab;
    // �ּ� ���� �ֱ�
    public float spawnRateMin = 0.5f;
    // �ִ� ���� �ֱ�
    public float spawnRateMax = 3f;

    // ���� ���� �ֱ�
    private float spawnRate;
    // �ֱ� ���� �������� ���� �ð�
    private float timeAfterSpawn;
    // �߻��� ���
    private Transform target;

    void Start()
    {
        // �ֱ� ���� ������ ���� �ð��� 0���� �ʱ�ȭ
        timeAfterSpawn = 0f;
        // ź�� ���� ������ spawnRateMin��
        // spawnRateMax ���̿��� ���� �� ����
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        // PlayerController ������Ʈ�� ���� ����
        // ������Ʈ�� ã�Ƽ� �� ������Ʈ�� ��ġ����
        // ������
        target = FindObjectOfType<PlayerController>()
            .transform;
    }

    void Update()
    {
        // timeAfterspawn ����
        timeAfterSpawn += Time.deltaTime;

        //�ֱ� ���� ������������ ������ �ð���
        //�����ֱ⺸�� ũ�ų� ���ٸ�
        if(timeAfterSpawn>=spawnRate)
        {
            // bulletprefab�� �������� transform.position
            //��ġ�� transform.rotation ȸ������ ����
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            // ������ bullet ���� ������Ʈ�� ���� ������
            // target�� ���ϵ��� ȸ��
            bullet.transform.LookAt(target);

            //������ ���� ������ spawnRatemin,
            //spawnRatemax���̿��� ��������
            spawnRate = Random.Range(spawnRateMin, spawnRateMax);


            // ������ �ð��� ����
            timeAfterSpawn = 0f;
        }
        

        
        
      
        
    }
}
