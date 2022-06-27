using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [SerializeField] private Slider _sliderTime;
    [SerializeField] private Text _textTime;
    public float Time { get ; private set ; }

    private void Start()
    {
        Time = Setting.sizeMazeHeight * Setting.sizeMazeWidth / 5;
        _sliderTime.maxValue = Time;
    }

    private void Update()
    {
        if (Time > 0)
        {
            Time -= UnityEngine.Time.deltaTime;
            _sliderTime.value = Time;
            _textTime.text = Time.ToString("F2");
        }
    }
}
