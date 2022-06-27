using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [SerializeField] private GameTimer _gameTimer;
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private Text _textTotalTimeGameOwer;
    [SerializeField] private Text _textTotalTimeFinish;
    [SerializeField] private Text _textPassedTimeFinish;
    [SerializeField] private GameObject _panelGameOwer;
    [SerializeField] private GameObject _panelPause;
    [SerializeField] private GameObject _panelFinishGame;
    private float _timeGame;

    private void Start()
    {
        Time.timeScale = 1f;
        _timeGame = Setting.sizeMazeHeight * Setting.sizeMazeWidth / 5;
    }
    private void Update()
    {
        if (_gameTimer.Time <= 0)
            GameOwer();
        if(_playerController.FinishGame)
            FinishGame();
    }
    private void GameOwer()
    {
        _panelGameOwer.SetActive(true);
        _textTotalTimeGameOwer.text = "Времени всего: " + _timeGame.ToString("F2");
        Time.timeScale = 0f;
    }
    private void FinishGame()
    {
        _panelFinishGame.SetActive(true);
        _textTotalTimeFinish.text = "Времени всего: " + _timeGame.ToString("F2");
        _textPassedTimeFinish.text = "Вы справились за: " + (_timeGame - _gameTimer.Time).ToString("F2");
        Time.timeScale = 0f;
    }
    public void ButtonPause()
    {
        _panelPause.SetActive(true);
        Time.timeScale = 0f;
    }
    public void ButtonLoadScene(int indexScene)
    {
        SceneManager.LoadScene(indexScene);
    }
    public void ButtonResume()
    {
        _panelPause.SetActive(false);
        Time.timeScale = 1f;
    }
}
