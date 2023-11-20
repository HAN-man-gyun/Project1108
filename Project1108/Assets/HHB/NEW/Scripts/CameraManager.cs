using Cinemachine;
using Unity.VisualScripting;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager Instance;
    private CinemachineVirtualCamera characterCamera;

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(this);
    }

    public void SetCharacterCamera(GameObject character)
    {
        GameObject camera = GFUNC.FindTopLevelGameObject("CharacterCamera");
        characterCamera = camera.GetComponent<CinemachineVirtualCamera>();
        characterCamera.LookAt = character.transform;
    }
}
