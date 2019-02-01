using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TrueSync;

class MyTimer
{
	public Action CompletedEvent;
	private string _flag;
	public string flag { get { return _flag; } }
	//private int _TotalTick;
	//private int _CompletedTick;
	//private bool _SafeTick = true;
	//private int CurrentTick { get { return _SafeTick ? TrueSyncManager.LastSafeTick : TrueSyncManager.Ticks; } }// ��õ�ǰ֡
	public MyTimer(int Tick, string flag, Action completedEvent)
	{
		//_TotalTick = Tick;
		//_CompletedTick = Tick + CurrentTick;
		_flag = flag;
		CompletedEvent = completedEvent;
	}

	//public int LeftTick { get { return (_CompletedTick - CurrentTick); } }
}

//ʵ�����̶�ʱ��
public class MyTimerDriver : TrueSyncBehaviour
{
	#region ����
	private static MyTimerDriver _instance;
	public static MyTimerDriver Instance
	{
		get
		{
			if (null == _instance)
			{
				_instance = FindObjectOfType<MyTimerDriver>() ?? new GameObject("MyTimerEntity").AddComponent<MyTimerDriver>();
			}
			return _instance;
		}
	}
	private void Awake()
	{
		_instance = this;
	}
	#endregion

	private Dictionary<int, List<MyTimer>> AllTimerDict = new Dictionary<int, List<MyTimer>>();		//���ж�ʱ��:<֡,��ʱ���б�>
	private bool _SafeTick = true;
	private int CurrentTick { get { return _SafeTick ? TrueSyncManager.LastSafeTick : TrueSyncManager.Ticks; } }// ��õ�ǰ֡

	/// <summary>
	/// ע�ᶨʱ��
	/// </summary>
	/// <param name="Tick">��ʱʱ��(��λ:֡)</param>
	/// <param name="flag">��ʱ����ʶ��</param>
	/// <param name="completedEvent">��������</param>
	public bool SetTimer(int Tick, string flag, Action completedEvent)
	{
		int ExecutTick = CurrentTick + Tick;//��Ҫִ�е�֡
		if (!AllTimerDict.ContainsKey(ExecutTick))
		{
			List<MyTimer> myTimerList = new List<MyTimer>();
			myTimerList.Add(new MyTimer(Tick, flag, completedEvent));
			AllTimerDict[ExecutTick] = myTimerList;
		}
		else {
			List<MyTimer> myTimerList = AllTimerDict[ExecutTick];
			foreach (var myTimer in myTimerList) {
				if (myTimer.flag.Equals(flag)) {
					//ͬ��ǵ�ֻ�����һ��
					return false;
				}
			}
			myTimerList.Add(new MyTimer(Tick, flag, completedEvent));
		}
		return true;
	}

	/// <summary>
	/// ɾ����ʱ��(����ɾ������,��ʱ�õ�ȫ��������)
	/// </summary>
	public bool DelTimer(string flag)
	{
		foreach (KeyValuePair<int, List<MyTimer>> kv in AllTimerDict)
		{
			List<MyTimer> myTimerList = kv.Value;
			foreach (var myTimer in myTimerList)
			{
				if (myTimer.flag.Equals(flag))
				{
					myTimerList.Remove(myTimer);
					return true;
				}
			}
		}
		return false;//û�������ʱ��
	}

	public override void OnSyncedUpdate()
	{
		if (AllTimerDict.ContainsKey(CurrentTick))
		{
			foreach (var myTimer in AllTimerDict[CurrentTick])
			{
				//Debug.LogErrorFormat("myTimer.flag====>{0}", myTimer.flag);
				myTimer.CompletedEvent();
			}
			AllTimerDict.Remove(CurrentTick);
		}
	}
}