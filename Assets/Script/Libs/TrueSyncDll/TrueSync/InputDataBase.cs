using System;
using System.Collections.Generic;

namespace TrueSync
{
    /// <summary>
    /// DV �̳�ResourcePoolItem ����ض���ӿ�
    /// �����������ݣ���Ҫ�����˼����ӿڡ���һ��owerIDӵ��������
    /// </summary>
	[Serializable]
	public abstract class InputDataBase : ResourcePoolItem
	{
		public byte ownerID;

		public InputDataBase()
		{
		}

        // ���л�
		public abstract void Serialize(List<byte> bytes);

        // �����л�:����
		public abstract void Deserialize(byte[] data, ref int offset);

        // �Ƿ����
		public abstract bool EqualsData(InputDataBase otherBase);

        // ����
		public abstract void CleanUp();

        // ����
		public abstract void CopyFrom(InputDataBase fromBase);
	}
}
