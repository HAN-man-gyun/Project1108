using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using PlayFab;
using PlayFab.ClientModels;
using System.Collections;
using System.Collections.Generic;
using Unity.Animations.SpringBones.GameObjectExtensions;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Video;


namespace LEGACY
{
    // unity-chan
    public class Character
    {
        //public string userName;
        //public string foreHair;
        //public string backHair;
        //public string eyeLeft;
        //public string eyeRight;
        //public string headAcc;
        //public string hairAcc;
        //public string costumeMesh;
        public string costumeMaterial;

        public Character(/*string userName, string foreHair, string backHair,
        string eyeLeft, string eyeRight, string headAcc, string hairAcc,string costumeMesh,*/ string costumeMaterial)
        {
            //this.userName = userName;
            //this.foreHair = foreHair;
            //this.backHair = backHair;
            //this.eyeLeft = eyeLeft;
            //this.eyeRight = eyeRight;
            //this.headAcc = headAcc;
            //this.hairAcc = hairAcc;
            //this.costumeMesh = costumeMesh;
            this.costumeMaterial = costumeMaterial;
        }
    }

    public class CharacterData : MonoBehaviour
    {
        //public Mesh[] costumeMeshes;
        public Material[] costumeMaterial;
        public GameObject myCharacter;

        //public int meshIndex;
        public int matIndex = 0;

        public void ClickRightButton()
        {
            if (matIndex < 2)
            {
                matIndex++;
            }
            else { matIndex = 0; }
            ChangeMaterial(matIndex);
        }

        public void ClickLeftButton()
        {
            if (matIndex > 0)
            {
                matIndex--;
            }
            else { matIndex = 2; }
            ChangeMaterial(matIndex);
        }

        public void ChangeMaterial(int matIndex)
        {
            Debug.Log("changeMaterial 들어옴");
            SkinnedMeshRenderer costumeSkin = myCharacter.transform.GetChild(0).GetComponent<SkinnedMeshRenderer>();
            costumeSkin.material = costumeMaterial[matIndex];
        }

        public void ClickSaveButton()
        {
            var request = new UpdateUserDataRequest
            {
                Data = new Dictionary<string, string>
            {
                { "Character", matIndex.ToString() }
            }
            };

            PlayFabClientAPI.UpdateUserData(request, (result) =>
            {
                Debug.Log(result);
            },
            (error) => { Debug.Log(error); });
        }

        public void ClickLoadButton()
        {
            PlayFabClientAPI.GetUserData(new GetUserDataRequest(), (result) =>
            {
                if (result.Data != null)
                {
                    matIndex = int.Parse(result.Data["Character"].Value);
                    ChangeMaterial(matIndex);
                }
            },
            (error) => { Debug.Log(error); });
        }

        public Character ReturnClass()
        {
            return new Character(matIndex.ToString());
        }
    }
}

