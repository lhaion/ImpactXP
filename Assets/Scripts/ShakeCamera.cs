using UnityEngine;

public class ShakeCamera : MonoBehaviour {

	public static float shakePower;
	public static float shakeDuration;

	private Vector3 startPosition;

	private void Start() {
		startPosition = transform.position;
	}

	private void Update() {
		if (shakeDuration >= 0) {
			Vector2 shakePosition = Random.insideUnitCircle * shakePower;
			transform.position = new Vector3(transform.position.x + shakePosition.x, transform.position.y + shakePosition.y, transform.position.z);
			shakeDuration -= Time.deltaTime;
			
		} else {
			transform.position = startPosition;
		}
	}

	public static void Shake(float _shakePower, float _shakeDuration) {
		shakePower = _shakePower;
		shakeDuration = _shakeDuration;
	}
}
