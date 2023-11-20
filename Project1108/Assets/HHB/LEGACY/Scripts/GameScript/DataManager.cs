using Cinemachine;
using PlayFab.ClientModels;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

namespace LEGACY
{
    /// <summary>
    /// 플레이어 커스텀 선택
    /// </summary>
    public partial class DataManager : MonoBehaviour
    {
        public static DataManager Instance;
        public GameObject[] characters;
        public CinemachineVirtualCamera characterCamera;

        public CharacterData[] characterData;

        //private int index = 0;
        private void Awake()
        {
            Instance = this;
            MatchCharacterAndCamera(characters[1]);
        }

        public void MatchCharacterAndCamera(GameObject character)
        {
            characterCamera.LookAt = character.transform;
        }

        public void OnClickRight()
        {
            return;
            //if (index < 2)
            //{
            //    index++;
            //    MatchCharacterAndCamera(characters[index]);
            //}
            //else { index = 0; MatchCharacterAndCamera(characters[index]); }
        }

        public void OnClickLeft()
        {
            return;
            //if (index > 0)
            //{
            //    index--;
            //    MatchCharacterAndCamera(characters[index]);
            //}
            //else { index = 2; MatchCharacterAndCamera(characters[index]); }
        }


        public void SaveCharData()
        {
            List<CharacterData> character = new List<CharacterData>();

            foreach (var item in characterData)
            {
                //character.Add(item.ReturnClass());
            }
            var request = new UpdateUserDataRequest
            {
                Data = new Dictionary<string, string>
                {
                    //{ "PlayerCharacter", JsonConvert.SerializeObject()}
                }
            };
        }

        public void GetCharData()
        {

        }
    }


}

