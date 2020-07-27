/***************************************************************************\
Project:      Daily Rewards
Copyright (c) Niobium Studios.
Author:       Guilherme Nunes Barbosa (gnunesb@gmail.com)
\***************************************************************************/
using UnityEngine;
using UnityEditor;

/*
 * Editor layout tools
 */
public class EditorTools {

	public static bool DrawHeader (string text) {
		string key = text;
		
		bool state = EditorPrefs.GetBool(key, true);
		
		GUILayout.Space(3f);
		if(!state) {
			GUI.backgroundColor = new Color(0.8f, 0.8f, 0.8f);
		}
		GUILayout.BeginHorizontal();
		GUI.changed = false;
		
		
		text = "<b><size=11>" + text + "</size></b>";
		if (state) {
			text = "\u25BC " + text;
		} else {
			text = "\u25BA " + text;
		}
		
		if (!GUILayout.Toggle(true, text, "dragtab", GUILayout.MinWidth(20f))) {
			state = !state;
		}
		
		if (GUI.changed) {
			EditorPrefs.SetBool(key, state);
			state = EditorPrefs.GetBool(text, true);
		}
		
		GUILayout.Space(2f);
		GUILayout.EndHorizontal();
		GUI.backgroundColor = Color.white;
		if (!state) {
			GUILayout.Space(3f);
		}
		return state;
	}
	
	public static void BeginContents() {
		GUILayout.BeginHorizontal (GUILayout.MinHeight (10f));
		GUILayout.Space(5f);
		GUILayout.BeginVertical();
		GUILayout.Space(2f);
	}
	
	public static void EndContents() {
		GUILayout.Space(3f);
		GUILayout.EndVertical();
		EditorGUILayout.EndHorizontal();
		GUILayout.Space(3f);
	}
}

