using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    private const float PIPE_MOVE_SPEED = 10f;
    private const float GROUND_DESTROY_X_POSITION = -50f;
    private const float GROUND_SPAWN_X_POSITION = 100f;

    [SerializeField]
    private List<Transform> groundList;

    [SerializeField]
    Transform groundTransform;



    private static Level instance;
    public static Level GetLevel()
    {
        return instance;
    }



    private void Awake() 
    {
        instance = this;

        InitialGroundSpawning();
    }
    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update() 
    {
        HandleGroundMovement();
    }



    //Spawn first Ground
    private void InitialGroundSpawning()
    {
        // Transform groundTransform;
        float yPosition = -0f;

        groundTransform = Instantiate(Game_Assets.GetInstance().Ground_Pf, new Vector3(GROUND_SPAWN_X_POSITION,yPosition,0), Quaternion.identity);
        groundList.Add(groundTransform);
        groundTransform = Instantiate(Game_Assets.GetInstance().Ground_Pf, new Vector3(0,yPosition,0), Quaternion.identity);
        groundList.Add(groundTransform);
        groundTransform = Instantiate(Game_Assets.GetInstance().Ground_Pf, new Vector3(40,yPosition,0), Quaternion.identity);
        groundList.Add(groundTransform);
    }

    //Ground Moving Handler
    private void HandleGroundMovement()
    {
        foreach (Transform groundTransform in groundList)
        {
            //Move ground to the left
            groundTransform.position += new Vector3(-1, 0, 0) * PIPE_MOVE_SPEED * Time.deltaTime;

            //Could find the right edge's position of the other ground prefab 
            if (groundTransform.position.x <= GROUND_DESTROY_X_POSITION)
            {
                groundTransform.position = new Vector3(GROUND_SPAWN_X_POSITION, groundTransform.position.y, 0); 
            }
        }
    }



}
