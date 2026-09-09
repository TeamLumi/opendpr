using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class Balloon
{
    public bool isBusy;
    public int Index;
    public float Time;
    public int type;
    public Transform Target;
    public RectTransform ParentRectTra;
    public GameObject parent;
    public RectTransform MyRectTra;
    public GameObject gameObject;
    public Image BlnImg;
    public Image MarkImg;
    public Image HostImgLeft;
    public Image HostImgRight;
    private UnionHostEmoticonController hostController;
    private int spriteIndex;
    private int spriteIndexMaxCount;
    public SpriteAtlas ballonAtlas;
    public float changeSpriteFlameCount;
    private int updateFrame;
    private List<Tween> tweens;
    private static readonly string[] IconName = new string[30]
    {
        "fld_txt_exclamation_01", "fld_txt_exclamation_02", "fld_txt_heart_01",
        "fld_txt_note_02",        "fld_txt_note_03",        "fld_txt_notice_01",
        "fld_txt_panic_01",       "fld_txt_question_01",    "fld_txt_sad_01",
        "fld_txt_silent_anim_01", "fld_txt_sleepy_anim_01", "fld_txt_sparkle_anim_01",
        "fld_txt_stress_anim_01", "fld_txt_note_02",        "fld_txt_note_03",
        "fld_txt_battle_01",      "fld_txt_switch_01",      "fld_txt_switch_02",
        "fld_txt_deco_01",        "fld_txt_circle_01",      "fld_txt_cross_01",
        "fld_txt_greet_01",       "fld_txt_local_01",       "fld_txt_net_01",
        "fld_txt_pickel_01",      "fld_txt_get_01",         "fld_txt_exit_01",
        "fld_txt_together_01",    "fld_txt_likes_01",       "fld_txt_exclamation_03",
    };
    private static readonly string[] FukidashiName = new string[5]
    {
        "fld_wd_balloon_01", "fld_wd_balloon_01", "fld_wd_balloon_02", "fld_wd_balloon_03", "fld_wd_balloon_04",
    };
    private readonly string[] UNION_HOST_ICON_NAME = new string[4]
    {
        "fld_txt_notice_02_0", "fld_txt_notice_02_1", "fld_txt_notice_02_2", "fld_txt_notice_02_3",
    };
    private Sprite[] CacheUnionHostIconNotice = new Sprite[4];
    private Color fukidasiImgColorWhite = new Color(1.0f, 1.0f, 1.0f);
    private Color fukidasiImgColorYellow = new Color(1.0f, 0.85f, 0.0f);
    private static readonly Vector3[] path = new Vector3[3]
    {
        Vector3.up * 60.0f + Vector3.right * 30.0f,
        Vector3.up * 30.0f + Vector3.right * 60.0f,
        Vector3.up * 80.0f + Vector3.right * 100.0f,
    };

    // TODO
    public void PlayAnimation(int type, SpriteAtlas atlas) { }

    // TODO
    public Tweener Fade(float alpha, float duration) { return null; }

    // TODO
    private Sprite GetMultipleSprite(SpriteAtlas atlas, int index) { return null; }

    // TODO
    private void SetFukidashiImg(SpriteAtlas atlas, int balloonType) { }

    // TODO
    public void SetFukidasiImgColorWhite() { }

    // TODO
    public void SetFukidasiImgColorYellow() { }

    // TODO
    public void StopHostEmoAnimation() { }

    public void SetSpriteIndexMaxCount(int count) {
        spriteIndexMaxCount = count;
    }

    // TODO
    public void AddSpriteIndex() { }

    // TODO
    public void SetHostImgIcon(SpriteAtlas atlas) { }

    // TODO
    public Tween Exclamation() { return null; }

    // TODO
    public Tween ExclamationDouble() { return null; }

    // TODO
    public Tween Heart() { return null; }

    // TODO
    public Tween MusicalNote() { return null; }

    // TODO
    public Tween MusicalNoteDouble() { return null; }

    // TODO
    public Tween Notice() { return null; }

    // TODO
    public Tween Panic() { return null; }

    // TODO
    public Tween Question() { return null; }

    // TODO
    public Tween Sad() { return null; }

    // TODO
    public Tween Silent(SpriteAtlas atlas) { return null; }

    // TODO
    public Tween Sleepy(SpriteAtlas atlas) { return null; }

    // TODO
    public Tween Sparkle(SpriteAtlas atlas) { return null; }

    // TODO
    public Tween Stress(SpriteAtlas atlas) { return null; }

    // TODO
    public Tween Kutibue(SpriteAtlas atlas) { return null; }
}