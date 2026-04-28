using System.Collections;
using UnityEngine;
using TMPro; // 引入 TextMeshPro 命名空间

public class TypewriterEffect : MonoBehaviour
{
    public TextMeshProUGUI textMesh;
    public float typingSpeed = 0.03f;

    private Coroutine typingCoroutine;

    public void PlayTypewriter(string newText)
    {
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
        }
        
        typingCoroutine = StartCoroutine(TypeTextCoroutine(newText));
    }

    private IEnumerator TypeTextCoroutine(string textToType)
    {
        textMesh.text = textToType;
        textMesh.maxVisibleCharacters = 0;

        for (int i = 0; i <= textToType.Length; i++)
        {
            textMesh.maxVisibleCharacters = i;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
}