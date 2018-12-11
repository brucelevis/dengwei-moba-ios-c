using System;
using System.Collections.Generic;
using System.Text;

namespace TrueSync
{
    /// <summary>
    /// DV ͬ����Ϣ��������3������,2 ������
    /// </summary>
	public class SyncedInfo
	{
		private const int CHECKSUM_LENGTH = 32;

        // ���ID
		public byte playerId;
        // ֡
		public int tick;
        // У����
		public string checksum;

		public SyncedInfo()
		{
		}

		public SyncedInfo(byte playerId, int tick, string checksum)
		{
			this.tick = tick;
			this.checksum = checksum;
		}

        // ���л�
		public static byte[] Encode(SyncedInfo info)
		{
			List<byte> list = new List<byte>();
			list.Add(info.playerId);
			bool flag = info.checksum != null;
			if (flag)
			{
				list.AddRange(BitConverter.GetBytes(info.tick));
				list.AddRange(Encoding.ASCII.GetBytes(info.checksum));
			}
			return list.ToArray();
		}

        // ����
		public static SyncedInfo Decode(byte[] infoBytes)
		{
			SyncedInfo syncedInfo = new SyncedInfo();
			int num = 0;
			syncedInfo.playerId = infoBytes[num++];
			bool flag = num < infoBytes.Length;
			if (flag)
			{
				syncedInfo.tick = BitConverter.ToInt32(infoBytes, num);
				num += 4;
				syncedInfo.checksum = Encoding.ASCII.GetString(infoBytes, num, 32);
			}
			return syncedInfo;
		}
	}
}
