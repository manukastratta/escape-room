using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RHL.Scripts.InputSystem
{
    public class RHControllerManager : MonoBehaviour
    {
        public static RHControllerManager Instance;

        [SerializeField]
        private KeyCode simulatedTriggerKey = KeyCode.Space;

        [SerializeField]
        private KeyCode simulatedTouchpadKey = KeyCode.M;

        public Dictionary<OVRInput.Controller, RHControllerBase> ControllerMap;

        /// <summary>
        /// Subscribes a controller to the manager so the manager has a reference to it.
        /// </summary>
        /// <param name="controller">The controller to add to the manager's list of controllers.</param>
        public void AddController(RHControllerBase controller)
        {
            ControllerMap.Add(controller.ControllerType, controller);
        }

        // Only one instance of the ControllerManager should exist in the scene
        void Awake()
        {
            if (Instance != null)
            {
                Destroy(this);
            }
            else
            {
                Instance = this;
            }
            ControllerMap = new Dictionary<OVRInput.Controller, RHControllerBase>();
        }

        /// <summary>
        /// True during the frame that the trigger was pulled
        /// on the primary controller. 
        /// </summary>
        public bool PrimaryTriggerPulled
        {
            get
            {
                return OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) || Input.GetKeyDown(simulatedTriggerKey);
            }
        }

        /// <summary>
        /// True if the primary controller's trigger is currently down and
        /// false if the trigger is not.
        /// </summary>
        public bool PrimaryTriggerPressed
        {
            get
            {
                return OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger) || Input.GetKey(simulatedTriggerKey);
            }
        }

        /// <summary>
        /// True during the frame that the trigger was released
        /// on the primary controller. 
        /// </summary>
        public bool PrimaryTriggerReleased
        {
            get
            {
                return OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger) || Input.GetKeyUp(simulatedTriggerKey);
            }
        }

        public bool PrimaryTouchpadPressed
        {
            get
            {
                return OVRInput.Get(OVRInput.Button.PrimaryTouchpad) || Input.GetKey(simulatedTouchpadKey);
            }
        }

        public bool PrimaryTouchpadReleased
        {
            get
            {
                return OVRInput.GetUp(OVRInput.Button.PrimaryTouchpad) || Input.GetKeyUp(simulatedTouchpadKey);
            }
        }
    }
}
