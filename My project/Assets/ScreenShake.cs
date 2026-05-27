using UnityEngine;
using System.Collections;

public class ScreenShake : MonoBehaviour
{
    private Vector3 originalPos;

    // 专为 Send Message 准备的无参数方法（Unity 就不报错了！）
    public void PlayShake()
    {
        StopAllCoroutines(); 
        // 在这里直接定死效果：0.3秒时长，15的力度
        StartCoroutine(ShakeCoroutine(0.3f, 15f));
    }

    // 保留这个带参数的方法，以后万一你要写复杂代码还能用
    public void PlayShakeWithParams(float duration, float magnitude)
    {
        StopAllCoroutines(); 
        StartCoroutine(ShakeCoroutine(duration, magnitude));
    }

    private IEnumerator ShakeCoroutine(float duration, float magnitude)
    {
        originalPos = transform.localPosition;
        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = new Vector3(originalPos.x + x, originalPos.y + y, originalPos.z);
            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = originalPos;
    }
}