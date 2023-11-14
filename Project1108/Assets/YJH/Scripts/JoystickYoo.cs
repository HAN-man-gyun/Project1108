using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class JoystickYoo : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    [SerializeField] private Image joystickImg;
    [SerializeField] private Image joystickBGImg;
    private Vector3 inputVector;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void OnDrag(PointerEventData pointEventData)
    {

    }

    public virtual void OnPointerDown(PointerEventData pointEventData)
    {

    }

    public virtual void OnPointerUp(PointerEventData pointEventData)
    {

    }

}
