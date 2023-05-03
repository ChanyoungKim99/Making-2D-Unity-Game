using UnityEngine;

// 게임 오브젝트를 계속 왼쪽으로 움직이는 스크립트
public class ScrollingObject : MonoBehaviour {
    public float speed = 10f; // 이동 속도

    private void Update() {
        // 게임오버가 아니라면
        if(!GameManager.instance.isGameover)
        {
            // 초당 speed의 속도로 왼쪽으로 평행이동
            transform.Translate(Vector3.left * speed * Time.deltaTime);     // 싱글턴 전역변수로 GameManager 오브젝트에 접근
            // Translate 메서드 = 평행이동 메서드
            // Vector3.left = (-1,0,0)인 방향벡터
        }
    }
}