using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(CharacterData))]
[CanEditMultipleObjects]
public class CharacterDataEditor : Editor
 {
	 private float minArrivalTime = 0;
	 private float maxArrivalTime = 23.9f;

	 private float minReturnTime = 0;
	 private float maxReturnTime = 23.9f;


	 private float minLimit = 0;	
	 private float maxLimit = 23.99f;

	 public override void OnInspectorGUI()
	 {
		serializedObject.Update ();

		 DrawDefaultInspector();

		

		 CharacterData character = (CharacterData)target;

		 minArrivalTime = character.minArrivalTime;
		 maxArrivalTime = character.maxArrivalTime;

		 EditorGUILayout.LabelField("Arrival Time");
		 EditorGUILayout.LabelField("Min Arrival Time:", minArrivalTime.ToString("F2"));
         EditorGUILayout.LabelField("Max Arrival Time:", maxArrivalTime.ToString("F2"));
         EditorGUILayout.MinMaxSlider(ref minArrivalTime, ref maxArrivalTime, minLimit, maxLimit);

   		 character.SetArrivalTimeLimits(minArrivalTime, maxArrivalTime); 

		 minReturnTime = character.minReturnTime;
		 maxReturnTime = character.maxReturnTime;


		 EditorGUILayout.LabelField("Return Time");
		 EditorGUILayout.LabelField("Min Return Time:", minReturnTime.ToString("F2"));
         EditorGUILayout.LabelField("Max Return Time:", maxReturnTime.ToString("F2"));
         EditorGUILayout.MinMaxSlider(ref minReturnTime, ref maxReturnTime, minLimit, maxLimit);
		
		 serializedObject.ApplyModifiedProperties();

	 }
}
