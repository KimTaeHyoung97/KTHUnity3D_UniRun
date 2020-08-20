using UnityEngine;

// 발판으로서 필요한 동작을 담은 스크립트
public class Platform : MonoBehaviour 
{
    public GameObject[] obstacles; // 장애물 오브젝트들
    private bool isstepped = false; // 플레이어 캐릭터가 밟았었는가

    // 컴포넌트가 활성화될때 마다 매번 실행되는 메서드
    private void OnEnable() //처음에 생성/실행될때,비활성화에서 활성화될때
    {// 발판을 리셋하는 처리
        isstepped = false;

        for(int i = 0; i <obstacles.Length; i++)
        {
            if(Random.Range(0, obstacles.Length) == 0)//3분의 1확률
            {
                obstacles[i].SetActive(true);
            }
            else//3분의2확률
            {
                obstacles[i].SetActive(false);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {// 플레이어 캐릭터가 자신을 밟았을때 점수를 추가하는 처리
        if(collision.collider.CompareTag("Player") && !isstepped)
        {
            isstepped = true;//밟음
            GameManager.instance.AddScore(1);
        }
    }
}