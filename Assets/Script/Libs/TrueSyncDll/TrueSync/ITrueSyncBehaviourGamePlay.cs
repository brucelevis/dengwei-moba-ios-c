using System;

namespace TrueSync
{
    /// <summary>
    /// DV �ӿ� ��Ҳ���֡ͬ����Ϊ, �̳���ITrueSyncBehaviour
    /// </summary>
	public interface ITrueSyncBehaviourGamePlay : ITrueSyncBehaviour
	{
        /// <summary>
        /// DV ͬ�� Ԥ��ȡ��Ҳ���
        /// </summary>
		void OnPreSyncedUpdate();

        /// <summary>
        /// DV ͬ�� ��ȡ��Ҳ���
        /// </summary>
		void OnSyncedUpdate();
	}
}
