using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WorldInteraction : MonoBehaviour {
	NavMeshAgent playerAgent;


	// Use this for initialization
	void Start () {
		playerAgent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
		{
			GetInteraction();
		}
	}

	void GetInteraction()
	{
		Ray interationRay = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit interactionInfo;
		if (Physics.Raycast(interationRay, out interactionInfo, Mathf.Infinity))
		{
			GameObject interactionObject = interactionInfo.collider.gameObject;
			if (interactionObject.tag == "Interactable Object")
			{
				playerAgent.stoppingDistance = 3f;
				interactionObject.GetComponent<Interactable>().MoveToInteraction(playerAgent);
			}
			else
			{
				playerAgent.stoppingDistance = 0;
				playerAgent.destination = interactionInfo.point;
			}
		}
	}
}
