using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public Maze mazePrefab;
    private Maze mazeInstance;

    public Player playerPrefab;
    private Player playerInstance;

    public Food foodPrefab;
    private Food foodInstance;

	// Use this for initialization
	void Start () {
        StartCoroutine(BeginGame());
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RestartGame();
        }

        if (AtFood())
        {
            HUDInfo._Hunger += 100;
            SpawnNewFood();
        }
    }

    private IEnumerator BeginGame()
    {
        Camera.main.clearFlags = CameraClearFlags.Skybox;
        Camera.main.rect = new Rect(0f, 0f, 1f, 1f);
        HUDInfo._Hunger = 200;
        mazeInstance = Instantiate(mazePrefab) as Maze;
        yield return StartCoroutine(mazeInstance.Generate());
        playerInstance = Instantiate(playerPrefab) as Player;
        playerInstance.SetLocation(mazeInstance.GetCell(mazeInstance.RandomCoordinates));
        Player.gameOver = false;
        foodInstance = Instantiate(foodPrefab) as Food;
        SpawnNewFood();
        Camera.main.clearFlags = CameraClearFlags.Depth;
        Camera.main.rect = new Rect(0f, 0f, 0.5f, 0.5f);
    }

    private void RestartGame()
    {
        StopAllCoroutines();
        Destroy(mazeInstance.gameObject);
        if (foodInstance != null)
        {
            Destroy(foodInstance.gameObject);
        }
        if (playerInstance != null)
        {
            Destroy(playerInstance.gameObject);
        }
        StartCoroutine(BeginGame());
    }

    private bool AtFood()
    {
        if (playerInstance != null && foodInstance != null)
        {
            return (playerInstance.GetLocation().coordinates.x == foodInstance.GetLocation().coordinates.x
         && playerInstance.GetLocation().coordinates.z == foodInstance.GetLocation().coordinates.z);
        }
        else
        {
            return false;
        }
        
    }

    private void SpawnNewFood()
    {
        IntVector2 foodLocation = mazeInstance.RandomCoordinates;
        foodInstance.SetLocation(mazeInstance.GetCell(foodLocation));
    }
}
