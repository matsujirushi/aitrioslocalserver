// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

namespace SmartCamera
{

using global::System;
using global::System.Collections.Generic;
using global::Google.FlatBuffers;

public struct ObjectDetectionData : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static void ValidateVersion() { FlatBufferConstants.FLATBUFFERS_25_1_24(); }
  public static ObjectDetectionData GetRootAsObjectDetectionData(ByteBuffer _bb) { return GetRootAsObjectDetectionData(_bb, new ObjectDetectionData()); }
  public static ObjectDetectionData GetRootAsObjectDetectionData(ByteBuffer _bb, ObjectDetectionData obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p = new Table(_i, _bb); }
  public ObjectDetectionData __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public SmartCamera.GeneralObject? ObjectDetectionList(int j) { int o = __p.__offset(4); return o != 0 ? (SmartCamera.GeneralObject?)(new SmartCamera.GeneralObject()).__assign(__p.__indirect(__p.__vector(o) + j * 4), __p.bb) : null; }
  public int ObjectDetectionListLength { get { int o = __p.__offset(4); return o != 0 ? __p.__vector_len(o) : 0; } }

  public static Offset<SmartCamera.ObjectDetectionData> CreateObjectDetectionData(FlatBufferBuilder builder,
      VectorOffset object_detection_listOffset = default(VectorOffset)) {
    builder.StartTable(1);
    ObjectDetectionData.AddObjectDetectionList(builder, object_detection_listOffset);
    return ObjectDetectionData.EndObjectDetectionData(builder);
  }

  public static void StartObjectDetectionData(FlatBufferBuilder builder) { builder.StartTable(1); }
  public static void AddObjectDetectionList(FlatBufferBuilder builder, VectorOffset objectDetectionListOffset) { builder.AddOffset(0, objectDetectionListOffset.Value, 0); }
  public static VectorOffset CreateObjectDetectionListVector(FlatBufferBuilder builder, Offset<SmartCamera.GeneralObject>[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddOffset(data[i].Value); return builder.EndVector(); }
  public static VectorOffset CreateObjectDetectionListVectorBlock(FlatBufferBuilder builder, Offset<SmartCamera.GeneralObject>[] data) { builder.StartVector(4, data.Length, 4); builder.Add(data); return builder.EndVector(); }
  public static VectorOffset CreateObjectDetectionListVectorBlock(FlatBufferBuilder builder, ArraySegment<Offset<SmartCamera.GeneralObject>> data) { builder.StartVector(4, data.Count, 4); builder.Add(data); return builder.EndVector(); }
  public static VectorOffset CreateObjectDetectionListVectorBlock(FlatBufferBuilder builder, IntPtr dataPtr, int sizeInBytes) { builder.StartVector(1, sizeInBytes, 1); builder.Add<Offset<SmartCamera.GeneralObject>>(dataPtr, sizeInBytes); return builder.EndVector(); }
  public static void StartObjectDetectionListVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static Offset<SmartCamera.ObjectDetectionData> EndObjectDetectionData(FlatBufferBuilder builder) {
    int o = builder.EndTable();
    return new Offset<SmartCamera.ObjectDetectionData>(o);
  }
  public ObjectDetectionDataT UnPack() {
    var _o = new ObjectDetectionDataT();
    this.UnPackTo(_o);
    return _o;
  }
  public void UnPackTo(ObjectDetectionDataT _o) {
    _o.ObjectDetectionList = new List<SmartCamera.GeneralObjectT>();
    for (var _j = 0; _j < this.ObjectDetectionListLength; ++_j) {_o.ObjectDetectionList.Add(this.ObjectDetectionList(_j).HasValue ? this.ObjectDetectionList(_j).Value.UnPack() : null);}
  }
  public static Offset<SmartCamera.ObjectDetectionData> Pack(FlatBufferBuilder builder, ObjectDetectionDataT _o) {
    if (_o == null) return default(Offset<SmartCamera.ObjectDetectionData>);
    var _object_detection_list = default(VectorOffset);
    if (_o.ObjectDetectionList != null) {
      var __object_detection_list = new Offset<SmartCamera.GeneralObject>[_o.ObjectDetectionList.Count];
      for (var _j = 0; _j < __object_detection_list.Length; ++_j) { __object_detection_list[_j] = SmartCamera.GeneralObject.Pack(builder, _o.ObjectDetectionList[_j]); }
      _object_detection_list = CreateObjectDetectionListVector(builder, __object_detection_list);
    }
    return CreateObjectDetectionData(
      builder,
      _object_detection_list);
  }
}

public class ObjectDetectionDataT
{
  [Newtonsoft.Json.JsonProperty("object_detection_list")]
  public List<SmartCamera.GeneralObjectT> ObjectDetectionList { get; set; }

  public ObjectDetectionDataT() {
    this.ObjectDetectionList = null;
  }
}


static public class ObjectDetectionDataVerify
{
  static public bool Verify(Google.FlatBuffers.Verifier verifier, uint tablePos)
  {
    return verifier.VerifyTableStart(tablePos)
      && verifier.VerifyVectorOfTables(tablePos, 4 /*ObjectDetectionList*/, SmartCamera.GeneralObjectVerify.Verify, false)
      && verifier.VerifyTableEnd(tablePos);
  }
}

}
