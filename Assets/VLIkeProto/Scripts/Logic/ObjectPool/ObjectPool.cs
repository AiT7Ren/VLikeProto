using System;
using UnityEngine;
using System.Collections.Generic;
using Object = UnityEngine.Object;

public class ObjectPool<T>where T : MonoBehaviour
{
   private List<T> _objectPool;
   private Transform _parentObj;

   public ObjectPool(int size,T obj,Transform parent)
   {
      _parentObj=parent;
      CreatePool(size,obj);
   }
   
   private void CreatePool(int size,T obj)
   {
      _objectPool = new List<T>(size);
      while (size>0)
      {
         FartoryCreate(obj);
         size--;
      }
   }

   public T GetPoolObject()
   {
      for (int i = 0; i < _objectPool.Count; i++)
      {
         if (!_objectPool[i].isActiveAndEnabled)
         {
            return _objectPool[i];
         }
      }
      FartoryCreate(_objectPool[0]);
      return GetPoolObject();
   }
   
   private void FartoryCreate(T obj) //TODO
   {
      var go = Object.Instantiate(obj,_parentObj);
      go.gameObject.SetActive(false);
      _objectPool.Add(go);
   }
   
}
