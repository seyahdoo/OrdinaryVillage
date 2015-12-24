using UnityEngine;
using System.Collections;

public class BuildingDragger : MonoBehaviour {



	private Vector3 ClickPosition; //dokunduğum yer.
	private Vector3 dragMargin; //dokunduğum yerin merkezden farkı.
	public static bool Dragging = false; //Şimdi bi saat kim Dragging yapıyor diye mi bakıcam ?_? Yoğamua

	public GameObject BuildingToDrag;
	public bool nearSnappable = false;
	//public Vector2 snappablePosition;

	void OnMouseDown() 
	{
		Dragging = true; //Farklı bir scriptle Draggingi bitirmek için kullanılıcak.

		//Dokunduğum yeri bul
		ClickPosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		ClickPosition.z = 0;

		//dokunduğum yerin mekezden farkını bul
		dragMargin = ClickPosition - this.transform.position;
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
	}


	void OnTriggerEnter2D(Collider2D other) 
	{
		Debug.Log ("Hello From OnTriggerEnter2D");
		//Draggablev4.Dragging = false;
		nearSnappable = true;
		BuildingToDrag.transform.position = other.transform.position;
	}

	void OnTriggerExit2D(Collider2D other) 
	{
		Debug.Log ("Hello From Exit");

		//Draggablev4.Dragging = true;
		nearSnappable = false;
	}


}
