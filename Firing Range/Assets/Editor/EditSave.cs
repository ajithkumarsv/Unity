
using UnityEngine;
using UnityEditor;
using GM;

[CustomEditor(typeof(LevelSaveLoadData))]
public class EditSave : Editor
{

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        LevelSaveLoadData myComponent = (LevelSaveLoadData)target;

        if (GUILayout.Button("Save"))
        {

            myComponent.save();

        }
        if (GUILayout.Button("Load"))
        {

            myComponent.load();
            
        }


    }
    

}
