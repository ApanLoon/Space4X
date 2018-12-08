using Space4X.Controllers;
using UnityEngine;

namespace Space4X.Views.UI
{
    public class MainViewPanel : MonoBehaviour
    {
        [SerializeField] protected ButtonToggle GalaxyViewToggle;
        [SerializeField] protected ButtonToggle SystemViewToggle;

        private void Start()
        {
            MainViewController.Instance.OnMainViewChange += OnMainViewChange;
            OnMainViewChange(MainViewController.Instance.CurrentMainView);
        }

        private void OnMainViewChange(MainViewController.MainView view)
        {
            GalaxyViewToggle.SetToggle(view == MainViewController.MainView.Galaxy);
            SystemViewToggle.SetToggle(view == MainViewController.MainView.System);
        }
    }
}
