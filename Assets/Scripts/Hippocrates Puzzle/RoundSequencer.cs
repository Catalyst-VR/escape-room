using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RoundSequencer : MonoBehaviour
{
    [SerializeField]
    Round[] rounds;


    [SerializeField]
    TMP_Text centreText;


    public static RoundSequencer Instance;


    int currentRound = 0;

    int currentElement = 0;

    bool roundInProgress = true;


    private void Awake()
    {
        Instance = this;
    }

    public void CheckVial(string vialID)
    {
        if(rounds[currentRound].correctFormula[currentElement] == vialID)
        {
            currentElement++;
            BowlVisuals.Instance.VialCorrect();

            if (currentElement == rounds[currentRound].correctFormula.Length)
            {
                FormulaComplete();
            }
        }
        else
        {
            FormulaFailed();
        }

    }


    void FormulaComplete()
    {
        currentElement = 0;
        roundInProgress = false;
    }

    void FormulaFailed()
    {
        currentElement = 0;
        BowlVisuals.Instance.VialIncorrect();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha0))
        {
            roundInProgress = false;
        }
    }

    private IEnumerator Start()
    {

        for (currentRound = currentRound; currentRound < rounds.Length; currentRound++)
        {
            string formulaText = "";
            int i;
            for (i = 0; i < rounds[currentRound].correctFormula.Length-1; i++)
            {
                formulaText += rounds[currentRound].correctFormula[i] + " + ";
            }
            formulaText += rounds[currentRound].correctFormula[i];


            centreText.text = formulaText;


            yield return StartCoroutine(RiddleController.Instance.SetRiddles(rounds[currentRound]));


            while (roundInProgress)
            {
                yield return null;
            }
            roundInProgress = true;


            yield return StartCoroutine(RiddleController.Instance.ResetRiddles());


        }



        centreText.text = "END";


    }



}
