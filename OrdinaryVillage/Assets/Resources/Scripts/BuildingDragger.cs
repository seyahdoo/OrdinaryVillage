using UnityEngine;
using System.Collections;

public class BuildingDragger : MonoBehaviour {



	private Vector3 ClickPosition; //dokunduğum yer.
	private Vector3 dragMargin; //dokunduğum yerin merkezden farkı.
	public static bool Dragging = false; //Şimdi bi saat kim Dragging yapıyor diye mi bakıcam ?_? Yoğamua

	public GameObject BuildingToDrag;
	public Vector2 BuildingToDragSize = new Vector2 (1f,1f);
	public bool nearSnappable = false;

	public GameObject SnappedObject;
	public bool isAvalible;

	public Material MaterialDefault;
	public Material MaterialNotAvalible;
	public Material MaterialAvalible;


	void OnMouseDown() 
	{
		Dragging = true; //Farklı bir scriptle Draggingi bitirmek için kullanılıcak.

		//Dokunduğum yeri bul
		ClickPosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		ClickPosition.z = 0;

		//dokunduğum yerin mekezden farkını bul
		dragMargin = ClickPosition - this.transform.position;

		BuildingToDrag.GetComponent<SpriteRenderer> ().sortingOrder = 6;

		//İf Im Snapped, DeSnap it.
		//TODO write this.
		if (nearSnappable) 
		{
			//DeSnap
			SnappedObject.GetComponent<GridPeaceBehaviour>().DePlace(BuildingToDragSize);
		}


	}

	void OnMouseDrag() 
	{
		//Diğer scriptten Draggingi bitirmediysem filan
		if (Dragging) 
		{ 

			//Dokunduğum yeri bul
			ClickPosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			ClickPosition.z = 0;

			//Hesaplara göre nesnemin yerini değiştir. 
			//dandik telefonlarda sorun çıkartabilir belki ama, sal ya.
			this.transform.position = ClickPosition - dragMargin;

		}

		if (!nearSnappable) 
		{
			BuildingToDrag.transform.position = ClickPosition - dragMargin;
		}


	}

	void OnMouseUp()
	{
		//if we snapped, this will prevent dragger to desync;
		this.transform.position = BuildingToDrag.transform.position;
		if (nearSnappable && isAvalible)
		{
			//todo fix this
			SnappedObject.GetComponent<GridPeaceBehaviour> ().PlaceBlock(BuildingToDragSize);
		}

		BuildingToDrag.GetComponent<SpriteRenderer> ().sortingOrder = 5;
	}


	void OnTriggerEnter2D(Collider2D other) 
	{
		nearSnappable = true;

		//size Breaks this.
		//BuildingToDrag.transform.position = other.transform.position;

		//this is more good suppose..
		BuildingToDrag.transform.position = new Vector2 (
			other.transform.position.x + (BuildingToDragSize.x * 0.5f) - 0.5f,
			other.transform.position.y + (BuildingToDragSize.y * 0.5f) - 0.5f
		);

		SnappedObject = other.gameObject;
		isAvalible = SnappedObject.GetComponent<GridPeaceBehaviour> ().CheckIsAvalible (BuildingToDragSize);
		//Debug.Log (isAvalible);
		if (isAvalible) {
			BuildingToDrag.GetComponent<SpriteRenderer> ().material = MaterialAvalible;
		} else 
		{
			BuildingToDrag.GetComponent<SpriteRenderer> ().material = MaterialNotAvalible;
		}

	}

	void OnTriggerExit2D(Collider2D other) 
	{
		BuildingToDrag.GetComponent<SpriteRenderer> ().material = MaterialDefault;
		nearSnappable = false;
	}


}
