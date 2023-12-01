using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UFO : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Rocket"))
        {
            Destroy(collision.gameObject);
            GameOver.EndGame();
        }
        else
        {
            Destroy(gameObject);
            ScoreKeeper.AddToScore(1);
        }
    }

    private void OnBecameInvisible()
    {
        var y = transform.position.y;
        if (y < -5)
            GameOver.EndGame();
        Destroy(gameObject);
    }
}

