using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode]
public class GridManager : MonoBehaviour {


	public int sizeX = 20;
	public int sizeY = 20;

	public GameObject GridPeace;

	void Awake()
	{

		if (GridPeace == null) {
			GridPeace = Resources.Load ("Prefabs/GridPeace") as GameObject;
		}

	}

	// Update is called once per frame
	void Update () {

		if (CreateGrid) {
			CreateGrid = false;
			createGrid ();
		}

		if (DestroyGrid) {
			DestroyGrid = false;
			destroyGrid ();
		}

	}

	public bool CreateGrid;
	void createGrid()
	{
		for (int x = 0; x < sizeX; x++) {
			for (int y = 0; y < sizeY; y++) {
				GameObject g = Instantiate (GridPeace);
				g.transform.position = new Vector3 (x, y, 0);
				g.transform.SetParent (this.transform);
				g.name = "Grid Peace " + x.ToString("00") + ", " + y.ToString("00") + "!";
			}
		}
	}

	public bool DestroyGrid;
	void destroyGrid()
	{

		var toDestroy = new List<GameObject> ();

		foreach (Transform child in this.transform) {
			toDestroy.Add (child.gameObject);
		}

		foreach (var go in toDestroy) {
			DestroyImmediate (go);
		}

	}


}
