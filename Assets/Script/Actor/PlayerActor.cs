﻿using System;
using System.Collections;
using System.Collections.Generic;
using LitJson;
using UnityEngine;
using Google.Protobuf;
using TrueSync;
using Werewolf.StatusIndicators.Components;

/// <summary>
/// 技能按钮操控类型
/// </summary>
public enum SkillControlType
{
    Button_KeyDown = 1,         //点击按钮操控:当按钮按下时候施放
    Button_KeyUp = 2,           //点击按钮操控:当按钮松开时候施放(满足松开范围)
    Joy_Angle = 4,              //通过摇杆选择的角度操控
    Joy_XY = 8,                 //通过摇杆选择地图上某个坐标操控
}

public class PlayerActor : Actor
{
    ETCJoystick joy_move;
    protected SkillControlType SkillControlType_1;
    ETCJoystick joy_skill_1;
    ETCButton button_1;
    protected SkillControlType SkillControlType_2;
    ETCJoystick joy_skill_2;
    ETCButton button_2;
    protected SkillControlType SkillControlType_3;
    ETCJoystick joy_skill_3;
    ETCButton button_3;
    protected SkillControlType SkillControlType_4;
    //ETCJoystick joy_skill_4;
    ETCButton button_4;

	protected GameObject image_quxiao;
	protected GameObject image_quxiao2;
	private int ScreenWidth = 1920;
	private int ScreenHeigth = 1080;
	private int ScreenScale = 1;
	private int ScreenWidth_Min = 1620;
	private int ScreenWidth_Max = 1720;
	private int ScreenHeigth_Min = 780;
	private int ScreenHeigth_Max = 880;

    public SplatManager splatManager;
    public GameObject[] WillUsedPrefabs;

    protected override void InitStateMachine()
    {
        mStateMachineDic[ActorStateType.Idle] = new GameState_Idle_Normal();
        mStateMachineDic[ActorStateType.Move] = new GameState_Move_Normal();
    }

    protected override void InitCurState()
    {
        CurState = mStateMachineDic[ActorStateType.Idle];
        CurState.Enter(this);
    }

    protected override void InitStateTransLimit()
    {

    }

    protected override void InitWillUsedPrefabs()
    {

    }

    protected override void InitSkill()
    {
        SkillControlType_1 = SkillControlType.Button_KeyUp;
        SkillControlType_2 = SkillControlType.Joy_Angle;
        SkillControlType_3 = SkillControlType.Joy_Angle;
        SkillControlType_4 = SkillControlType.Button_KeyUp;
        GameObject splat_1 = _AssetManager.GetGameObject("werewolf/statusindicators/prefabs/point/point basic_prefab");
        splat_1.name = "Point";
        splat_1.transform.SetParent(splatManager.transform);
        GameObject splat_2 = _AssetManager.GetGameObject("werewolf/statusindicators/prefabs/linemissile/line missile basic 2_prefab");
        splat_2.name = "Line";
        splat_2.transform.SetParent(splatManager.transform);
        GameObject splat_3 = _AssetManager.GetGameObject("werewolf/statusindicators/prefabs/status/status dots_prefab");
        splat_3.name = "Status";
        splat_3.transform.SetParent(splatManager.transform);
        GameObject splat_4 = _AssetManager.GetGameObject("werewolf/statusindicators/prefabs/range/rangebasic_prefab");
        splat_4.name = "Range";
        splat_4.transform.SetParent(splatManager.transform);
    }
    //==========================处理网络数据开始=============================================================
    public override void PlayerInputHandle(PB_ClientInput input)
    {
        InputType iInputType = input.InputType;
        switch (iInputType)
        {
            case InputType.MoveStart:
                PlayerInputHandle_MoveStart();
                break;
            case InputType.MoveAngle:
                PlayerInputHandle_MoveAngle(input.AngleX, input.AngleY);
                break;
            case InputType.MoveEnd:
                PlayerInputHandle_MoveEnd();
                break;
            case InputType.KeyUp:
				PlayerInputHandle_KeyUp(input.Key, input.TargetID);
                break;
            case InputType.KeyDown:
				PlayerInputHandle_KeyDown(input.Key, input.TargetID);
                break;
            case InputType.KeyAngle:
				PlayerInputHandle_KeyAngle(input.Key, input.AngleX, input.AngleY);
                break;
            case InputType.ClickXy:
                PlayerInputHandle_ClickXY(input.PosX, input.PosY);
                break;
        }
    }

    public override void PlayerInputHandle_MoveStart()
    {
        this.TransState(ActorStateType.Move);
    }

    public override void PlayerInputHandle_MoveAngle(int inputAngleX, int inputAngleY)
    {
        TSVector mTSVector = new TSVector((FP)inputAngleX / 1000, FP.Zero, (FP)inputAngleY / 1000);
        //TSVector mTSVector2 = new TSVector(-(FP)inputAngleY / 1000, FP.Zero, (FP)inputAngleX / 1000);//(x,y)的法向量就是(-y,x)
        this.Angle = mTSVector;
        //Debug.LogErrorFormat("PlayerInputHandle_MoveAngle======>mTSVector={0}", mTSVector.ToString());
        //RotateTSTransform.LookAt(this.Angle);
        //RotateTSTransform.Rotate(this.Angle);
        RotateTSTransform.rotation = TSQuaternion.LookRotation(mTSVector);
    }

    public override void PlayerInputHandle_MoveEnd()
    {
		IsMove = false;
        this.TransState(ActorStateType.Idle);
    }

	public override void PlayerInputHandle_KeyUp(int inputKey, int TargetID)
    {
        switch (inputKey)
        {
            case 1:
				this.TransState(ActorStateType.Skill_1, TargetID);
                break;
            case 2:
				this.TransState(ActorStateType.Skill_2, TargetID);
                break;
            case 3:
				this.TransState(ActorStateType.Skill_3, TargetID);
                break;
            case 4:
				this.TransState(ActorStateType.Skill_4, TargetID);
                break;
        }
    }

    public override void PlayerInputHandle_KeyDown(int inputKey, int TargetID)
    {
        switch (inputKey)
        {
            case 1:
				this.TransState(ActorStateType.Idle, TargetID);
                break;
            case 2:
				this.TransState(ActorStateType.Idle, TargetID);
                break;
            case 3:
				this.TransState(ActorStateType.Idle, TargetID);
                break;
            case 4:
				this.TransState(ActorStateType.Idle, TargetID);
                break;
        }
    }

	public override void PlayerInputHandle_KeyAngle(int inputKey, int inputAngleX, int inputAngleY)
    {
		Debug.LogErrorFormat("PlayerInputHandle_KeyAngle==========>{0},{1},{2}", inputKey, inputAngleX, inputAngleY);
		switch (inputKey)
		{
			case 1:
				this.TransState(ActorStateType.Skill_1, inputAngleX, inputAngleY);
				break;
			case 2:
				this.TransState(ActorStateType.Skill_2, inputAngleX, inputAngleY);
				break;
			case 3:
				this.TransState(ActorStateType.Skill_3, inputAngleX, inputAngleY);
				break;
			case 4:
				this.TransState(ActorStateType.Skill_4, inputAngleX, inputAngleY);
				break;
		}
    }

    public override void PlayerInputHandle_ClickXY(int inputPosX, int inputPosY)
    {
        
    }
    //==========================处理网络数据结束=============================================================
    //==========================处理摇杆等本地操作开始=======================================================
    void Start()
    {
		bloodStrip = transform.gameObject.AddComponent<BloodStrip>();
		bloodStrip.InitBloodStrip(mActorAttr);
		InitWillUsedPrefabs();
        Camera mCamera = transform.Find("camera").GetComponent<Camera>();
        if (this.IsETCControl == false) 
        {
            mCamera.enabled = false;
            return;
        }
        mCamera.enabled = true;
		_FightCamera = mCamera;
		splatManager = ActorObj.AddComponent<SplatManager>();
        InitSkill();
        splatManager.AutoInit();
        joy_move = GameObject.Find("Joystick_move").GetComponent<ETCJoystick>();
        joy_skill_1 = GameObject.Find("Joystick_skill_1").GetComponent<ETCJoystick>();
        button_1 = GameObject.Find("ETCButton_1").GetComponent<ETCButton>();
        joy_skill_2 = GameObject.Find("Joystick_skill_2").GetComponent<ETCJoystick>();
        button_2 = GameObject.Find("ETCButton_2").GetComponent<ETCButton>();
        joy_skill_3 = GameObject.Find("Joystick_skill_3").GetComponent<ETCJoystick>();
        button_3 = GameObject.Find("ETCButton_3").GetComponent<ETCButton>();
        //joy_skill_4 = GameObject.Find("Joystick_skill_4").GetComponent<ETCJoystick>();
        button_4 = GameObject.Find("ETCButton_4").GetComponent<ETCButton>();
		image_quxiao = GameObject.Find("Image_quxiao");
		image_quxiao.SetActive(false);
		image_quxiao2 = GameObject.Find("Image_quxiao2");
		image_quxiao2.SetActive(false);
		ScreenWidth = Screen.width;
		ScreenHeigth = Screen.height;
		ScreenScale = Screen.width * 1000 / 1920;//已宽度为准的缩放比例
		ScreenWidth_Min = ScreenWidth - 325 * ScreenScale / 1000;
		ScreenWidth_Max = ScreenWidth - 175 * ScreenScale / 1000;
		ScreenHeigth_Min = ScreenHeigth - 325 * ScreenScale / 1000;
		ScreenHeigth_Max = ScreenHeigth - 175 * ScreenScale / 1000;
		//Debug.LogErrorFormat("Screen==========>{0},{1},{2}", ScreenWidth, ScreenHeigth, ScreenScale);
		//Debug.LogErrorFormat("Scale===========>{0},{1},{2},{3}", ScreenWidth_Min, ScreenWidth_Max, ScreenHeigth_Min, ScreenHeigth_Max);
        if (joy_move != null)
        {
            joy_move.onMoveStart.AddListener(StartMoveCallBack);
            joy_move.onMove.AddListener(MoveCallBack);
            joy_move.onMoveEnd.AddListener(EndMoveCallBack);
        }
        if (button_1 != null)
        {
            switch (SkillControlType_1)
            {
                case SkillControlType.Button_KeyDown:
                case SkillControlType.Button_KeyUp://操作上都生效,网络不一定都发送
                    joy_skill_1.activated = false;
                    button_1.activated = true;
                    button_1.onUp.AddListener(onUp_Skill_1);
                    button_1.onDown.AddListener(onDown_Skill_1);
                    break;
                case SkillControlType.Joy_Angle:
                    button_1.activated = false;
                    button_1.visible = false;
                    joy_skill_1.activated = true;
                    joy_skill_1.onMoveStart.AddListener(StartMoveCallBack_Skill_1);
                    joy_skill_1.onMove.AddListener(MoveCallBack_Skill_1);
                    joy_skill_1.onMoveEnd.AddListener(EndMoveCallBack_Skill_1);
                    break;
                case SkillControlType.Joy_XY:
                    button_1.activated = false;
                    button_1.visible = false;
                    joy_skill_1.activated = true;
                    joy_skill_1.activated = true;
                    joy_skill_1.onMoveStart.AddListener(StartMoveCallBack_Skill_1);
                    joy_skill_1.onMove.AddListener(MoveCallBack_Skill_1);
                    joy_skill_1.onMoveEnd.AddListener(EndMoveCallBack_Skill_1);
                    break;
            }
        }
        if (button_2 != null)
        {
            switch (SkillControlType_2)
            {
                case SkillControlType.Button_KeyDown:
                case SkillControlType.Button_KeyUp:
                    joy_skill_2.activated = false;
                    button_2.activated = true;
                    button_2.onUp.AddListener(onUp_Skill_2);
                    button_2.onDown.AddListener(onDown_Skill_2);
                    break;
                case SkillControlType.Joy_Angle:
                    button_2.activated = false;
                    button_2.visible = false;
                    joy_skill_2.activated = true;
                    joy_skill_2.onMoveStart.AddListener(StartMoveCallBack_Skill_2);
                    joy_skill_2.onMove.AddListener(MoveCallBack_Skill_2);
                    joy_skill_2.onMoveEnd.AddListener(EndMoveCallBack_Skill_2);
                    break;
                case SkillControlType.Joy_XY:
                    button_2.activated = false;
                    button_2.visible = false;
                    joy_skill_2.activated = true;
                    joy_skill_2.onMoveStart.AddListener(StartMoveCallBack_Skill_2);
                    joy_skill_2.onMove.AddListener(MoveCallBack_Skill_2);
                    joy_skill_2.onMoveEnd.AddListener(EndMoveCallBack_Skill_2);
                    break;
            }
        }
        if (button_3 != null)
        {
            switch (SkillControlType_3)
            {
                case SkillControlType.Button_KeyDown:
                case SkillControlType.Button_KeyUp:
                    joy_skill_3.activated = false;
                    button_3.activated = true;
                    button_3.onUp.AddListener(onUp_Skill_3);
                    button_3.onDown.AddListener(onDown_Skill_3);
                    break;
                case SkillControlType.Joy_Angle:
                    button_3.activated = false;
                    button_3.visible = false;
                    joy_skill_3.activated = true;
                    joy_skill_3.onMoveStart.AddListener(StartMoveCallBack_Skill_3);
                    joy_skill_3.onMove.AddListener(MoveCallBack_Skill_3);
                    joy_skill_3.onMoveEnd.AddListener(EndMoveCallBack_Skill_3);
                    break;
                case SkillControlType.Joy_XY:
                    button_3.activated = false;
                    button_3.visible = false;
                    joy_skill_3.activated = true;
                    joy_skill_3.onMoveStart.AddListener(StartMoveCallBack_Skill_3);
                    joy_skill_3.onMove.AddListener(MoveCallBack_Skill_3);
                    joy_skill_3.onMoveEnd.AddListener(EndMoveCallBack_Skill_3);
                    break;
            }
        }
        if (button_4 != null)
        {
            switch (SkillControlType_4)
            {
                case SkillControlType.Button_KeyDown:
                case SkillControlType.Button_KeyUp:
                    //joy_skill_4.activated = false;
                    button_4.activated = true;
                    button_4.onUp.AddListener(onUp_Skill_4);
                    button_4.onDown.AddListener(onDown_Skill_4);
                    break;
                case SkillControlType.Joy_Angle:
                    button_4.activated = false;
                    //joy_skill_4.activated = true;
                    //joy_skill_4.onMoveStart.AddListener(StartMoveCallBack_Skill_4);
                    //joy_skill_4.onMove.AddListener(MoveCallBack_Skill_4);
                    //joy_skill_4.onMoveEnd.AddListener(EndMoveCallBack_Skill_4);
                    break;
                case SkillControlType.Joy_XY:
                    button_4.activated = false;
                    //joy_skill_4.activated = true;
                    //joy_skill_4.onMoveStart.AddListener(StartMoveCallBack_Skill_4);
                    //joy_skill_4.onMove.AddListener(MoveCallBack_Skill_4);
                    //joy_skill_4.onMoveEnd.AddListener(EndMoveCallBack_Skill_4);
                    break;
            }
        }
                
    }

    void StartMoveCallBack()
    {
        _UdpSendManager.SendStartMove();
    }

    void MoveCallBack(Vector2 tVec2)
    {
        TSVector2 mTSVector2 = new TSVector2((FP)(tVec2.x - 0.001f), (FP)(tVec2.y - 0.001f)).normalized;//这里减0.001f是因为这里精度有问题,会传来一个极其微小大于1的浮点数,后面使用时候导致FP Acos()中算出来的1值(4294967297)大于FP.ONE值(4294967296)
        FP anglenew = TSVector2.Angle(mTSVector2, TSVector2.up);
        FP angle = TSQuaternion.Angle(AllTSTransform.rotation, RotateTSTransform.rotation);
        //FP iTanDeg = TSMath.Atan2((FP)tVec2.y, (FP)tVec2.x) * FP.Rad2Deg;
        //Debug.LogErrorFormat("MoveCallBack===12=======>{0},{1},{2},{3},iTanDeg={4}", mTSVector2.x, mTSVector2.y, mTSVector2.ToString(), anglenew, iTanDeg);
        if (mTSVector2.x < 0 && (360 - anglenew) < 183) anglenew = 360 - anglenew; //这里让他们夹角在0-183范围内,刚好与下面的0-180错开3(灵敏度5的一半),这样就少算了一次RotateTransform.rotation.eulerAngles的值
        //if (mTSVector2.y < 0) anglenew = 360 - anglenew;
        //if (RotateTransform.rotation.eulerAngles.x < 0) angle = 360 - angle;
        //Debug.LogErrorFormat("MoveCallBack==2====>{0},{1},ToString={2}", anglenew, angle, RotateTSTransform.rotation.ToString());
        if (TSMath.Abs(angle - anglenew) > 5)
        {
            int x = FP.ToInt(mTSVector2.x * 1000);
            int y = FP.ToInt(mTSVector2.y * 1000);
            //Debug.LogErrorFormat("MoveCallBack=3==>{0},{1}", x, y);
            _UdpSendManager.SendChangeAngle(x,y);
        }
    }

	void EndMoveCallBack(Vector2 tVec2)
    {
        _UdpSendManager.SendEndMove();
    }
	//===========================================================================
	/// <summary>
	/// 判断ETCJoystick的EndMove时候,时候在取消区域范围内
	/// </summary>
	protected bool IsInQuXiaoArea(Vector2 tVec2)
	{
		//取消区域锚点在右上角,屏幕为1920*1080时,坐标(-250,-250),大小150*150,所以范围是X=(-325,-175),Y=(-325,-175),用左下角坐标系为
		if ((ScreenWidth_Min < tVec2.x && tVec2.x < ScreenWidth_Max) && (ScreenHeigth_Min < tVec2.y && tVec2.y < ScreenHeigth_Max))
			return true;
		return false;
	}
	protected bool IsInQuXiaoArea(Vector3 tVec3)
	{
		if ((ScreenWidth_Min < tVec3.x && tVec3.x < ScreenWidth_Max) && (ScreenHeigth_Min < tVec3.y && tVec3.y < ScreenHeigth_Max))
			return true;
		return false;
	}
	/// <summary>
	/// 根据选择策略,选择不同目标
	/// </summary>
	protected int SelectTargetActor(SelectTargetTactics iTactics, int iDistanceRange)
	{ 
		int TargetID = 0;
		FP NearestDistance = 99;//最近距离
		FP LowestHp = 99999;	//最低血量
		if (iTactics == SelectTargetTactics.ENEMY_GUAI_LOWEST_HP || iTactics == SelectTargetTactics.ENEMY_GUAI_NEAREST_DISTANCE
			|| iTactics == SelectTargetTactics.ENEMY_ALL_LOWEST_HP || iTactics == SelectTargetTactics.ENEMY_ALL_NEAREST_DISTANCE)
		{
			//=====野怪
			List<Actor> mEnemyMonsterActorList = GameProcessManager_Dota.Instance.GetMonsterActorList();
			foreach (Actor mEnemyMonsterActor in mEnemyMonsterActorList) {
				if (mEnemyMonsterActor.IsDeath) continue;
				FP Distance = (mEnemyMonsterActor.AllTSTransform.position - AllTSTransform.position).magnitude;
				if (iDistanceRange != -1 && Distance > iDistanceRange) continue;
				switch (iTactics)
				{
					case SelectTargetTactics.ENEMY_GUAI_NEAREST_DISTANCE:
					case SelectTargetTactics.ENEMY_ALL_NEAREST_DISTANCE:
						if (Distance < NearestDistance)
						{
							NearestDistance = Distance;
							TargetID = mEnemyMonsterActor.OwnerID;
						}
						break;
					case SelectTargetTactics.ENEMY_GUAI_LOWEST_HP:
					case SelectTargetTactics.ENEMY_ALL_LOWEST_HP:
						if (mEnemyMonsterActor.mActorAttr.Hp < LowestHp)
						{
							LowestHp = mEnemyMonsterActor.mActorAttr.Hp;
							TargetID = mEnemyMonsterActor.OwnerID;
						}
						break;
				}
			}
			//=====士兵
			List<Actor> mEnemySoldiersActorList = GameProcessManager_Dota.Instance.GetEnemySoldiersActorList(OwnerCamp);
			foreach (Actor mEnemySoldiersActor in mEnemySoldiersActorList)
			{
				if (mEnemySoldiersActor.IsDeath) continue;
				FP Distance = (mEnemySoldiersActor.AllTSTransform.position - AllTSTransform.position).magnitude;
				if (iDistanceRange != -1 && Distance > iDistanceRange) continue;
				switch (iTactics)
				{
					case SelectTargetTactics.ENEMY_GUAI_NEAREST_DISTANCE:
					case SelectTargetTactics.ENEMY_ALL_NEAREST_DISTANCE:
						if (Distance < NearestDistance)
						{
							NearestDistance = Distance;
							TargetID = mEnemySoldiersActor.OwnerID;
						}
						break;
					case SelectTargetTactics.ENEMY_GUAI_LOWEST_HP:
					case SelectTargetTactics.ENEMY_ALL_LOWEST_HP:
						if (mEnemySoldiersActor.mActorAttr.Hp < LowestHp)
						{
							LowestHp = mEnemySoldiersActor.mActorAttr.Hp;
							TargetID = mEnemySoldiersActor.OwnerID;
						}
						break;
				}
			}
			if (TargetID != 0 && (iTactics == SelectTargetTactics.ENEMY_GUAI_LOWEST_HP || iTactics == SelectTargetTactics.ENEMY_GUAI_NEAREST_DISTANCE))
			{
				return TargetID;
			}
		}
		//=====玩家
		List<Actor> mEnemyPlayerActorList;
		if (iTactics == SelectTargetTactics.FRIEND_PALYER_LOWEST_HP || iTactics == SelectTargetTactics.FRIEND_PALYER_NEAREST_DISTANCE)
			mEnemyPlayerActorList = TrueSyncManager.Instance.GetFriendPlayerActorList(OwnerCamp);
		else if (iTactics == SelectTargetTactics.ENEMY_PALYER_LOWEST_HP || iTactics == SelectTargetTactics.ENEMY_PALYER_NEAREST_DISTANCE)
			mEnemyPlayerActorList = TrueSyncManager.Instance.GetEnemyPlayerActorList(OwnerCamp);
		else
			mEnemyPlayerActorList = TrueSyncManager.Instance.GetAllPlayerActorList(OwnerCamp);

		foreach (Actor mEnemyPlayerActor in mEnemyPlayerActorList) {
			if (mEnemyPlayerActor.IsDeath) continue;
			FP Distance = (mEnemyPlayerActor.AllTSTransform.position - AllTSTransform.position).magnitude;
			if (iDistanceRange!=-1 && Distance>iDistanceRange) continue;
			switch(iTactics)
			{
				case SelectTargetTactics.FRIEND_PALYER_NEAREST_DISTANCE:
				case SelectTargetTactics.ENEMY_PALYER_NEAREST_DISTANCE:
				case SelectTargetTactics.ENEMY_GUAI_NEAREST_DISTANCE:
				case SelectTargetTactics.ENEMY_ALL_NEAREST_DISTANCE:
					if (Distance > NearestDistance)
					{
						NearestDistance = Distance;
						TargetID = mEnemyPlayerActor.OwnerID;
					}
					break;
				case SelectTargetTactics.FRIEND_PALYER_LOWEST_HP:
				case SelectTargetTactics.ENEMY_PALYER_LOWEST_HP:
				case SelectTargetTactics.ENEMY_GUAI_LOWEST_HP:
				case SelectTargetTactics.ENEMY_ALL_LOWEST_HP:
					if (mEnemyPlayerActor.mActorAttr.Hp > LowestHp)
					{
						LowestHp = mEnemyPlayerActor.mActorAttr.Hp;
						TargetID = mEnemyPlayerActor.OwnerID;
					}
					break;
			}
		}
		return TargetID;
	}
    //===========================================================================
	protected override void onUp_Skill_1() { }
	protected override void onDown_Skill_1() { }
	protected override void StartMoveCallBack_Skill_1() { }
	protected override void MoveCallBack_Skill_1(Vector2 tVec2) { }
	protected override void EndMoveCallBack_Skill_1(Vector2 tVec2) { }
	protected override void onUp_Skill_2() { }
	protected override void onDown_Skill_2() { }
	protected override void StartMoveCallBack_Skill_2() { }
	protected override void MoveCallBack_Skill_2(Vector2 tVec2) { }
	protected override void EndMoveCallBack_Skill_2(Vector2 tVec2) { }
	protected override void onUp_Skill_3() { }
	protected override void onDown_Skill_3() { }
	protected override void StartMoveCallBack_Skill_3() { }
	protected override void MoveCallBack_Skill_3(Vector2 tVec2) { }
	protected override void EndMoveCallBack_Skill_3(Vector2 tVec2) { }
	protected override void onUp_Skill_4() { }
	protected override void onDown_Skill_4() { }
	protected override void StartMoveCallBack_Skill_4() { }
	protected override void MoveCallBack_Skill_4(Vector2 tVec2) { }
	protected override void EndMoveCallBack_Skill_4(Vector2 tVec2) { }
	/***
	protected override void onUp_Skill_1()
    {
        splatManager.CancelAll();
        Debug.LogErrorFormat("onUp_Skill_1==========>{0}", SkillControlType_1);
        if (SkillControlType_1 == SkillControlType.Button_KeyUp)
            _UdpSendManager.SendInputSkill(1, InputType.KeyUp);
    }
	protected override void onDown_Skill_1()
    {
        splatManager.SelectStatusIndicator("Status");
        Debug.LogErrorFormat("onDown_Skill_1==========>{0}", SkillControlType_1);
        if (SkillControlType_1 == SkillControlType.Button_KeyDown)
            _UdpSendManager.SendInputSkill(1, InputType.KeyDown);
    }
	protected override void StartMoveCallBack_Skill_1()
    {
		image_quxiao.SetActive(true);
        Debug.LogErrorFormat("StartMoveCallBack_Skill_1==========>");
    }
	protected override void MoveCallBack_Skill_1(Vector2 tVec2)
    {
		if (IsInQuXiaoArea(Input.mousePosition))
			image_quxiao2.SetActive(true);
		else
			image_quxiao2.SetActive(false);
        //Debug.LogErrorFormat("MoveCallBack_Skill_1==========>{0}", tVec2);
    }
	protected override void EndMoveCallBack_Skill_1(Vector2 tVec2)
    {
		image_quxiao.SetActive(false);
		image_quxiao2.SetActive(false);
		Debug.LogErrorFormat("EndMoveCallBack_Skill_1==========>{0},在取消区域内:{1}", tVec2, IsInQuXiaoArea(tVec2));
		if (!IsInQuXiaoArea(tVec2))
			_UdpSendManager.SendAngleSkill(1, 0, 0);
    }
    //===========================================================================
	protected override void onUp_Skill_2()
    {
        if (SkillControlType_2 == SkillControlType.Button_KeyUp)
            _UdpSendManager.SendInputSkill(2, InputType.KeyUp);
    }
	protected override void onDown_Skill_2()
    {
        if (SkillControlType_2 == SkillControlType.Button_KeyDown)
            _UdpSendManager.SendInputSkill(2, InputType.KeyDown);
    }
	protected override void StartMoveCallBack_Skill_2()
    {
		image_quxiao.SetActive(true);
        Debug.LogErrorFormat("StartMoveCallBack_Skill_2==========>");
        splatManager.SelectSpellIndicator("Point");
    }
	protected override void MoveCallBack_Skill_2(Vector2 tVec2)
    {
		if (IsInQuXiaoArea(Input.mousePosition))
			image_quxiao2.SetActive(true);
		else
			image_quxiao2.SetActive(false);
        SpellIndicator mCone = splatManager.GetSpellIndicator("Point");
        mCone.JoystickVector = new Vector3(tVec2.x, 0, tVec2.y);
		//Debug.LogErrorFormat("MoveCallBack_Skill_2==========>{0}", tVec2);
    }
	protected override void EndMoveCallBack_Skill_2(Vector2 tVec2)
    {
		image_quxiao.SetActive(false);
		image_quxiao2.SetActive(false);
        SpellIndicator mCone = splatManager.GetSpellIndicator("Point");
        splatManager.CancelAll();
		Debug.LogErrorFormat("EndMoveCallBack_Skill_2==========>{0},在取消区域内:{1}", tVec2, IsInQuXiaoArea(tVec2));
    }
    //===========================================================================
	protected override void onUp_Skill_3()
    {
        if (SkillControlType_3 == SkillControlType.Button_KeyUp)
            _UdpSendManager.SendInputSkill(3, InputType.KeyUp);
    }
	protected override void onDown_Skill_3()
    {
        if (SkillControlType_3 == SkillControlType.Button_KeyDown)
            _UdpSendManager.SendInputSkill(3, InputType.KeyDown);
    }
	protected override void StartMoveCallBack_Skill_3()
    {
		image_quxiao.SetActive(true);
        splatManager.SelectSpellIndicator("Line");
        Debug.LogErrorFormat("StartMoveCallBack_Skill_3==========>");
    }
	protected override void MoveCallBack_Skill_3(Vector2 tVec2)
    {
		if (IsInQuXiaoArea(Input.mousePosition))
			image_quxiao2.SetActive(true);
		else
			image_quxiao2.SetActive(false);
        SpellIndicator mCone = splatManager.GetSpellIndicator("Line");
        mCone.JoystickVector = new Vector3(tVec2.x, 0, tVec2.y);
		//Debug.LogErrorFormat("MoveCallBack_Skill_3==========>{0}", tVec2);
    }
	protected override void EndMoveCallBack_Skill_3(Vector2 tVec2)
    {
		image_quxiao.SetActive(false);
		image_quxiao2.SetActive(false);
        splatManager.CancelAll();
		Debug.LogErrorFormat("EndMoveCallBack_Skill_3==========>{0},在取消区域内:{1}", tVec2, IsInQuXiaoArea(tVec2));
    }
    //===========================================================================
	protected override void onUp_Skill_4()
    {
        splatManager.CancelAll();
        if (SkillControlType_4 == SkillControlType.Button_KeyUp)
            _UdpSendManager.SendInputSkill(4, InputType.KeyUp);
    }
	protected override void onDown_Skill_4()
    {
        splatManager.SelectRangeIndicator("Range");
        if (SkillControlType_4 == SkillControlType.Button_KeyDown)
            _UdpSendManager.SendInputSkill(4, InputType.KeyDown);
    }
	protected override void StartMoveCallBack_Skill_4()
    {
		image_quxiao.SetActive(true);
        Debug.LogErrorFormat("StartMoveCallBack_Skill_4==========>");
    }
	protected override void MoveCallBack_Skill_4(Vector2 tVec2)
    {
		if (IsInQuXiaoArea(Input.mousePosition))
			image_quxiao2.SetActive(true);
		else
			image_quxiao2.SetActive(false);
		//Debug.LogErrorFormat("MoveCallBack_Skill_4==========>{0}", tVec2);
    }
	protected override void EndMoveCallBack_Skill_4(Vector2 tVec2)
    {
		image_quxiao.SetActive(false);
		image_quxiao2.SetActive(false);
		Debug.LogErrorFormat("EndMoveCallBack_Skill_4==========>{0},在取消区域内:{1}", tVec2, IsInQuXiaoArea(tVec2));
    }
	***/
    //===========================================================================

	public override void AddHp(int hp, int iOwnerID)
	{
		mActorAttr.Hp -= 10;
	}

    void OnDestroy()
    {
        if (joy_move != null)
        {
            joy_move.onMoveStart.RemoveListener(StartMoveCallBack);
            joy_move.onMove.RemoveListener(MoveCallBack);
            joy_move.onMoveEnd.RemoveListener(EndMoveCallBack);
        }
        if (button_1 != null)
        {
            button_1.onUp.RemoveListener(onUp_Skill_1);
            button_1.onUp.RemoveListener(onDown_Skill_1);
        }
        if (button_2 != null)
        {
            button_2.onUp.RemoveListener(onUp_Skill_2);
            button_2.onUp.RemoveListener(onDown_Skill_2);
        }
        if (button_3 != null)
        {
            button_3.onUp.RemoveListener(onUp_Skill_3);
            button_3.onUp.RemoveListener(onDown_Skill_3);
        }
        if (button_4 != null)
        {
            button_4.onUp.RemoveListener(onUp_Skill_4);
            button_4.onUp.RemoveListener(onDown_Skill_4);
        }
    }
    //==========================处理摇杆等本地操作结束=======================================================
}
