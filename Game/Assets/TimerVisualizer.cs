using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerVisualizer : MonoBehaviour
{
    private float maxScale = 1.5f;

    private GameState gameState;

    // Start is called before the first frame update
    void Start()
    {
        // todo :: not the best way to do this? ^^'
        gameState = GameObject.Find("GameStateHolder").GetComponent<GameState>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameState.timeLeft > 0) {
            GetComponent<Transform>().localScale = new Vector3(1, maxScale * gameState.timeLeft / gameState.totalTime, 1);
        } else {
            GetComponent<MeshRenderer>().enabled = false;
        }
    }
}
