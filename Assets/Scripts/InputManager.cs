using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[DefaultExecutionOrder(-1)]
public class InputManager : MonoBehaviourSingleton<InputManager>
{
    #region Events
    public delegate void StartTouch(Vector2 position, float time);
    public event StartTouch OnStartTouch;
    public delegate void EndTouch(Vector2 position, float time);
    public event EndTouch OnEndTouch;
    #endregion

    private TouchControls touchControls;
    private Camera mainCamera;

    private void Awake()
    {
        touchControls = new TouchControls();
        mainCamera = Camera.main;
    }
    private void OnEnable()
    {
        touchControls.Enable();
    }
    private void OnDisable()
    {
        touchControls.Disable();
    }


    // Start is called before the first frame update
    void Start()
    {
        touchControls.Touch.PrimaryContact.started += ctx => StartTouchPrimary(ctx);
        touchControls.Touch.PrimaryContact.canceled += ctx => EndTouchPrimary(ctx);
    }

    private Vector2 DetectObject()
    {
        Ray ray = mainCamera.ScreenPointToRay(touchControls.Touch.PrimaryPosition.ReadValue<Vector2>());
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit))
        {
            if(hit.collider != null)
            {
                Debug.Log("3D Hit: " + hit.collider.tag);
                return hit.point;
            }
        }
        return Vector2.zero;
    }

    private void StartTouchPrimary(InputAction.CallbackContext context)
    {
        Vector2 touchPosition = DetectObject();
        if (OnStartTouch != null && touchPosition != Vector2.zero) OnStartTouch(touchPosition, (float)context.startTime);
        
    }

    private void EndTouchPrimary(InputAction.CallbackContext context)
    {
        Vector2 touchPosition = DetectObject();
        if (OnStartTouch != null && touchPosition != Vector2.zero) OnStartTouch(touchPosition, (float)context.time);

    }

    public Vector2 PrimaryPosition()
    {
        return touchControls.Touch.PrimaryPosition.ReadValue<Vector2>();
    }
}
