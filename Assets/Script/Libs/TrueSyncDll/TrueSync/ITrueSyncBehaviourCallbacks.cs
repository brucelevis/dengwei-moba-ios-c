using System;

namespace TrueSync
{
    /// <summary>
    /// DV �ӿ� �ص�ͬ����Ϊ, �̳���ITrueSyncBehaviour
    /// </summary>
	public interface ITrueSyncBehaviourCallbacks : ITrueSyncBehaviour
	{
        // ��ʼ
		void OnSyncedStart();

        // ��Ϸ��ͣ
		void OnGamePaused();

        // ��Ϸ����
		void OnGameUnPaused();

        // ������Ϸ�ˣ� ʲôʱ����� ��Ҳ�����
		void OnGameEnded();

        // ���������ʱ����
		void OnPlayerDisconnection(int playerId);
	}
}
