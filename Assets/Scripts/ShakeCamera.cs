using UnityEngine;
using Cinemachine;
using UnityEngine.Serialization;

public class ShakeCamera : MonoBehaviour
{

	[SerializeField] private float initialPower, finalPowerMultiplier;
	
	private float shakeDuration;
	private CinemachineVirtualCamera cinemachineVirtualCamera;
	
	
	public static ShakeCamera instance;


	private void Start() {
		instance = this;
		cinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();
	}

	private void Update() {
		/*if (shakeDuration >= 0) {
			Vector2 shakePosition = Random.insideUnitCircle * shakePower;
			transform.position = new Vector3(transform.position.x + shakePosition.x, transform.position.y + shakePosition.y, transform.position.z);
			shakeDuration -= Time.deltaTime;
			
		} else {
			transform.position = startPosition;
		}*/

		if (shakeDuration > 0)
		{
			shakeDuration -= Time.deltaTime;

			if (shakeDuration <= 0)
			{
				CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin =
					cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

				cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = initialPower;
			}
		}
	}

	public void Shake(float power, float duration) {
		/*shakePower = _shakePower;
		shakeDuration = _shakeDuration;*/
		CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin =
			cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

		cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = finalPowerMultiplier * power;
		shakeDuration = duration;
	}
}
