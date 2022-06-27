using UnityEngine;

public class GenerateLabyrinth : MonoBehaviour
{
    [SerializeField] private GameObject _cubePrefab;
    [SerializeField] private GameObject _endPrefab;
    [SerializeField] private GameObject _plane;
    [SerializeField] private GameObject _maze;
    private GameObject[,] Cubes = new GameObject[(int)Setting.sizeMazeWidth, (int)Setting.sizeMazeHeight];

    private void Start()
    {
        _plane.transform.localScale = new Vector3(Setting.sizeMazeWidth / 10, 1, Setting.sizeMazeHeight / 10);
        _plane.transform.position = new Vector3(
            Setting.sizeMazeWidth * 0.5f + 0.5f, 0, Setting.sizeMazeHeight * 0.5f + 0.5f
            );
        SpawnCubes();
        BuildingMaze();
        SpawnEnd();
    }

    private void SpawnCubes()
    {
        for (int i = 0; i < Setting.sizeMazeWidth + 2; i++)
        {
            for (int j = 0; j < Setting.sizeMazeHeight + 2; j++)
            {
                var cube = Instantiate(_cubePrefab, new Vector3(i, 0.5f, j), Quaternion.identity, _maze.transform);
                if (i > 0 && j > 0 && i < Setting.sizeMazeWidth + 1 && j < Setting.sizeMazeHeight + 1)
                    Cubes[i - 1, j - 1] = cube;
            }
        }
    }

    private void BuildingMaze()
    {
        int minerZ = 0;
        int minerX = 0;
        bool process = true;
        bool mining = false;
        Cubes[0, 0].SetActive(false);

        while (process)
        {
            int direction = Random.Range(0, 4);
            if (direction == 0)
            {
                if (minerZ + 2 < Setting.sizeMazeHeight)
                {
                    if (!Cubes[minerX, minerZ + 1].activeSelf && !Cubes[minerX, minerZ + 2].activeSelf)
                        minerZ += 2;
                    else if (Cubes[minerX, minerZ + 2].activeSelf)
                    {
                        Cubes[minerX, minerZ + 1].SetActive(false);
                        Cubes[minerX, minerZ + 2].SetActive(false);
                        minerZ += 2;
                    }
                }
            }
            if (direction == 1)
            {
                if (minerX + 2 < Setting.sizeMazeWidth)
                {
                    if (!Cubes[minerX + 1, minerZ].activeSelf && !Cubes[minerX + 2, minerZ].activeSelf)
                        minerX += 2;
                    else if (Cubes[minerX + 2, minerZ].activeSelf)
                    {
                        Cubes[minerX + 1, minerZ].SetActive(false);
                        Cubes[minerX + 2, minerZ].SetActive(false);
                        minerX += 2;
                    }
                }
            }
            if (direction == 2)
            {
                if (minerZ - 2 >= 0)
                {
                    if (!Cubes[minerX, minerZ - 1].activeSelf && !Cubes[minerX, minerZ - 2].activeSelf)
                        minerZ -= 2;
                    else if (Cubes[minerX, minerZ - 2].activeSelf)
                    {
                        Cubes[minerX, minerZ - 1].SetActive(false);
                        Cubes[minerX, minerZ - 2].SetActive(false);
                        minerZ -= 2;
                    }
                }
            }
            if (direction == 3)
            {
                if (minerX - 2 >= 0)
                {
                    if (!Cubes[minerX - 1, minerZ].activeSelf && !Cubes[minerX - 2, minerZ].activeSelf)
                        minerX -= 2;
                    else if (Cubes[minerX - 2, minerZ].activeSelf)
                    {
                        Cubes[minerX - 1, minerZ].SetActive(false);
                        Cubes[minerX - 2, minerZ].SetActive(false);
                        minerX -= 2;
                    }
                }
            }
            mining = false;
            for (int i = 0; i < Setting.sizeMazeWidth; i += 2)
            {
                for (int j = 0; j < Setting.sizeMazeHeight; j += 2)
                {
                    if (Cubes[i, j].activeSelf)
                        mining = true;
                }
            }
            if (!mining)
                process = false;
        }
    }

    private void SpawnEnd()
    {
        Vector3 pointEnd = new Vector3(0,0,0);
        for (int i = 2; i < Setting.sizeMazeWidth; i += 2)
        {
            for (int j = 2; j < Setting.sizeMazeHeight; j += 2)
            {
                if (Cubes[i, j].transform.position.x >= pointEnd.x && Cubes[i, j].transform.position.z >= pointEnd.z)
                    pointEnd = new Vector3(Cubes[i, j].transform.position.x, 0, Cubes[i, j].transform.position.z);
            }
        }
        Instantiate(_endPrefab, new Vector3(pointEnd.x, 0, pointEnd.z), Quaternion.identity);
    }
}
