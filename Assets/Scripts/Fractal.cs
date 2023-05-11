using UnityEngine;
using System.Collections;
using System;

public class Fractal : MonoBehaviour {

	[SerializeField] Mesh mesh;
	[SerializeField] Material material;
	[SerializeField] int maxDepth;
    [SerializeField] float childScale;
    [SerializeField] int depth;

	private void Start () 
	{
		gameObject.AddComponent<MeshFilter>().mesh = mesh;
		gameObject.AddComponent<MeshRenderer>().material = material;
		if (depth < maxDepth) {
			StartCoroutine(CreateChildren());
		}
	}

	private static Vector3[] childDirections =
	{
		Vector3.up,
		Vector3.right,
		Vector3.left,
		Vector3.forward,
		Vector3.back,
	};

	private static Quaternion[] childOrientations =
	{
		Quaternion.identity,
		Quaternion.Euler(0, 0, -90),
        Quaternion.Euler(0, 0, 90),
        Quaternion.Euler(90, 0, 90),
        Quaternion.Euler(90, 0, 90),
    };

    private IEnumerator CreateChildren () 
	{
		for (int i = 0; i < childDirections.Length; i++)
		{
            yield return new WaitForSeconds(0.5f);
            new GameObject("Fractal Child").AddComponent<Fractal>().Initialize(this, i);
        }

		//yield return new WaitForSeconds(0.5f);
		//new GameObject("Fractal Child").AddComponent<Fractal>().Initialize(this, Vector3.right, Quaternion.Euler(0f, 0f, -90f));
		//yield return new WaitForSeconds(0.5f);
		//new GameObject("Fractal Child").AddComponent<Fractal>().Initialize(this, Vector3.left, Quaternion.Euler(0f, 0f, 90f));
	}

	private void Initialize (Fractal parent, int childIndex)
	{
		mesh = parent.mesh;
		material = parent.material;
		maxDepth = parent.maxDepth;
		depth = parent.depth + 1;
		childScale = parent.childScale;
		transform.parent = parent.transform;
		transform.localScale = Vector3.one * childScale;
		transform.localPosition = childDirections[childIndex] * (0.5f + 0.5f * childScale);
		transform.localRotation = childOrientations[childIndex];
	}
}