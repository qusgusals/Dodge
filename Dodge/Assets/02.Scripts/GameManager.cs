using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//UI 관련 library 사용할래
using UnityEngine.UI;
// 씬 관리 관련 라이브러리 사용할래
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // 게임오버 시 활성화할 텍스트 게임 오브젝트
    public GameObject gameOverText;
    //생존 시간을 표시할 텍스트 컴포넌트
    public Text timeText;
    // 최고 기록을 표시할 텍스트 컴포넌트
    public Text recordText;

    //실제 생존 시간
    private float surviveTime;

    // 게임오버 상태

    private bool isGameover;
    void Start()
    {
        //생존 시간과 게임오버 상태 초기화
        surviveTime = 0f;
        isGameover = false;
    }

    
    void Update()
    {
        // 게임오버가 아닌 동안
        if(!isGameover)
        {
            // 생존시간 갱신
            surviveTime += Time.deltaTime;
            //갱신한 생존 시간을 timeText
            //컴포넌트를 이용해 표시
            timeText.text = "Time: " + (int)surviveTime;
        }
        else
        {
            //게임오버인 상태에서 'R'키를 누른다면,
            if(Input.GetKeyDown(KeyCode.R))
            {
                // SampleScene 씬을 로드
                SceneManager.LoadScene("SampleScene");
            }
        }
    }

    // 현재 게임을 게임오버 상태로 변경하는 메서드
    public void EndGame()
    {
        //현재 상태를 게임오버 상태로 전환
        isGameover = true;
        // 게임오버 텍스트 게임 오브젝트를 활성화
        gameOverText.SetActive(true);

        //'BestTime' 키로 저장된 이전까지의 최고 
        //기록을 가져오기
        float bestTime=
            PlayerPrefs.GetFloat("BestTime");

        // 이전까지의 최고 기록과 현재 생존 시간비교
        if(bestTime<surviveTime)
        {
            // 최고 기록 값을 현재 생존 시간 값으로 변경
            bestTime = surviveTime;
            // 변경된 최고 기록을 besttime 키로 저장
            PlayerPrefs.SetFloat("BestTime", bestTime);
        }


        //최고 기록을 recordText 컴포넌트에 표시
        recordText.text = "Best Time: " +(int)bestTime;


        // 기록을 데이터로 저장하는 방법
        //Playerprefs(Player Preference)
        // Get: 어떤값을 가져온다
        //Set: 어떤 것을 쓴다.
        // 돈 : 1000원을 데이터 저장
        // PlayerPres.SetInt("Money",1000);
        // PlayerPrefs.SetString("Nick","hyenmin");

        //  Debug.Log(PlayerPrefs.GetInt("Money"));
        // Debug.Log(PlayerPrefs.GetString("Nick"));
    }
}
