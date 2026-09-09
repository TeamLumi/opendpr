using Dpr.Trainer;
using System;
using UnityEngine;

public class FieldObjectMoveCode
{
    public FieldObjectMoveCode()
    {
        // Empty, explicitly declared
    }

    public FieldObjectEntity Entity { private set; get; }

    public void SetEntity(FieldObjectEntity entity)
    {
        Entity = entity;

        if (Entity == null)
        {
            _isMissing = false;
        }
        else
        {
            if (Entity is FieldPokemonEntity)
            {
                EntityType = 1;
                pokeEntity = Entity as FieldPokemonEntity;
            }
            else if (Entity is FieldCharacterEntity)
            {
                EntityType = 2;
                charaEntity = Entity as FieldCharacterEntity;
            }
            else
            {
                _isMissing = false;
            }
        }
    }

    private FieldPokemonEntity pokeEntity;
    private FieldCharacterEntity charaEntity;
    public int EntityType;

    public int PlayerGridDistance { private set; get; } = 9999;
    public bool IsPlayerHeight { private set; get; }
    public bool IsForceEyeHit { get; set; }

    private Vector3 playerPosition;
    private Vector2Int playerGridPosition;
    private bool isPlayerRun;

    public const int EV_TYPE_NORMAL = 0;
    public const int EV_TYPE_TRAINER = 1;
    public const int EV_TYPE_TRAINER_EYEALL = 2;
    public const int EV_TYPE_ITEM = 3;
    public const int EV_TYPE_TRAINER_KYORO = 4;
    public const int EV_TYPE_TRAINER_SPIN_STOP_L = 5;
    public const int EV_TYPE_TRAINER_SPIN_STOP_R = 6;
    public const int EV_TYPE_TRAINER_SPIN_MOVE_L = 7;
    public const int EV_TYPE_TRAINER_SPIN_MOVE_R = 8;
    public const int EV_TYPE_MSG = 9;

    public int BaseMoveCode;
    public int MoveCode;
    public DIR MoveDirHead;
    public int MoveParam0;
    public int MoveParam1;
    public int MoveParam2;
    public int MoveLimitX;
    public int MoveLimitZ;
    public int Ev_Type;
    public int mv_old_dir = -1;
    public int mv_dir;
    private float _mv_targetYawAngle;
    private float _mv_oldYawAngle;
    private float _mv_YawAngleTime;
    private bool _mv_isMoveStart;
    private Vector3 _mv_StartPos;
    private Vector3 _mv_EndPos;
    private float _mv_Time;
    private float _mv_TimeRate;
    public Vector3Int _mv_defaultPosition;
    private float _mv_WaitWalkTime;
    public MV_STATE MvState;
    public TrainerID TrainerID;
    public bool Param_from_LoadData;
    private MV_PARAM _mvParam;

    private const int FLDOBJ_STA_BIT_NON = 0;
    private const int FLDOBJ_STA_BIT_USE = 1;
    private const int FLDOBJ_STA_BIT_MOVE = 2;
    private const int FLDOBJ_STA_BIT_MOVE_START = 4;
    private const int FLDOBJ_STA_BIT_MOVE_END = 8;

    private int _objectStatus;
    private bool _isSubProc;
    private const int MOVE_LIMIT_NOT = -1;
    private Vector3 _stopPos;
    private const int MAX_MOVE_CACHE = 10;
    public MoveCache moveCache;
    private bool _isEyeHitStop;
    private bool _isMissing;
    private Vector2 _movelimit_Min;
    private Vector2 _movelimit_Max;

    public const int MV_DMY = 0;
    public const int MV_PLAYER = 1;
    public const int MV_DIR_RND = 2;
    public const int MV_RND = 3;
    public const int MV_RND_V = 4;
    public const int MV_RND_H = 5;
    public const int MV_RND_UL = 6;
    public const int MV_RND_UR = 7;
    public const int MV_RND_DL = 8;
    public const int MV_RND_DR = 9;
    public const int MV_RND_UDL = 10;
    public const int MV_RND_UDR = 11;
    public const int MV_RND_ULR = 12;
    public const int MV_RND_DLR = 13;
    public const int MV_UP = 14;
    public const int MV_DOWN = 15;
    public const int MV_LEFT = 16;
    public const int MV_RIGHT = 17;
    public const int MV_SPIN_L = 18;
    public const int MV_SPIN_R = 19;
    public const int MV_RT2 = 20;
    public const int MV_RTURLD = 21;
    public const int MV_RTRLDU = 22;
    public const int MV_RTDURL = 23;
    public const int MV_RTLDUR = 24;
    public const int MV_RTULRD = 25;
    public const int MV_RTLRDU = 26;
    public const int MV_RTDULR = 27;
    public const int MV_RTRDUL = 28;
    public const int MV_RTLUDR = 29;
    public const int MV_RTUDRL = 30;
    public const int MV_RTRLUD = 31;
    public const int MV_RTDRLU = 32;
    public const int MV_RTRUDL = 33;
    public const int MV_RTUDLR = 34;
    public const int MV_RTLRUD = 35;
    public const int MV_RTDLRU = 36;
    public const int MV_RTUL = 37;
    public const int MV_RTDR = 38;
    public const int MV_RTLD = 39;
    public const int MV_RTRU = 40;
    public const int MV_RTUR = 41;
    public const int MV_RTDL = 42;
    public const int MV_RTLU = 43;
    public const int MV_RTRD = 44;
    public const int MV_RND_UD = 45;
    public const int MV_RND_LR = 46;
    public const int MV_SEED = 47;
    public const int MV_PAIR = 48;
    public const int MV_REWAR = 49;
    public const int MV_TR_PAIR = 50;
    public const int MV_HIDE_SNOW = 51;
    public const int MV_HIDE_SAND = 52;
    public const int MV_HIDE_GRND = 53;
    public const int MV_HIDE_KUSA = 54;
    public const int MV_CODE_MAX = 55;
    public const int MV_CODE_NOT = 255;
    public const int MV_RND_MOVE_CHECK_NORMAL = 0;
    public const int MV_RND_MOVE_CHECK_RECT = 1;
    public const int RT_KURU2_L = 0;
    public const int RT_KURU2_R = 1;
    public const int RT_KURU2_MAX = 2;
    public const int FLDOBJ_MOVE_HIT_BIT_NON = 0;
    public const int FLDOBJ_MOVE_HIT_BIT_LIM = 1;
    public const int FLDOBJ_MOVE_HIT_BIT_ATTR = 2;
    public const int FLDOBJ_MOVE_HIT_BIT_OBJ = 4;
    public const int FLDOBJ_MOVE_HIT_BIT_HEIGHT = 8;
    public const int SEQNO_MV_RT3_MOVE_DIR_SET = 0;
    public const int SEQNO_MV_RT3_MOVE = 1;
    public const int MV_RT3_TURN_END_NO = 3;
    public const int MV_RT3_CHECK_TYPE_X = 0;
    public const int MV_RT3_CHECK_TYPE_Z = 1;

    private FIELD_OBJ_MOVE_PROC_LIST _moveProc;
    private static readonly int[] DATA_MvDirRndWaitTbl_Taiki = { 0x20, 0x40, 0x60, 0x80 };
    private static readonly int[] DATA_MvDirRndWaitTbl_Move = { 0x0, 0x20, 0x40, 0x60, 0x80 };
    private static readonly int[] DATA_MvDirRndDirTbl =     { (int)DIR.DIR_UP,    (int)DIR.DIR_DOWN,  (int)DIR.DIR_LEFT,  (int)DIR.DIR_RIGHT };
    private static readonly int[] DATA_MvDirRndDirTbl_UL =  { (int)DIR.DIR_UP,    (int)DIR.DIR_LEFT };
    private static readonly int[] DATA_MvDirRndDirTbl_UR =  { (int)DIR.DIR_UP,    (int)DIR.DIR_RIGHT };
    private static readonly int[] DATA_MvDirRndDirTbl_DL =  { (int)DIR.DIR_DOWN,  (int)DIR.DIR_LEFT };
    private static readonly int[] DATA_MvDirRndDirTbl_DR =  { (int)DIR.DIR_DOWN,  (int)DIR.DIR_RIGHT };
    private static readonly int[] DATA_MvDirRndDirTbl_UDL = { (int)DIR.DIR_UP,    (int)DIR.DIR_DOWN,  (int)DIR.DIR_LEFT };
    private static readonly int[] DATA_MvDirRndDirTbl_UDR = { (int)DIR.DIR_UP,    (int)DIR.DIR_DOWN,  (int)DIR.DIR_RIGHT };
    private static readonly int[] DATA_MvDirRndDirTbl_ULR = { (int)DIR.DIR_UP,    (int)DIR.DIR_LEFT,  (int)DIR.DIR_RIGHT };
    private static readonly int[] DATA_MvDirRndDirTbl_DLR = { (int)DIR.DIR_DOWN,  (int)DIR.DIR_LEFT,  (int)DIR.DIR_RIGHT };
    private static readonly int[] DATA_MvDirRndDirTbl_UD =  { (int)DIR.DIR_UP,    (int)DIR.DIR_DOWN };
    private static readonly int[] DATA_MvDirRndDirTbl_LR =  { (int)DIR.DIR_LEFT,  (int)DIR.DIR_RIGHT };
    private static readonly int[] DATA_MV_RND_DirTbl =      { (int)DIR.DIR_UP,    (int)DIR.DIR_DOWN,  (int)DIR.DIR_LEFT,  (int)DIR.DIR_RIGHT };
    private static readonly int[] DATA_MV_RND_V_DirTbl =    { (int)DIR.DIR_UP,    (int)DIR.DIR_DOWN };
    private static readonly int[] DATA_MV_RND_H_DirTbl =    { (int)DIR.DIR_LEFT,  (int)DIR.DIR_RIGHT };
    private static readonly int[] DATA_MvRtURLD_DirTbl =    { (int)DIR.DIR_UP,    (int)DIR.DIR_RIGHT, (int)DIR.DIR_LEFT,  (int)DIR.DIR_DOWN };
    private static readonly int[] DATA_MvRtRLDU_DirTbl =    { (int)DIR.DIR_RIGHT, (int)DIR.DIR_LEFT,  (int)DIR.DIR_DOWN,  (int)DIR.DIR_UP };
    private static readonly int[] DATA_MvRtDURL_DirTbl =    { (int)DIR.DIR_DOWN,  (int)DIR.DIR_UP,    (int)DIR.DIR_RIGHT, (int)DIR.DIR_LEFT };
    private static readonly int[] DATA_MvRtLDUR_DirTbl =    { (int)DIR.DIR_LEFT,  (int)DIR.DIR_DOWN,  (int)DIR.DIR_UP,    (int)DIR.DIR_RIGHT };
    private static readonly int[] DATA_MvRtULRD_DirTbl =    { (int)DIR.DIR_LEFT,  (int)DIR.DIR_RIGHT, (int)DIR.DIR_DOWN,  (int)DIR.DIR_UP }; // BUG: This table is the same as the one below
    private static readonly int[] DATA_MvRtLRDU_DirTbl =    { (int)DIR.DIR_LEFT,  (int)DIR.DIR_RIGHT, (int)DIR.DIR_DOWN,  (int)DIR.DIR_UP };
    private static readonly int[] DATA_MvRtDULR_DirTbl =    { (int)DIR.DIR_DOWN,  (int)DIR.DIR_UP,    (int)DIR.DIR_LEFT,  (int)DIR.DIR_RIGHT };
    private static readonly int[] DATA_MvRtRDUL_DirTbl =    { (int)DIR.DIR_RIGHT, (int)DIR.DIR_DOWN,  (int)DIR.DIR_UP,    (int)DIR.DIR_LEFT };
    private static readonly int[] DATA_MvRtLUDR_DirTbl =    { (int)DIR.DIR_LEFT,  (int)DIR.DIR_UP,    (int)DIR.DIR_DOWN,  (int)DIR.DIR_RIGHT };
    private static readonly int[] DATA_MvRtUDRL_DirTbl =    { (int)DIR.DIR_UP,    (int)DIR.DIR_DOWN,  (int)DIR.DIR_RIGHT, (int)DIR.DIR_LEFT };
    private static readonly int[] DATA_MvRtRLUD_DirTbl =    { (int)DIR.DIR_RIGHT, (int)DIR.DIR_LEFT,  (int)DIR.DIR_UP,    (int)DIR.DIR_DOWN };
    private static readonly int[] DATA_MvRtDRLU_DirTbl =    { (int)DIR.DIR_DOWN,  (int)DIR.DIR_RIGHT, (int)DIR.DIR_LEFT,  (int)DIR.DIR_UP };
    private static readonly int[] DATA_MvRtRUDL_DirTbl =    { (int)DIR.DIR_RIGHT, (int)DIR.DIR_UP,    (int)DIR.DIR_DOWN,  (int)DIR.DIR_LEFT };
    private static readonly int[] DATA_MvRtUDLR_DirTbl =    { (int)DIR.DIR_UP,    (int)DIR.DIR_DOWN,  (int)DIR.DIR_LEFT,  (int)DIR.DIR_RIGHT };
    private static readonly int[] DATA_MvRtLRUD_DirTbl =    { (int)DIR.DIR_LEFT,  (int)DIR.DIR_RIGHT, (int)DIR.DIR_UP,    (int)DIR.DIR_DOWN };
    private static readonly int[] DATA_MvRtDLRU_DirTbl =    { (int)DIR.DIR_DOWN,  (int)DIR.DIR_LEFT,  (int)DIR.DIR_RIGHT, (int)DIR.DIR_UP };
    private static readonly int[] DATA_MvRtUL_DirTbl =      { (int)DIR.DIR_UP,    (int)DIR.DIR_LEFT,  (int)DIR.DIR_DOWN,  (int)DIR.DIR_RIGHT };
    private static readonly int[] DATA_MvRtDR_DirTbl =      { (int)DIR.DIR_DOWN,  (int)DIR.DIR_RIGHT, (int)DIR.DIR_UP,    (int)DIR.DIR_LEFT };
    private static readonly int[] DATA_MvRtLD_DirTbl =      { (int)DIR.DIR_LEFT,  (int)DIR.DIR_DOWN,  (int)DIR.DIR_RIGHT, (int)DIR.DIR_UP };
    private static readonly int[] DATA_MvRtRU_DirTbl =      { (int)DIR.DIR_RIGHT, (int)DIR.DIR_UP,    (int)DIR.DIR_LEFT,  (int)DIR.DIR_DOWN };
    private static readonly int[] DATA_MvRtUR_DirTbl =      { (int)DIR.DIR_UP,    (int)DIR.DIR_RIGHT, (int)DIR.DIR_DOWN,  (int)DIR.DIR_LEFT };
    private static readonly int[] DATA_MvRtDL_DirTbl =      { (int)DIR.DIR_DOWN,  (int)DIR.DIR_LEFT,  (int)DIR.DIR_UP,    (int)DIR.DIR_RIGHT };
    private static readonly int[] DATA_MvRtLU_DirTbl =      { (int)DIR.DIR_LEFT,  (int)DIR.DIR_UP,    (int)DIR.DIR_RIGHT, (int)DIR.DIR_DOWN };
    private static readonly int[] DATA_MvRtRD_DirTbl =      { (int)DIR.DIR_RIGHT, (int)DIR.DIR_DOWN,  (int)DIR.DIR_LEFT,  (int)DIR.DIR_UP };
    private static readonly int[] DATA_MvDirSpin_DirTbl =   { (int)DIR.DIR_UP,    (int)DIR.DIR_DOWN,  (int)DIR.DIR_LEFT,  (int)DIR.DIR_RIGHT };
    private static readonly int[] DATA_MvDirKurukuru =      { (int)DIR.DIR_UP,    (int)DIR.DIR_LEFT,  (int)DIR.DIR_DOWN,  (int)DIR.DIR_RIGHT };
    private static readonly int[] enable_code =
    {
        MV_DIR_RND,
        MV_RND_UL, MV_RND_UR, MV_RND_DL, MV_RND_DR,
        MV_RND_UDL, MV_RND_UDR, MV_RND_ULR, MV_RND_DLR,
        MV_RND_UD, MV_RND_LR,
        MV_SPIN_L, MV_SPIN_R,
        MV_CODE_NOT
    };
    private SUBWORK _subWork;

    private const int DIR_H_TYPE = 0;
    private const int DIR_V_TYPE = 1;
    private const int KYORO_WAIT_FRAME = 16;
    private const int KYORO_COUNT_MAX = 4;
    private const int SPIN_STOP_L_TYPE = 0;
    private const int SPIN_STOP_R_TYPE = 1;
    private const int SPIN_STOP_WAIT_FRAME = 16;
    private const int SPIN_STOP_COUNT_MAX = 4;
    private const int DIR_4_MAX = 4;

    public Action<FieldObjectMoveCode> OnEyeAction;
    private HitData _hitData;
    
    public Vector3 MvParamGoalPos { get => _mvParam.goalPos; }

    public bool IsMissing()
    {
        if (_isMissing)
            return true;

        if (Entity == null)
        {
            _isMissing = true;
            return true;
        }

        return false;
    }

    public bool IsNoneStart()
    {
        return _moveProc == null;
    }

    public void MVCodeStart()
    {
        moveCache = new MoveCache();
        moveCache.Pos = new Vector3[10];
        moveCache.Angle = new float[10];

        _moveProc = GetMoveProc(MoveCode);
        _moveProc.InitProc.Invoke(0.0f);
        SetMVCodeLimit();

        switch (Ev_Type)
        {
            case EV_TYPE_TRAINER_KYORO:
                _subWork.wait = 0;
                _subWork.check_seq_no = 0;
                _subWork.move_seq_no = 0;
                _subWork.walk_count = 0;
                _subWork.max_count = 0;
                _subWork.origin_dir = 0;
                _subWork.dir_type = 0;
                _subWork.dir_no = 0;
                _subWork.dir_count = 0;
                _subWork.max_count = MoveParam1;
                break;

            case EV_TYPE_TRAINER_SPIN_STOP_L:
                _subWork.max_count = MoveParam1;
                _subWork.dir_type = 0;
                break;

            case EV_TYPE_TRAINER_SPIN_STOP_R:
                _subWork.max_count = MoveParam1;
                _subWork.dir_type = 0;
                break;
        }

        MvState = MV_STATE.Update;
        _mvParam.goalPos = Entity.transform.position;
        _mvParam.walkCountStart = false;
        _mvParam.waitTime = 0.0f;
        _mvParam.endWait = 0.0f;
        _mvParam.goalDir = DIR.DIR_NOT;
        _mvParam.isZeroFrameAngle = false;
        _mvParam._isForceWalkAnime = false;
    }

    // TODO
    public void MVCodeStop() { }

    // TODO
    public void MVCodeRestart() { }

    // TODO
    public void MVCodeChange(int code) { }

    // TODO
    public void MVCodeEncount() { }

    // TODO
    public void MVCodeTrainerStop() { }

    private FIELD_OBJ_MOVE_PROC_LIST GetMoveProc(int movecode)
    {
        switch (movecode)
        {
            case MV_DMY:
                return new FIELD_OBJ_MOVE_PROC_LIST(MV_DMY, FieldOBJ_MoveInitProcDummy, FieldOBJ_MoveProcDummy, FieldOBJ_MoveDeleteProcDummy, FieldOBJ_MoveReturnProcDummy);

            case MV_PLAYER:
                return new FIELD_OBJ_MOVE_PROC_LIST(MV_PLAYER, FieldOBJ_MoveInitProcDummy, FieldOBJ_MoveProcDummy, FieldOBJ_MoveDeleteProcDummy, FieldOBJ_MoveReturnProcDummy);

            case MV_DIR_RND:
                return new FIELD_OBJ_MOVE_PROC_LIST(MV_DIR_RND, FieldOBJ_MoveDirRnd_Init, FieldOBJ_MoveDirRnd_Move, FieldOBJ_MoveDirRnd_Delete, FieldOBJ_MoveReturnProcDummy);

            case MV_RND:
                return new FIELD_OBJ_MOVE_PROC_LIST(MV_RND, FieldOBJ_MoveRnd_Init, FieldOBJ_MvRnd_Move, FieldOBJ_MoveDeleteProcDummy, FieldOBJ_MoveReturnProcDummy);

            case MV_RND_V:
                return new FIELD_OBJ_MOVE_PROC_LIST(MV_RND, FieldOBJ_MoveRndV_Init, FieldOBJ_MvRnd_Move, FieldOBJ_MoveDeleteProcDummy, FieldOBJ_MoveReturnProcDummy);

            case MV_RND_H:
                return new FIELD_OBJ_MOVE_PROC_LIST(MV_RND, FieldOBJ_MoveRndH_Init, FieldOBJ_MvRnd_Move, FieldOBJ_MoveDeleteProcDummy, FieldOBJ_MoveReturnProcDummy);

            case MV_RND_UL:
                return new FIELD_OBJ_MOVE_PROC_LIST(MV_RND, FieldOBJ_MoveDirRndUL_Init, FieldOBJ_MoveDirRnd_Move, FieldOBJ_MoveDirRnd_Delete, FieldOBJ_MoveReturnProcDummy);

            case MV_RND_UR:
                return new FIELD_OBJ_MOVE_PROC_LIST(MV_RND, FieldOBJ_MoveDirRndUR_Init, FieldOBJ_MoveDirRnd_Move, FieldOBJ_MoveDirRnd_Delete, FieldOBJ_MoveReturnProcDummy);

            case MV_RND_DL:
                return new FIELD_OBJ_MOVE_PROC_LIST(MV_RND, FieldOBJ_MoveDirRndDL_Init, FieldOBJ_MoveDirRnd_Move, FieldOBJ_MoveDirRnd_Delete, FieldOBJ_MoveReturnProcDummy);

            case MV_RND_DR:
                return new FIELD_OBJ_MOVE_PROC_LIST(MV_RND, FieldOBJ_MoveDirRndDR_Init, FieldOBJ_MoveDirRnd_Move, FieldOBJ_MoveDirRnd_Delete, FieldOBJ_MoveReturnProcDummy);

            case MV_RND_UDL:
                return new FIELD_OBJ_MOVE_PROC_LIST(MV_RND, FieldOBJ_MoveDirRndUDL_Init, FieldOBJ_MoveDirRnd_Move, FieldOBJ_MoveDirRnd_Delete, FieldOBJ_MoveReturnProcDummy);

            case MV_RND_UDR:
                return new FIELD_OBJ_MOVE_PROC_LIST(MV_RND, FieldOBJ_MoveDirRndUDR_Init, FieldOBJ_MoveDirRnd_Move, FieldOBJ_MoveDirRnd_Delete, FieldOBJ_MoveReturnProcDummy);

            case MV_RND_ULR:
                return new FIELD_OBJ_MOVE_PROC_LIST(MV_RND, FieldOBJ_MoveDirRndULR_Init, FieldOBJ_MoveDirRnd_Move, FieldOBJ_MoveDirRnd_Delete, FieldOBJ_MoveReturnProcDummy);

            case MV_RND_DLR:
                return new FIELD_OBJ_MOVE_PROC_LIST(MV_RND, FieldOBJ_MoveDirRndDLR_Init, FieldOBJ_MoveDirRnd_Move, FieldOBJ_MoveDirRnd_Delete, FieldOBJ_MoveReturnProcDummy);
                
            case MV_UP:
                return new FIELD_OBJ_MOVE_PROC_LIST(MV_RND, FieldOBJ_MoveUp_Init, FieldOBJ_MoveDir_Move, FieldOBJ_MoveDeleteProcDummy, FieldOBJ_MoveReturnProcDummy);
                
            case MV_DOWN:
                return new FIELD_OBJ_MOVE_PROC_LIST(MV_RND, FieldOBJ_MoveDown_Init, FieldOBJ_MoveDir_Move, FieldOBJ_MoveDeleteProcDummy, FieldOBJ_MoveReturnProcDummy);
                
            case MV_LEFT:
                return new FIELD_OBJ_MOVE_PROC_LIST(MV_RND, FieldOBJ_MoveLeft_Init, FieldOBJ_MoveDir_Move, FieldOBJ_MoveDeleteProcDummy, FieldOBJ_MoveReturnProcDummy);
                
            case MV_RIGHT:
                return new FIELD_OBJ_MOVE_PROC_LIST(MV_RND, FieldOBJ_MoveRight_Init, FieldOBJ_MoveDir_Move, FieldOBJ_MoveDeleteProcDummy, FieldOBJ_MoveReturnProcDummy);

            case MV_SPIN_L:
                return new FIELD_OBJ_MOVE_PROC_LIST(MV_RND, FieldOBJ_MoveSpinLeft_Init, FieldOBJ_MoveSpin_Move, FieldOBJ_MoveDeleteProcDummy, FieldOBJ_MoveReturnProcDummy);

            case MV_SPIN_R:
                return new FIELD_OBJ_MOVE_PROC_LIST(MV_RND, FieldOBJ_MoveSpinRight_Init, FieldOBJ_MoveSpin_Move, FieldOBJ_MoveDeleteProcDummy, FieldOBJ_MoveReturnProcDummy);

            case MV_RT2:
                return new FIELD_OBJ_MOVE_PROC_LIST(MV_RND, FieldOBJ_MoveRoute2_Init, FieldOBJ_MoveRoute2_Move, FieldOBJ_MoveDeleteProcDummy, FieldOBJ_MoveReturnProcDummy);

            case MV_RTURLD:
                return new FIELD_OBJ_MOVE_PROC_LIST(MV_RND, FieldOBJ_MoveRouteURLD_Init, FieldOBJ_MoveRoute3_Move, FieldOBJ_MoveDeleteProcDummy, FieldOBJ_MoveReturnProcDummy);

            case MV_RTRLDU:
                return new FIELD_OBJ_MOVE_PROC_LIST(MV_RND, FieldOBJ_MoveRouteRLDU_Init, FieldOBJ_MoveRoute3_Move, FieldOBJ_MoveDeleteProcDummy, FieldOBJ_MoveReturnProcDummy);

            case MV_RTDURL:
                return new FIELD_OBJ_MOVE_PROC_LIST(MV_RND, FieldOBJ_MoveRouteDURL_Init, FieldOBJ_MoveRoute3_Move, FieldOBJ_MoveDeleteProcDummy, FieldOBJ_MoveReturnProcDummy);

            case MV_RTLDUR:
                return new FIELD_OBJ_MOVE_PROC_LIST(MV_RND, FieldOBJ_MoveRouteLDUR_Init, FieldOBJ_MoveRoute3_Move, FieldOBJ_MoveDeleteProcDummy, FieldOBJ_MoveReturnProcDummy);

            case MV_RTULRD:
                return new FIELD_OBJ_MOVE_PROC_LIST(MV_RND, FieldOBJ_MoveRouteULRD_Init, FieldOBJ_MoveRoute3_Move, FieldOBJ_MoveDeleteProcDummy, FieldOBJ_MoveReturnProcDummy);

            case MV_RTLRDU:
                return new FIELD_OBJ_MOVE_PROC_LIST(MV_RND, FieldOBJ_MoveRouteLRDU_Init, FieldOBJ_MoveRoute3_Move, FieldOBJ_MoveDeleteProcDummy, FieldOBJ_MoveReturnProcDummy);

            case MV_RTDULR:
                return new FIELD_OBJ_MOVE_PROC_LIST(MV_RND, FieldOBJ_MoveRouteDULR_Init, FieldOBJ_MoveRoute3_Move, FieldOBJ_MoveDeleteProcDummy, FieldOBJ_MoveReturnProcDummy);

            case MV_RTRDUL:
                return new FIELD_OBJ_MOVE_PROC_LIST(MV_RND, FieldOBJ_MoveRouteRDUL_Init, FieldOBJ_MoveRoute3_Move, FieldOBJ_MoveDeleteProcDummy, FieldOBJ_MoveReturnProcDummy);

            case MV_RTLUDR:
                return new FIELD_OBJ_MOVE_PROC_LIST(MV_RND, FieldOBJ_MoveRouteLUDR_Init, FieldOBJ_MoveRoute3_Move, FieldOBJ_MoveDeleteProcDummy, FieldOBJ_MoveReturnProcDummy);

            case MV_RTUDRL:
                return new FIELD_OBJ_MOVE_PROC_LIST(MV_RND, FieldOBJ_MoveRouteUDRL_Init, FieldOBJ_MoveRoute3_Move, FieldOBJ_MoveDeleteProcDummy, FieldOBJ_MoveReturnProcDummy);

            case MV_RTRLUD:
                return new FIELD_OBJ_MOVE_PROC_LIST(MV_RND, FieldOBJ_MoveRouteRLUD_Init, FieldOBJ_MoveRoute3_Move, FieldOBJ_MoveDeleteProcDummy, FieldOBJ_MoveReturnProcDummy);

            case MV_RTDRLU:
                return new FIELD_OBJ_MOVE_PROC_LIST(MV_RND, FieldOBJ_MoveRouteDRLU_Init, FieldOBJ_MoveRoute3_Move, FieldOBJ_MoveDeleteProcDummy, FieldOBJ_MoveReturnProcDummy);

            case MV_RTRUDL:
                return new FIELD_OBJ_MOVE_PROC_LIST(MV_RND, FieldOBJ_MoveRouteRUDL_Init, FieldOBJ_MoveRoute3_Move, FieldOBJ_MoveDeleteProcDummy, FieldOBJ_MoveReturnProcDummy);

            case MV_RTUDLR:
                return new FIELD_OBJ_MOVE_PROC_LIST(MV_RND, FieldOBJ_MoveRouteUDLR_Init, FieldOBJ_MoveRoute3_Move, FieldOBJ_MoveDeleteProcDummy, FieldOBJ_MoveReturnProcDummy);

            case MV_RTLRUD:
                return new FIELD_OBJ_MOVE_PROC_LIST(MV_RND, FieldOBJ_MoveRouteLRUD_Init, FieldOBJ_MoveRoute3_Move, FieldOBJ_MoveDeleteProcDummy, FieldOBJ_MoveReturnProcDummy);

            case MV_RTDLRU:
                return new FIELD_OBJ_MOVE_PROC_LIST(MV_RND, FieldOBJ_MoveRouteDLRU_Init, FieldOBJ_MoveRoute3_Move, FieldOBJ_MoveDeleteProcDummy, FieldOBJ_MoveReturnProcDummy);

            case MV_RTUL:
                return new FIELD_OBJ_MOVE_PROC_LIST(MV_RND, FieldOBJ_MoveRouteUL_Init, FieldOBJ_MoveRoute3_Move, FieldOBJ_MoveDeleteProcDummy, FieldOBJ_MoveReturnProcDummy);

            case MV_RTDR:
                return new FIELD_OBJ_MOVE_PROC_LIST(MV_RND, FieldOBJ_MoveRouteDR_Init, FieldOBJ_MoveRoute3_Move, FieldOBJ_MoveDeleteProcDummy, FieldOBJ_MoveReturnProcDummy);

            case MV_RTLD:
                return new FIELD_OBJ_MOVE_PROC_LIST(MV_RND, FieldOBJ_MoveRouteLD_Init, FieldOBJ_MoveRoute3_Move, FieldOBJ_MoveDeleteProcDummy, FieldOBJ_MoveReturnProcDummy);

            case MV_RTRU:
                return new FIELD_OBJ_MOVE_PROC_LIST(MV_RND, FieldOBJ_MoveRouteRU_Init, FieldOBJ_MoveRoute3_Move, FieldOBJ_MoveDeleteProcDummy, FieldOBJ_MoveReturnProcDummy);

            case MV_RTUR:
                return new FIELD_OBJ_MOVE_PROC_LIST(MV_RND, FieldOBJ_MoveRouteUR_Init, FieldOBJ_MoveRoute3_Move, FieldOBJ_MoveDeleteProcDummy, FieldOBJ_MoveReturnProcDummy);

            case MV_RTDL:
                return new FIELD_OBJ_MOVE_PROC_LIST(MV_RND, FieldOBJ_MoveRouteDL_Init, FieldOBJ_MoveRoute3_Move, FieldOBJ_MoveDeleteProcDummy, FieldOBJ_MoveReturnProcDummy);

            case MV_RTLU:
                return new FIELD_OBJ_MOVE_PROC_LIST(MV_RND, FieldOBJ_MoveRouteLU_Init, FieldOBJ_MoveRoute3_Move, FieldOBJ_MoveDeleteProcDummy, FieldOBJ_MoveReturnProcDummy);

            case MV_RTRD:
                return new FIELD_OBJ_MOVE_PROC_LIST(MV_RND, FieldOBJ_MoveRouteRD_Init, FieldOBJ_MoveRoute3_Move, FieldOBJ_MoveDeleteProcDummy, FieldOBJ_MoveReturnProcDummy);

            case MV_RND_UD:
                return new FIELD_OBJ_MOVE_PROC_LIST(MV_RND, FieldOBJ_MoveDirRndUD_Init, FieldOBJ_MoveDirRnd_Move, FieldOBJ_MoveDirRnd_Delete, FieldOBJ_MoveReturnProcDummy);

            case MV_RND_LR:
                return new FIELD_OBJ_MOVE_PROC_LIST(MV_RND, FieldOBJ_MoveDirRndLR_Init, FieldOBJ_MoveDirRnd_Move, FieldOBJ_MoveDirRnd_Delete, FieldOBJ_MoveReturnProcDummy);

            case MV_SEED:
                return new FIELD_OBJ_MOVE_PROC_LIST(MV_SEED, FieldOBJ_MoveSeed_Init, FieldOBJ_MoveSeed_Move, FieldOBJ_MoveSeed_Delete, FieldOBJ_MoveReturnProcDummy);

            case MV_PAIR:
                return new FIELD_OBJ_MOVE_PROC_LIST(MV_RND, FieldOBJ_MovePair_Init, FieldOBJ_MovePair_Move, FieldOBJ_MovePair_Delete, FieldOBJ_MoveReturnProcDummy);
                
            case MV_REWAR:
                return new FIELD_OBJ_MOVE_PROC_LIST(MV_RND, FieldOBJ_MoveRewar_Init, FieldOBJ_MoveRewar_Move, FieldOBJ_MoveDeleteProcDummy, FieldOBJ_MoveReturnProcDummy);
                
            case MV_TR_PAIR:
                return new FIELD_OBJ_MOVE_PROC_LIST(MV_RND, FieldOBJ_MovePairTr_Init, FieldOBJ_MovePairTr_Move, FieldOBJ_MovePairTr_Delete, FieldOBJ_MovePairTr_Return);

            case MV_HIDE_SNOW:
                return new FIELD_OBJ_MOVE_PROC_LIST(MV_HIDE_SNOW, FieldOBJ_MoveHideSnow_Init, FieldOBJ_MoveHide_Move, FieldOBJ_MoveHide_Delete, FieldOBJ_MoveHide_Return);

            case MV_HIDE_SAND:
                return new FIELD_OBJ_MOVE_PROC_LIST(MV_HIDE_SAND, FieldOBJ_MoveHideSand_Init, FieldOBJ_MoveHide_Move, FieldOBJ_MoveHide_Delete, FieldOBJ_MoveHide_Return);

            case MV_HIDE_GRND:
                return new FIELD_OBJ_MOVE_PROC_LIST(MV_HIDE_GRND, FieldOBJ_MoveHideGround_Init, FieldOBJ_MoveHide_Move, FieldOBJ_MoveHide_Delete, FieldOBJ_MoveHide_Return);

            case MV_HIDE_KUSA:
                return new FIELD_OBJ_MOVE_PROC_LIST(MV_HIDE_KUSA, FieldOBJ_MoveHideKusa_Init, FieldOBJ_MoveHide_Move, FieldOBJ_MoveHide_Delete, FieldOBJ_MoveHide_Return);

            default:
                return null;
        }
    }

    private void FieldOBJ_MoveInitProcDummy(float time)
    {
        // Empty
    }

    private void FieldOBJ_MoveProcDummy(float time)
    {
        // Empty
    }

    private void FieldOBJ_MoveDeleteProcDummy(float time)
    {
        // Empty
    }

    private void FieldOBJ_MoveReturnProcDummy(float time)
    {
        // Empty
    }

    // TODO
    private void FieldOBJ_MoveDirRnd_Init(float time) { }

    // TODO
    private void FieldOBJ_MoveDirRndUL_Init(float time) { }

    // TODO
    private void FieldOBJ_MoveDirRndUR_Init(float time) { }

    // TODO
    private void FieldOBJ_MoveDirRndDL_Init(float time) { }

    // TODO
    private void FieldOBJ_MoveDirRndDR_Init(float time) { }

    // TODO
    private void FieldOBJ_MoveDirRndUDL_Init(float time) { }

    // TODO
    private void FieldOBJ_MoveDirRndUDR_Init(float time) { }

    // TODO
    private void FieldOBJ_MoveDirRndULR_Init(float time) { }

    // TODO
    private void FieldOBJ_MoveDirRndDLR_Init(float time) { }

    // TODO
    private void FieldOBJ_MoveDirRndUD_Init(float time) { }

    // TODO
    private void FieldOBJ_MoveDirRndLR_Init(float time) { }

    // TODO
    private void FieldOBJ_MoveDirRnd_Move(float time) { }

    // TODO
    private void FieldOBJ_MoveDirRnd_Delete(float time) { }

    // TODO
    private void FieldOBJ_MoveRnd_Init(float time) { }

    // TODO
    private void FieldOBJ_MoveRndV_Init(float time) { }

    // TODO
    private void FieldOBJ_MoveRndH_Init(float time) { }

    // TODO
    private void FieldOBJ_MvRnd_Move(float time) { }

    // TODO
    private void FieldOBJ_MoveUp_Init(float time) { }

    // TODO
    private void FieldOBJ_MoveDown_Init(float time) { }

    // TODO
    private void FieldOBJ_MoveLeft_Init(float time) { }

    // TODO
    private void FieldOBJ_MoveRight_Init(float time) { }

    // TODO
    private void FieldOBJ_MoveDir_Move(float time) { }

    // TODO
    private void FieldOBJ_MoveSpinLeft_Init(float time) { }

    // TODO
    private void FieldOBJ_MoveSpinRight_Init(float time) { }

    // TODO
    private void CheckSpinDir() { }

    // TODO
    private void FieldOBJ_MoveSpin_Move(float time) { }

    // TODO
    private void FieldOBJ_MoveRewar_Init(float time) { }

    // TODO
    private void FieldOBJ_MoveRewar_Move(float time) { }

    // TODO
    private void FieldOBJ_MoveRoute2_Init(float time) { }

    // TODO
    private void FieldOBJ_MoveRoute2_Move(float time) { }

    // TODO
    private void FieldOBJ_MoveRouteURLD_Init(float time) { }

    // TODO
    private void FieldOBJ_MoveRouteRLDU_Init(float time) { }

    // TODO
    private void FieldOBJ_MoveRouteDURL_Init(float time) { }

    // TODO
    private void FieldOBJ_MoveRouteLDUR_Init(float time) { }

    // TODO
    private void FieldOBJ_MoveRouteULRD_Init(float time) { }

    // TODO
    private void FieldOBJ_MoveRouteLRDU_Init(float time) { }

    // TODO
    private void FieldOBJ_MoveRouteDULR_Init(float time) { }

    // TODO
    private void FieldOBJ_MoveRouteRDUL_Init(float time) { }

    // TODO
    private void FieldOBJ_MoveRouteLUDR_Init(float time) { }

    // TODO
    private void FieldOBJ_MoveRouteUDRL_Init(float time) { }

    // TODO
    private void FieldOBJ_MoveRouteRLUD_Init(float time) { }

    // TODO
    private void FieldOBJ_MoveRouteDRLU_Init(float time) { }

    // TODO
    private void FieldOBJ_MoveRouteRUDL_Init(float time) { }

    // TODO
    private void FieldOBJ_MoveRouteUDLR_Init(float time) { }

    // TODO
    private void FieldOBJ_MoveRouteLRUD_Init(float time) { }

    // TODO
    private void FieldOBJ_MoveRouteDLRU_Init(float time) { }

    // TODO
    private void FieldOBJ_MoveRouteUL_Init(float time) { }

    // TODO
    private void FieldOBJ_MoveRouteDR_Init(float time) { }

    // TODO
    private void FieldOBJ_MoveRouteLD_Init(float time) { }

    // TODO
    private void FieldOBJ_MoveRouteRU_Init(float time) { }

    // TODO
    private void FieldOBJ_MoveRouteUR_Init(float time) { }

    // TODO
    private void FieldOBJ_MoveRouteDL_Init(float time) { }

    // TODO
    private void FieldOBJ_MoveRouteLU_Init(float time) { }

    // TODO
    private void FieldOBJ_MoveRouteRD_Init(float time) { }

    // TODO
    private void FieldOBJ_MoveRoute3_Move(float time) { }

    // TODO
    private void SetGoalPos() { }

    // TODO
    private void FieldOBJ_MoveSeed_Init(float time) { }

    // TODO
    private void FieldOBJ_MoveSeed_Move(float time) { }

    // TODO
    private void FieldOBJ_MoveSeed_Delete(float time) { }

    // TODO
    private void FieldOBJ_MovePair_Init(float time) { }

    // TODO
    private void FieldOBJ_MovePair_Move(float time) { }

    // TODO
    private void FieldOBJ_MovePair_Delete(float time) { }

    // TODO
    private void FieldOBJ_MovePairTr_Init(float time) { }

    // TODO
    private void FieldOBJ_MovePairTr_Move(float time) { }

    // TODO
    private void FieldOBJ_MovePairTr_Delete(float time) { }

    // TODO
    private void FieldOBJ_MovePairTr_Return(float time) { }

    // TODO
    private void FieldOBJ_MoveHideSnow_Init(float time) { }

    // TODO
    private void FieldOBJ_MoveHide_Move(float time) { }

    // TODO
    private void FieldOBJ_MoveHide_Delete(float time) { }

    // TODO
    private void FieldOBJ_MoveHide_Return(float time) { }

    // TODO
    private void FieldOBJ_MoveHideSand_Init(float time) { }

    // TODO
    private void FieldOBJ_MoveHideGround_Init(float time) { }

    // TODO
    private void FieldOBJ_MoveHideKusa_Init(float time) { }

    // TODO
    private void DirRndWorkInit(int id) { }

    // TODO
    private int TblRndGet(int[] list) { return 0; }

    // TODO
    private int TblIDRndGet(int id) { return 0; }

    // TODO
    private void MvRndWorkInit(int ac, int tbl_id, int check) { }

    // TODO
    private void FieldOBJ_DirDispCheckSet(int dir) { }

    private int FieldOBJ_DirMoveGet() {
        return mv_dir;
    }

    // TODO
    private void FieldOBJ_DirMoveSet(int dir) { }

    // TODO
    private bool MvRndRectMoveLimitCheck(Vector3 pos) { return false; }

    // TODO
    private bool IsInside(Vector3 vA, Rect rect, Vector3 size) { return false; }

    // TODO
    private void MvDirWorkInit(int dir) { }

    // TODO
    private void MvSpinDirWorkInit(int dir) { }

    // TODO
    private int FieldOBJTool_DirFlip(int dir) { return 0; }

    // TODO
    private int FieldOBJ_GoalPosCheck() { return 0; }

    // TODO
    private bool FieldOBJ_MoveHitCheckLimit(float x, float z) { return false; }

    // TODO
    private bool FieldOBJ_GoalPosHitCheckFellow() { return false; }

    // TODO
    private bool FieldOBJ_MoveHitCheckAttr(float x, float z, int dir) { return false; }

    // TODO
    private bool MoveSub_KuruKuruCheck() { return false; }

    // TODO
    private void MoveSub_KuruKuruInit() { }

    // TODO
    private void MoveSub_KuruKuruSet() { }

    // TODO
    private void MoveSub_KuruKuruEnd() { }

    // TODO
    private void MvRt3WorkInit(int check_no, int check_type, int tbl_id) { }

    // TODO
    private int TrJikiDashSearch() { return 0; }

    // TODO
    private int TrJikiDashSearchTbl(int id) { return 0; }

    // TODO
    private int FieldOBJTool_DirRange(int ax, int az, int bx, int bz) { return 0; }

    // TODO
    private int[] MoveDirTblIDSearch(int id) { return null; }

    // TODO
    private int[] DATA_MoveDirTbl(DIRID id) { return null; }

    // TODO
    private bool FieldOBJ_StatusBitCheck_Use() { return false; }

    // TODO
    private void FieldOBJ_StatusBitON_Move() { }

    // TODO
    private void FieldOBJ_StatusBitOFF_Move() { }

    // TODO
    private bool FieldOBJ_StatusBitCheck_Move() { return false; }

    // TODO
    private void FieldOBJ_StatusBit_ON(int bit) { }

    // TODO
    private void FieldOBJ_StatusBit_OFF(int bit) { }

    // TODO
    private bool FieldOBJ_StatusBit_CheckEasy(int bit) { return false; }

    // TODO
    private bool IsSubProcActive() { return false; }

    // TODO
    private void DATA_FldOBJ_EventTypeInitProcTbl() { }

    // TODO
    private bool DATA_FldOBJ_EventTypeStartCheckProcTbl() { return false; }

    // TODO
    private bool DATA_FldOBJ_EventTypeMoveProcTbl() { return false; }

    // TODO
    private bool FieldOBJ_MoveSub() { return false; }

    // TODO
    private bool SubStart() { return false; }

    // TODO
    private bool SubUpdate() { return false; }

    // TODO
    private void SubMoveNon_Init() { }

    private bool SubMoveNon_StartCheck() {
        return false;
    }

    private bool SubMoveNon_Move() {
        return false;
    }

    // TODO
    private void SubMoveKyoro_Init() { }

    // TODO
    private bool SubMoveKyoro_StartCheck() { return false; }

    // TODO
    private bool SubMoveKyoro_Move() { return false; }

    // TODO
    private void SubMoveSpinStop_Init() { }

    // TODO
    private bool SubMoveSpinStop_StartCheck() { return false; }

    // TODO
    private bool SubMoveSpinStop_Move() { return false; }

    // TODO
    private int FieldOBJ_DirDispGet() { return 0; }

    // TODO
    private bool MoveSub_PosUpdateStartCheck() { return false; }

    // TODO
    private bool MoveSub_PosUpdateEndCheck() { return false; }

    // TODO
    public void MoveCodeUpdate(float time, ref Vector3 pWorld, ref Vector2Int pGrid, bool isrun) { }

    // TODO
    private bool UpdateAngle(float dir, float anglespd, bool zeroframe = false) { return false; }

    // TODO
    private void SetWait(int frame) { }

    // TODO
    private bool IsWaitEnd() { return false; }

    // TODO
    private int GetDirAngle(DIR dir) { return 0; }

    // TODO
    private void SetGoalPos(DIR dir) { }

    // TODO
    private bool IsNowDefaultPosX() { return false; }

    // TODO
    private bool IsNowDefaultPosZ() { return false; }

    // TODO
    private bool IsNowDefaultPosXZ() { return false; }

    // TODO
    private void MoveCodeUpdateAfter(bool move, float time) { }

    // TODO
    private void AnimeStop() { }

    // TODO
    public void MoveCodeLateUpdate(float deltatime) { }

    // TODO
    public bool TrainerEyeUpdate(ref Vector3 moveVector, ref Vector2 hitpos) { return false; }

    // TODO
    private bool IsEyeHit(int dir, ref Vector3 moveVector, out int hitdir, ref Vector2 hitpos)
    {
        hitdir = 0;
        return false;
    }

    // TODO
    private bool IsHit(float x, float y, float w, float h, Vector2Int point) { return false; }

    // TODO
    private int EyeObjectCheck(int dir, int length) { return 0; }

    // TODO
    public bool PlayerApproach(float time) { return false; }

    // TODO
    public bool IsTrainer() { return false; }

    // TODO
    public int EyeType() { return 0; }

    // TODO
    public void SetPlayerDistance(int gx, int gz, float h) { }

    // TODO
    private void SetMVCodeLimit() { }

    public enum MV_STATE : int
    {
        Update = 0,
        Encount = 1,
        Stop = 2,
        TrainerStop = 3,
    }

    private struct MV_PARAM
    {
        public int seq_no;
        public float wait;
        public int move_check_type;
        public int acmd_code;
        public int tbl_id;
        public int dir;
        public int spin_dir;
        public int tbl_no;
        public bool turn_flag;
        public int turn_no;
        public int turn_check_no;
        public int turn_check_type;
        public int spin_type;
        public int state;
        public int work_id;
        public float krkr_basedir;
        public bool krkr_start;
        public bool object_hit;
        public int object_hit_move_dir;
        public int loopcnt;
        public Vector3 goalPos;
        public bool walkCountStart;
        public float waitTime;
        public float endWait;
        public DIR goalDir;
        public bool isGoalPos;
        public bool isZeroFrameAngle;
        public string parentname;
        public bool _isForceWalkAnime;
    }

    public struct MoveCache
    {
        public int index;
        public Vector3[] Pos;
        public float[] Angle;
    }

    private class FIELD_OBJ_MOVE_PROC_LIST
    {
        public int MoveCode;
        public Action<float> InitProc;
        public Action<float> UpdateProc;
        public Action<float> DeleteProc;
        public Action<float> ReturnProc;

        public FIELD_OBJ_MOVE_PROC_LIST(int movecode, Action<float> init, Action<float> proc, Action<float> del, Action<float> ret)
        {
            MoveCode = movecode;
            InitProc = init;
            UpdateProc = proc;
            DeleteProc = del;
            ReturnProc = ret;
        }
    }

    private enum DIRID : int
    {
        DIRID_MvDirRndDirTbl = 0,
        DIRID_MvDirRndDirTbl_UL = 1,
        DIRID_MvDirRndDirTbl_UR = 2,
        DIRID_MvDirRndDirTbl_DL = 3,
        DIRID_MvDirRndDirTbl_DR = 4,
        DIRID_MvDirRndDirTbl_UDL = 5,
        DIRID_MvDirRndDirTbl_UDR = 6,
        DIRID_MvDirRndDirTbl_ULR = 7,
        DIRID_MvDirRndDirTbl_DLR = 8,
        DIRID_MvDirRndDirTbl_UD = 9,
        DIRID_MvDirRndDirTbl_LR = 10,
        DIRID_MV_RND_DirTbl = 11,
        DIRID_MV_RND_V_DirTbl = 12,
        DIRID_MV_RND_H_DirTbl = 13,
        DIRID_MvRtURLD_DirTbl = 14,
        DIRID_MvRtRLDU_DirTbl = 15,
        DIRID_MvRtDURL_DirTbl = 16,
        DIRID_MvRtLDUR_DirTbl = 17,
        DIRID_MvRtULRD_DirTbl = 18,
        DIRID_MvRtLRDU_DirTbl = 19,
        DIRID_MvRtDULR_DirTbl = 20,
        DIRID_MvRtRDUL_DirTbl = 21,
        DIRID_MvRtLUDR_DirTbl = 22,
        DIRID_MvRtUDRL_DirTbl = 23,
        DIRID_MvRtRLUD_DirTbl = 24,
        DIRID_MvRtDRLU_DirTbl = 25,
        DIRID_MvRtRUDL_DirTbl = 26,
        DIRID_MvRtUDLR_DirTbl = 27,
        DIRID_MvRtLRUD_DirTbl = 28,
        DIRID_MvRtDLRU_DirTbl = 29,
        DIRID_MvRtUL_DirTbl = 30,
        DIRID_MvRtDR_DirTbl = 31,
        DIRID_MvRtLD_DirTbl = 32,
        DIRID_MvRtRU_DirTbl = 33,
        DIRID_MvRtUR_DirTbl = 34,
        DIRID_MvRtDL_DirTbl = 35,
        DIRID_MvRtLU_DirTbl = 36,
        DIRID_MvRtRD_DirTbl = 37,
        DIRID_MvDirSpin_DirTbl = 38,
        DIRID_END = 39,
        DIRID_MAX = 40,
    }

    private struct SUBWORK
    {
        public int check_seq_no;
        public int move_seq_no;
        public int walk_count;
        public int max_count;
        public int origin_dir;
        public int dir_type;
        public int dir_no;
        public int dir_count;
        public int wait;
    }

    private struct HitData
    {
        public int seqNo;
        public int dir;
        public Vector2 endpos;
    }
}