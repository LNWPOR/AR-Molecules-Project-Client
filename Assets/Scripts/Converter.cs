using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class Converter {

	public static string  JsonToString( string target ){

		string[] newString = Regex.Split(target,"\"");

		return newString[1];

	}

	public static Vector3 JsonToVecter3(string target ){

        Vector3 newVector;
		string[] newString = Regex.Split(target,",");
        newVector = new Vector3( float.Parse(newString[0]), float.Parse(newString[1]), float.Parse(newString[2]));
        return newVector;

	}

	public static Vector2 JsonToVecter2(string target ){

		Vector2 newVector;
		string[] newString = Regex.Split(target,",");
		newVector = new Vector2( float.Parse(newString[0]), float.Parse(newString[1]));

		return newVector;

	}

	public static float JsonToFloat(string target ){

		float newFloat = 0;
		string[] newString = Regex.Split(target,"\"");
		newFloat = float.Parse(newString[1]);

		return newFloat;

	}

	public static Quaternion JsonToRotation(string target ){

		float[] newRotation = new float[3];
		string[] newString = Regex.Split(target,",");
		newRotation[0] = float.Parse(newString[0]);
		newRotation[1] = float.Parse(newString[1]);
		newRotation[2] = float.Parse(newString[2]);

        return Quaternion.Euler(new Vector3(newRotation[0], newRotation[1], newRotation[2]));

	}

}
