using UnityEngine;

// 발판으로서 필요한 동작을 담은 스크립트
public class Platform : MonoBehaviour {
    public GameObject[] obstacles; // 장애물 오브젝트들
    private bool stepped = false; // 플레이어 캐릭터가 밟았었는가

    // Awake나 Start와 비슷하지만
    // 컴포넌트가 활성화될때 마다 매번 실행되는 메서드이다
    // 게임 오브젝트가 활성화/비활성화되면 게임 오브젝트의 모든 컴포넌트들도 활성화/비활성화됨
    // 주로 게임 오브젝트가 활성화될 때마다 상태를 리셋하는 기능 구현할 때 이용
    private void OnEnable() {
        // 발판을 리셋하는 처리

        // 밟힘 상태를 리셋
        stepped = false;

        // 장애물의 수만큼 루프
        for(int i = 0; i < obstacles.Length; i++)       // obstacles 배열에 있는 장애물 게임 오브젝트들을 순서대로 접근
        {
            // 현재 순번의 장애물을 1/3의 확률로 활서오하
            if(Random.Range(0, 3) == 0)         // 0, 1, 2 중에서 한 숫자를 랜덤으로 반환
            {
                obstacles[i].SetActive(true);
            }
            else
            {
                obstacles[i].SetActive(false);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision) {
        // 플레이어 캐릭터가 자신을 밟았을때 점수를 추가하는 처리

        // 충돌한 상대방의 태그가 Player이고 이전에 플레이어 캐릭터가 밟지 않았다면
        if(collision.collider.tag == "Player" && !stepped)
        {
            // !stepped를 통해 같은 발판을 두번 이상 밟을 때 점수증가를 방지 + 같은 발판을 다시 밟을 때 if문이 실행되지않음

            // 점수를 추가하고 밟힘 상태를 참으로 변경
            stepped = true;
            GameManager.instance.AddScore(1);
        }
    }
}