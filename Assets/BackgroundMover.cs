using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMover : MonoBehaviour
{
    private SpriteRenderer myRenderer;
    public float speed;
    const int distanceBeforeWrap = -20;
    const int distanceAfterWrap = 20;


    void Start()
    {
        myRenderer = this.GetComponent<SpriteRenderer>() as SpriteRenderer;
        //Debug.Log(myRenderer.size.x);
        //TODO: See if I can make a background element disappear only when it's not visible, by tracking if x+sprite width is < camera left bound's x
    }

    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
        if (transform.position.x < distanceBeforeWrap) transform.position = new Vector3(distanceAfterWrap, 0,0);
    }
}
