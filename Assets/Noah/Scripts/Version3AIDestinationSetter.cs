using UnityEngine;
using System.Collections;

namespace Pathfinding
{
	/// <summary>
	/// Sets the destination of an AI to the position of a specified object.
	/// This component should be attached to a GameObject together with a movement script such as AIPath, RichAI or AILerp.
	/// This component will then make the AI move towards the <see cref="target"/> set on this component.
	///
	/// See: <see cref="Pathfinding.IAstarAI.destination"/>
	///
	/// [Open online documentation to see images]
	/// </summary>
	[UniqueComponent(tag = "ai.destination")]
	[HelpURL("http://arongranberg.com/astar/docs/class_pathfinding_1_1_a_i_destination_setter.php")]
	public class Version3AIDestinationSetter : VersionedMonoBehaviour
	{
		/// <summary>The object that the AI should move to</summary>
		public Transform target;
		IAstarAI ai;
		public Version2AIDestinationSetter V2;
		public Version3AIDestinationSetter V3;

		private Transform Caravan;
		private GameObject[] multipleCaravans;
		public bool caravanContact;

		void OnEnable()
		{
			ai = GetComponent<IAstarAI>();
			// Update the destination right before searching for a path as well.
			// This is enough in theory, but this script will also update the destination every
			// frame as the destination is used for debugging and may be used for other things by other
			// scripts as well. So it makes sense that it is up to date every frame.
			if (ai != null) ai.onSearchPath += Update;
		}

		void Start()
		{
			V2 = GetComponent<Version2AIDestinationSetter>();
			V3 = GetComponent<Version3AIDestinationSetter>();
			caravanContact = false;
		}

		void OnDisable()
		{
			if (ai != null) ai.onSearchPath -= Update;
		}

		/// <summary>Updates the AI's destination every frame</summary>
		void Update()
		{
			Caravan = FindClosestNPC();

			if (target != null && ai != null) ai.destination = target.position;
			target = Caravan;
			if (Input.GetKey(KeyCode.O))
			{
				V3.enabled = false;
				V2.enabled = true;
			}
		}

		Transform FindClosestNPC()
		{
			multipleCaravans = GameObject.FindGameObjectsWithTag("Caravan");
			float closestDistance = Mathf.Infinity;
			Transform trans = null;

			foreach (GameObject go in multipleCaravans)
			{
				float currentDistance;
				currentDistance = Vector3.Distance(transform.position, go.transform.position);
				if (currentDistance < closestDistance)
				{
					closestDistance = currentDistance;
					trans = go.transform;
				}
			}
			return trans;
		}
	}
}