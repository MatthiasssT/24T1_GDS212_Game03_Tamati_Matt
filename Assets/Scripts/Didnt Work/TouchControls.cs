////------------------------------------------------------------------------------
//// <auto-generated>
////     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
////     version 1.7.0
////     from Assets/Scripts/TouchControls.inputactions
////
////     Changes to this file may cause incorrect behavior and will be lost if
////     the code is regenerated.
//// </auto-generated>
////------------------------------------------------------------------------------

//using System;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine.InputSystem;
//using UnityEngine.InputSystem.Utilities;

//public partial class @TouchControls: IInputActionCollection2, IDisposable
//{
//    public InputActionAsset asset { get; }
//    public @TouchControls()
//    {
//        asset = InputActionAsset.FromJson(@"{
//    ""name"": ""TouchControls"",
//    ""maps"": [
//        {
//            ""name"": ""Touch"",
//            ""id"": ""88016eb8-d869-4933-b44f-b9ec5382491f"",
//            ""actions"": [
//                {
//                    ""name"": ""PrimaryContact"",
//                    ""type"": ""PassThrough"",
//                    ""id"": ""e2b7048d-d4b2-4481-a1f6-5a225639f58a"",
//                    ""expectedControlType"": ""Button"",
//                    ""processors"": """",
//                    ""interactions"": """",
//                    ""initialStateCheck"": false
//                },
//                {
//                    ""name"": ""PrimaryPosition"",
//                    ""type"": ""PassThrough"",
//                    ""id"": ""839dac29-80b3-4643-a497-fa85c2c899a0"",
//                    ""expectedControlType"": ""Vector2"",
//                    ""processors"": """",
//                    ""interactions"": """",
//                    ""initialStateCheck"": false
//                }
//            ],
//            ""bindings"": [
//                {
//                    ""name"": """",
//                    ""id"": ""18074049-6ae9-4771-b6d0-30e55479c79c"",
//                    ""path"": ""<Touchscreen>/primaryTouch/press"",
//                    ""interactions"": ""Press"",
//                    ""processors"": """",
//                    ""groups"": """",
//                    ""action"": ""PrimaryContact"",
//                    ""isComposite"": false,
//                    ""isPartOfComposite"": false
//                },
//                {
//                    ""name"": """",
//                    ""id"": ""d1eca7a8-1a0b-4df3-9b38-af1f452068d2"",
//                    ""path"": ""<Touchscreen>/primaryTouch/position"",
//                    ""interactions"": """",
//                    ""processors"": """",
//                    ""groups"": """",
//                    ""action"": ""PrimaryPosition"",
//                    ""isComposite"": false,
//                    ""isPartOfComposite"": false
//                }
//            ]
//        }
//    ],
//    ""controlSchemes"": []
//}");
//        // Touch
//        m_Touch = asset.FindActionMap("Touch", throwIfNotFound: true);
//        m_Touch_PrimaryContact = m_Touch.FindAction("PrimaryContact", throwIfNotFound: true);
//        m_Touch_PrimaryPosition = m_Touch.FindAction("PrimaryPosition", throwIfNotFound: true);
//    }

//    public void Dispose()
//    {
//        UnityEngine.Object.Destroy(asset);
//    }

//    public InputBinding? bindingMask
//    {
//        get => asset.bindingMask;
//        set => asset.bindingMask = value;
//    }

//    public ReadOnlyArray<InputDevice>? devices
//    {
//        get => asset.devices;
//        set => asset.devices = value;
//    }

//    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

//    public bool Contains(InputAction action)
//    {
//        return asset.Contains(action);
//    }

//    public IEnumerator<InputAction> GetEnumerator()
//    {
//        return asset.GetEnumerator();
//    }

//    IEnumerator IEnumerable.GetEnumerator()
//    {
//        return GetEnumerator();
//    }

//    public void Enable()
//    {
//        asset.Enable();
//    }

//    public void Disable()
//    {
//        asset.Disable();
//    }

//    public IEnumerable<InputBinding> bindings => asset.bindings;

//    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
//    {
//        return asset.FindAction(actionNameOrId, throwIfNotFound);
//    }

//    public int FindBinding(InputBinding bindingMask, out InputAction action)
//    {
//        return asset.FindBinding(bindingMask, out action);
//    }

//    // Touch
//    private readonly InputActionMap m_Touch;
//    private List<ITouchActions> m_TouchActionsCallbackInterfaces = new List<ITouchActions>();
//    private readonly InputAction m_Touch_PrimaryContact;
//    private readonly InputAction m_Touch_PrimaryPosition;
//    public struct TouchActions
//    {
//        private @TouchControls m_Wrapper;
//        public TouchActions(@TouchControls wrapper) { m_Wrapper = wrapper; }
//        public InputAction @PrimaryContact => m_Wrapper.m_Touch_PrimaryContact;
//        public InputAction @PrimaryPosition => m_Wrapper.m_Touch_PrimaryPosition;
//        public InputActionMap Get() { return m_Wrapper.m_Touch; }
//        public void Enable() { Get().Enable(); }
//        public void Disable() { Get().Disable(); }
//        public bool enabled => Get().enabled;
//        public static implicit operator InputActionMap(TouchActions set) { return set.Get(); }
//        public void AddCallbacks(ITouchActions instance)
//        {
//            if (instance == null || m_Wrapper.m_TouchActionsCallbackInterfaces.Contains(instance)) return;
//            m_Wrapper.m_TouchActionsCallbackInterfaces.Add(instance);
//            @PrimaryContact.started += instance.OnPrimaryContact;
//            @PrimaryContact.performed += instance.OnPrimaryContact;
//            @PrimaryContact.canceled += instance.OnPrimaryContact;
//            @PrimaryPosition.started += instance.OnPrimaryPosition;
//            @PrimaryPosition.performed += instance.OnPrimaryPosition;
//            @PrimaryPosition.canceled += instance.OnPrimaryPosition;
//        }

//        private void UnregisterCallbacks(ITouchActions instance)
//        {
//            @PrimaryContact.started -= instance.OnPrimaryContact;
//            @PrimaryContact.performed -= instance.OnPrimaryContact;
//            @PrimaryContact.canceled -= instance.OnPrimaryContact;
//            @PrimaryPosition.started -= instance.OnPrimaryPosition;
//            @PrimaryPosition.performed -= instance.OnPrimaryPosition;
//            @PrimaryPosition.canceled -= instance.OnPrimaryPosition;
//        }

//        public void RemoveCallbacks(ITouchActions instance)
//        {
//            if (m_Wrapper.m_TouchActionsCallbackInterfaces.Remove(instance))
//                UnregisterCallbacks(instance);
//        }

//        public void SetCallbacks(ITouchActions instance)
//        {
//            foreach (var item in m_Wrapper.m_TouchActionsCallbackInterfaces)
//                UnregisterCallbacks(item);
//            m_Wrapper.m_TouchActionsCallbackInterfaces.Clear();
//            AddCallbacks(instance);
//        }
//    }
//    public TouchActions @Touch => new TouchActions(this);
//    public interface ITouchActions
//    {
//        void OnPrimaryContact(InputAction.CallbackContext context);
//        void OnPrimaryPosition(InputAction.CallbackContext context);
//    }
//}