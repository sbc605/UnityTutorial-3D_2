using System.Collections;
using UnityEngine;

public class CrossBow : MonoBehaviour
{
    public GameObject arrowPrefab;
    public Transform shootTf;

    private bool isShoot;

    private void Update()
    {
        Ray ray = new Ray(shootTf.position, shootTf.forward);
        RaycastHit hit; // ������ ���� ���

        bool isTargeting = Physics.Raycast(ray, out hit); // ������� true, �ƴϸ� false

        Debug.DrawRay(shootTf.position, shootTf.forward * 100, Color.green); // �߻� ��ġ���� ������ ��

        if (isTargeting && !isShoot)
        {
            StartCoroutine(ShootRoutine());            
        }
    }

    IEnumerator ShootRoutine()
    {
        isShoot = true;

        GameObject arrow = Instantiate(arrowPrefab, transform);

        Quaternion rot = Quaternion.Euler(new Vector3(90, 0, 0));

        arrow.transform.SetPositionAndRotation(shootTf.position, rot);
        //arrow.transform.position = shootTf.position;
        //arrow.transform.rotation = Quaternion.identity;

        // ����: GameObject arrow = Instantiate(arrowPrefab, shootTf.position, Quaternion.identity);


        yield return new WaitForSeconds(3f);
        isShoot = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(shootTf.position, shootTf.forward * 100f);
    }
}
