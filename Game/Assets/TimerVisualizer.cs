using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerVisualizer : MonoBehaviour
{
    private float originalYScale;

    private GameState gameState;

    // Start is called before the first frame update
    void Start()
    {
        originalYScale = GetComponent<Transform>().localScale.y;
        // todo :: not the best way to do this? ^^'
        gameState = GameObject.Find("GameStateHolder").GetComponent<GameState>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameState.timeLeft > 0) {
            var tf = GetComponent<Transform>();
            tf.localScale = new Vector3(
                tf.localScale.x,
                originalYScale * gameState.timeLeft / gameState.totalTime,
                tf.localScale.z
            );
        } else {
            GetComponent<MeshRenderer>().enabled = false;
        }
    }
}
