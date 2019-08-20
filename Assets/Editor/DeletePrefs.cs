using UnityEditor;
using UnityEngine;

public class DeletePrefs : EditorWindow
{

    [MenuItem("Edit/Delete All PlayerPrefs")]

    public static void DeletePlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("delete prefs");
    }
}