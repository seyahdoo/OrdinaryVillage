using UnityEngine;
using System.Collections;

public class GridPeaceBehaviour : MonoBehaviour {


	void Update()
	{
		if (checkavalible) {
			checkavalible = false;
			Debug.Log( CheckIsAvalible (new Vector2(toCheckX,toCheckY)));
		
		}

	}

	//this is for debugging
	//todo private this,hide this
	public bool IsFull = false;

	public bool GetIsFull()
	{
		return IsFull;
	}

	//theese three is for debugging...
	public int toCheckX = 1;
	public int toCheckY = 1;
	public bool checkavalible = false;
	public bool CheckIsAvalible(Vector2 Size)
	{
		//find pieces and check if avalible, 
		//if you find a full true return false
		//else return true

		//if im full then no need to check others.
		if (GetIsFull ()) {
			return false;
		}

		//what is the relative place??? where am i???
		Vector2 myPlace = GetCordsFromName (this.name);
		//Debug.Log (myPlace);

		Debug.Log (Size.x + ":" + Size.y);

		for (int x = 1; x <= Size.x; x++) 
		{
			for (int y = 1; y <= Size.y; y++) 
			{
				//check if peace (i,j) is full if true return false;
				Debug.Log("Im in! "+ x + "," + y);
				GameObject toCheck = GameObject.Find(GetNameFromCords(new Vector2(myPlace.x + x - 1, myPlace.y + y - 1)));
				//if on corner!
				if (toCheck == null) 
				{
					return false;
				}
				//if its full
				if (toCheck.GetComponent<GridPeaceBehaviour> ().GetIsFull()) 
				{
					return false;
				}

			}
		}

		//E artık bu kadar olaydan sonra oyabiliyorumdur artık bea...
		return true;
	}


	private Vector2 GetCordsFromName(string str)
	{
		//sample Grid Peace 01, 02!
		 
		int X = 0;
		int Y = 0;

		//Debug.Log (str [11]);
		//Debug.Log (str [12]);
		//Debug.Log (str [15]);
		//Debug.Log (str [16]);

		//OH GOD! THE WORST CODE WRiTTEN EVER!!! ToDo: do this elegantly
		//maybe use the grid object???
		X += 10 * int.Parse(str [11].ToString());
		X += int.Parse (str [12].ToString());
		//Debug.Log (X);


		Y += 10 * int.Parse( str [15].ToString());
		Y += int.Parse( str [16].ToString());
		//Debug.Log (Y);

		return new Vector2 (X,Y);
	}

	private string GetNameFromCords(Vector2 cords)
	{
		return "Grid Peace " + cords.x.ToString("00") + ", " + cords.y.ToString("00") + "!";
	}


}
