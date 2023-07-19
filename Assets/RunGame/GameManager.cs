using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    GameObject player;
    int score = 0; 
    public Text scoreText;
    public Text EndScoreText;
    public static GameManager instance;
    public DataManager dataManager;
    public Image HP;
    public GameObject EndPanel;
    private Animator animator;
    private MapMove mapMoveComponent;
    // 게임 메니저 인스턴스 생성
    private void Awake()
    {
        if (GameManager.instance == null)
        {
            GameManager.instance = this;
        }
    }

    // 필요 오브젝트 선언
    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        dataManager = DataManager.Instance;
        animator=player.GetComponent<Animator>(); 
        // TiledMap의 object를 가져옴
        GameObject mapObject = GameObject.FindGameObjectWithTag("Map");
        // TiledMap의 스크립트를 가져옴
        mapMoveComponent = mapObject.GetComponent<MapMove>();
    }


    private void Update()
    {
        // 죽지 않았을 경우
        if(!DataManager.Instance.PlayerDie)
        {
            // HP 감소
            DataManager.Instance.playTimeCurrent-=1*Time.deltaTime;
            // HP bar image 감소
            HP.fillAmount=DataManager.Instance.playTimeCurrent/DataManager.Instance.playTimeMax;
            // HP 완전 소모
            if(DataManager.Instance.playTimeCurrent<0)
            {
                animator.SetTrigger("Die");
                mapMoveComponent.mapSpeed = 0f; // MapMove 스크립트의 mapSpeed 값을 수정
                // 게임종료
                DataManager.Instance.PlayerDie=true;
                EndPanel.SetActive(true);
                EndGame();
            }
            
        }
    }

    // 샐러드 먹을 때마다 올라가는 점수
    public void AddScore(int plusScore)
    {
        // 100점으로 설정 중
        score += plusScore;
        // 점수를 먹을 때마다 렌더링
        scoreText.text = "Score :" + score.ToString();
    }
    // 게임종료
    private void EndGame()
    {
        //게임 종료
        // TODO : 단순히 종료되는게 아니라 score를 표출하고 버튼 클릭 시 종료되게 끔 변횐 필요
        EndScoreText.text = "SCORE :" + score.ToString();
        // UnityEditor.EditorApplication.isPlaying=false;
        // Application.Quit();
    }
    
}