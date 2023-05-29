using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int lives = 3;
    public static int score = 0;
    public static int bricks = 0;
    public static int level = 1;
    public static int maxLevels = 3;
    public static bool isPaused = false;
    public static bool isGameOver = false;
    public static bool isGameWon = false;
    public static bool isLevelWon = false;
    public static bool isLevelLoaded = false;
    public static bool isLevelLoading = false;
    public static bool isLevelUnloading = false;
    public static bool isLevelUnloaded = false;
    public static bool isLevelStarted = false;
    public static bool isLevelStarting = false;
    public static bool isLevelEnding = false;
    public static bool isLevelEnded = false;

    // Start is called before the first frame update
    void Start()
    {
        ResetGameFlags();
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
#endif

        if (isLevelEnded)
        {
            isLevelUnloading = true;
            ResetLevelFlags();
        }

        if (isLevelEnding)
        {
            isLevelEnded = true;
            ResetLevelFlags();
        }

        if (isLevelStarted)
        {
            isLevelEnding = true;
            ResetLevelFlags();
        }

        if (isLevelStarting)
        {
            isLevelStarted = true;
            ResetLevelFlags();
        }

        if (isLevelUnloading)
        {
            isLevelUnloaded = true;
            ResetLevelFlags();
        }

        if (isLevelLoading)
        {
            isLevelLoaded = true;
            ResetLevelFlags();
        }

        if (isLevelLoaded)
        {
            isLevelStarting = true;
            ResetLevelFlags();
        }

        if (isLevelUnloaded)
        {
            isLevelLoading = true;
            ResetLevelFlags();
        }

        if (isLevelWon)
        {
            isLevelEnding = true;
            ResetLevelFlags();
        }

        if (isGameWon)
        {
            isLevelUnloading = true;
            ResetLevelFlags();
        }

        if (isGameOver)
        {
            isLevelUnloading = true;
            ResetLevelFlags();
        }

        Time.timeScale = isPaused ? 0 : 1;

        if (lives <= 0)
        {
            isGameOver = true;
        }

        if (bricks <= 0)
        {
            isLevelWon = true;
        }
    }

    private void ResetGameFlags()
    {
        isPaused = false;
        isGameOver = false;
        isGameWon = false;
    }

    private void ResetLevelFlags()
    {
        isLevelStarted = false;
        isLevelStarting = false;
        isLevelEnding = false;
        isLevelEnded = false;
        isLevelLoaded = false;
        isLevelLoading = false;
        isLevelUnloading = false;
        isLevelUnloaded = false;
    }
}
