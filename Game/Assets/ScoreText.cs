using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreText : MonoBehaviour
{
    private GameState gameState;

    // Start is called before the first frame update
    void Start()
    {
        // probably not the way to do this
        gameState = GameObject.Find("GameStateHolder").GetComponent<GameState>();
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<TextMeshPro>().SetText(gameState.score.ToString("F2"));
    }
}
