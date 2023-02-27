using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndlessMap : MonoBehaviour
{

    [SerializeField]
    GameObject joystick;
    [SerializeField]
    GameObject[] walls;
    [SerializeField]
    GameObject player;
    float cWidth;
    float cHeight;
    Vector3 positon;
    // Start is called before the first frame update
    void Start()
    {
        positon = player.transform.position;
        cWidth = Camera.main.orthographicSize * 2f;
        cHeight = cWidth * Camera.main.aspect;
    }

    // Update is called once per frame
    void Update()
    {
        //distanceText.text = "Distance: " + System.Math.Abs(GameObject.Find("Environment").transform.position.x - player.transform.position.x) + " ---- " + System.Math.Abs(GameObject.Find("Environment").transform.position.y - player.transform.position.y);
        if (IsMoving() && Inscreen() == 0)
        {
            GenarateWall();
        }
        positon = player.transform.position;
    }

    void GenarateWall()
    {
        Vector3 Location;
        Vector3 worldLocation;
        bool check = true;
    
        if (joystick.GetComponent<FixedJoystick>().GetV() > 0) // top
        {
            Debug.Log("poooo: top");
            Location = Camera.main.ScreenToWorldPoint(new Vector3(Screen.height + 20, Screen.width / 2, 10));
        }
        else if (joystick.GetComponent<FixedJoystick>().GetV() < 0) // bottom
        {
            Debug.Log("poooo: bottom");
            Location = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.width / 2, 10));
        }
        else if (joystick.GetComponent<FixedJoystick>().GetH() < 0) // left
        {
            Debug.Log("poooo: left");
            Location = Camera.main.ScreenToWorldPoint(new Vector3(Screen.height / 2, -Screen.width / 2 - 20, 10));
        }
        else if (joystick.GetComponent<FixedJoystick>().GetH() > 0) // right
        {
            Debug.Log("poooo: right");
            Location = Camera.main.ScreenToWorldPoint(new Vector3(Screen.height / 2, Screen.width + 20, 10));
        }
        else
        {
            return;
        }

        foreach (var wall in GameObject.FindGameObjectsWithTag("Wall1"))
        {
            if (IsOverride(wall, Location))
            {
                check = false;
                break;
            }
        }

        if (check)
        {
            GameObject ball = Instantiate(walls[Random.Range(0, walls.Length)]) as GameObject;
            ball.transform.position = Location;
        }


    }

    int Inscreen()
    {
        int count = 0;
        foreach (var wall in GameObject.FindGameObjectsWithTag("Wall1"))
        {
            if (System.Math.Abs(wall.transform.position.x - player.transform.position.x) < cHeight / 2
            && System.Math.Abs(wall.transform.position.y - player.transform.position.y) < cWidth / 2)
            {
                count++;
            }
        }
        Debug.Log("count: " + count);
        return count;
    }
    /// <summary>
    /// 0 -> left 
    /// 1 -> right
    /// 2 -> top 
    /// 3 -> bottom
    /// </summary>
    /// <returns></returns>
    int Minimum()
    {
        int[] a = { 0, 0, 0, 0 };
        foreach (var wall in GameObject.FindGameObjectsWithTag("Wall1"))
        {
            if (wall.transform.position.x - player.transform.position.x < 0)
            {
                a[0] = a[0] + 1;
            }

            if (wall.transform.position.x - player.transform.position.x > 0)
            {
                a[1] = a[1] + 1;
            }

            if (wall.transform.position.y - player.transform.position.y < 0)
            {
                a[2] = a[2] + 1;
            }

            if (wall.transform.position.y - player.transform.position.y > 0)
            {
                a[3] = a[3] + 1;
            }
        }
        int Min = a[0];
        foreach (int number in a)
        {
            if (number < Min)
            {
                Min = number;
            }
        }
        for (int i = 0; i < 3; i++)
        {
            if (a[i] == Min) return i;
        }
        return 0;
    }
    bool IsOverride(GameObject go, Vector3 newlocation)
    {
        if (System.Math.Abs(go.transform.position.x - newlocation.x) < 20 && System.Math.Abs(go.transform.position.y - newlocation.y) < 20)
        {
            return true;
        }
        return false;
    }

    bool IsMoving()
    {
        return player.transform.position != positon;
    }
}
