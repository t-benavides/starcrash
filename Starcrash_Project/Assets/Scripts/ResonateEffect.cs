using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ResonateEffect : MonoBehaviour
{
    [SerializeField] Color32 restColor = new Color32(255, 255, 255, 0);
    [SerializeField] Color32 activeColor = new Color32(255, 255, 255, 255);
    [SerializeField] float transitionDuration = 0f; // Duration of the color transition in seconds
    [SerializeField] float fadeDuration = 3f; // Duration of the fade back to black in seconds
    [SerializeField] float delayBeforeFade = 0f; // Delay before the fade starts in seconds

    private SpriteRenderer spriteRenderer;
    private Color32 initialColor;
    private Color32 targetColor;
    private float transitionStartTime;
    private float fadeStartTime;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = restColor;
        initialColor = restColor;
        targetColor = restColor;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Pinball"))
        {
            initialColor = spriteRenderer.color;
            targetColor = activeColor;
            transitionStartTime = Time.time;
            fadeStartTime = transitionStartTime + delayBeforeFade;
            Debug.Log("Bumper Hit");
        }
    }

    private void Update()
    {
        if (spriteRenderer.color != targetColor)
        {
            float elapsedTime = Time.time - transitionStartTime;
            float t = Mathf.Clamp01(elapsedTime / transitionDuration);
            spriteRenderer.color = Color32.Lerp(initialColor, targetColor, t);

            if (Time.time >= fadeStartTime)
            {
                float fadeElapsedTime = Time.time - fadeStartTime;
                float fadeT = Mathf.Clamp01(fadeElapsedTime / fadeDuration);
                spriteRenderer.color = Color32.Lerp(targetColor, restColor, fadeT);
            }
        }
    }
}