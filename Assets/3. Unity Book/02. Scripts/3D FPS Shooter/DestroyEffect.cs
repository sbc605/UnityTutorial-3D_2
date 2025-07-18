using UnityEngine;

public class DestroyEffect : MonoBehaviour
{
    public float destroyTime = 2f;
    float currentTime = 0;

    void Update()
    {
        if (currentTime > destroyTime)
        {
            Destroy(gameObject);
        }

        currentTime += destroyTime;
    }
}
