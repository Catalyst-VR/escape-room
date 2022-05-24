using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RiddleController : MonoBehaviour
{

    Vector3 origin = new Vector3(0, 0, 0);

    Vector3 reveal= new Vector3(0, 0.53f, 0);

    [SerializeField]
    TMP_Text[] formulas;

    [SerializeField]
    TMP_Text[] instructions;

    public static RiddleController Instance;
    private void Awake()
    {
        Instance = this;
    }


    public IEnumerator SetRiddles(Round currentRound)
    {

        for (int i = 0; i < currentRound.formulas.Length; i++)
        {
            formulas[i].text = currentRound.formulas[i];
        }

        for (int i = 0; i < currentRound.instructions.Length; i++)
        {
            instructions[i].text = currentRound.instructions[i];
        }


        while (transform.position != reveal)
        {
            transform.position = Vector3.Lerp(transform.position, reveal, 0.008f);
            yield return null;
        }

    }

    public IEnumerator ResetRiddles()
    {

        while (transform.position != origin)
        {
            transform.position = Vector3.Lerp(transform.position, origin, 0.008f);
            yield return null;
        }

        print("bill");
    }

        // Update is called once per frame
        void Update()
    {
        
    }
}
