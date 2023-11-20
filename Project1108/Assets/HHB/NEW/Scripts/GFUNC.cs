using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class GFUNC
{
    #region HHB GFUNC
    public static GameObject FindTopLevelGameObject(string name_)
    {
        GameObject[] rootObjs = SceneManager.GetActiveScene().GetRootGameObjects();
        foreach (GameObject obj in rootObjs)
        {
            if (obj.name == name_)
            {
                return obj;
            }
        }
        return null;
    }

    public static List<GameObject> FindAllTargets(string rootName, string targetName)
    {
        GameObject root = FindTopLevelGameObject(rootName);
        List<GameObject> results = new List<GameObject>();

        if (root != null)
        {
            FindAllTargetsRecursive(root.transform, targetName, results);
        }
        else
        {
            Debug.LogWarning("Root GameObject not found.");
        }
        return results;
    }

    public static GameObject FindMyTarget(string rootName, string targetName)
    {
        GameObject root = FindTopLevelGameObject(rootName);
        GameObject result = default;
        List<GameObject> results = new List<GameObject>();

        if (root != null)
        {
            FindAllTargetsRecursive(root.transform, targetName, results);
        }
        else
        {
            Debug.LogWarning("Root GameObject not found.");
        }
        result = results[0]; 
        return result;
    }


    private static void FindAllTargetsRecursive(Transform rootTransform, string targetName, List<GameObject> results)
    {
        foreach (Transform childTransform in rootTransform)
        {
            GameObject childGameObject = childTransform.gameObject;
            if (childGameObject.name.StartsWith(targetName))
            {
                results.Add(childGameObject);
            }
            FindAllTargetsRecursive(childTransform, targetName, results);
        }
    }


    #endregion
}

