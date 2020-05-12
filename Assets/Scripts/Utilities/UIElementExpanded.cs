//======= Copyright (c) Valve Corporation, All rights reserved. ===============
//
// Purpose: UIElement that responds to VR hands and generates UnityEvents
//
//=============================================================================

using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System;

namespace Valve.VR.InteractionSystem
{
	//-------------------------------------------------------------------------
	[RequireComponent( typeof( Interactable ) )]
	public class UIElementExpanded : MonoBehaviour
	{
		[Header("Variables")]
		public bool triggerExitOnClick = true;

		[Header("Events")]
		public CustomEvents.UnityEventHand onHandClick;
		public CustomEvents.UnityEventHand onHandHover;
		public CustomEvents.UnityEventHand onHandExit;

		protected Hand currentHand;


		//-------------------------------------------------
		protected virtual void Awake()
		{
			Button button = GetComponent<Button>();
			if ( button )
			{
				button.onClick.AddListener(OnButtonClick);
			}
		}


		//-------------------------------------------------
		protected virtual void OnHandHoverBegin( Hand hand )
		{
			currentHand = hand;
			InputModule.instance.HoverBegin( gameObject );
			ControllerButtonHints.ShowButtonHint( hand, hand.uiInteractAction);
			onHandHover.Invoke(hand);
		}


        //-------------------------------------------------
        protected virtual void OnHandHoverEnd( Hand hand )
		{
			InputModule.instance.HoverEnd( gameObject );
			ControllerButtonHints.HideButtonHint( hand, hand.uiInteractAction);
			currentHand = null;
			onHandExit.Invoke(hand);
		}


        //-------------------------------------------------
        protected virtual void HandHoverUpdate( Hand hand )
		{
			if ( hand.uiInteractAction != null && hand.uiInteractAction.GetStateDown(hand.handType) )
			{
				InputModule.instance.Submit( gameObject );
				ControllerButtonHints.HideButtonHint( hand, hand.uiInteractAction);
			}
		}


		//-------------------------------------------------
		protected virtual void OnButtonClick()
		{
			onHandClick.Invoke(currentHand);

			if (triggerExitOnClick)
				onHandExit.Invoke(currentHand);
		}

		protected virtual void OnButtonHover()
		{
			onHandHover.Invoke(currentHand);
		}

		protected virtual void OnButtonExit()
		{
			onHandExit.Invoke(currentHand);
		}
	}

#if UNITY_EDITOR
	//-------------------------------------------------------------------------
	[UnityEditor.CustomEditor( typeof( UIElement ) )]
	public class UIElementEditor : UnityEditor.Editor
	{
		//-------------------------------------------------
		// Custom Inspector GUI allows us to click from within the UI
		//-------------------------------------------------
		public override void OnInspectorGUI()
		{
			DrawDefaultInspector();

			UIElement uiElement = (UIElement)target;
			if ( GUILayout.Button( "Click" ) )
			{
				InputModule.instance.Submit( uiElement.gameObject );
			}
		}
	}
#endif
}
