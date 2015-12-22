using UnityEngine;
using System.Collections;

public class ObjectTest : MonoBehaviour {

	// Use this for initialization
	void Start () {

		GameObject go = BuildingManager.CreateBuilding ();

		go.name = "asdasd";

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
