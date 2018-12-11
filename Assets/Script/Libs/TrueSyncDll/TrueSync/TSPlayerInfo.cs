using System;
using UnityEngine;

namespace TrueSync
{
    /// <summary>
    /// DV ֡ͬ�������Ϣ
    /// </summary>
	[Serializable]
	public class TSPlayerInfo
	{
		[SerializeField]
        internal byte id;// ���ID

		[SerializeField]
        internal string name;// �������

		public byte Id
		{
			get
			{
				return this.id;
			}
		}

		public string Name
		{
			get
			{
				return this.name;
			}
		}

		public TSPlayerInfo(byte id, string name)
		{
			this.id = id;
			this.name = name;
		}
	}
}
