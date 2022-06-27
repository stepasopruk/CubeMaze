using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{
    [SerializeField] private Text _textSize;
    [SerializeField] private Slider _sliderSizeWidthMaze;
    [SerializeField] private Slider _sliderSizeHeightMaze;

    private void Start()
    {
        Time.timeScale = 1f;
    }
    private void Update()
    {
        _textSize.text = _sliderSizeWidthMaze.value + " x " + _sliderSizeHeightMaze.value;
    }
    public void ButtonExit()
    {
        Application.Quit();
    }

    public void ButtonGame(int indexScene)
    {
        Setting.sizeMazeWidth = _sliderSizeWidthMaze.value;
        Setting.sizeMazeHeight = _sliderSizeHeightMaze.value;
        SceneManager.LoadScene(indexScene);
    }
}
