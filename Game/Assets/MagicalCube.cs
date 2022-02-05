using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicalCube : MonoBehaviour
{
    // todo:: random cube score rate? signified by some kind of brightness, or cube size, or something?
    
    [SerializeField]
    private float magicPhase;

    [SerializeField]
    private float magicPhaseRate = 1.8f;

    private GameState gameState;

    // Start is called before the first frame update
    void Start()
    {
        // todo :: not the best way to do this? ^^'
        gameState = GameObject.Find("GameStateHolder").GetComponent<GameState>();

        magicPhase = Random.Range(0, 2 * Mathf.PI);
        magicPhaseRate = Random.Range(0.5f, 3.5f);
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
