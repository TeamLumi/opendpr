using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Text;
using UnityEngine;

namespace INL1
{
    public class IlcaNetServerValidate : IlcaNetServer
    {
        private const int PokeCoreSize = 328;
        public const string DefaultPublicKeyBASE64 = "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAyfdgDoOQrnwDynmAWJuFzKHAy6na8v8jHtMkFXcGoM3ogRL07Bh+BSWOroOwpXrCkIlvEYCVA0gX4zis0wrwhRhavBtWCvPJCJTXpjxrMpssj2Tk1/23bPHnT+yOv1eBuuwCrHNgUVUeQ1WlV6RtlCPrKRFbtprMQQ5HPVTCK4m9iNXKPk5k6xZdGi9mYkz5BboqFH9RnZwrNStWXZlwMNOUheZy9gtf+U7mszwXTNSRc+j4nY06qd9Xm7cX1s+PWGffJWZroBUsXHNWzarNI8mIeieOyS5N0PI6AmQBpOR7BSzjTMCHT8Tw+5rjiRfGjguDJ5h97xMOkmfb1MSh/QIDAQAB";

        private static ushort nowPublicKeyVersion;
        private static byte[] nowPublicKeyBASE64;
        private static byte[] nowPublicKeyBASE64Decode;
        private static CheckResponse cres;
        private static PublicKeyResponse pkres = new PublicKeyResponse();
        private static MonoBehaviour s_callobj;
        private static CheckRequest s_cReq;
        private static IlcaNetServerAsyncCallback s_usercallback;
        private static volatile bool next;
        private static volatile bool abort;
        private static byte[] data;
        private static byte[] checkDataForVerifySignature;
        private static byte[] buffValidate;

        public const uint SignatureSize = 256;
        public const uint PublicKeySizeBASE64 = 392;

        static IlcaNetServerValidate()
        {
            pkres.PublicKeyVersion = 0;
            pkres.PublicKeyValueBASE64 = Encoding.UTF8.GetBytes(DefaultPublicKeyBASE64);
        }

        // TODO
        public static void Init([Optional][DefaultParameterValue((ushort)0)] ushort publicKeyversion, [Optional] byte[] publicKey) { }

        // TODO
        public static bool PublicKeyResponseGet(ref PublicKeyResponse pkr) { return default; }

        // TODO
        public static bool CheckResponseGet(ref CheckResponse cr) { return default; }

        // TODO
        public static bool CheckRequestAutoAsync(MonoBehaviour callobj, CheckRequest creq, IlcaNetServerAsyncCallback callback) { return default; }

        // TODO
        private static void PublicKeySet(ushort ver, byte[] pk) { }

        // TODO
        private static void CheckRequestAutoCallback(bool isSuccess, IlcaNetServerCallbackEventType eve, IlcaNetServerCallbackResult result, long responseCode, string responseStr) { }

        // TODO
        private static bool CheckRequestAsync(MonoBehaviour callobj, CheckRequest cr, IlcaNetServerAsyncCallback callback) { return default; }

        // TODO
        private static void CallbackNSAIDT(bool isSuccess, IlcaNetServerCallbackEventType eve, IlcaNetServerCallbackResult result, long responseCode, string responseStr) { }

        // TODO
        private static void NextAbort(bool isSuccess) { }

        // TODO
        private static IEnumerator CheckRequestAsyncCore(MonoBehaviour callobj, CheckRequest cr, IlcaNetServerAsyncCallback callback) { return default; }

        // TODO
        private static bool PublicKeyRequestAsync(MonoBehaviour callobj, IlcaNetServerAsyncCallback callback) { return default; }

        // TODO
        private static IEnumerator PublicKeyRequestAsyncCore(MonoBehaviour callobj, IlcaNetServerAsyncCallback callback) { return default; }

        // TODO
        public static bool CheckVerifySignatureAdd4byte(byte[] coreDataAdd4byte, byte[] signature) { return default; }

        // TODO
        private static bool CheckVerifySignature(CheckRequest creq, byte[] signature) { return default; }

        // TODO
        public static ref byte[] CheckDataMakeAndSet(CheckRequest creq) { return ref data; }

        [Serializable]
        public class CheckRequest
        {
            public string NsaIdToken;
            public ushort PublicKeyVersion;
            public ushort ROMVersion;
            public ushort GameMode;
            public ushort DataNum;
            public byte[] Data;
            public bool patch;

            // TODO
            public static string Serialize(CheckRequest data) { return default; }

            // TODO
            public static ref byte[] SerializeBinary(CheckRequest data) { return ref IlcaNetServerValidate.data; }
        }

        [Serializable]
        public class CheckResponse
        {
            public byte success;
            public ushort ROMVersion;
            public ushort GameMode;
            public ushort DataNum;
            public uint[] DataResult;
            public byte[] Signature;

            // TODO
            public static CheckResponse Deserialize(string json) { return default; }

            // TODO
            public static CheckResponse DeserializeBinary(byte[] data) { return default; }
        }

        [Serializable]
        public class PublicKeyRequest
        {
            public string NsaIdToken;

            // TODO
            public static string Serialize(PublicKeyRequest data) { return default; }

            // TODO
            public static ref byte[] SerializeBinary(PublicKeyRequest data) { return ref IlcaNetServerValidate.data; }
        }

        [Serializable]
        public class PublicKeyResponse
        {
            public ushort PublicKeyVersion;
            public byte[] PublicKeyValueBASE64;

            // TODO
            public static PublicKeyResponse Deserialize(string json) { return default; }

            // TODO
            public static PublicKeyResponse DeserializeBinary(byte[] data) { return default; }
        }
    }
}