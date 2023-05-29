using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomColor : MonoBehaviour
{
    [SerializeField] Color32 restColor = new Color32(0, 0, 0, 0);
    [SerializeField] float transitionDuration = 1f; // Duration of the color transition in seconds
    [SerializeField] float fadeDuration = 1f; // Duration of the fade back to black in seconds
    [SerializeField] float delayBeforeFade = 2f; // Delay before the fade starts in seconds

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
            targetColor = GetRandomColor();
            transitionStartTime = Time.time;
            fadeStartTime = transitionStartTime + delayBeforeFade;
            Debug.Log("Bumper Hit");
        }
    }

    private Color32 GetRandomColor()
    {
        byte r = (byte)Random.Range(0, 256);
        byte g = (byte)Random.Range(0, 256);
        byte b = (byte)Random.Range(0, 256);
        return new Color32(r, g, b, 255);
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
