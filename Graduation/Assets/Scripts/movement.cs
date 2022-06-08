using UnityEngine;

public class movement : MonoBehaviour
{
	public float speed = 10f;
    // Update is called once per frame
    void Update()
    {
		float HorizontalMovement = Input.GetAxis("Horizontal")*speed;
		float VerticalMovement = Input.GetAxis("Vertical")*speed;
		HorizontalMovement *= Time.deltaTime;
		VerticalMovement *= Time.deltaTime;
		transform.Translate(HorizontalMovement, 0, 0); 
		transform.Translate(0, VerticalMovement, 0);
	}
}
