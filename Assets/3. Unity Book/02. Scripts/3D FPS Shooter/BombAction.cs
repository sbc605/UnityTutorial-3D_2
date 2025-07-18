using UnityEngine;

public class BombAction : MonoBehaviour
{
    public GameObject bombEffect;

    private void OnCollisionEnter(Collision collision) // ����ź�� �浹�� ���
    {
        GameObject eff = Instantiate(bombEffect); // ��ƼŬ ����
        eff.transform.position = transform.position; // ��ƼŬ ��ġ �ʱ�ȭ

        Destroy(gameObject); // �浹�� ��ź �����
    }
}
