using UnityEngine;
using UnityEditor;

public class ExampleWindow : EditorWindow {

	Color color;

	[MenuItem("Window/Colorizer")]
	public static void ShowWindow ()
	{
		GetWindow<ExampleWindow>("Colorizer");
	}

    private void OnEnable()
    {
        Debug.Log("hello is me!");
    }

    void OnGUI ()
	{
		// 界面创建
        GUILayout.Label("Color the selected objects!", EditorStyles.boldLabel);

		color = EditorGUILayout.ColorField("Color", color);

		if (GUILayout.Button("COLORIZE!"))
		{
			Colorize();
		}
	}

	// 设置颜色
	void Colorize ()
	{
		foreach (GameObject obj in Selection.gameObjects)
		{
			Renderer renderer = obj.GetComponent<Renderer>();
			if (renderer != null)
			{
				renderer.sharedMaterial.color = color;
			}
		}
	}

}
