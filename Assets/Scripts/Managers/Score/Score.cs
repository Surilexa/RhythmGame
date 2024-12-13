using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
public class Score : MonoBehaviour
{
    [SerializeField] float fontMin = 30;
    [SerializeField] float fontMax = 50;
    [SerializeField] Color defaultColor = Color.yellow;
    [SerializeField] Color positiveColor;
    [SerializeField] Color negativeColor = Color.black;
    [SerializeField] Color hurtColor;
    [SerializeField] float fontShrinkSpeed = 2;
    [SerializeField] AnimationCurve scoreEffect;

    private int currentScore = 100;

    private TextMeshProUGUI textPro;
    private void Start()
    {
        textPro = GetComponentInChildren<TextMeshProUGUI>();
        textPro.color = defaultColor;
        textPro.fontSize = fontMin;
        textPro.fontSizeMin = fontMin;
        textPro.fontSizeMax = fontMax;
        textPro.text = currentScore.ToString();
    }
    private void Update()
    {
        if (textPro != null)
        {
            if(textPro.fontSize > fontMin)
            {
                textPro.fontSize -= Time.deltaTime * fontShrinkSpeed;
            }
        }
    }
    public void AddScore(int score)
    {
        textPro.text = (currentScore + score).ToString();
        currentScore += score;
        EnlargeScoreEffect(score, true, false);
    }
    public void RemoveScore(int score)
    {
        if(currentScore - score <= 0)
        {
            textPro.text = 0.ToString();
            currentScore = 0;
            EnlargeScoreEffect(score, false, true);
        }
        else
        {
            textPro.text = (currentScore - score).ToString();
            currentScore -= score;
            EnlargeScoreEffect(score, false, false);
        }
        

    }
    private void EnlargeScoreEffect(float score, bool add, bool hurt)
    {
        if (add)
        {
            textPro.fontSize = fontMax / 1 + scoreEffect.Evaluate(score / 1000f);
            StartCoroutine(ColorFlash(positiveColor));
        }
        else if (!add && hurt)
        {
            textPro.fontSize = fontMax/ 1 + scoreEffect.Evaluate(score / 1000f);
            StartCoroutine(ColorFlash(hurtColor));
        }
        else if(!add && !hurt) 
        {
            textPro.fontSize = fontMax / 1 + scoreEffect.Evaluate(score / 1000f);
            StartCoroutine(ColorFlash(negativeColor));
        }
    }
    private IEnumerator ColorFlash(Color color)
    {
        textPro.color = color;
        yield return new WaitForSeconds(.3f);
        textPro.color = defaultColor;
    }
}
