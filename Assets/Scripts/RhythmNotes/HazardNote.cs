using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardNote : RhythmNote
{
    //This function needs to damage the player or reduce their score.
    public override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ScoreManager.instance.RemoveScore(300);
            //SoundManager.PlaySound(SoundType.Hurt);
            Destroy(this.gameObject);
        }
    }
}
