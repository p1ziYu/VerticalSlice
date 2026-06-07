using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HoverBorderController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Material mat;
    private float targetAlpha = 0f;
    private float currentAlpha = 0f;
    
    [Header("发光渐变速度")]
    public float speed = 15f; 

    void Start()
    {
    Image img = GetComponent<Image>();
    img.material = new Material(img.material);
    mat = img.material;
    
    mat.SetFloat("_HoverAlpha", 0f); 
    }

    void Update()
    {
        if (Mathf.Abs(currentAlpha - targetAlpha) > 0.001f)
        {
            currentAlpha = Mathf.Lerp(currentAlpha, targetAlpha, Time.deltaTime * speed);
            mat.SetFloat("_HoverAlpha", currentAlpha); 
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        targetAlpha = 1f; 
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        targetAlpha = 0f; 
    }
}