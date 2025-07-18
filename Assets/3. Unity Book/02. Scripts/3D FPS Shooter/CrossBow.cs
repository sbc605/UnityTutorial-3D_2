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
        RaycastHit hit; // 레이저 닿은 대상

        bool isTargeting = Physics.Raycast(ray, out hit); // 닿았으면 true, 아니면 false

        Debug.DrawRay(shootTf.position, shootTf.forward * 100, Color.green); // 발사 위치에서 레이저 쏨

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

        // 같음: GameObject arrow = Instantiate(arrowPrefab, shootTf.position, Quaternion.identity);


        yield return new WaitForSeconds(3f);
        isShoot = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(shootTf.position, shootTf.forward * 100f);
    }
}
