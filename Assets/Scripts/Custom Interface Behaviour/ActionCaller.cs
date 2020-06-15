using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class ActionCaller : MonoBehaviour
    {
        private IContainAction[] triggerCustomAction;
        private void Start()
        {
            triggerCustomAction = GetComponentsInChildren<IContainAction>();
            UpdateCustomActions();
        }

        public void UpdateCustomActions()
        {
            triggerCustomAction = GetComponentsInChildren<IContainAction>();
        }
        public void ExecuteAction()
        {
            foreach(IContainAction action in triggerCustomAction)
            {
                action.CustomAction();
            }
        }


    }  
  


