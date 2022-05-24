using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VialCollisionCheck : MonoBehaviour
{

    public string ID;

    Rigidbody rigibody;

    Vector3 startingPos;
    Quaternion startingRot;

    List<Coroutine> countdownRoutines = new List<Coroutine>();

    [SerializeField]
    GameObject destroyParticle;

    // Start is called before the first frame update
    void Start()
    {
        startingPos = transform.position;
        startingRot = transform.rotation;
        rigibody = GetComponent<Rigidbody>();
    }


    void ResetPos()
    {
        Instantiate(destroyParticle, transform.position, new Quaternion(0,0,0,0));
        rigibody.velocity = new Vector3(0,0,0);
        transform.position = startingPos;
        transform.rotation = startingRot;
        rigibody.velocity = new Vector3(0, 0, 0);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.layer == 7)
        {
            ResetPos();
            RoundSequencer.Instance.CheckVial(ID);
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 6 || collision.gameObject.layer == 8)
        {
            countdownRoutines.Add(StartCoroutine(Countdown()));
        }
    }

    IEnumerator Countdown()
    {        
        yield return new WaitForSeconds(5f);

        ResetPos();
    }


    private void OnCollisionExit(Collision collision)
    {

        if (collision.gameObject.layer == 6)
        {

            foreach (var item in countdownRoutines)
            {
                StopCoroutine(item);
            }

            countdownRoutines.Clear();

        }
        
    }
}
