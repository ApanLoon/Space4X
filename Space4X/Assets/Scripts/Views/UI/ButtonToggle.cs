using UnityEngine;

namespace Space4X.Views.UI
{
    public class ButtonToggle : MonoBehaviour
    {
        [SerializeField] protected GameObject ActiveGraphic;

        public bool IsToggleOn { get; protected set; }

        public void SetToggle(bool isToggleOn)
        {
            IsToggleOn = isToggleOn;
            if (ActiveGraphic != null)
            {
                ActiveGraphic.SetActive(isToggleOn);
            }
        }

        public void Toggle()
        {
            SetToggle(!IsToggleOn);
        }
    }
}
