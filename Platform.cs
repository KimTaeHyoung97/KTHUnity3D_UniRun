using UnityEngine;

// 발판으로서 필요한 동작을 담은 스크립트
public class Platform : MonoBehaviour {
    public GameObject[] obstacles; // 장애물 오브젝트들
    public GameObject[] coins; // 코인 오브젝트들
    private bool isstepped = false; // 플레이어 캐릭터가 밟았었는가

    // 컴포넌트가 활성화될때 마다 매번 실행되는 메서드
    private void OnEnable() {
        // 발판을 리셋하는 처리
        isstepped = false;

        if (GameManager.instance.isGameover)
        {
            return;
        }

        for(int i = 0; i < obstacles.Length; i++)
        {
            //for (int j = 0; j < coins.Length; j++)
            //{
                if (Random.Range(0, obstacles.Length) == 0/* || Random.Range(0, coins.Length) == 0*/)
                {
                    obstacles[i].SetActive(true);
                    //coins[j].SetActive(true);
                }
                else
                {
                    obstacles[i].SetActive(false);
                    //coins[i].SetActive(false);
                }
            //}
        }
        for (int i = 0; i < coins.Length; i++)
        {
            if (Random.Range(0, coins.Length) == 0)
            {
                coins[i].SetActive(true);
            }
            else
            {
                coins[i].SetActive(false);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // 플레이어 캐릭터가 자신을 밟았을때
        if (collision.collider.CompareTag("Player") && !isstepped)
        {
            isstepped = true;
            GameManager.instance.SkillGuage();//스킬게이즈 25퍼센트씩 상승
            //GameManager.instance.AddScore(1);
        }
    }
}