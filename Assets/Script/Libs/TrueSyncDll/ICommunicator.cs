using System;

/// <summary>
/// TrueSync's communicator interface.
/// TrueSync��ͨ���� �ӿ�
/// </summary>
public interface ICommunicator
{
    /// <summary>
    /// Returns the roundtrip time between local player and server. 
    /// ����ʱ��
    /// </summary>
	int RoundTripTime();

    /// <summary>
    /// Raises a custom event to be sent to all other players.
    /// ����ʱ��
    /// </summary>
    /// <param name="eventCode">Code of the custom event</param>
    /// <param name="message">Message to be sent in event's body</param>
    /// <param name="reliable">If true it should have a guaranteed delivery</param>
    /// <param name="toPlayers"></param>
	void OpRaiseEvent(byte eventCode, object message, bool reliable, int[] toPlayers);

}
