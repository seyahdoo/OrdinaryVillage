using UnityEngine;
using System.Collections;

public class BuildingManager : MonoBehaviour {


	public static GameObject CreateBuilding()
	{

		return GameObject.CreatePrimitive (PrimitiveType.Capsule);
	}



}
