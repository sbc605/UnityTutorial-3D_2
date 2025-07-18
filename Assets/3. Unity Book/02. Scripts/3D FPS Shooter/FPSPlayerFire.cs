using UnityEngine;

public class FPSPlayerFire : MonoBehaviour
{
    public GameObject firePosition;

    public GameObject bombFactory;

    public float throwPower = 15f;

    public GameObject bulletEffect;
    private ParticleSystem ps;

    private void Start()
    {
        ps = bulletEffect.GetComponent<ParticleSystem>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 마우스 왼쪽 버튼 클릭
        {
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward); // 사용하는 레이저를 미리 만들고
            RaycastHit hitInfo = new RaycastHit(); // 레이저에 닿은 대상을 담음

            if (Physics.Raycast(ray, out hitInfo)) // 레이저에 무언가 닿으면 hitInfo가 위에 담김
            {
                bulletEffect.transform.position = hitInfo.point; // hitInfo는 레이저 맞은 대상, point는 충돌된 위치
                bulletEffect.transform.forward = hitInfo.normal;

                ps.Play();
            }
        }

            if (Input.GetMouseButtonDown(1)) // 마우스 오른쪽 버튼 클릭
        {
            GameObject bomb = Instantiate(bombFactory);
            bomb.transform.position = firePosition.transform.position;

            Rigidbody rb = bomb.GetComponent<Rigidbody>();
            rb.AddForce(Camera.main.transform.forward * throwPower, ForceMode.Impulse);
            // 카메라의 정면 방향으로 순간적인 힘
        }
    }
}