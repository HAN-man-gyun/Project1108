using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// DB Load
public partial class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    public int costumeIndex = 1;
    //public int hairIndex = 11;
    //public int accIndex = 21;
    //public int bagIndex = 31;


    public void RightCostume()
    {
        if (costumeIndex < 3)
        {
            costumeIndex++; SetCostume(costumeIndex);
        }
        else
        {
            costumeIndex = 1; SetCostume(costumeIndex);   
        }
    }

    public void LeftCostume() 
    {
        if (costumeIndex > 1)
        {
            costumeIndex--; SetCostume(costumeIndex);
        }
        else
        {
            costumeIndex = 3; SetCostume(costumeIndex);
        }
    }

    public void SetCostume(int costumeIndex)
    {
        GameObject player = GFUNC.FindTopLevelGameObject("Player");
        SkinnedMeshRenderer playerSkin = player.transform.GetChild(4).GetComponent<SkinnedMeshRenderer>();
        GameObject costume = ResourceManager.Instance.GetCustomPrefabFromID(costumeIndex);

        if (costume != null) 
        { 
            SkinnedMeshRenderer skinnedMesh = costume.GetComponent<SkinnedMeshRenderer>();
            playerSkin.bounds = skinnedMesh.bounds;
            playerSkin.sharedMaterial = skinnedMesh.sharedMaterial;
            playerSkin.sharedMesh = skinnedMesh.sharedMesh;
            playerData.character.ReturnCostume(costumeIndex);
        }
    }

}
