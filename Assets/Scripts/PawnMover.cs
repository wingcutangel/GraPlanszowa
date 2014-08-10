using UnityEngine;
using System.Collections;

public class PawnMover : MonoBehaviour {
	static float jumpSpeed = 0.5f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("space")){
			StartCoroutine(Jump(transform.position + new Vector3(5f, 0f, 0f)));
		}
	}
	public IEnumerator Jump (Vector3 target){
		var startPos = transform.position;
		var startTime = Time.time;
		while (Time.time < startTime + jumpSpeed){
			var newPos = Vector3.Lerp(startPos, target, (Time.time - startTime) / jumpSpeed);
			newPos.y = startPos.y + Mathf.Sin (Mathf.Lerp(0f, Mathf.PI,(Time.time - startTime) / jumpSpeed));
			transform.position = newPos;
			yield return null;
		}
		transform.position = target;
	}
}
