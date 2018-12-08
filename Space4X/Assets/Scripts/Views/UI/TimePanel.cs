using Space4X.Controllers;
using UnityEngine;
using UnityEngine.UI;

namespace Space4X.Views.UI
{
    [RequireComponent(typeof(Text))]
    public class TimePanel : MonoBehaviour
    {
        protected Text TimeText;

        private void Start()
        {
            TimeText =  GetComponent<Text>();
        }

        private void Update()
        {
            TimeText.text = TimeController.Instance.CurrentTime.ToString();
        }
    }
}
