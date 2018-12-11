using System;
using System.Collections.Generic;

namespace TrueSync
{
    /// <summary>
    /// DV ��Դ��(������)
    /// ��һ����������,����һ����̬������б����������ж���ص�����CleanUpAll();
    /// </summary>
	public abstract class ResourcePool
	{
		protected bool fresh = true;

        // Ϊ�����������Դ�ض�����
		protected static List<ResourcePool> resourcePoolReferences = new List<ResourcePool>();

        // ȫ�����
		public static void CleanUpAll()
		{
			int i = 0;
			int count = ResourcePool.resourcePoolReferences.Count;
			while (i < count)
			{
				ResourcePool.resourcePoolReferences[i].ResetResourcePool();
				i++;
			}
			ResourcePool.resourcePoolReferences.Clear();
		}

        // ����
		public abstract void ResetResourcePool();
	}

    // ��Դ��
	public class ResourcePool<T> : ResourcePool
	{
		protected Stack<T> stack = new Stack<T>(10);

        #region ��������
        // ����Ԫ�ص�����
		public int Count
		{
			get
			{
				return this.stack.Count;
			}
		}

        // ����
		public override void ResetResourcePool()
		{
			this.stack.Clear();
			this.fresh = true;
		}

        /// <summary>
        /// ����Ԫ��
        /// DV ���ض���
        /// </summary>
		public void GiveBack(T obj)
		{
			this.stack.Push(obj);
		}

        /// <summary>
        /// ��ȡԪ��
        /// DV ��ȡ����, ���T��ResourcePoolItem��������ͻ�������CleanUp()����
        /// </summary>
        public T GetNew()
        {
            bool fresh = this.fresh;
            if (fresh)
            {
                ResourcePool.resourcePoolReferences.Add(this);
                this.fresh = false;
            }
            bool flag = this.stack.Count == 0;
            if (flag) // ����û��Ԫ��
            {
                this.stack.Push(this.NewInstance());
            }
            T t = this.stack.Pop();
            bool flag2 = t is ResourcePoolItem;
            if (flag2) // �����Ԫ����ResourcePoolItem���ͣ���Ҫ��ִ������
            {
                ((ResourcePoolItem)((object)t)).CleanUp();
            }
            return t;
        }
        #endregion ��������

        /// <summary>
        /// ����Ԫ��ʵ��:ʵ��������
        /// </summary>
		protected virtual T NewInstance()
		{
			return Activator.CreateInstance<T>();
		}
	}
}
