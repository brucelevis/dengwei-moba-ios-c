using System;
using System.Collections.Generic;
using UnityEngine;

namespace TrueSync
{
    /// <summary>
    /// DV ֡ͬ�����
    /// </summary>
	[Serializable]
	public class TSPlayer
	{
        /// <summary>
        /// ֡ͬ�������Ϣ
        /// </summary>
		[SerializeField]
		public TSPlayerInfo playerInfo;

        /// <summary>
        /// ���ߴ���
        /// </summary>
		[NonSerialized]
        public int dropCount; 

        /// <summary>
        /// �Ƿ����
        /// </summary>
		[NonSerialized]
        public bool dropped;

        /// <summary>
        /// �����������ս���Ĳ���ͬ������, ����һ���ֵ�SerializableDictionary<int, SyncedData>
        /// </summary>
		[SerializeField]
        internal SerializableDictionaryIntSyncedData controls;

        /// <summary>
        /// ���һ�� ͬ���������ݵ�֡, AddData(SyncedData data)
        /// </summary>
        private int lastTick;

		public byte ID
		{
			get
			{
				return this.playerInfo.id;
			}
		}

		internal TSPlayer(byte id, string name)
		{
            // ���������Ϣ
			this.playerInfo = new TSPlayerInfo(id, name);
			this.dropCount = 0;
			this.dropped = false;
            // ������Ҳ����ֵ�洢��
			this.controls = new SerializableDictionaryIntSyncedData();
		}

        #region ��������
        /// <summary>
        /// DV �����Ƿ���׼����
        /// ��ȡĳ֡�Ƿ�����ʵͬ����������
        /// </summary>
        public bool IsDataReady(int tick)
		{
            return true;
			//return this.controls.ContainsKey(tick) && !this.controls[tick].fake;
		}

        /// <summary>
        /// DV �ǲ���������
        /// ��ȡĳ֡�Ƿ���ģ��ͬ����������, �ͻ������У��ǿͻ���Ԥ��Ĳ���, �ع���ӵġ�
        /// </summary>
		public bool IsDataDirty(int tick)
		{
			bool flag = this.controls.ContainsKey(tick);
			return flag && this.controls[tick].dirty;
		}
        
        /// <summary>
        /// DV ��ȡ��֡��ͬ����������
        /// </summary>
        public SyncedData GetData(int tick)
		{
			bool flag = !this.controls.ContainsKey(tick);
			SyncedData result;
			if (flag) // û������
			{
                bool flag2 = this.controls.ContainsKey(tick - 1); // ��������ڣ��Ͳ�����һ֡�Ƿ����
				SyncedData syncedData;
				if (flag2) // ������,��ǰһ�����ݸ���Ϊ��ǰ����
				{
					syncedData = this.controls[tick - 1].clone();
					syncedData.tick = tick;
				}
				else // û������,��ȡһ���µ�����
				{
					syncedData = SyncedData.pool.GetNew();
					syncedData.Init(this.ID, tick);
				}
				syncedData.fake = true; // ����Ϊ������
                this.controls[tick] = syncedData;// ���浽֡�ֵ�
				result = syncedData;
			}
			else // �������,�ͷ��ظ�֡����
			{
				result = this.controls[tick];
			}
			return result;
		}

        /// <summary>
        /// DV ��Ӵ���֡ͬ������
        /// </summary>
		public void AddData(SyncedData data)
		{
			int tick = data.tick;
			bool flag = this.controls.ContainsKey(tick);
			if (flag) // �����Ѵ��ڣ������ݶ�����յ�����
			{
				SyncedData.pool.GiveBack(data);
			}
			else // δ������
			{
				this.controls[tick] = data;
                this.lastTick = tick;// �������洢��֡
			}
		}

        /// <summary>
        /// DV ��Ӵ���֡ͬ������
        /// </summary>
		public void AddData(List<SyncedData> data)
		{
			for (int i = 0; i < data.Count; i++)
			{
				this.AddData(data[i]);
			}
		}

        // �Ƴ�����
		public void RemoveData(int refTick)
		{
			bool flag = this.controls.ContainsKey(refTick);
			if (flag)
			{
				SyncedData.pool.GiveBack(this.controls[refTick]);
				this.controls.Remove(refTick);
			}
		}

        // ����ͬ������
		public void AddDataProjected(int refTick, int window)
		{
			SyncedData syncedData = this.GetData(refTick);
			for (int i = 1; i <= window; i++)
			{
				SyncedData data = this.GetData(refTick + i);
				bool fake = data.fake;
				if (fake)
				{
					SyncedData syncedData2 = syncedData.clone();
					syncedData2.fake = true;
					syncedData2.tick = refTick + i;
					bool flag = this.controls.ContainsKey(syncedData2.tick);
					if (flag)
					{
						SyncedData.pool.GiveBack(this.controls[syncedData2.tick]);
					}
					this.controls[syncedData2.tick] = syncedData2;
				}
				else
				{
					bool dirty = data.dirty;
					if (dirty)
					{
						data.dirty = false;
						syncedData = data;
					}
				}
			}
		}

        // �������
		public void AddDataRollback(List<SyncedData> data)
		{
			for (int i = 0; i < data.Count; i++)
			{
				SyncedData data2 = this.GetData(data[i].tick);
				bool fake = data2.fake;
				if (fake) // ȡ�����Ǽ�����
				{
					bool flag = data2.EqualsData(data[i]);
					if (!flag) // �������ݲ����
					{
						data[i].dirty = true; // ����Ϊ������
						SyncedData.pool.GiveBack(this.controls[data[i].tick]); // ���ո�λ�õ�����
						this.controls[data[i].tick] = data[i]; // ����������
						break; // �жϣ�û����һ������Ҫ����
					}
					data2.fake = false;
					data2.dirty = false;
				}
				SyncedData.pool.GiveBack(data[i]);
			}
		}

		public bool GetSendDataForDrop(byte fromPlayerId, SyncedData[] sendWindowArray)
		{
			bool flag = this.controls.Count == 0;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				this.GetDataFromTick(this.lastTick, sendWindowArray);
				sendWindowArray[0] = sendWindowArray[0].clone();
				sendWindowArray[0].dropFromPlayerId = fromPlayerId;
				sendWindowArray[0].dropPlayer = true;
				result = true;
			}
			return result;
		}

		public void GetSendData(int tick, SyncedData[] sendWindowArray)
		{
			this.GetDataFromTick(tick, sendWindowArray);
		}
        #endregion ��������

        #region ˽�з���
        private void GetDataFromTick(int tick, SyncedData[] sendWindowArray)
        {
            for (int i = 0; i < sendWindowArray.Length; i++)
            {
                // �Ե���ķ�ʽ�����ݷ���������
                sendWindowArray[i] = this.GetData(tick - i);
            }
        }
        #endregion ˽�з���
    }
}
