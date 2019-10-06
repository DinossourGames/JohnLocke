using UnityEngine;

public class cameraFollow : MonoBehaviour
{
	public Transform PlayerTransform;

	[Space]
	public float speed;

	[Header("Boundaries")]
	public float minX;
	public float maxX;
	public float minY;
	public float maxY;

	private Vector2 _currentVelocity;

	private void Awake() => transform.position = GetClampedPosition(PlayerTransform.position);
	private void FixedUpdate() => Follow();

	private void Follow()
	{
		if (PlayerTransform == null)
			return;

		Vector3 selfPosition = transform.position;
		Vector2 targetPosition = GetClampedPosition(PlayerTransform.position);

		transform.position = Vector2.SmoothDamp(selfPosition, targetPosition, ref _currentVelocity, 1 / speed);
	}

	private Vector2 GetClampedPosition(Vector3 position)
	{
		float clampedX = Mathf.Clamp(position.x, minX, maxX);
		float clampedY = Mathf.Clamp(position.y, minY, maxY);

		return new Vector2(clampedX, clampedY);
	}
}