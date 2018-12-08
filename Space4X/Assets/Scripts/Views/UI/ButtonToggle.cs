using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonToggle : MonoBehaviour
{
    protected Button B;
    public Color ActiveColour;
    public Color InactiveColour;

    public bool IsActive;

    public void SetActive(bool isActive)
    {

    }
    private void OnEnable()
    {
        B = gameObject.GetComponent<Button>();
    }
}
