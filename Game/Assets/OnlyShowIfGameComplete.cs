using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnlyShowIfGameComplete : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    private GameState gameState;
    
    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();

        // todo :: not the best way to do this? ^^'
        gameState = GameObject.Find("GameStateHolder").GetComponent<GameState>();
    }

    // Update is called once per frame
    void Update()
    {
        meshRenderer.enabled = !gameState.active;
    }
}
