using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlVisuals : MonoBehaviour
{


    [SerializeField]
    GameObject correctParticle;

    [SerializeField]
    GameObject incorrectParticle;


    public static BowlVisuals Instance;

    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
    }


    public void VialCorrect()
    {
        Instantiate(correctParticle, transform.position, new Quaternion(0, 0, 0, 0));
    }

    public void VialIncorrect()
    {
        Instantiate(incorrectParticle, transform.position, new Quaternion(0, 0, 0, 0));
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
