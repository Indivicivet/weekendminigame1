using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicalCube : MonoBehaviour
{
    // todo:: random cube score rate? signified by some kind of brightness, or cube size, or something?

    private float magicPhase;

    private float magicPhaseRate = 1.8f;

    private GameState gameState;

    private float tTilActive = 0.0f;
    private const float inactiveTime = 0.5f;

    private bool active {get { return tTilActive <= 0; }}

    // Start is called before the first frame update
    void Start()
    {
        // todo :: not the best way to do this? ^^'
        gameState = GameObject.Find("GameStateHolder").GetComponent<GameState>();

        magicPhase = Random.Range(0, 2 * Mathf.PI);
        magicPhaseRate = Random.Range(0.5f, 4.0f);

        tTilActive = Random.Range(0, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        magicPhase += Time.deltaTime * magicPhaseRate * (gameState.active ? 1 : 0.3f);
        var magicScore01 = (1 + Mathf.Cos(magicPhase)) / 2;
        var active_scale = active ? 1 : 0.2f;
        GetComponent<Renderer>().material.color = new Color(
            (1 - magicScore01) * active_scale,
            magicScore01 * active_scale,
            0
        );

        if (tTilActive > 0) {
            tTilActive -= Time.deltaTime;
            if (tTilActive < 0) {
                tTilActive = 0;
            }
        }
    }

    void OnMouseDown()
    {
        if (active && gameState.active) {
            gameState.score += Mathf.Cos(magicPhase);
            tTilActive = inactiveTime;
        }
    }
}
