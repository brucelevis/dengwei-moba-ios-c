using System;
using System.Collections.Generic;

namespace TrueSync
{
    /// <summary>
    /// DV ֡ͬ���й���Ϊ��
    /// ֡ͬ����Ϊ��������ʵ�ֽӿ� ITrueSyncBehaviourGamePlay, ITrueSyncBehaviour, ITrueSyncBehaviourCallbacks
    /// ��Ҫ�ǰ�װ��TrueSyncBehaviour/ITrueSyncBehaviour, ʵ�ֵĽӿڷ���ֱ�ӵ�TrueSyncBehaviour�ķŷ�����TrueSyncBehaviour��OnSyncedStartLocalPlayer ��������Ϊ�Ǳ����û�ʱ�ŵ�
    /// �������һЩȫ�־�̬�������ù������б���¼�
    /// </summary>
	public class TrueSyncManagedBehaviour : ITrueSyncBehaviourGamePlay, ITrueSyncBehaviourCallbacks
	{
		public ITrueSyncBehaviour trueSyncBehavior;

		[AddTracking]
        public bool disabled;// trueʱ���������֡����

		public TSPlayerInfo owner;

		public TrueSyncManagedBehaviour(ITrueSyncBehaviour trueSyncBehavior)
		{
			StateTracker.AddTracking(this);
			StateTracker.AddTracking(trueSyncBehavior);
			this.trueSyncBehavior = trueSyncBehavior;
		}

        #region ITrueSyncBehaviourGamePlay �ӿڷ���
        public void OnPreSyncedUpdate()
		{
			bool flag = this.trueSyncBehavior is ITrueSyncBehaviourGamePlay;
			if (flag)
			{
				((ITrueSyncBehaviourGamePlay)this.trueSyncBehavior).OnPreSyncedUpdate();
			}
		}

		public void OnSyncedUpdate()
		{
			bool flag = this.trueSyncBehavior is ITrueSyncBehaviourGamePlay;
			if (flag)
			{
				((ITrueSyncBehaviourGamePlay)this.trueSyncBehavior).OnSyncedUpdate();
			}
		}
        #endregion ITrueSyncBehaviourGamePlay �ӿڷ���

        #region �������ڷ���
        // ��ʼͬ��
        public static void OnGameStarted(List<TrueSyncManagedBehaviour> generalBehaviours, Dictionary<byte, List<TrueSyncManagedBehaviour>> behaviorsByPlayer)
        {
            int i = 0;
            int count = generalBehaviours.Count;
            while (i < count)
            {
                generalBehaviours[i].OnSyncedStart();
                i++;
            }
            Dictionary<byte, List<TrueSyncManagedBehaviour>>.Enumerator enumerator = behaviorsByPlayer.GetEnumerator();
            while (enumerator.MoveNext())
            {
                KeyValuePair<byte, List<TrueSyncManagedBehaviour>> current = enumerator.Current;
                List<TrueSyncManagedBehaviour> value = current.Value;
                int j = 0;
                int count2 = value.Count;
                while (j < count2)
                {
                    value[j].OnSyncedStart();
                    j++;
                }
            }
        }

        // ��Ϸ��ͣ
        public static void OnGamePaused(List<TrueSyncManagedBehaviour> generalBehaviours, Dictionary<byte, List<TrueSyncManagedBehaviour>> behaviorsByPlayer)
        {
            int i = 0;
            int count = generalBehaviours.Count;
            while (i < count)
            {
                generalBehaviours[i].OnGamePaused();
                i++;
            }
            Dictionary<byte, List<TrueSyncManagedBehaviour>>.Enumerator enumerator = behaviorsByPlayer.GetEnumerator();
            while (enumerator.MoveNext())
            {
                KeyValuePair<byte, List<TrueSyncManagedBehaviour>> current = enumerator.Current;
                List<TrueSyncManagedBehaviour> value = current.Value;
                int j = 0;
                int count2 = value.Count;
                while (j < count2)
                {
                    value[j].OnGamePaused();
                    j++;
                }
            }
        }

        // ȡ����ͣ
        public static void OnGameUnPaused(List<TrueSyncManagedBehaviour> generalBehaviours, Dictionary<byte, List<TrueSyncManagedBehaviour>> behaviorsByPlayer)
        {
            int i = 0;
            int count = generalBehaviours.Count;
            while (i < count)
            {
                generalBehaviours[i].OnGameUnPaused();
                i++;
            }
            Dictionary<byte, List<TrueSyncManagedBehaviour>>.Enumerator enumerator = behaviorsByPlayer.GetEnumerator();
            while (enumerator.MoveNext())
            {
                KeyValuePair<byte, List<TrueSyncManagedBehaviour>> current = enumerator.Current;
                List<TrueSyncManagedBehaviour> value = current.Value;
                int j = 0;
                int count2 = value.Count;
                while (j < count2)
                {
                    value[j].OnGameUnPaused();
                    j++;
                }
            }
        }

        // ��Ϸ����
        public static void OnGameEnded(List<TrueSyncManagedBehaviour> generalBehaviours, Dictionary<byte, List<TrueSyncManagedBehaviour>> behaviorsByPlayer)
        {
            int i = 0;
            int count = generalBehaviours.Count;
            while (i < count)
            {
                generalBehaviours[i].OnGameEnded();
                i++;
            }
            Dictionary<byte, List<TrueSyncManagedBehaviour>>.Enumerator enumerator = behaviorsByPlayer.GetEnumerator();
            while (enumerator.MoveNext())
            {
                KeyValuePair<byte, List<TrueSyncManagedBehaviour>> current = enumerator.Current;
                List<TrueSyncManagedBehaviour> value = current.Value;
                int j = 0;
                int count2 = value.Count;
                while (j < count2)
                {
                    value[j].OnGameEnded();
                    j++;
                }
            }
        }

        // ��ҶϿ�����
        public static void OnPlayerDisconnection(List<TrueSyncManagedBehaviour> generalBehaviours, Dictionary<byte, List<TrueSyncManagedBehaviour>> behaviorsByPlayer, byte playerId)
        {
            int i = 0;
            int count = generalBehaviours.Count;
            while (i < count)
            {
                generalBehaviours[i].OnPlayerDisconnection((int)playerId);
                i++;
            }
            Dictionary<byte, List<TrueSyncManagedBehaviour>>.Enumerator enumerator = behaviorsByPlayer.GetEnumerator();
            while (enumerator.MoveNext())
            {
                KeyValuePair<byte, List<TrueSyncManagedBehaviour>> current = enumerator.Current;
                List<TrueSyncManagedBehaviour> value = current.Value;
                int j = 0;
                int count2 = value.Count;
                while (j < count2)
                {
                    value[j].OnPlayerDisconnection((int)playerId);
                    j++;
                }
            }
        }
        #endregion �������ڷ���

        #region ITrueSyncBehaviourCallbacks �ӿڷ���
        // ��ʼͬ��
        public void OnSyncedStart()
		{	
            bool flag = this.trueSyncBehavior is ITrueSyncBehaviourCallbacks;
            if (flag)
            {
                ((ITrueSyncBehaviourCallbacks)this.trueSyncBehavior).OnSyncedStart();
            }
		}

        // ��Ϸ��ͣ
		public void OnGamePaused()
		{
			bool flag = this.trueSyncBehavior is ITrueSyncBehaviourCallbacks;
			if (flag)
			{
				((ITrueSyncBehaviourCallbacks)this.trueSyncBehavior).OnGamePaused();
			}
		}

        // ȡ����ͣ
		public void OnGameUnPaused()
		{
			bool flag = this.trueSyncBehavior is ITrueSyncBehaviourCallbacks;
			if (flag)
			{
				((ITrueSyncBehaviourCallbacks)this.trueSyncBehavior).OnGameUnPaused();
			}
		}

        // ��Ϸ����
		public void OnGameEnded()
		{
			bool flag = this.trueSyncBehavior is ITrueSyncBehaviourCallbacks;
			if (flag)
			{
				((ITrueSyncBehaviourCallbacks)this.trueSyncBehavior).OnGameEnded();
			}
		}

        // ��ҶϿ�����
		public void OnPlayerDisconnection(int playerId)
		{
			bool flag = this.trueSyncBehavior is ITrueSyncBehaviourCallbacks;
			if (flag)
			{
				((ITrueSyncBehaviourCallbacks)this.trueSyncBehavior).OnPlayerDisconnection(playerId);
			}
		}
        #endregion ITrueSyncBehaviourCallbacks �ӿڷ���
    }
}
