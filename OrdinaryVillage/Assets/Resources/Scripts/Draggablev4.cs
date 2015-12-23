using UnityEngine;
using System.Collections;

public class Draggablev4 : MonoBehaviour {


	public Vector3 ClickPosition; //dokunduğum yer.
	public Vector3 dragMargin; //dokunduğum yerin merkezden farkı.
	public static bool Dragging = false; //Şimdi bi saat kim Dragging yapıyor diye mi bakıcam ?_? Yoğamua


	void OnMouseDown() 
	{
		Dragging = true; //Farklı bir scriptle Draggingi bitirmek için kullanılıcak.

        //Dokunduğum yeri bul
		ClickPosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		ClickPosition.z = 0;
		
        //dokunduğum yerin mekezden farkını bul
		dragMargin = ClickPosition - this.transform.position;

        //TODO delete this. //Debug için yazıldı. //Gereksiz kod.
        //this.transform.position = ClickPosition - dragMargin;


    }

    void OnMouseDrag() 
	{
        //Diğer scriptten Draggingi bitirmediysem filan
        if (Dragging) { 

            //Dokunduğum yeri bul
			ClickPosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			ClickPosition.z = 0;

            //Hesaplara göre nesnemin yerini değiştir. 
            //dandik telefonlarda sorun çıkartabilir belki ama, sal ya.
            this.transform.position = ClickPosition - dragMargin;
            
        }

	}

	void OnTriggerEnter2D(Collider2D other) 
	{
		Debug.Log ("Hello From OnTriggerEnter2D");
	}

	void OnTriggerExit2D(Collider2D other) 
	{
		Debug.Log ("Hello From Exit");
	}




}
