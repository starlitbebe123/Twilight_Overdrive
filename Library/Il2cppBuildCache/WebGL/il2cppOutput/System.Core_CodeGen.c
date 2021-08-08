#include "pch-c.h"
#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif


#include "codegen/il2cpp-codegen-metadata.h"





// 0x00000001 System.Exception System.Linq.Error::ArgumentNull(System.String)
extern void Error_ArgumentNull_m0EDA0D46D72CA692518E3E2EB75B48044D8FD41E (void);
// 0x00000002 System.Exception System.Linq.Error::MoreThanOneMatch()
extern void Error_MoreThanOneMatch_m4C4756AF34A76EF12F3B2B6D8C78DE547F0FBCF8 (void);
// 0x00000003 System.Exception System.Linq.Error::NoElements()
extern void Error_NoElements_mB89E91246572F009281D79730950808F17C3F353 (void);
// 0x00000004 System.Collections.Generic.IEnumerable`1<TSource> System.Linq.Enumerable::Where(System.Collections.Generic.IEnumerable`1<TSource>,System.Func`2<TSource,System.Boolean>)
// 0x00000005 System.Collections.Generic.IEnumerable`1<TResult> System.Linq.Enumerable::Select(System.Collections.Generic.IEnumerable`1<TSource>,System.Func`2<TSource,TResult>)
// 0x00000006 System.Func`2<TSource,System.Boolean> System.Linq.Enumerable::CombinePredicates(System.Func`2<TSource,System.Boolean>,System.Func`2<TSource,System.Boolean>)
// 0x00000007 System.Func`2<TSource,TResult> System.Linq.Enumerable::CombineSelectors(System.Func`2<TSource,TMiddle>,System.Func`2<TMiddle,TResult>)
// 0x00000008 TSource[] System.Linq.Enumerable::ToArray(System.Collections.Generic.IEnumerable`1<TSource>)
// 0x00000009 System.Collections.Generic.List`1<TSource> System.Linq.Enumerable::ToList(System.Collections.Generic.IEnumerable`1<TSource>)
// 0x0000000A System.Collections.Generic.Dictionary`2<TKey,TElement> System.Linq.Enumerable::ToDictionary(System.Collections.Generic.IEnumerable`1<TSource>,System.Func`2<TSource,TKey>,System.Func`2<TSource,TElement>)
// 0x0000000B System.Collections.Generic.Dictionary`2<TKey,TElement> System.Linq.Enumerable::ToDictionary(System.Collections.Generic.IEnumerable`1<TSource>,System.Func`2<TSource,TKey>,System.Func`2<TSource,TElement>,System.Collections.Generic.IEqualityComparer`1<TKey>)
// 0x0000000C TSource System.Linq.Enumerable::First(System.Collections.Generic.IEnumerable`1<TSource>)
// 0x0000000D TSource System.Linq.Enumerable::SingleOrDefault(System.Collections.Generic.IEnumerable`1<TSource>,System.Func`2<TSource,System.Boolean>)
// 0x0000000E System.Boolean System.Linq.Enumerable::Any(System.Collections.Generic.IEnumerable`1<TSource>)
// 0x0000000F System.Boolean System.Linq.Enumerable::Any(System.Collections.Generic.IEnumerable`1<TSource>,System.Func`2<TSource,System.Boolean>)
// 0x00000010 System.Int32 System.Linq.Enumerable::Count(System.Collections.Generic.IEnumerable`1<TSource>)
// 0x00000011 System.Int32 System.Linq.Enumerable::Count(System.Collections.Generic.IEnumerable`1<TSource>,System.Func`2<TSource,System.Boolean>)
// 0x00000012 System.Int32 System.Linq.Enumerable::Sum(System.Collections.Generic.IEnumerable`1<System.Int32>)
extern void Enumerable_Sum_m6CFC8CEAC70AE3C469A5D1993FAF8EEEC6A06FB5 (void);
// 0x00000013 System.Void System.Linq.Enumerable/Iterator`1::.ctor()
// 0x00000014 TSource System.Linq.Enumerable/Iterator`1::get_Current()
// 0x00000015 System.Linq.Enumerable/Iterator`1<TSource> System.Linq.Enumerable/Iterator`1::Clone()
// 0x00000016 System.Void System.Linq.Enumerable/Iterator`1::Dispose()
// 0x00000017 System.Collections.Generic.IEnumerator`1<TSource> System.Linq.Enumerable/Iterator`1::GetEnumerator()
// 0x00000018 System.Boolean System.Linq.Enumerable/Iterator`1::MoveNext()
// 0x00000019 System.Collections.Generic.IEnumerable`1<TResult> System.Linq.Enumerable/Iterator`1::Select(System.Func`2<TSource,TResult>)
// 0x0000001A System.Collections.Generic.IEnumerable`1<TSource> System.Linq.Enumerable/Iterator`1::Where(System.Func`2<TSource,System.Boolean>)
// 0x0000001B System.Object System.Linq.Enumerable/Iterator`1::System.Collections.IEnumerator.get_Current()
// 0x0000001C System.Collections.IEnumerator System.Linq.Enumerable/Iterator`1::System.Collections.IEnumerable.GetEnumerator()
// 0x0000001D System.Void System.Linq.Enumerable/Iterator`1::System.Collections.IEnumerator.Reset()
// 0x0000001E System.Void System.Linq.Enumerable/WhereEnumerableIterator`1::.ctor(System.Collections.Generic.IEnumerable`1<TSource>,System.Func`2<TSource,System.Boolean>)
// 0x0000001F System.Linq.Enumerable/Iterator`1<TSource> System.Linq.Enumerable/WhereEnumerableIterator`1::Clone()
// 0x00000020 System.Void System.Linq.Enumerable/WhereEnumerableIterator`1::Dispose()
// 0x00000021 System.Boolean System.Linq.Enumerable/WhereEnumerableIterator`1::MoveNext()
// 0x00000022 System.Collections.Generic.IEnumerable`1<TResult> System.Linq.Enumerable/WhereEnumerableIterator`1::Select(System.Func`2<TSource,TResult>)
// 0x00000023 System.Collections.Generic.IEnumerable`1<TSource> System.Linq.Enumerable/WhereEnumerableIterator`1::Where(System.Func`2<TSource,System.Boolean>)
// 0x00000024 System.Void System.Linq.Enumerable/WhereArrayIterator`1::.ctor(TSource[],System.Func`2<TSource,System.Boolean>)
// 0x00000025 System.Linq.Enumerable/Iterator`1<TSource> System.Linq.Enumerable/WhereArrayIterator`1::Clone()
// 0x00000026 System.Boolean System.Linq.Enumerable/WhereArrayIterator`1::MoveNext()
// 0x00000027 System.Collections.Generic.IEnumerable`1<TResult> System.Linq.Enumerable/WhereArrayIterator`1::Select(System.Func`2<TSource,TResult>)
// 0x00000028 System.Collections.Generic.IEnumerable`1<TSource> System.Linq.Enumerable/WhereArrayIterator`1::Where(System.Func`2<TSource,System.Boolean>)
// 0x00000029 System.Void System.Linq.Enumerable/WhereListIterator`1::.ctor(System.Collections.Generic.List`1<TSource>,System.Func`2<TSource,System.Boolean>)
// 0x0000002A System.Linq.Enumerable/Iterator`1<TSource> System.Linq.Enumerable/WhereListIterator`1::Clone()
// 0x0000002B System.Boolean System.Linq.Enumerable/WhereListIterator`1::MoveNext()
// 0x0000002C System.Collections.Generic.IEnumerable`1<TResult> System.Linq.Enumerable/WhereListIterator`1::Select(System.Func`2<TSource,TResult>)
// 0x0000002D System.Collections.Generic.IEnumerable`1<TSource> System.Linq.Enumerable/WhereListIterator`1::Where(System.Func`2<TSource,System.Boolean>)
// 0x0000002E System.Void System.Linq.Enumerable/WhereSelectEnumerableIterator`2::.ctor(System.Collections.Generic.IEnumerable`1<TSource>,System.Func`2<TSource,System.Boolean>,System.Func`2<TSource,TResult>)
// 0x0000002F System.Linq.Enumerable/Iterator`1<TResult> System.Linq.Enumerable/WhereSelectEnumerableIterator`2::Clone()
// 0x00000030 System.Void System.Linq.Enumerable/WhereSelectEnumerableIterator`2::Dispose()
// 0x00000031 System.Boolean System.Linq.Enumerable/WhereSelectEnumerableIterator`2::MoveNext()
// 0x00000032 System.Collections.Generic.IEnumerable`1<TResult2> System.Linq.Enumerable/WhereSelectEnumerableIterator`2::Select(System.Func`2<TResult,TResult2>)
// 0x00000033 System.Collections.Generic.IEnumerable`1<TResult> System.Linq.Enumerable/WhereSelectEnumerableIterator`2::Where(System.Func`2<TResult,System.Boolean>)
// 0x00000034 System.Void System.Linq.Enumerable/WhereSelectArrayIterator`2::.ctor(TSource[],System.Func`2<TSource,System.Boolean>,System.Func`2<TSource,TResult>)
// 0x00000035 System.Linq.Enumerable/Iterator`1<TResult> System.Linq.Enumerable/WhereSelectArrayIterator`2::Clone()
// 0x00000036 System.Boolean System.Linq.Enumerable/WhereSelectArrayIterator`2::MoveNext()
// 0x00000037 System.Collections.Generic.IEnumerable`1<TResult2> System.Linq.Enumerable/WhereSelectArrayIterator`2::Select(System.Func`2<TResult,TResult2>)
// 0x00000038 System.Collections.Generic.IEnumerable`1<TResult> System.Linq.Enumerable/WhereSelectArrayIterator`2::Where(System.Func`2<TResult,System.Boolean>)
// 0x00000039 System.Void System.Linq.Enumerable/WhereSelectListIterator`2::.ctor(System.Collections.Generic.List`1<TSource>,System.Func`2<TSource,System.Boolean>,System.Func`2<TSource,TResult>)
// 0x0000003A System.Linq.Enumerable/Iterator`1<TResult> System.Linq.Enumerable/WhereSelectListIterator`2::Clone()
// 0x0000003B System.Boolean System.Linq.Enumerable/WhereSelectListIterator`2::MoveNext()
// 0x0000003C System.Collections.Generic.IEnumerable`1<TResult2> System.Linq.Enumerable/WhereSelectListIterator`2::Select(System.Func`2<TResult,TResult2>)
// 0x0000003D System.Collections.Generic.IEnumerable`1<TResult> System.Linq.Enumerable/WhereSelectListIterator`2::Where(System.Func`2<TResult,System.Boolean>)
// 0x0000003E System.Void System.Linq.Enumerable/<>c__DisplayClass6_0`1::.ctor()
// 0x0000003F System.Boolean System.Linq.Enumerable/<>c__DisplayClass6_0`1::<CombinePredicates>b__0(TSource)
// 0x00000040 System.Void System.Linq.Enumerable/<>c__DisplayClass7_0`3::.ctor()
// 0x00000041 TResult System.Linq.Enumerable/<>c__DisplayClass7_0`3::<CombineSelectors>b__0(TSource)
// 0x00000042 System.Void System.Linq.Buffer`1::.ctor(System.Collections.Generic.IEnumerable`1<TElement>)
// 0x00000043 TElement[] System.Linq.Buffer`1::ToArray()
// 0x00000044 System.Void System.Collections.Generic.HashSet`1::.ctor()
// 0x00000045 System.Void System.Collections.Generic.HashSet`1::.ctor(System.Collections.Generic.IEqualityComparer`1<T>)
// 0x00000046 System.Void System.Collections.Generic.HashSet`1::.ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)
// 0x00000047 System.Void System.Collections.Generic.HashSet`1::System.Collections.Generic.ICollection<T>.Add(T)
// 0x00000048 System.Void System.Collections.Generic.HashSet`1::Clear()
// 0x00000049 System.Boolean System.Collections.Generic.HashSet`1::Contains(T)
// 0x0000004A System.Void System.Collections.Generic.HashSet`1::CopyTo(T[],System.Int32)
// 0x0000004B System.Boolean System.Collections.Generic.HashSet`1::Remove(T)
// 0x0000004C System.Int32 System.Collections.Generic.HashSet`1::get_Count()
// 0x0000004D System.Boolean System.Collections.Generic.HashSet`1::System.Collections.Generic.ICollection<T>.get_IsReadOnly()
// 0x0000004E System.Collections.Generic.HashSet`1/Enumerator<T> System.Collections.Generic.HashSet`1::GetEnumerator()
// 0x0000004F System.Collections.Generic.IEnumerator`1<T> System.Collections.Generic.HashSet`1::System.Collections.Generic.IEnumerable<T>.GetEnumerator()
// 0x00000050 System.Collections.IEnumerator System.Collections.Generic.HashSet`1::System.Collections.IEnumerable.GetEnumerator()
// 0x00000051 System.Void System.Collections.Generic.HashSet`1::GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)
// 0x00000052 System.Void System.Collections.Generic.HashSet`1::OnDeserialization(System.Object)
// 0x00000053 System.Boolean System.Collections.Generic.HashSet`1::Add(T)
// 0x00000054 System.Void System.Collections.Generic.HashSet`1::CopyTo(T[])
// 0x00000055 System.Void System.Collections.Generic.HashSet`1::CopyTo(T[],System.Int32,System.Int32)
// 0x00000056 System.Void System.Collections.Generic.HashSet`1::Initialize(System.Int32)
// 0x00000057 System.Void System.Collections.Generic.HashSet`1::IncreaseCapacity()
// 0x00000058 System.Void System.Collections.Generic.HashSet`1::SetCapacity(System.Int32)
// 0x00000059 System.Boolean System.Collections.Generic.HashSet`1::AddIfNotPresent(T)
// 0x0000005A System.Int32 System.Collections.Generic.HashSet`1::InternalGetHashCode(T)
// 0x0000005B System.Void System.Collections.Generic.HashSet`1/Enumerator::.ctor(System.Collections.Generic.HashSet`1<T>)
// 0x0000005C System.Void System.Collections.Generic.HashSet`1/Enumerator::Dispose()
// 0x0000005D System.Boolean System.Collections.Generic.HashSet`1/Enumerator::MoveNext()
// 0x0000005E T System.Collections.Generic.HashSet`1/Enumerator::get_Current()
// 0x0000005F System.Object System.Collections.Generic.HashSet`1/Enumerator::System.Collections.IEnumerator.get_Current()
// 0x00000060 System.Void System.Collections.Generic.HashSet`1/Enumerator::System.Collections.IEnumerator.Reset()
static Il2CppMethodPointer s_methodPointers[96] = 
{
	Error_ArgumentNull_m0EDA0D46D72CA692518E3E2EB75B48044D8FD41E,
	Error_MoreThanOneMatch_m4C4756AF34A76EF12F3B2B6D8C78DE547F0FBCF8,
	Error_NoElements_mB89E91246572F009281D79730950808F17C3F353,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	Enumerable_Sum_m6CFC8CEAC70AE3C469A5D1993FAF8EEEC6A06FB5,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
};
static const int32_t s_InvokerIndices[96] = 
{
	1972,
	2056,
	2056,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	1939,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
};
static const Il2CppTokenRangePair s_rgctxIndices[32] = 
{
	{ 0x02000004, { 59, 4 } },
	{ 0x02000005, { 63, 9 } },
	{ 0x02000006, { 74, 7 } },
	{ 0x02000007, { 83, 10 } },
	{ 0x02000008, { 95, 11 } },
	{ 0x02000009, { 109, 9 } },
	{ 0x0200000A, { 121, 12 } },
	{ 0x0200000B, { 136, 1 } },
	{ 0x0200000C, { 137, 2 } },
	{ 0x0200000D, { 139, 4 } },
	{ 0x0200000E, { 143, 21 } },
	{ 0x02000010, { 164, 2 } },
	{ 0x06000004, { 0, 10 } },
	{ 0x06000005, { 10, 10 } },
	{ 0x06000006, { 20, 5 } },
	{ 0x06000007, { 25, 5 } },
	{ 0x06000008, { 30, 3 } },
	{ 0x06000009, { 33, 2 } },
	{ 0x0600000A, { 35, 1 } },
	{ 0x0600000B, { 36, 7 } },
	{ 0x0600000C, { 43, 4 } },
	{ 0x0600000D, { 47, 3 } },
	{ 0x0600000E, { 50, 1 } },
	{ 0x0600000F, { 51, 3 } },
	{ 0x06000010, { 54, 2 } },
	{ 0x06000011, { 56, 3 } },
	{ 0x06000022, { 72, 2 } },
	{ 0x06000027, { 81, 2 } },
	{ 0x0600002C, { 93, 2 } },
	{ 0x06000032, { 106, 3 } },
	{ 0x06000037, { 118, 3 } },
	{ 0x0600003C, { 133, 3 } },
};
static const Il2CppRGCTXDefinition s_rgctxValues[166] = 
{
	{ (Il2CppRGCTXDataType)2, 1049 },
	{ (Il2CppRGCTXDataType)3, 3353 },
	{ (Il2CppRGCTXDataType)2, 1735 },
	{ (Il2CppRGCTXDataType)2, 1444 },
	{ (Il2CppRGCTXDataType)3, 5953 },
	{ (Il2CppRGCTXDataType)2, 1106 },
	{ (Il2CppRGCTXDataType)2, 1451 },
	{ (Il2CppRGCTXDataType)3, 5976 },
	{ (Il2CppRGCTXDataType)2, 1446 },
	{ (Il2CppRGCTXDataType)3, 5960 },
	{ (Il2CppRGCTXDataType)2, 1050 },
	{ (Il2CppRGCTXDataType)3, 3354 },
	{ (Il2CppRGCTXDataType)2, 1746 },
	{ (Il2CppRGCTXDataType)2, 1453 },
	{ (Il2CppRGCTXDataType)3, 5983 },
	{ (Il2CppRGCTXDataType)2, 1120 },
	{ (Il2CppRGCTXDataType)2, 1461 },
	{ (Il2CppRGCTXDataType)3, 6011 },
	{ (Il2CppRGCTXDataType)2, 1457 },
	{ (Il2CppRGCTXDataType)3, 5996 },
	{ (Il2CppRGCTXDataType)2, 382 },
	{ (Il2CppRGCTXDataType)3, 14 },
	{ (Il2CppRGCTXDataType)3, 15 },
	{ (Il2CppRGCTXDataType)2, 652 },
	{ (Il2CppRGCTXDataType)3, 2480 },
	{ (Il2CppRGCTXDataType)2, 383 },
	{ (Il2CppRGCTXDataType)3, 20 },
	{ (Il2CppRGCTXDataType)3, 21 },
	{ (Il2CppRGCTXDataType)2, 661 },
	{ (Il2CppRGCTXDataType)3, 2485 },
	{ (Il2CppRGCTXDataType)2, 424 },
	{ (Il2CppRGCTXDataType)3, 424 },
	{ (Il2CppRGCTXDataType)3, 425 },
	{ (Il2CppRGCTXDataType)2, 1107 },
	{ (Il2CppRGCTXDataType)3, 3673 },
	{ (Il2CppRGCTXDataType)3, 7088 },
	{ (Il2CppRGCTXDataType)2, 491 },
	{ (Il2CppRGCTXDataType)3, 799 },
	{ (Il2CppRGCTXDataType)2, 824 },
	{ (Il2CppRGCTXDataType)2, 871 },
	{ (Il2CppRGCTXDataType)3, 2483 },
	{ (Il2CppRGCTXDataType)3, 2484 },
	{ (Il2CppRGCTXDataType)3, 800 },
	{ (Il2CppRGCTXDataType)2, 997 },
	{ (Il2CppRGCTXDataType)2, 739 },
	{ (Il2CppRGCTXDataType)2, 812 },
	{ (Il2CppRGCTXDataType)2, 869 },
	{ (Il2CppRGCTXDataType)2, 813 },
	{ (Il2CppRGCTXDataType)2, 870 },
	{ (Il2CppRGCTXDataType)3, 2482 },
	{ (Il2CppRGCTXDataType)2, 806 },
	{ (Il2CppRGCTXDataType)2, 807 },
	{ (Il2CppRGCTXDataType)2, 867 },
	{ (Il2CppRGCTXDataType)3, 2479 },
	{ (Il2CppRGCTXDataType)2, 738 },
	{ (Il2CppRGCTXDataType)2, 810 },
	{ (Il2CppRGCTXDataType)2, 811 },
	{ (Il2CppRGCTXDataType)2, 868 },
	{ (Il2CppRGCTXDataType)3, 2481 },
	{ (Il2CppRGCTXDataType)3, 3355 },
	{ (Il2CppRGCTXDataType)3, 3357 },
	{ (Il2CppRGCTXDataType)2, 266 },
	{ (Il2CppRGCTXDataType)3, 3356 },
	{ (Il2CppRGCTXDataType)3, 3365 },
	{ (Il2CppRGCTXDataType)2, 1053 },
	{ (Il2CppRGCTXDataType)2, 1447 },
	{ (Il2CppRGCTXDataType)3, 5961 },
	{ (Il2CppRGCTXDataType)3, 3366 },
	{ (Il2CppRGCTXDataType)2, 841 },
	{ (Il2CppRGCTXDataType)2, 887 },
	{ (Il2CppRGCTXDataType)3, 2490 },
	{ (Il2CppRGCTXDataType)3, 7064 },
	{ (Il2CppRGCTXDataType)2, 1458 },
	{ (Il2CppRGCTXDataType)3, 5997 },
	{ (Il2CppRGCTXDataType)3, 3358 },
	{ (Il2CppRGCTXDataType)2, 1052 },
	{ (Il2CppRGCTXDataType)2, 1445 },
	{ (Il2CppRGCTXDataType)3, 5954 },
	{ (Il2CppRGCTXDataType)3, 2489 },
	{ (Il2CppRGCTXDataType)3, 3359 },
	{ (Il2CppRGCTXDataType)3, 7063 },
	{ (Il2CppRGCTXDataType)2, 1454 },
	{ (Il2CppRGCTXDataType)3, 5984 },
	{ (Il2CppRGCTXDataType)3, 3372 },
	{ (Il2CppRGCTXDataType)2, 1054 },
	{ (Il2CppRGCTXDataType)2, 1452 },
	{ (Il2CppRGCTXDataType)3, 5977 },
	{ (Il2CppRGCTXDataType)3, 3710 },
	{ (Il2CppRGCTXDataType)3, 1734 },
	{ (Il2CppRGCTXDataType)3, 2491 },
	{ (Il2CppRGCTXDataType)3, 1733 },
	{ (Il2CppRGCTXDataType)3, 3373 },
	{ (Il2CppRGCTXDataType)3, 7065 },
	{ (Il2CppRGCTXDataType)2, 1462 },
	{ (Il2CppRGCTXDataType)3, 6012 },
	{ (Il2CppRGCTXDataType)3, 3386 },
	{ (Il2CppRGCTXDataType)2, 1056 },
	{ (Il2CppRGCTXDataType)2, 1460 },
	{ (Il2CppRGCTXDataType)3, 5999 },
	{ (Il2CppRGCTXDataType)3, 3387 },
	{ (Il2CppRGCTXDataType)2, 844 },
	{ (Il2CppRGCTXDataType)2, 890 },
	{ (Il2CppRGCTXDataType)3, 2495 },
	{ (Il2CppRGCTXDataType)3, 2494 },
	{ (Il2CppRGCTXDataType)2, 1449 },
	{ (Il2CppRGCTXDataType)3, 5963 },
	{ (Il2CppRGCTXDataType)3, 7069 },
	{ (Il2CppRGCTXDataType)2, 1459 },
	{ (Il2CppRGCTXDataType)3, 5998 },
	{ (Il2CppRGCTXDataType)3, 3379 },
	{ (Il2CppRGCTXDataType)2, 1055 },
	{ (Il2CppRGCTXDataType)2, 1456 },
	{ (Il2CppRGCTXDataType)3, 5986 },
	{ (Il2CppRGCTXDataType)3, 2493 },
	{ (Il2CppRGCTXDataType)3, 2492 },
	{ (Il2CppRGCTXDataType)3, 3380 },
	{ (Il2CppRGCTXDataType)2, 1448 },
	{ (Il2CppRGCTXDataType)3, 5962 },
	{ (Il2CppRGCTXDataType)3, 7068 },
	{ (Il2CppRGCTXDataType)2, 1455 },
	{ (Il2CppRGCTXDataType)3, 5985 },
	{ (Il2CppRGCTXDataType)3, 3393 },
	{ (Il2CppRGCTXDataType)2, 1057 },
	{ (Il2CppRGCTXDataType)2, 1464 },
	{ (Il2CppRGCTXDataType)3, 6014 },
	{ (Il2CppRGCTXDataType)3, 3711 },
	{ (Il2CppRGCTXDataType)3, 1736 },
	{ (Il2CppRGCTXDataType)3, 2497 },
	{ (Il2CppRGCTXDataType)3, 2496 },
	{ (Il2CppRGCTXDataType)3, 1735 },
	{ (Il2CppRGCTXDataType)3, 3394 },
	{ (Il2CppRGCTXDataType)2, 1450 },
	{ (Il2CppRGCTXDataType)3, 5964 },
	{ (Il2CppRGCTXDataType)3, 7070 },
	{ (Il2CppRGCTXDataType)2, 1463 },
	{ (Il2CppRGCTXDataType)3, 6013 },
	{ (Il2CppRGCTXDataType)3, 2487 },
	{ (Il2CppRGCTXDataType)3, 2488 },
	{ (Il2CppRGCTXDataType)3, 2498 },
	{ (Il2CppRGCTXDataType)2, 740 },
	{ (Il2CppRGCTXDataType)2, 1749 },
	{ (Il2CppRGCTXDataType)2, 825 },
	{ (Il2CppRGCTXDataType)2, 872 },
	{ (Il2CppRGCTXDataType)3, 2170 },
	{ (Il2CppRGCTXDataType)2, 587 },
	{ (Il2CppRGCTXDataType)3, 2689 },
	{ (Il2CppRGCTXDataType)3, 2690 },
	{ (Il2CppRGCTXDataType)3, 2695 },
	{ (Il2CppRGCTXDataType)2, 922 },
	{ (Il2CppRGCTXDataType)3, 2692 },
	{ (Il2CppRGCTXDataType)3, 7298 },
	{ (Il2CppRGCTXDataType)2, 568 },
	{ (Il2CppRGCTXDataType)3, 1729 },
	{ (Il2CppRGCTXDataType)1, 796 },
	{ (Il2CppRGCTXDataType)2, 1755 },
	{ (Il2CppRGCTXDataType)3, 2691 },
	{ (Il2CppRGCTXDataType)1, 1755 },
	{ (Il2CppRGCTXDataType)1, 922 },
	{ (Il2CppRGCTXDataType)2, 1793 },
	{ (Il2CppRGCTXDataType)2, 1755 },
	{ (Il2CppRGCTXDataType)3, 2696 },
	{ (Il2CppRGCTXDataType)3, 2694 },
	{ (Il2CppRGCTXDataType)3, 2693 },
	{ (Il2CppRGCTXDataType)2, 185 },
	{ (Il2CppRGCTXDataType)3, 1737 },
	{ (Il2CppRGCTXDataType)2, 275 },
};
extern const CustomAttributesCacheGenerator g_System_Core_AttributeGenerators[];
IL2CPP_EXTERN_C const Il2CppCodeGenModule g_System_Core_CodeGenModule;
const Il2CppCodeGenModule g_System_Core_CodeGenModule = 
{
	"System.Core.dll",
	96,
	s_methodPointers,
	0,
	NULL,
	s_InvokerIndices,
	0,
	NULL,
	32,
	s_rgctxIndices,
	166,
	s_rgctxValues,
	NULL,
	g_System_Core_AttributeGenerators,
	NULL, // module initializer,
	NULL,
	NULL,
	NULL,
};
