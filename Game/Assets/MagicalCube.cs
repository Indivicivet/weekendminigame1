using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicalCube : MonoBehaviour
{
    [SerializeField]
    private float magicPhase = 0.3f;

    [SerializeField]
    private float magicPhaseRate = 1.8f;

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
        magicPhase += Time.deltaTime * magicPhaseRate;
        var magicScore01 = (1 + Mathf.Cos(magicPhase)) / 2;
        GetComponent<Renderer>().material.color = new Color(1 - magicScore01, magicScore01, 0);
    }

    void OnMouseDown()
    {
        gameState.score += Mathf.Cos(magicPhase);
    }
}
