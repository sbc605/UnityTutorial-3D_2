using UnityEngine;

public class BombAction : MonoBehaviour
{
    public GameObject bombEffect;

    private void OnCollisionEnter(Collision collision) // 수류탄이 충돌할 경우
    {
        GameObject eff = Instantiate(bombEffect); // 파티클 생성
        eff.transform.position = transform.position; // 파티클 위치 초기화

        Destroy(gameObject); // 충돌시 폭탄 사라짐
    }
}
