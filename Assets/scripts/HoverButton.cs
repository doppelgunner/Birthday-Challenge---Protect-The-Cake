using UnityEngine.EventSystems;
using UnityEngine;

public class HoverButton : MonoBehaviour, IPointerEnterHandler {

	public void OnPointerEnter(PointerEventData eventData) {
        Audio.PlaySND2(Audio.SND_BUTTON);
    }
}
