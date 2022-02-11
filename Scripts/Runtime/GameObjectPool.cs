using UnityEngine;
using CM.ObjectCreation;

namespace CM.Collections
{
	public class GameObjectPool : MonoBehaviour, IObjectPool<GameObject>
	{
		public int PreloadAmount => _preloadAmount;
		public int MaxObjects { get => objectPool.MaxObjects; set => objectPool.MaxObjects = value; }
		public bool IsEmpty => objectPool.IsEmpty;
		public int Count => objectPool.Count;
		public GameObject DefaultObject { get => objectPool.DefaultObject; set => objectPool.DefaultObject = value; }

		[SerializeField]
		private int _preloadAmount;

		[SerializeField]
		private int _maxObjects;

		[SerializeField]
		private GameObject _defaultObject;

		protected ObjectPool<GameObject> objectPool;

		public void AddReusable(GameObject reusable)
		{
			objectPool.AddReusable(reusable);
		}

		public GameObject GetReusable()
		{
			return objectPool.GetReusable();
		}

		private void Awake()
		{
			GameObjectCreator gameObjectCreator = new GameObjectCreator();

			objectPool = new ObjectPool<GameObject>(gameObjectCreator, _defaultObject, _maxObjects);

			PreloadObjectPool(gameObjectCreator, _preloadAmount);
		}

		private void PreloadObjectPool(GameObjectCreator gameObjectCreator, int amount)
		{
			for (int i = 0; i < amount; i++)
			{
				GameObject reusableObject = gameObjectCreator.CloneObject(_defaultObject);

				reusableObject.SetActive(false);

				objectPool.AddReusable(reusableObject);
			}
		}
	}
}