using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    float duration = 0.3f;
    float magnitude = 0.3f;
    
    public IEnumerator Shake()
    {
        Vector3 originalPos = transform.localPosition;
        float elapsed = 0.0f;

        while(elapsed < duration)
        {
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = new Vector3(originalPos.x, originalPos.y + y, originalPos.z);
            elapsed += Time.deltaTime;
            yield return null;

        }

        transform.localPosition = originalPos;
    }
}
