using UnityEngine;

public class HitBoxRenderer : MonoBehaviour
{
	private new Collider collider;
	private PrimitiveType primitive;

	public void RenderHitbox(Material hitboxMaterial)
	{
		Mesh customMesh = null;

		var canScale = true;

		collider = GetComponent<Collider>();

		var colliderType = collider.GetType();

		if(colliderType == typeof(CapsuleCollider))
		{ 
			primitive = PrimitiveType.Capsule;
		}
		else if(colliderType == typeof(SphereCollider))
		{
			primitive = PrimitiveType.Sphere;
		}
		else if(colliderType == typeof(MeshCollider))
		{
			customMesh = ((MeshCollider) collider).sharedMesh;

			if(customMesh.name == "Plane")
			{
				canScale = false;
			}
		}
		else
		{
			primitive = PrimitiveType.Cube;
		}

		var mesh = GameObject.CreatePrimitive(primitive);

		Destroy(mesh.GetComponent<Collider>());

		mesh.transform.SetParent(transform, false);
		mesh.transform.position = collider.transform.position;
		mesh.name = "Hitbox";
		mesh.tag = "VisibleHitbox";

		if(canScale)
		{
			var parentScale = collider.transform.localScale;
			var meshScale = mesh.transform.localScale;
			var newScale = new Vector3(
				(0.2f / parentScale.x) + meshScale.x,
				(0.2f / parentScale.y) + meshScale.y,
				(0.2f / parentScale.z) + meshScale.z
				);

			mesh.transform.localScale = newScale;
		}

		if(customMesh != null)
		{
			mesh.GetComponent<MeshFilter>().mesh = customMesh;
		}

		mesh.GetComponent<MeshRenderer>().materials = new Material[] { hitboxMaterial };
	}
}
