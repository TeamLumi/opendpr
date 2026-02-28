using Dpr.SubContents;
using UnityEngine;

namespace Dpr.FureaiHiroba
{
    public class Emoticon : MonoBehaviour
    {
        private Balloon bln;
        private static readonly uint[] SELabels = new uint[30]
        {
            AK.EVENTS.UI_EMOTIONAL_EXCLAMATION, AK.EVENTS.UI_EMOTIONAL_EXCLAMATION2,
            AK.EVENTS.UI_EMOTIONAL_HEART,       AK.EVENTS.UI_EMOTIONAL_HAPPY,
            AK.EVENTS.UI_EMOTIONAL_HAPPY,       AK.EVENTS.UI_EMOTIONAL_NOMAL,
            AK.EVENTS.UI_EMOTIONAL_SWEAT,       AK.EVENTS.UI_EMOTIONAL_Q,
            AK.EVENTS.UI_EMOTIONAL_DEPRESSED,   AK.EVENTS.UI_EMOTIONAL_THINKING,
            AK.EVENTS.UI_EMOTIONAL_SLEEP,       AK.EVENTS.UI_EMOTIONAL_VERYHAPPY,
            AK.EVENTS.UI_EMOTIONAL_CONFUSE,     AK.EVENTS.UI_EMOTIONAL_UR,
            AK.EVENTS.UI_EMOTIONAL_UR,          AK.EVENTS.UI_EMOTIONAL_UR,
            AK.EVENTS.UI_EMOTIONAL_UR,          AK.EVENTS.UI_EMOTIONAL_UR,
            AK.EVENTS.UI_EMOTIONAL_UR,          AK.EVENTS.UI_EMOTIONAL_UR,
            AK.EVENTS.UI_EMOTIONAL_UR,          AK.EVENTS.UI_EMOTIONAL_UR,
            AK.EVENTS.UI_EMOTIONAL_UR,          AK.EVENTS.UI_EMOTIONAL_UR,
            AK.EVENTS.UI_EMOTIONAL_UR,          AK.EVENTS.UI_EMOTIONAL_UR,
            AK.EVENTS.UI_EMOTIONAL_UR,          AK.EVENTS.UI_EMOTIONAL_UR,
            AK.EVENTS.UI_EMOTIONAL_UR,          AK.EVENTS.UI_EMOTIONAL_UR,
        };
        [Button("TestBaloon", "!", new object[1] { 0 })]
        public int Button10;
        [Button("TestBaloon", "!!", new object[1] { 1 })]
        public int Button11;
        [Button("TestBaloon", "♥", new object[1] { 2 })]
        public int Button12;
        [Button("TestBaloon", "♪", new object[1] { 3 })]
        public int Button13;
        [Button("TestBaloon", "♬", new object[1] { 4 })]
        public int Button14;
        [Button("TestBaloon", "〃", new object[1] { 5 })]
        public int Button15;
        [Button("TestBaloon", "汗", new object[1] { 6 })]
        public int Button16;
        [Button("TestBaloon", "？", new object[1] { 7 })]
        public int Button17;
        [Button("TestBaloon", "川", new object[1] { 8 })]
        public int Button18;
        [Button("TestBaloon", "･･･", new object[1] { 9 })]
        public int Button19;
        [Button("TestBaloon", "zzz", new object[1] { 10 })]
        public int Button20;
        [Button("TestBaloon", "˖✧", new object[1] { 11 })]
        public int Button21;
        [Button("TestBaloon", "§", new object[1] { 12 })]
        public int Button22;
        [Button("TestBaloon", "Kutibue Kaisan", new object[1] { 13 })]
        public int Button23;
        [Button("TestBaloon", "Kutibue Syuugou", new object[1] { 14 })]
        public int Button24;
        [Button("TestBaloon", "Battle", new object[1] { 15 })]
        public int Button25;
        [Button("TestBaloon", "Trade", new object[1] { 16 })]
        public int Button26;
        [Button("TestBaloon", "Record", new object[1] { 17 })]
        public int Button27;
        [Button("TestBaloon", "Deco", new object[1] { 18 })]
        public int Button28;
        [Button("TestBaloon", "〇", new object[1] { 19 })]
        public int Button29;
        [Button("TestBaloon", "×", new object[1] { 20 })]
        public int Button30;
        [Button("TestBaloon", "TrainerCard", new object[1] { 21 })]
        public int Button31;
        [Button("TestBaloon", "Local", new object[1] { 22 })]
        public int Button32;
        [Button("TestBaloon", "Grobal", new object[1] { 23 })]
        public int Button33;
        [Button("TestBaloon", "Pickel", new object[1] { 24 })]
        public int Button34;
        [Button("TestBaloon", "Get", new object[1] { 25 })]
        public int Button35;
        [Button("TestBaloon", "Exit", new object[1] { 26 })]
        public int Button36;
        [Button("TestBaloon", "TOGETHER", new object[1] { 27 })]
        public int Button37;
        [Button("TestBaloon", "LIKES", new object[1] { 28 })]
        public int Button38;
        [Button("TestBaloon", "EXXLAMATION", new object[1] { 29 })]
        public int Button39;
        [Button("PlaySeAmbient", "PlaySe 0", new object[1] { 0 })]
        public int Button40;
        [Button("PlaySeAmbient", "PlaySe 1", new object[1] { 1 })]
        public int Button41;
        [Button("PlaySeAmbient", "PlaySe 2", new object[1] { 2 })]
        public int Button42;
        [Button("PlaySeAmbient", "PlaySe 3", new object[1] { 3 })]
        public int Button43;
        [Button("PlaySeAmbient", "PlaySe 4", new object[1] { 4 })]
        public int Button44;
        [Button("PlaySeAmbient", "PlaySe 5", new object[1] { 5 })]
        public int Button45;
        [Button("PlaySeAmbient", "PlaySe 6", new object[1] { 6 })]
        public int Button46;
        [Button("PlaySeAmbient", "PlaySe 7", new object[1] { 7 })]
        public int Button47;
        [Button("PlaySeAmbient", "PlaySe 8", new object[1] { 8 })]
        public int Button48;
        [Button("PlaySeAmbient", "PlaySe 9", new object[1] { 9 })]
        public int Button49;
        [Button("PlaySeAmbient", "PlaySe 10", new object[1] { 10 })]
        public int Button50;
        [Button("PlaySeAmbient", "PlaySe 11", new object[1] { 11 })]
        public int Button51;
        [Button("PlaySeAmbient", "PlaySe 12", new object[1] { 12 })]
        public int Button52;

        public bool IsVisible { get => bln != null && bln.gameObject.activeInHierarchy; }

        // TODO
        public void SetParent(Transform t) { }

        // TODO
        public void Enter(int type = 0, bool UseSE = false) { }

        // TODO
        public Balloon Show(int type, bool useSE = true) { return null; }

        // TODO
        public void SetHostEmoIcon(Balloon balloon) { }

        // TODO
        public void StopHostEmoticon(Balloon balloon) { }

        // TODO
        public void Delete(Balloon balloon) { }

        // TODO
        public void Delete() { }

        // TODO
        public void TestBaloon(int type) { }

        private void OnDestroy()
        {
        	this.bln = null;
        }

        // TODO
        public static void PlaySeByEvent(int type) { }

        // TODO
        public void PlaySeAmbient(int type) { }

        // TODO
        public void PlaySeDirect(uint audioEventId) { }
    }
}