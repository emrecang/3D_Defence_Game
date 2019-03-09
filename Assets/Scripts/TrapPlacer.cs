using UnityEngine;

public class TrapPlacer : MonoBehaviour
{
    private Camera fpsCam;
    private LineRenderer fpsLine;
    public TrapCollision trapLogic;
    public GameObject[] TrapPrefabs;
    public GameObject[] GhostTrapPrefabs;
    public GameObject ghostTrap;
    public GameObject ghost;
    public Material green;
    public Material red;

    public LayerMask walls;


    CursorLockMode wantedCursorMode;

    [Range(10, 100)]
    public float maxDistance = 20f;
    public int index = 0;
    public int tempIndex = 0;
    public bool isPlaceEmpty = false;
    public bool isWallColliding = false;
    public bool isPlacable = true;
    public bool trapPhase = true;
    bool ghostCreated = false;

    private void Start()
    {
        fpsLine = GetComponent<LineRenderer>();
        fpsCam = GetComponentInChildren<Camera>();
    }
    public void FixedUpdate()
    {
        if (trapPhase)
        {
            wantedCursorMode = CursorLockMode.Locked;
            GhostTrap();
        }
        else
        {
            ExitTrapPhase();
        }
        SetCursorState();
    }
 
    public bool placeTrap(RaycastHit hit)
    {
        GameObject candidateWall = hit.collider.gameObject;
        WallCalculation cwScript = candidateWall.GetComponent<WallCalculation>();
        isWallColliding = trapLogic.isCollidingWall();

        if (hit.collider.gameObject.CompareTag("WallObject")){
            isPlacable = cwScript.CalculateWallScale(hit.point.x, hit.point.z);
        }

        if(hit.collider.gameObject.CompareTag("GroundObject") && !isWallColliding)
        {
            isPlacable = cwScript.CalculateGroundScale(hit.point.x, hit.point.z);
        }
        
        if (Input.GetKeyDown(KeyCode.Mouse0) && isPlacable )
        {
            if (isPlaceEmpty)
            {
                Instantiate(TrapPrefabs[index], spawnPosCalculator(hit), hit.transform.rotation);
                return true;
            }
        }
        return false;
    }

    public Vector3 spawnPosCalculator(RaycastHit hit)
    {
        Vector3 spawnPos = new Vector3(Mathf.Round(hit.point.x), hit.transform.position.y, Mathf.Round(hit.point.z));
        return spawnPos;
    }


    public void GhostTrap()
    {
        Vector3 originAim = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit hit;

        if (Physics.Raycast(originAim, fpsCam.transform.forward, out hit, maxDistance, walls))
        {
            if (!ghostCreated)
            {
                InstantiateGhostTrap(hit);
            }

            if (ghostCreated && (tempIndex != index))
            {
                Destroy(ghostTrap);
                ghostCreated = false;
            }

            if (ghostCreated)
            {
                ghostTrap.transform.position = spawnPosCalculator(hit);
                ghostTrap.transform.rotation = hit.transform.rotation;

                isPlaceEmpty = trapLogic.isEmptyGet();
                Debug.Log(isPlaceEmpty + " <--- this | trap's--->  " + trapLogic.isEmptyGet());

                if (isPlacable && isPlaceEmpty)
                {
                    ghostTrap.gameObject.GetComponent<MeshRenderer>().material = green;
                }
                else
                {
                    ghostTrap.gameObject.GetComponent<MeshRenderer>().material = red;

                    trapLogic.deletion = false;
                }
            }
            if(Input.GetKeyUp(KeyCode.F))
            {
                trapLogic.deleteTrap(hit);
                isPlaceEmpty = true;
                trapLogic.deletion = true;
                trapLogic.isEmptySet(true);
            }

            isPlacable = false;
            placeTrap(hit);
        }
        else
        {
            Debug.Log("TOO FAR");
        }
    }

    void InstantiateGhostTrap(RaycastHit hit)
    {
        ghostTrap = Instantiate(GhostTrapPrefabs[index], spawnPosCalculator(hit), hit.transform.rotation);
        ghostTrap.transform.localScale = TrapPrefabs[index].transform.lossyScale; //koyulcak trap ile ghosttrap aynı boyuta sahip olsun diye.
        ghostCreated = true;
        trapLogic = ghostTrap.GetComponent<TrapCollision>();
        tempIndex = index;
    }

    void ExitTrapPhase()
    {
        Destroy(ghostTrap);
        ghostCreated = false;
    }
    void SetCursorState()
    {
        Cursor.lockState = wantedCursorMode;
        Cursor.visible = (CursorLockMode.Locked != wantedCursorMode);
    }
}
