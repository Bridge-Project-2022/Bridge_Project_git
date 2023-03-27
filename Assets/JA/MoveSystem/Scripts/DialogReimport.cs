using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DialogReimport : MonoBehaviour
{
    [MenuItem("Tools/DialogReimport")]
    static void ReimportDialogData()
    {
        string path = "Assets/JA/MoveSystem/Scripts/PlaceDialogDB.xlsx";
        AssetDatabase.ImportAsset(path, ImportAssetOptions.ImportRecursive);

        EditorUtility.DisplayDialog("Reimport Data", "Done.", "ok");
    }
}
