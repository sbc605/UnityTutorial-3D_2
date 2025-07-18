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
        if (Input.GetMouseButtonDown(0)) // ���콺 ���� ��ư Ŭ��
        {
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward); // ����ϴ� �������� �̸� �����
            RaycastHit hitInfo = new RaycastHit(); // �������� ���� ����� ����

            if (Physics.Raycast(ray, out hitInfo)) // �������� ���� ������ hitInfo�� ���� ���
            {
                bulletEffect.transform.position = hitInfo.point; // hitInfo�� ������ ���� ���, point�� �浹�� ��ġ
                bulletEffect.transform.forward = hitInfo.normal;

                ps.Play();
            }
        }

            if (Input.GetMouseButtonDown(1)) // ���콺 ������ ��ư Ŭ��
        {
            GameObject bomb = Instantiate(bombFactory);
            bomb.transform.position = firePosition.transform.position;

            Rigidbody rb = bomb.GetComponent<Rigidbody>();
            rb.AddForce(Camera.main.transform.forward * throwPower, ForceMode.Impulse);
            // ī�޶��� ���� �������� �������� ��
        }
    }
}