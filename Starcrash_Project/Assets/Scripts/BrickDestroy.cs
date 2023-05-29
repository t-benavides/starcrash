using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickDestroy : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Pinball")
        {
            GameManager.bricks--;
            GameManager.score += 100;
            Destroy(gameObject);
        }
    }
}
