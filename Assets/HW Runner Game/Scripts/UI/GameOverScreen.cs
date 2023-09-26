using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace HWRunnerGame
{
    [RequireComponent(typeof(CanvasGroup))]
    public class GameOverScreen : MonoBehaviour
    {
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _endButton;
        [SerializeField] private Player _player;
        
        private CanvasGroup _gameOverGroup;

        private void OnEnable()
        {
            _player.Died += OnDied;
            _restartButton.onClick.AddListener(OnRestartButtonClick);
            _endButton.onClick.AddListener(OnEndButtonClick);
        }

        private void OnDisable()
        {
            _player.Died -= OnDied;
            _restartButton.onClick.RemoveListener(OnRestartButtonClick);
            _endButton.onClick.RemoveListener(OnEndButtonClick);

        }

        private void Start()
        {
            _gameOverGroup = GetComponent<CanvasGroup>();
            _gameOverGroup.alpha = 0;
        }

        private void OnDied()
        {
            _gameOverGroup.alpha = 1;
            Time.timeScale = 0;
        }

        private void OnRestartButtonClick()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(0);
        }

        private void OnEndButtonClick()
        {
            Application.Quit();
        }
    }
}