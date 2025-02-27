// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

namespace SmartCamera
{

using global::System;
using global::System.Collections.Generic;
using global::Google.FlatBuffers;

public struct BoundingBox2d : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static void ValidateVersion() { FlatBufferConstants.FLATBUFFERS_25_1_24(); }
  public static BoundingBox2d GetRootAsBoundingBox2d(ByteBuffer _bb) { return GetRootAsBoundingBox2d(_bb, new BoundingBox2d()); }
  public static BoundingBox2d GetRootAsBoundingBox2d(ByteBuffer _bb, BoundingBox2d obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p = new Table(_i, _bb); }
  public BoundingBox2d __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public int Left { get { int o = __p.__offset(4); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public int Top { get { int o = __p.__offset(6); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public int Right { get { int o = __p.__offset(8); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public int Bottom { get { int o = __p.__offset(10); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }

  public static Offset<SmartCamera.BoundingBox2d> CreateBoundingBox2d(FlatBufferBuilder builder,
      int left = 0,
      int top = 0,
      int right = 0,
      int bottom = 0) {
    builder.StartTable(4);
    BoundingBox2d.AddBottom(builder, bottom);
    BoundingBox2d.AddRight(builder, right);
    BoundingBox2d.AddTop(builder, top);
    BoundingBox2d.AddLeft(builder, left);
    return BoundingBox2d.EndBoundingBox2d(builder);
  }

  public static void StartBoundingBox2d(FlatBufferBuilder builder) { builder.StartTable(4); }
  public static void AddLeft(FlatBufferBuilder builder, int left) { builder.AddInt(0, left, 0); }
  public static void AddTop(FlatBufferBuilder builder, int top) { builder.AddInt(1, top, 0); }
  public static void AddRight(FlatBufferBuilder builder, int right) { builder.AddInt(2, right, 0); }
  public static void AddBottom(FlatBufferBuilder builder, int bottom) { builder.AddInt(3, bottom, 0); }
  public static Offset<SmartCamera.BoundingBox2d> EndBoundingBox2d(FlatBufferBuilder builder) {
    int o = builder.EndTable();
    return new Offset<SmartCamera.BoundingBox2d>(o);
  }
  public BoundingBox2dT UnPack() {
    var _o = new BoundingBox2dT();
    this.UnPackTo(_o);
    return _o;
  }
  public void UnPackTo(BoundingBox2dT _o) {
    _o.Left = this.Left;
    _o.Top = this.Top;
    _o.Right = this.Right;
    _o.Bottom = this.Bottom;
  }
  public static Offset<SmartCamera.BoundingBox2d> Pack(FlatBufferBuilder builder, BoundingBox2dT _o) {
    if (_o == null) return default(Offset<SmartCamera.BoundingBox2d>);
    return CreateBoundingBox2d(
      builder,
      _o.Left,
      _o.Top,
      _o.Right,
      _o.Bottom);
  }
}

public class BoundingBox2dT
{
  [Newtonsoft.Json.JsonProperty("left")]
  public int Left { get; set; }
  [Newtonsoft.Json.JsonProperty("top")]
  public int Top { get; set; }
  [Newtonsoft.Json.JsonProperty("right")]
  public int Right { get; set; }
  [Newtonsoft.Json.JsonProperty("bottom")]
  public int Bottom { get; set; }

  public BoundingBox2dT() {
    this.Left = 0;
    this.Top = 0;
    this.Right = 0;
    this.Bottom = 0;
  }
}


static public class BoundingBox2dVerify
{
  static public bool Verify(Google.FlatBuffers.Verifier verifier, uint tablePos)
  {
    return verifier.VerifyTableStart(tablePos)
      && verifier.VerifyField(tablePos, 4 /*Left*/, 4 /*int*/, 4, false)
      && verifier.VerifyField(tablePos, 6 /*Top*/, 4 /*int*/, 4, false)
      && verifier.VerifyField(tablePos, 8 /*Right*/, 4 /*int*/, 4, false)
      && verifier.VerifyField(tablePos, 10 /*Bottom*/, 4 /*int*/, 4, false)
      && verifier.VerifyTableEnd(tablePos);
  }
}

}
