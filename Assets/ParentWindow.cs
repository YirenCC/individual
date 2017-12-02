using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Runtime.InteropServices;
using System;
using System.IO;

public class ParentWindow : EditorWindow
{
    public string parents;
    public string[] lineBline;


    [DllImport("LoggingPlugin")]
    public static extern void Log(string a_Objectname, string a_Item, string a_Value);
    [DllImport("LoggingPlugin")]
    public static extern IntPtr LoadFile();

    bool myBool;
    List<string> ParentMap = new List<string>();
    [MenuItem("Window/Parent Window Editor")]
    static void ShowWindow()
    {
        GetWindow<ParentWindow>("Parent Window Editor");
    }

    void OnGUI()
    {
        if (GUILayout.Button("Save Parents"))
        {
            GameObject root = GameObject.Find("ParentManager");
            forEachChild(root.transform);
            for (int i = 0; i < ParentMap.Count; i++)
            {
                Debug.Log(ParentMap[i]);
                Log("Root","Parent",ParentMap[i]);
            }
            
        }
        if (GUILayout.Button("Load Parents"))
        {
            //this is where you should do the loading of the text file and assignment of parents for the objects

            parents = Marshal.PtrToStringAnsi(LoadFile());
            lineBline = new string[] { "Parent" };
            ParentMap.Clear();

            using (StringReader p = new StringReader(parents))
            {
                string line;
                {
                    while ((line = p.ReadLine())!= null)
                    {
                        string[] split = line.Split(lineBline, StringSplitOptions.None);

                        GameObject newObject = GameObject.Find(split[0]);
                        Debug.Log("s"+split[0]);
                        newObject.transform.parent = GameObject.Find(split[1]).transform;
                    }
                } 
            }
        }

    }
    string forEachChild(Transform T)
    {

        foreach (Transform child in T)
        {
                ParentMap.Add(forEachChild(child));
        }
        if (T.parent != null)
            return T.name + " Parent " + T.parent.name;
        else
            return T.name;

    }
}
