using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //panning speed
    public float moveSpeed;

    //invisible walls
    public float leftBorder;
    public float upBorder;
    public float rightBorder;
    public float downBorder;

    public ItemSpawner itemSpawner;
    public Soup soup;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //left
        if(Input.mousePosition.x <= 0)
        {
            if (gameObject.transform.position.x >= leftBorder)
            {
                gameObject.transform.Translate(Vector3.left * Time.deltaTime * moveSpeed);
            }
        }
        //right
        if (Input.mousePosition.x >= Screen.width)
        {
            if (gameObject.transform.position.x <= rightBorder)
            {
                gameObject.transform.Translate(-Vector3.left * Time.deltaTime * moveSpeed);
            }
        }
        //up
        if (Input.mousePosition.y >= Screen.height)
        {
            if (gameObject.transform.position.y <= upBorder)
            {
                gameObject.transform.Translate(Vector3.up * Time.deltaTime * moveSpeed);
            }
        }
        //down
        if (Input.mousePosition.y <= 0)
        {
            if (gameObject.transform.position.y >= downBorder)
            {
                gameObject.transform.Translate(-Vector3.up * Time.deltaTime * moveSpeed);
            }
        }

        //item grabbing
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePosition2D = new Vector2(mousePosition.x, mousePosition.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePosition2D, Vector2.zero);
            if (hit.collider != null)
            {
                if(hit.collider.gameObject.layer == LayerMask.NameToLayer("item"))
                {
                    Item itemClicked = hit.collider.gameObject.GetComponent<Item>();
                    itemSpawner.totalItemsSpawned -= 1;
                    soup.addItem(itemClicked);
                    Debug.Log("Added " + itemClicked.name + " To Soup");
                    Destroy(hit.collider.gameObject);
                }
            }
        }
    }
}
