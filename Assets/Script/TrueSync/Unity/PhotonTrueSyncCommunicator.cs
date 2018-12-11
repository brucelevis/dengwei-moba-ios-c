using System;

namespace TrueSync {

    /// <summary>
    /// Truesync's ICommunicator implementation based on PUN.
    /// ֡ͬ�� ͨ������ ʵ��ICommunicator�ӿ�( TrueSyncManager��Start()�г�ʼ��)
    /// </summary>
    public class PhotonTrueSyncCommunicator : ICommunicator {

        //private LoadBalancingPeer loadBalancingPeer;

        //private static PhotonNetwork.EventCallback lastEventCallback;

        /**
         *  @brief Instantiates a new PhotonTrueSyncCommunicator based on a Photon's LoadbalancingPeer. 
         *  
         *  @param loadBalancingPeer Instance of a Photon's LoadbalancingPeer.
         **/
        //internal PhotonTrueSyncCommunicator(LoadBalancingPeer loadBalancingPeer) {
        //    this.loadBalancingPeer = loadBalancingPeer;
        //}

        public int RoundTripTime()
        {
            return 0;//loadBalancingPeer.RoundTripTime;
        }

        public void OpRaiseEvent(byte eventCode, object message, bool reliable, int[] toPlayers) {
            //if (loadBalancingPeer.PeerState != ExitGames.Client.Photon.PeerStateValue.Connected) {
            //    return;
            //}

            //RaiseEventOptions eventOptions = new RaiseEventOptions();
            //eventOptions.TargetActors = toPlayers;

            //loadBalancingPeer.OpRaiseEvent(eventCode, message, reliable, eventOptions);
        }

    }

}
