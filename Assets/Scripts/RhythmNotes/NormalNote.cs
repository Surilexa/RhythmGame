using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalNote : RhythmNote
{
    //this will be the note that the player will pick up.
    public override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ScoreManager.instance.AddScore(200);
            Destroy(this.gameObject);
        }
    }
}
