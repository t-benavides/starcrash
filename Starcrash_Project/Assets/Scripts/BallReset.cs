using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallReset : MonoBehaviour
{
    [SerializeField] private float disappearY = -10f; // Y coordinate where the object should disappear
    [SerializeField] private Vector3 reappearPosition = Vector3.zero; // Coordinate where the object should reappear
    [SerializeField] private float shrinkSpeed = 1f; // Speed at which the object shrinks

    private Vector3 initialScale;
    private Vector3 initialPosition;
    private float shrinkTime;
    private Rigidbody2D rb;
    private CircleCollider2D circleCollider;

    private void Start()
    {
        initialScale = transform.localScale;
        initialPosition = transform.position;
        shrinkTime = initialScale.x / shrinkSpeed;
        rb = GetComponent<Rigidbody2D>();
        circleCollider = GetComponent<CircleCollider2D>();
    }

    private void Update()
    {
        if (transform.position.y <= disappearY)
        {
            ShrinkObject();
            Debug.Log("Ball Reset");
        }
    }

    private void ShrinkObject()
    {
        float shrinkAmount = Time.deltaTime / shrinkTime;
        Vector3 newScale = transform.localScale - initialScale * shrinkAmount;
        newScale = Vector3.Max(newScale, Vector3.zero);
        transform.localScale = newScale;

        if (Vector3.Distance(newScale, Vector3.zero) < 0.01f) // Check if scale is below threshold
        {
            rb.gravityScale = 0f;
            rb.velocity = Vector2.zero;
            circleCollider.enabled = false;
            transform.position = reappearPosition;
            StartCoroutine(GrowObject());
        }
    }

    private IEnumerator GrowObject()
    {
        rb.gravityScale = 0f;
        circleCollider.enabled = false;

        while (transform.localScale.x < initialScale.x)
        {
            float growAmount = Time.deltaTime / shrinkTime;
            transform.localScale += initialScale * growAmount;
            yield return null;
        }

        transform.localScale = initialScale;
        rb.gravityScale = 1f;
        circleCollider.enabled = true;
        transform.position = initialPosition;
    }
}

