using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreText : MonoBehaviour
{
    private GameState gameState;

    private Vector3 referenceScale;

    // Start is called before the first frame update
    void Start()
    {
        // probably not the way to do this
        gameState = GameObject.Find("GameStateHolder").GetComponent<GameState>();

        referenceScale = GetComponent<Transform>().localScale;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<TextMeshPro>().SetText("Score: " + gameState.score.ToString("F2"));

        var rescale = 0.5f + 0.8f * Mathf.Max(Mathf.Atan(gameState.score * 0.17f) / (Mathf.PI * 0.5f), 0.0f);
        GetComponent<Transform>().localScale = referenceScale * rescale;
    }
}
