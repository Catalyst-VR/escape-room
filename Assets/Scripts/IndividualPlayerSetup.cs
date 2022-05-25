using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class IndividualPlayerSetup : MonoBehaviour
{

    public PhotonView view;

    [SerializeField]
    Vector3[] startingPositions;

    [SerializeField]
    Vector3[] startingRotations;


    [Header("Components To Disable")]

    [SerializeField]
    Camera camera;

    [SerializeField]
    XRRayInteractor[] rayInteractors;

    [SerializeField]
    UnityEngine.SpatialTracking.TrackedPoseDriver poseDriver;

    [SerializeField]
    ActionBasedController[] controllers;

    [SerializeField]
    XRDirectInteractor[] directInteractors;

    [SerializeField]
    GameObject locomotionSystem;


    int thisPlayerID;

    // Start is called before the first frame update
    void Awake()
    {

        thisPlayerID = 0;


        thisPlayerID = Int32.Parse(view.ViewID.ToString()[0].ToString());


        if (!view.IsMine)
        {
            DisablePlayer();
        }

        SetStartingPosition();

    }

    void DisablePlayer()
    {
        camera.enabled = false;

        foreach (var item in rayInteractors)
        {
            item.enabled = false;
        }

        poseDriver.enabled = false;

        foreach (var item in controllers)
        {
            item.enabled = false;
        }

        foreach (var item in directInteractors)
        {
            item.enabled = false;
        }

        locomotionSystem.SetActive(false);

    }


    void SetStartingPosition()
    {

        transform.position = startingPositions[thisPlayerID - 1];

        transform.rotation = Quaternion.Euler(startingRotations[thisPlayerID - 1]);

    }

    
}
