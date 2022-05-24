using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class TeleportationManager : MonoBehaviour
{

    [SerializeField] private InputActionAsset actionAsset;

    [SerializeField] TeleportationProvider teleportationProvider;



    [Header("Interactors")]

    [SerializeField] XRRayInteractor leftRayInteractor;

    [SerializeField] XRRayInteractor rightRayInteractor;


    private bool _isActive;

    // Start is called before the first frame update
    void Start()
    {

        leftRayInteractor.enabled = false;
        rightRayInteractor.enabled = false;

        var activateRight = actionAsset.FindActionMap("XRI RightHand Locomotion").FindAction("Teleport Mode Activate");
        activateRight.Enable();
        activateRight.performed += OnTeleportActivateRight;

        var cancelRight = actionAsset.FindActionMap("XRI RightHand Locomotion").FindAction("Teleport Mode Cancel");
        cancelRight.Enable();
        cancelRight.performed += OnTeleportCancelRight;

        var moveRight = actionAsset.FindActionMap("XRI RightHand Locomotion").FindAction("Teleport Select");
        moveRight.Enable();
        moveRight.performed += OnTeleportMoveRight;


        var activateLeft = actionAsset.FindActionMap("XRI LeftHand Locomotion").FindAction("Teleport Mode Activate");
        activateLeft.Enable();
        activateLeft.performed += OnTeleportActivateLeft;

        var cancelLeft = actionAsset.FindActionMap("XRI LeftHand Locomotion").FindAction("Teleport Mode Cancel");
        cancelLeft.Enable();
        cancelLeft.performed += OnTeleportCancelLeft;

        var moveLeft = actionAsset.FindActionMap("XRI LeftHand Locomotion").FindAction("Teleport Select");
        moveLeft.Enable();
        moveLeft.performed += OnTeleportMoveLeft;


    }

    void OnTeleportMoveRight(InputAction.CallbackContext context)
    {
        if (!_isActive)
        {
            return;
        }

        if (!rightRayInteractor.TryGetCurrent3DRaycastHit(out RaycastHit hit))
        {
            rightRayInteractor.enabled = false;
            _isActive = false;
            return;
        }

        if (hit.transform.gameObject.layer == 6)
        {



            TeleportRequest request = new TeleportRequest()
            {
                destinationPosition = hit.point,
            };

            teleportationProvider.QueueTeleportRequest(request);

        }

        rightRayInteractor.enabled = false;
        leftRayInteractor.enabled = false;
        _isActive = false;
    }

    void OnTeleportActivateRight(InputAction.CallbackContext context)
    {
        rightRayInteractor.enabled = true;
        _isActive = true;   
    }

    void OnTeleportCancelRight(InputAction.CallbackContext context)
    {
        rightRayInteractor.enabled = false;
        leftRayInteractor.enabled = false;
        _isActive = false;
    }



    void OnTeleportMoveLeft(InputAction.CallbackContext context)
    {
        if (!_isActive)
        {
            return;
        }

        if (!leftRayInteractor.TryGetCurrent3DRaycastHit(out RaycastHit hit))
        {
            leftRayInteractor.enabled = false;
            _isActive = false;
            return;
        }


        if (hit.transform.gameObject.layer == 6)
        {



            TeleportRequest request = new TeleportRequest()
            {
                destinationPosition = hit.point,
            };

            teleportationProvider.QueueTeleportRequest(request);

        }

        leftRayInteractor.enabled = false;
        rightRayInteractor.enabled = false;
        _isActive = false;
    }

    void OnTeleportActivateLeft(InputAction.CallbackContext context)
    {
        leftRayInteractor.enabled = true;
        _isActive = true;
    }

    void OnTeleportCancelLeft(InputAction.CallbackContext context)
    {
        leftRayInteractor.enabled = false;
        rightRayInteractor.enabled = false;
        _isActive = false;
    }

}
