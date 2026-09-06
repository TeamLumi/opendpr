using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

public class PiaPluginSession
{
    private const int AttributeSizeMax = 6;
    public const int DefaultSessionKeepAliveInterval = 1000;
    public const int DefaultSessionSilenceTimeMax = 10000;
    public const int LanApplicationDataBufferSizeMax = 384;
    public const int UpdateMeshSendingIntervalDefault = 1000;
    private const int SessionUserPasswordLengthMax = 8;
    public const int InetApplicationDataBufferSizeMax = 512;
    public const int LocalApplicationDataBufferSizeMax = 360;
    private const int ApplicationDataSystemBufferSizeMax = 512;
    private const int SessionMatchmakeKeywordLength = 32;

    private static extern PiaPlugin.Result OpenSessionAsyncNative();

    // TODO
    public static PiaPlugin.Result OpenSessionAsync() { return default; }

    private static extern PiaPlugin.Result UpdateAndOpenSessionAsyncNative([In] UpdateSessionSettingNative setting, [In] PiaPlugin.DateTime startedTime);

    // TODO
    public static PiaPlugin.Result UpdateAndOpenSessionAsync(UpdateSessionSetting setting) { return default; }

    private static extern PiaPlugin.Result CloseSessionAsyncNative();

    // TODO
    public static PiaPlugin.Result CloseSessionAsync() { return default; }

    private static extern PiaPlugin.Result GetSessionStatusNative(ref SessionStatusNative sessionStatusNative);

    // TODO
    public static PiaPlugin.Result GetSessionStatus(ref SessionStatus sessionStatus) { return default; }

    private static extern PiaPlugin.Result KickoutStationNative(ulong constantId);

    // TODO
    public static PiaPlugin.Result KickoutStation(ulong constantId) { return default; }

    private static extern PiaPlugin.Result BrowseSessionAsyncNative([In] SessionSearchCriteriaNative criteria);

    // TODO
    public static PiaPlugin.Result BrowseSessionAsync(SessionSearchCriteria criteria) { return default; }

    private static extern PiaPlugin.Result BrowseSessionAsyncWithOwnerNative([In] SessionSearchCriteriaOwnerNative criteria);

    // TODO
    public static PiaPlugin.Result BrowseSessionAsync(SessionSearchCriteriaOwner criteria) { return default; }

    private static extern PiaPlugin.Result BrowseSessionAsyncWithParticipantNative([In] SessionSearchCriteriaParticipantNative criteria);

    // TODO
    public static PiaPlugin.Result BrowseSessionAsync(SessionSearchCriteriaParticipant criteria) { return default; }

    private static extern PiaPlugin.Result BrowseSessionAsyncWithSessionIdNative([In] SessionSearchCriteriaSessionIdNative criteria);

    // TODO
    public static PiaPlugin.Result BrowseSessionAsync(SessionSearchCriteriaSessionId criteria) { return default; }

    private static extern PiaPlugin.Result CreateSessionAsyncNative([In] CreateSessionSettingNative setting);

    // TODO
    public static PiaPlugin.Result CreateSessionAsync(CreateSessionSetting setting) { return default; }

    private static extern PiaPlugin.Result JoinSessionAsyncNative([In] JoinSessionSettingNative setting);

    // TODO
    public static PiaPlugin.Result JoinSessionAsync(JoinSessionSetting setting) { return default; }

    private static extern PiaPlugin.Result UpdateSessionSettingAsyncNative([In] UpdateSessionSettingNative setting, [In] PiaPlugin.DateTime startedTime);

    // TODO
    public static PiaPlugin.Result UpdateSessionSettingAsync(UpdateSessionSetting setting) { return default; }

    private static extern SessionPropertyNative GetSessionPropertyNative();

    // TODO
    public static SessionProperty GetSessionProperty() { return default; }

    private static extern PiaPlugin.Result RequestSessionPropertyAsyncNative();

    // TODO
    public static PiaPlugin.Result RequestSessionPropertyAsync() { return default; }

    private static extern uint GetBrowsedSessionPropertyListSizeNative();

    // TODO
    public static uint GetBrowsedSessionPropertyListSize() { return default; }

    private static extern SessionPropertyNative GetBrowsedSessionPropertyNative([In] uint listIndex);

    // TODO
    public static SessionProperty GetBrowsedSessionProperty(uint listIndex) { return default; }

    private static extern PiaPlugin.Result GetConstantIdListNative(out IntPtr pConstantIdNativeList, out int constantIdNativeListLength);

    // TODO
    public static PiaPlugin.Result GetConstantIdList(List<ulong> constantIdList) { return default; }

    private static extern PiaPlugin.Result DestroyJointSessionAsyncNative();

    // TODO
    public static PiaPlugin.Result DestroyJointSessionAsync() { return default; }

    private static extern PiaPlugin.Result OpenJointSessionAsyncNative();

    // TODO
    public static PiaPlugin.Result OpenJointSessionAsync() { return default; }

    private static extern PiaPlugin.Result UpdateAndOpenJointSessionAsyncNative([In] UpdateSessionSettingNative setting, [In] PiaPlugin.DateTime startedTime);

    // TODO
    public static PiaPlugin.Result UpdateAndOpenJointSessionAsync(UpdateSessionSetting setting) { return default; }

    private static extern PiaPlugin.Result CloseJointSessionAsyncNative();

    // TODO
    public static PiaPlugin.Result CloseJointSessionAsync() { return default; }

    private static extern PiaPlugin.Result UpdateJointSessionSettingAsyncNative([In] UpdateSessionSettingNative setting, [In] PiaPlugin.DateTime startedTime);

    // TODO
    public static PiaPlugin.Result UpdateJointSessionSettingAsync(UpdateSessionSetting setting) { return default; }

    private static extern SessionPropertyNative GetJointSessionPropertyNative();

    // TODO
    public static SessionProperty GetJointSessionProperty() { return default; }

    private static extern PiaPlugin.Result RequestJointSessionPropertyAsyncNative();

    // TODO
    public static PiaPlugin.Result RequestJointSessionPropertyAsync() { return default; }

    private static extern bool IsHostNative();

    // TODO
    public static bool IsHost() { return default; }

    private static extern bool IsJointSessionHostNative();

    // TODO
    public static bool IsJointSessionHost() { return default; }

    private static extern uint GetSessionOpenStatusNative();

    // TODO
    public static SessionOpenStatus GetSessionOpenStatus() { return default; }

    private static extern uint GetJointSessionOpenStatusNative();

    // TODO
    public static SessionOpenStatus GetJointSessionOpenStatus() { return default; }

    private static extern int GetInetSearchCriteriaListSizeMaxNative();

    // TODO
    public static int GetInetSearchCriteriaListSizeMax() { return default; }

    private static extern int GetLanSearchCriteriaListSizeMaxNative();

    // TODO
    public static int GetLanSearchCriteriaListSizeMax() { return default; }

    public enum EventType : int
    {
        EventJoin = 0,
        EventLeave = 1,
        SessionHostChanged = 2,
        JointSessionHostChanged = 4,
        StartSessionCreateJoint = 11,
        EndSessionCreateJoint = 12,
        StartSessionJoinJoint = 13,
        EndSessionJoinJoint = 14,
        StartSessionJointRandom = 15,
        EndSessionJointRandom = 16,
        StartSessionDestroyJoint = 17,
        EndSessionDestroyJoint = 18,
        StartSessionLeaveJoint = 19,
        EndSessionLeaveJoint = 20,
        SetSessionSystemPassword = 22,
        ClearSessionSystemPassword = 23,
        InconsistentNotice = 24,
    }

    public enum Status : int
    {
        NotConnected = 0,
        ConnectedSession = 1,
        MigratingSession = 2,
        ConnectedJointSession = 3,
        DisconnectedSession = 4,
        DisconnectedNetwork = 5,
    }

    public enum DisconnectReason : int
    {
        UnknownReason = 0,
        NotYetCommunicated = 1,
        OperationOfOwn = 2,
        OperationOfOther = 3,
        KickoutByUser = 4,
        KickoutBySystem = 5,
        InconsistentInfo = 6,
        MigrationFail = 7,
        ExternalFactor = 8,
        MigrationFatalError = 9,
    }

    public enum NetworkTopology : int
    {
        FullMesh = 0,
        RelayMesh = 1,
    }

    public enum SelectionMethod : int
    {
        Random = 0,
        BroadenRangeWithSelectionPriority = 1,
        ScoreBased = 2,
    }

    public enum SessionOpenStatus : int
    {
        Unknown = 0,
        Open = 1,
        Close = 2,
    }

    public class SessionEvent
    {
        public EventType eventType;
        public ulong constantId;
        public int stationIndex;
    }

    [Serializable]
    public class CreateSessionSetting
    {
        public uint setCondMask;
        private ushort participantNumMin;
        private ushort participantNumMax;
        private ushort gameMode;
        private List<Attribute> attributeList = new List<Attribute>();
        private byte[] applicationData = (byte[])Enumerable.Empty<byte>(); // This looks weird, but I do think that's what was done here
        private bool isOpenSession;
        private uint matchmakeSessionOption;
        private string countryCode = "";
        private uint ratingValue;
        private uint disconnectionRate;
        private uint violationRate;
        private bool isGeoIpUsed;
        private string wirelessCryptoKey;
        private ulong localCommunicationId;
        private string sessionUserPassword;
        private string matchmakeKeyword;
        private ushort localCommunicationChannel;

        // TODO
        public void SetParticipantNumMin(ushort participantNumMin) { }

        public ushort GetParticipantNumMin() {
            return participantNumMin;
        }

        // TODO
        public void SetParticipantNumMax(ushort participantNumMax) { }

        public ushort GetParticipantNumMax() {
            return participantNumMax;
        }

        // TODO
        public void SetGameMode(ushort gameMode) { }

        public ushort GetGameMode() {
            return gameMode;
        }

        // TODO
        public void SetApplicationData(byte[] applicationData) { }

        public byte[] GetApplicationData() {
            return applicationData;
        }

        // TODO
        public void SetOpenSession(bool isOpenSession) { }

        public bool IsOpenSession() {
            return isOpenSession;
        }

        // TODO
        public void SetMatchmakeSessionOption(uint matchmakeSessionOption) { }

        public uint GetMatchmakeSessionOption() {
            return matchmakeSessionOption;
        }

        // TODO
        public void SetCountryCode(string countryCode) { }

        public string GetCountryCode() {
            return countryCode;
        }

        // TODO
        public void SetRatingValue(uint ratingValue) { }

        public uint GetRatingValue() {
            return ratingValue;
        }

        // TODO
        public void SetDisconnectionRate(uint disconnectionRate) { }

        public uint GetDisconnectionRate() {
            return disconnectionRate;
        }

        // TODO
        public void SetViolationRate(uint violationRate) { }

        public uint GetViolationRate() {
            return violationRate;
        }

        // TODO
        public void SetUseGeoIp(bool isGeoIpUsed) { }

        public bool IsGeoIpUsed() {
            return isGeoIpUsed;
        }

        // TODO
        public void SetWirelessCryptoKey(string wirelessCryptoKey) { }

        public string GetWirelessCryptoKey() {
            return wirelessCryptoKey;
        }

        // TODO
        public PiaPlugin.Result SetAttributeList(List<Attribute> attributeList) { return default; }

        public List<Attribute> GetAttributeList() {
            return attributeList;
        }

        public void SetLocalCommunicationId(ulong localCommunicationId) {
            this.localCommunicationId = localCommunicationId;
        }

        public ulong GetLocalCommunicationId() {
            return localCommunicationId;
        }

        // TODO
        public PiaPlugin.Result SetSessionUserPassword(string userPassword) { return default; }

        public string GetSessionUserPassword() {
            return sessionUserPassword;
        }

        // TODO
        public PiaPlugin.Result SetSessionMatchmakeKeyword(string keyword) { return default; }

        public string GetSessionMatchmakeKeyword() {
            return matchmakeKeyword;
        }

        public void SetLocalCommunicationChannel(ushort localCommunicationChannel) {
            this.localCommunicationChannel = localCommunicationChannel;
        }

        public ushort GetLocalCommunicationChannel() {
            return localCommunicationChannel;
        }

        private enum CondMask : int
        {
            GameMode = 0,
            ParticipantNumMin = 1,
            ParticipantNumMax = 2,
            ApplicationData = 3,
            OpenSession = 4,
            MatchmakeSessionOption = 5,
            ScoreBasedSettingIndex = 6,
            ScoreBasedRatingValue = 7,
            ScoreBasedDisconnectionRate = 8,
            ScoreBasedViolationRate = 9,
            ScoreBasedCountryCode = 10,
            ScoreBasedGeoIp = 11,
            SessionUserPassword = 12,
            MatchmakeKeyword = 13,
            Attribute = 14,
            Max = 15,
        }

        [Serializable]
        public class Attribute
        {
            public uint index;
            public uint value;
        }
    }

    public class CreateSessionSettingNative : IDisposable
    {
        public uint setCondMask;
        public ushort participantNumMin;
        public ushort participantNumMax;
        public ushort gameMode;
        public IntPtr pAttributeArray;
        public int attributeNum;
        public IntPtr pApplicationData;
        public int applicationDataSize;
        public bool isOpenSession;
        public uint matchmakeSessionOption;
        public IntPtr pCountryCode;
        public uint ratingValue;
        private uint disconnectionRate;
        private uint violationRate;
        public bool isGeoIpUsed;
        public IntPtr pWirelessCryptoKey;
        private ulong localCommunicationId;
        public IntPtr pSessionUserPassword;
        private IntPtr pMmatchmakeKeyword;
        private ushort localCommunicationChannel;

        internal CreateSessionSettingNative()
        {
            pAttributeArray = IntPtr.Zero;
            attributeNum = 0;
            pApplicationData = IntPtr.Zero;
            isOpenSession = false;
            matchmakeSessionOption = 0;
            setCondMask = 0;
            participantNumMin = 0;
            participantNumMax = 0;
            gameMode = 0;
            localCommunicationChannel = 0;
            pCountryCode = IntPtr.Zero;
            ratingValue = 0;
            disconnectionRate = 0;
            violationRate = 0;
            isGeoIpUsed = false;
            pWirelessCryptoKey = IntPtr.Zero;
            localCommunicationId = 0;
            pSessionUserPassword = IntPtr.Zero;
            pMmatchmakeKeyword = IntPtr.Zero;
        }

        // TODO
        internal CreateSessionSettingNative(CreateSessionSetting setting) { }

        // TODO
        public void Dispose() { }
    }

    [Serializable]
    public class SessionSearchCriteria
    {
        public uint setCondMask;
        private ushort participantNumMin;
        private ushort participantNumMax;
        private bool isOpenedOnly;
        private bool isVacantOnly;
        private ushort gameMode;
        private List<Attribute> attributeList = new List<Attribute>();
        private List<AttributeRange> attributeRangeList = new List<AttributeRange>();
        public uint[] resultRange = new uint[2];
        private string countryCode = "";
        private uint ratingValue;
        private uint disconnectionRate;
        private uint violationRate;
        private bool isGeoIpUsed;
        private uint scoreSettingIndex;
        private SelectionMethod selectionMethod;
        private ulong localCommunicationId;
        private string matchmakeKeyword;
        private bool isExcludeUserPasswordSet;

        // TODO
        public void SetParticipantNumMin(ushort participantNumMin) { }

        public ushort GetParticipantNumMin() {
            return participantNumMin;
        }

        // TODO
        public void SetParticipantNumMax(ushort participantNumMax) { }

        public ushort GetParticipantNumMax() {
            return participantNumMax;
        }

        // TODO
        public void SetOpenedOnly(bool isOpenedOnly) { }

        public bool IsOpenedOnly() {
            return isOpenedOnly;
        }

        // TODO
        public void SetVacantOnly(bool isVacantOnly) { }

        public bool IsVacantOnly() {
            return isVacantOnly;
        }

        // TODO
        public void SetGameMode(ushort gameMode) { }

        public ushort GetGameMode() {
            return gameMode;
        }

        // TODO
        public void SetCountryCode(string countryCode) { }

        public string GetCountryCode() {
            return countryCode;
        }

        // TODO
        public void SetRatingValue(uint ratingValue) { }

        public uint GetRatingValue() {
            return ratingValue;
        }

        // TODO
        public void SetDisconnectionRate(uint disconnectionRate) { }

        public uint GetDisconnectionRate() {
            return disconnectionRate;
        }

        // TODO
        public void SetViolationRate(uint violationRate) { }

        public uint GetViolationRate() {
            return violationRate;
        }

        // TODO
        public void SetUseGeoIp(bool isGeoIpUsed) { }

        public bool IsGeoIpUsed() {
            return isGeoIpUsed;
        }

        // TODO
        public void SetScoreSettingIndex(uint scoreSettingIndex) { }

        public uint GetScoreSettingIndex() {
            return scoreSettingIndex;
        }

        // TODO
        public void SetSelectionMethod(SelectionMethod selectionMethod) { }

        public SelectionMethod GetSelectionMethod() {
            return selectionMethod;
        }

        // TODO
        public PiaPlugin.Result SetAttributeList(List<Attribute> attributeList) { return default; }

        public List<Attribute> GetAttributeList() {
            return attributeList;
        }

        // TODO
        public PiaPlugin.Result SetAttributeRangeList(List<AttributeRange> attributeRangeList) { return default; }

        public List<AttributeRange> GetAttributeRangeList() {
            return attributeRangeList;
        }

        public void SetLocalCommunicationId(ulong localCommunicationId) {
            this.localCommunicationId = localCommunicationId;
        }

        public ulong GetLocalCommunicationId() {
            return localCommunicationId;
        }

        // TODO
        public PiaPlugin.Result SetSessionMatchmakeKeyword(string keyword) { return default; }

        public string GetSessionMatchmakeKeyword() {
            return matchmakeKeyword;
        }

        // TODO
        public void SetExcludeUserPasswordSet(bool isExcludeUserPasswordSet) { }

        public bool IsExcludeUserPasswordSet() {
            return isExcludeUserPasswordSet;
        }

        private enum CondMask : int
        {
            ParticipantNumMin = 0,
            ParticipantNumMax = 1,
            OpenedOnly = 2,
            VacantOnly = 3,
            GameMode = 4,
            RandomSessionSelectionMethod = 5,
            ScoreBasedSettingIndex = 6,
            ScoreBasedRatingValue = 7,
            ScoreBasedDisconnectionRate = 8,
            ScoreBasedViolationRate = 9,
            ScoreBasedCountryCode = 10,
            ScoreBasedGeoIp = 11,
            ExcludeUserPasswordSet = 12,
            MatchmakeKeyword = 13,
            Attribute = 14,
            AttributeRange = 15,
            Max = 16,
        }

        [Serializable]
        public class Attribute
        {
            public uint index;
            public List<uint> valueList = new List<uint>();
        }

        [Serializable]
        public class AttributeRange
        {
            public uint index;
            public uint min;
            public uint max;
        }
    }

    public struct SessionSearchCriteriaNative : IDisposable
    {
        private uint setCondMask;
        public ushort participantNumMin;
        public ushort participantNumMax;
        public bool isOpenedOnly;
        public bool isVacantOnly;
        public ushort gameMode;
        public IntPtr pAttributeNativeArray;
        public int attributeNativeNum;
        public IntPtr pAttributeRangeArray;
        public int attributeRangeNum;
        public uint resultOffset;
        public uint resultSize;
        public IntPtr pCountryCode;
        public uint ratingValue;
        private uint disconnectionRate;
        private uint violationRate;
        public bool isGeoIpUsed;
        public uint scoreSettingIndex;
        public int selectionMethod;
        private ulong localCommunicationId;
        private IntPtr pMmatchmakeKeyword;
        public bool isExcludeUserPasswordSet;

        // TODO
        public void Reset() { }

        // TODO
        internal SessionSearchCriteriaNative(SessionSearchCriteria criteria)
        {
            setCondMask = 0;
            participantNumMin = 0;
            participantNumMax = 0;
            isOpenedOnly = false;
            isVacantOnly = false;
            gameMode = 0;
            pAttributeNativeArray = IntPtr.Zero;
            attributeNativeNum = 0;
            pAttributeRangeArray = IntPtr.Zero;
            attributeRangeNum = 0;
            resultOffset = 0;
            resultSize = 0;
            pCountryCode = IntPtr.Zero;
            ratingValue = 0;
            disconnectionRate = 0;
            violationRate = 0;
            isGeoIpUsed = false;
            scoreSettingIndex = 0;
            selectionMethod = 0;
            localCommunicationId = 0;
            pMmatchmakeKeyword = IntPtr.Zero;
            isExcludeUserPasswordSet = false;
        }

        // TODO
        public void Dispose() { }

        public class AttributeNative : IDisposable
        {
            public uint index;
            public IntPtr pValueArray;
            public int valueNum;

            public AttributeNative()
            {
                index = 0;
                pValueArray = IntPtr.Zero;
                valueNum = 0;
            }

            public AttributeNative(SessionSearchCriteria.Attribute attribute)
            {
                index = attribute.index;

                int size = 0;
                pValueArray = UnmanagedMemoryManager.WriteList(attribute.valueList, ref size);

                valueNum = attribute.valueList.Count;
            }

            // TODO
            public void Dispose() { }
        }
    }

    [Serializable]
    public class SessionSearchCriteriaOwner
    {
        private ulong ownerConstantId;
        public uint[] resultRange = new uint[2];

        public void SetOwnerConstantId(ulong ownerConstantId)
        {
            this.ownerConstantId = ownerConstantId;
        }

        public ulong GetOwnerConstantId()
        {
            return ownerConstantId;
        }
    }

    public class SessionSearchCriteriaOwnerNative : IDisposable
    {
        public ulong ownerConstantId;
        public uint resultOffset;
        public uint resultSize;

        internal SessionSearchCriteriaOwnerNative()
        {
            ownerConstantId = 0;
            resultOffset = 0;
            resultSize = 0;
        }

        internal SessionSearchCriteriaOwnerNative(SessionSearchCriteriaOwner criteria)
        {
            ownerConstantId = criteria.GetOwnerConstantId();
            resultOffset = criteria.resultRange[0];
            resultSize = criteria.resultRange[1];
        }

        // TODO
        public void Dispose() { }
    }

    [Serializable]
    public class SessionSearchCriteriaParticipant
    {
        public List<ulong> participantConstantIdList = new List<ulong>();
        public bool isApplicationDataEnabled;
    }

    public class SessionSearchCriteriaParticipantNative : IDisposable
    {
        public IntPtr pConstantIdList;
        public int constantIdNum;
        public bool isApplicationDataEnabled;

        internal SessionSearchCriteriaParticipantNative()
        {
            pConstantIdList = IntPtr.Zero;
            constantIdNum = 0;
            isApplicationDataEnabled = false;
        }

        internal SessionSearchCriteriaParticipantNative(SessionSearchCriteriaParticipant criteria)
        {
            constantIdNum = criteria.participantConstantIdList.Count;

            int size = 0;
            pConstantIdList = UnmanagedMemoryManager.WriteList(criteria.participantConstantIdList, ref size);

            isApplicationDataEnabled = criteria.isApplicationDataEnabled;
        }

        // TODO
        public void Dispose() { }
    }

    public class SessionSearchCriteriaSessionId
    {
        public uint[] sessionIdArray;
    }

    public struct SessionSearchCriteriaSessionIdNative : IDisposable
    {
        private IntPtr pSessionIdArray;
        private uint sessionIdArraySize;

        internal SessionSearchCriteriaSessionIdNative(SessionSearchCriteriaSessionId criteria)
        {
            int size = 0;
            pSessionIdArray = UnmanagedMemoryManager.WriteArray(criteria.sessionIdArray, ref size);
            sessionIdArraySize = (uint)criteria.sessionIdArray.Length;
        }

        // TODO
        public void Dispose() { }
    }

    public class StationInfo
    {
        public ulong constantId { get; private set; }
        public int stationIndex { get; private set; }
        public ushort playerNum { get; private set; }
        public List<PiaPlugin.PlayerInfo> playerInfoList { get; private set; }
        public int rtt { get; private set; }
        public float unicastPacketLossRate { get; private set; }
        public float broadcastPacketLossRate { get; private set; }

        public StationInfo()
        {
            playerInfoList = null;
            constantId = 0;
            stationIndex = 0;
            playerNum = 0;
            rtt = 0;
            unicastPacketLossRate = 0.0f;
            broadcastPacketLossRate = 0.0f;
        }

        // TODO
        internal StationInfo(StationInfoNative stationInfoNative) { }
    }

    internal struct StationInfoNative : IDisposable
    {
        public ulong constantId { get; private set; }
        public int stationIndex { get; private set; }
        public ushort playerNum { get; private set; }
        public IntPtr pStationInfoArray { get; private set; }
        public int rtt { get; private set; }
        public float unicastPacketLossRate { get; private set; }
        public float broadcastPacketLossRate { get; private set; }

        // TODO
        public void Dispose() { }
    }

    public class SessionStatus
    {
        public uint sessionId { get; private set; }
        public ushort stationNum { get; private set; }
        public ushort playerNum { get; private set; }
        public ushort matchmakeSessionStationNum { get; private set; }
        public ushort matchmakeSessionParticipantNum { get; private set; }
        public ulong hostConstantId { get; private set; }
        public ulong localConstantId { get; private set; }
        public uint jointSessionId { get; private set; }
        public ulong jointSessionHostConstantId { get; private set; }
        public List<StationInfo> stationInfoList { get; private set; }
        public Status status { get; private set; }
        public DisconnectReason disconnectReason { get; private set; }

        public SessionStatus()
        {
            stationInfoList = null;
            matchmakeSessionStationNum = 0;
            matchmakeSessionParticipantNum = 0;
            sessionId = 0;
            stationNum = 0;
            playerNum = 0;
            jointSessionId = 0;
            jointSessionHostConstantId = 0;
            hostConstantId = 0;
            localConstantId = 0;
            status = Status.NotConnected;
            disconnectReason = DisconnectReason.ExternalFactor;
        }

        // TODO
        internal SessionStatus(SessionStatusNative sessionNative) { }
    }

    internal struct SessionStatusNative : IDisposable
    {
        public uint sessionId { get; private set; }
        public ushort stationNum { get; private set; }
        public ushort playerNum { get; private set; }
        public ushort matchmakeSessionStationNum { get; private set; }
        public ushort matchmakeSessionParticipantNum { get; private set; }
        public ulong hostConstantId { get; private set; }
        public ulong localConstantId { get; private set; }
        public uint jointSessionId { get; private set; }
        public ulong jointSessionHostConstantId { get; private set; }
        public IntPtr pStationInfoList { get; private set; }
        public Status status { get; private set; }
        public DisconnectReason disconnectReason { get; private set; }

        internal SessionStatusNative(SessionStatus sessionStatus)
        {
            sessionId = sessionStatus.sessionId;
            stationNum = sessionStatus.stationNum;
            playerNum = sessionStatus.playerNum;
            matchmakeSessionStationNum = sessionStatus.matchmakeSessionStationNum;
            matchmakeSessionParticipantNum = sessionStatus.matchmakeSessionParticipantNum;
            hostConstantId = sessionStatus.hostConstantId;
            localConstantId = sessionStatus.localConstantId;
            jointSessionId = sessionStatus.jointSessionId;
            jointSessionHostConstantId = sessionStatus.jointSessionHostConstantId;
            pStationInfoList = IntPtr.Zero;

            if (sessionStatus.stationInfoList != null)
            {
                int size = 0;
                pStationInfoList = UnmanagedMemoryManager.WriteList(sessionStatus.stationInfoList, ref size);
            }

            status = sessionStatus.status;
            disconnectReason = sessionStatus.disconnectReason;
        }

        // TODO
        public void Dispose() { }
    }

    public class JoinSessionSetting
    {
        public uint selectJoinSessionNum;
        public uint sessionId;
        public string wirelessCryptoKey;
        public string sessionUserPassword;
    }

    internal class JoinSessionSettingNative : IDisposable
    {
        public uint selectJoinSessionNum;
        public uint sessionId;
        public IntPtr pWirelessCryptoKey;
        public IntPtr pSessionUserPassword;

        internal JoinSessionSettingNative(JoinSessionSetting setting)
        {
            selectJoinSessionNum = setting.selectJoinSessionNum;
            sessionId = setting.sessionId;

            if (setting.wirelessCryptoKey != null)
            {
                int size = 0;
                pWirelessCryptoKey = UnmanagedMemoryManager.WriteUtf8(setting.wirelessCryptoKey, ref size);
            }

            if (setting.sessionUserPassword != null)
            {
                int size = 0;
                pSessionUserPassword = UnmanagedMemoryManager.WriteUtf8(setting.sessionUserPassword, ref size);
            }
        }

        // TODO
        public void Dispose() { }
    }

    public class UpdateSessionSetting
    {
        public uint setCondMask;
        private byte[] applicationData = (byte[])Enumerable.Empty<byte>(); // This looks weird, but I do think that's what was done here
        private int applicationDataSize;
        public byte priority;
        private ushort participantNumMin;
        private ushort participantNumMax;
        private List<Attribute> attributeList = new List<Attribute>();
        private string countryCode = "";
        private uint ratingValue;
        private uint disconnectionRate;
        private uint violationRate;
        private bool isUpdateGeoIp;
        private PiaPlugin.DateTime startedTime;
        private string sessionUserPassword = "";
        private string matchmakeKeyword;

        // TODO
        public void SetApplicationData(byte[] applicationData, int applicationDataSize) { }

        public byte[] GetApplicationData() {
            return applicationData;
        }

        public int GetApplicationDataSize() {
            return applicationDataSize;
        }

        // TODO
        public void SetSelectionPriority(byte selectionPriority) { }

        public byte GetSelectionPriority() {
            return priority;
        }

        // TODO
        public void SetParticipantNumMin(ushort participantNumMin) { }

        public ushort GetParticipantNumMin() {
            return participantNumMin;
        }

        // TODO
        public void SetParticipantNumMax(ushort participantNumMax) { }

        public ushort GetParticipantNumMax() {
            return participantNumMax;
        }

        // TODO
        public void SetCountryCode(string countryCode) { }

        public string GetCountryCode() {
            return countryCode;
        }

        // TODO
        public void SetRatingValue(uint ratingValue) { }

        public uint GetRatingValue() {
            return ratingValue;
        }

        // TODO
        public void SetDisconnectionRate(uint disconnectionRate) { }

        public uint GetDisconnectionRate() {
            return disconnectionRate;
        }

        // TODO
        public void SetViolationRate(uint violationRate) { }

        public uint GetViolationRate() {
            return violationRate;
        }

        // TODO
        public void SetUpdateGeoIp(bool isUpdateGeoIp) { }

        public bool IsUpdateGeoIp() {
            return isUpdateGeoIp;
        }

        // TODO
        public PiaPlugin.Result SetAttributeList(List<Attribute> attributeList) { return default; }

        public List<Attribute> GetAttributeList() {
            return attributeList;
        }

        // TODO
        public PiaPlugin.Result SetSessionUserPassword(string userPassword) { return default; }

        public string GetSessionUserPassword() {
            return sessionUserPassword;
        }

        // TODO
        public PiaPlugin.Result SetSessionMatchmakeKeyword(string keyword) { return default; }

        public string GetSessionMatchmakeKeyword() {
            return matchmakeKeyword;
        }

        // TODO
        public PiaPlugin.Result SetStartedTime(PiaPlugin.DateTime dateTime) { return default; }

        // TODO
        public PiaPlugin.DateTime GetStartedTime() { return default; }

        private enum CondMask : int
        {
            ApplicationData = 0,
            SelectionPriority = 1,
            ParticipantNumMin = 2,
            ParticipantNumMax = 3,
            ScoreBasedRatingValue = 4,
            ScoreBasedDisconnectionRate = 5,
            ScoreBasedViolationRate = 6,
            ScoreBasedCountryCode = 7,
            ScoreBasedUpdateGeoIp = 8,
            MatchmakeKeyword = 9,
            Attribute = 10,
            Max = 11,
        }

        [Serializable]
        public class Attribute
        {
            public uint index;
            public uint value;
        }
    }

    internal class UpdateSessionSettingNative : IDisposable
    {
        public uint setCondMask;
        public IntPtr pApplicationData;
        public int applicationDataSize;
        public byte priority;
        public ushort participantNumMin;
        public ushort participantNumMax;
        public IntPtr pAttributeArray;
        public int attributeNum;
        public uint ratingValue;
        public uint disconnectionRate;
        public uint violationRate;
        public IntPtr pCountryCode;
        public bool isUpdateGeoIp;
        public IntPtr pSessionUserPassword;
        private IntPtr pMmatchmakeKeyword;

        internal UpdateSessionSettingNative()
        {
            setCondMask = 0;
            pApplicationData = IntPtr.Zero;
            participantNumMin = 0;
            participantNumMax = 0;
            isUpdateGeoIp = false;
            pAttributeArray = IntPtr.Zero;
            attributeNum = 0;
            ratingValue = 0;
            disconnectionRate = 0;
            violationRate = 0;
            pCountryCode = IntPtr.Zero;
            pSessionUserPassword = IntPtr.Zero;
            pMmatchmakeKeyword = IntPtr.Zero;
        }

        // TODO
        internal UpdateSessionSettingNative(UpdateSessionSetting setting) { }

        // TODO
        public void Dispose() { }
    }

    public class SessionProperty
    {
        public ushort gameMode;
        public uint sessionId;
        public ushort currentParticipantNum;
        public ushort participantNumMin;
        public ushort participantNumMax;
        public bool isOpened;
        public bool isRestrictedByUserPassword;
        public byte[] applicationData;
        public uint applicationDataSize;
        public ulong targetConstantId;

        public SessionProperty()
        {
            gameMode = 0;
            sessionId = 0;
            currentParticipantNum = 0;
            participantNumMin = 0;
            participantNumMax = 0;
            isOpened = true;
            isRestrictedByUserPassword = true;
            applicationData = new byte[ApplicationDataSystemBufferSizeMax];
            applicationDataSize = 0;
        }

        internal SessionProperty(SessionPropertyNative sessionPropertyNative)
        {
            gameMode = sessionPropertyNative.gameMode;
            sessionId = sessionPropertyNative.sessionId;
            currentParticipantNum = sessionPropertyNative.currentParticipantNum;
            participantNumMin = sessionPropertyNative.participantNumMin;
            participantNumMax = sessionPropertyNative.participantNumMax;
            isOpened = sessionPropertyNative.isOpened;
            isRestrictedByUserPassword = sessionPropertyNative.isRestrictedByUserPassword;
            applicationDataSize = sessionPropertyNative.applicationDataSize;
            applicationData = new byte[ApplicationDataSystemBufferSizeMax];

            if (applicationDataSize != 0)
                Array.Copy(sessionPropertyNative.applicationData, 0, applicationData, 0, applicationDataSize);

            targetConstantId = sessionPropertyNative.targetConstantId;
        }
    }

    internal struct SessionPropertyNative : IDisposable
    {
        public ushort gameMode;
        public uint sessionId;
        public ushort currentParticipantNum;
        public ushort participantNumMin;
        public ushort participantNumMax;
        public bool isOpened;
        public bool isRestrictedByUserPassword;
        public byte[] applicationData;
        public uint applicationDataSize;
        public ulong targetConstantId;

        // TODO
        public void Dispose() { }
    }
}