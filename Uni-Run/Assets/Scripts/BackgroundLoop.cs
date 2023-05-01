using UnityEngine;

// 왼쪽 끝으로 이동한 배경을 오른쪽 끝으로 재배치하는 스크립트
public class BackgroundLoop : MonoBehaviour {
    private float width; // 배경의 가로 길이

    private void Awake()            // Start 메서드처럼 1회 자동실행되는 이벤트 메서드, 단 Start보다 1프레임 빠름
    {
        // 배경의 가로길이를 구하는 처리
        // BoxCollider2D 컴포넌트의 Size 필드의 x 값을 가로 길이로 사용
        BoxCollider2D backgroundCollider = GetComponent<BoxCollider2D>();
        width = backgroundCollider.size.x;

        // BoxCollider2D 컴포넌트가 스프라이트에 맞춰 크기를 자동으로 설정해준다
    }

    private void Update() 
    {
        // 현재 위치가 원점에서 왼쪽으로 width 이상 이동했을때 위치를 재배치
        if(transform.position.x <= -width)
        {
            Reposition();
        }
    }

    // 위치를 리셋하는 메서드
    private void Reposition() 
    {
        // 현재 위치에서 오른쪽으로 가로 길이 * 2만큼 이동
        Vector2 offset = new Vector2(width * 2f, 0);
        transform.position = (Vector2) transform.position + offset;
        // transform.position은 Vector3 타입이기 떄문에 Vector2로 명시적 형변환
    }
}