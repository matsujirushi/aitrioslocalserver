// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

namespace SmartCamera
{

using global::System;
using global::System.Collections.Generic;
using global::Google.FlatBuffers;

public struct GeneralObject : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static void ValidateVersion() { FlatBufferConstants.FLATBUFFERS_25_1_24(); }
  public static GeneralObject GetRootAsGeneralObject(ByteBuffer _bb) { return GetRootAsGeneralObject(_bb, new GeneralObject()); }
  public static GeneralObject GetRootAsGeneralObject(ByteBuffer _bb, GeneralObject obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p = new Table(_i, _bb); }
  public GeneralObject __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public uint ClassId { get { int o = __p.__offset(4); return o != 0 ? __p.bb.GetUint(o + __p.bb_pos) : (uint)0; } }
  public SmartCamera.BoundingBox BoundingBoxType { get { int o = __p.__offset(6); return o != 0 ? (SmartCamera.BoundingBox)__p.bb.Get(o + __p.bb_pos) : SmartCamera.BoundingBox.NONE; } }
  public TTable? BoundingBox<TTable>() where TTable : struct, IFlatbufferObject { int o = __p.__offset(8); return o != 0 ? (TTable?)__p.__union<TTable>(o + __p.bb_pos) : null; }
  public SmartCamera.BoundingBox2d BoundingBoxAsBoundingBox2d() { return BoundingBox<SmartCamera.BoundingBox2d>().Value; }
  public float Score { get { int o = __p.__offset(10); return o != 0 ? __p.bb.GetFloat(o + __p.bb_pos) : (float)0.0f; } }

  public static Offset<SmartCamera.GeneralObject> CreateGeneralObject(FlatBufferBuilder builder,
      uint class_id = 0,
      SmartCamera.BoundingBox bounding_box_type = SmartCamera.BoundingBox.NONE,
      int bounding_boxOffset = 0,
      float score = 0.0f) {
    builder.StartTable(4);
    GeneralObject.AddScore(builder, score);
    GeneralObject.AddBoundingBox(builder, bounding_boxOffset);
    GeneralObject.AddClassId(builder, class_id);
    GeneralObject.AddBoundingBoxType(builder, bounding_box_type);
    return GeneralObject.EndGeneralObject(builder);
  }

  public static void StartGeneralObject(FlatBufferBuilder builder) { builder.StartTable(4); }
  public static void AddClassId(FlatBufferBuilder builder, uint classId) { builder.AddUint(0, classId, 0); }
  public static void AddBoundingBoxType(FlatBufferBuilder builder, SmartCamera.BoundingBox boundingBoxType) { builder.AddByte(1, (byte)boundingBoxType, 0); }
  public static void AddBoundingBox(FlatBufferBuilder builder, int boundingBoxOffset) { builder.AddOffset(2, boundingBoxOffset, 0); }
  public static void AddScore(FlatBufferBuilder builder, float score) { builder.AddFloat(3, score, 0.0f); }
  public static Offset<SmartCamera.GeneralObject> EndGeneralObject(FlatBufferBuilder builder) {
    int o = builder.EndTable();
    return new Offset<SmartCamera.GeneralObject>(o);
  }
  public GeneralObjectT UnPack() {
    var _o = new GeneralObjectT();
    this.UnPackTo(_o);
    return _o;
  }
  public void UnPackTo(GeneralObjectT _o) {
    _o.ClassId = this.ClassId;
    _o.BoundingBox = new SmartCamera.BoundingBoxUnion();
    _o.BoundingBox.Type = this.BoundingBoxType;
    switch (this.BoundingBoxType) {
      default: break;
      case SmartCamera.BoundingBox.BoundingBox2d:
        _o.BoundingBox.Value = this.BoundingBox<SmartCamera.BoundingBox2d>().HasValue ? this.BoundingBox<SmartCamera.BoundingBox2d>().Value.UnPack() : null;
        break;
    }
    _o.Score = this.Score;
  }
  public static Offset<SmartCamera.GeneralObject> Pack(FlatBufferBuilder builder, GeneralObjectT _o) {
    if (_o == null) return default(Offset<SmartCamera.GeneralObject>);
    var _bounding_box_type = _o.BoundingBox == null ? SmartCamera.BoundingBox.NONE : _o.BoundingBox.Type;
    var _bounding_box = _o.BoundingBox == null ? 0 : SmartCamera.BoundingBoxUnion.Pack(builder, _o.BoundingBox);
    return CreateGeneralObject(
      builder,
      _o.ClassId,
      _bounding_box_type,
      _bounding_box,
      _o.Score);
  }
}

public class GeneralObjectT
{
  [Newtonsoft.Json.JsonProperty("class_id")]
  public uint ClassId { get; set; }
  [Newtonsoft.Json.JsonProperty("bounding_box_type")]
  private SmartCamera.BoundingBox BoundingBoxType {
    get {
      return this.BoundingBox != null ? this.BoundingBox.Type : SmartCamera.BoundingBox.NONE;
    }
    set {
      this.BoundingBox = new SmartCamera.BoundingBoxUnion();
      this.BoundingBox.Type = value;
    }
  }
  [Newtonsoft.Json.JsonProperty("bounding_box")]
  [Newtonsoft.Json.JsonConverter(typeof(SmartCamera.BoundingBoxUnion_JsonConverter))]
  public SmartCamera.BoundingBoxUnion BoundingBox { get; set; }
  [Newtonsoft.Json.JsonProperty("score")]
  public float Score { get; set; }

  public GeneralObjectT() {
    this.ClassId = 0;
    this.BoundingBox = null;
    this.Score = 0.0f;
  }
}


static public class GeneralObjectVerify
{
  static public bool Verify(Google.FlatBuffers.Verifier verifier, uint tablePos)
  {
    return verifier.VerifyTableStart(tablePos)
      && verifier.VerifyField(tablePos, 4 /*ClassId*/, 4 /*uint*/, 4, false)
      && verifier.VerifyField(tablePos, 6 /*BoundingBoxType*/, 1 /*SmartCamera.BoundingBox*/, 1, false)
      && verifier.VerifyUnion(tablePos, 6, 8 /*BoundingBox*/, SmartCamera.BoundingBoxVerify.Verify, false)
      && verifier.VerifyField(tablePos, 10 /*Score*/, 4 /*float*/, 4, false)
      && verifier.VerifyTableEnd(tablePos);
  }
}

}
