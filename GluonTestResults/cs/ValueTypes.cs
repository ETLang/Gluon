/* This file is automatically maintained by Gluon.
 * Do not attempt to modify, as any modifications will be overwritten.
 */

using Gluon;
using System;
using System.Runtime.InteropServices;
using ABI.GluonTest;
using ABI.Gluon;
using GluonTest;
using System.Runtime.CompilerServices;

public enum DXGI_FORMAT : int
{
    DXGI_FORMAT_UNKNOWN,
    DXGI_FORMAT_R32G32B32A32_TYPELESS,
    DXGI_FORMAT_R32G32B32A32_FLOAT,
    DXGI_FORMAT_R32G32B32A32_UINT,
    DXGI_FORMAT_R32G32B32A32_SINT,
    DXGI_FORMAT_R32G32B32_TYPELESS,
    DXGI_FORMAT_R32G32B32_FLOAT,
    DXGI_FORMAT_R32G32B32_UINT,
    DXGI_FORMAT_R32G32B32_SINT,
    DXGI_FORMAT_R16G16B16A16_TYPELESS,
    DXGI_FORMAT_R16G16B16A16_FLOAT,
    DXGI_FORMAT_R16G16B16A16_UNORM,
    DXGI_FORMAT_R16G16B16A16_UINT,
    DXGI_FORMAT_R16G16B16A16_SNORM,
    DXGI_FORMAT_R16G16B16A16_SINT,
    DXGI_FORMAT_R32G32_TYPELESS,
    DXGI_FORMAT_R32G32_FLOAT,
    DXGI_FORMAT_R32G32_UINT,
    DXGI_FORMAT_R32G32_SINT,
    DXGI_FORMAT_R32G8X24_TYPELESS,
    DXGI_FORMAT_D32_FLOAT_S8X24_UINT,
    DXGI_FORMAT_R32_FLOAT_X8X24_TYPELESS,
    DXGI_FORMAT_X32_TYPELESS_G8X24_UINT,
    DXGI_FORMAT_R10G10B10A2_TYPELESS,
    DXGI_FORMAT_R10G10B10A2_UNORM,
    DXGI_FORMAT_R10G10B10A2_UINT,
    DXGI_FORMAT_R11G11B10_FLOAT,
    DXGI_FORMAT_R8G8B8A8_TYPELESS,
    DXGI_FORMAT_R8G8B8A8_UNORM,
    DXGI_FORMAT_R8G8B8A8_UNORM_SRGB,
    DXGI_FORMAT_R8G8B8A8_UINT,
    DXGI_FORMAT_R8G8B8A8_SNORM,
    DXGI_FORMAT_R8G8B8A8_SINT,
    DXGI_FORMAT_R16G16_TYPELESS,
    DXGI_FORMAT_R16G16_FLOAT,
    DXGI_FORMAT_R16G16_UNORM,
    DXGI_FORMAT_R16G16_UINT,
    DXGI_FORMAT_R16G16_SNORM,
    DXGI_FORMAT_R16G16_SINT,
    DXGI_FORMAT_R32_TYPELESS,
    DXGI_FORMAT_D32_FLOAT,
    DXGI_FORMAT_R32_FLOAT,
    DXGI_FORMAT_R32_UINT,
    DXGI_FORMAT_R32_SINT,
    DXGI_FORMAT_R24G8_TYPELESS,
    DXGI_FORMAT_D24_UNORM_S8_UINT,
    DXGI_FORMAT_R24_UNORM_X8_TYPELESS,
    DXGI_FORMAT_X24_TYPELESS_G8_UINT,
    DXGI_FORMAT_R8G8_TYPELESS,
    DXGI_FORMAT_R8G8_UNORM,
    DXGI_FORMAT_R8G8_UINT,
    DXGI_FORMAT_R8G8_SNORM,
    DXGI_FORMAT_R8G8_SINT,
    DXGI_FORMAT_R16_TYPELESS,
    DXGI_FORMAT_R16_FLOAT,
    DXGI_FORMAT_D16_UNORM,
    DXGI_FORMAT_R16_UNORM,
    DXGI_FORMAT_R16_UINT,
    DXGI_FORMAT_R16_SNORM,
    DXGI_FORMAT_R16_SINT,
    DXGI_FORMAT_R8_TYPELESS,
    DXGI_FORMAT_R8_UNORM,
    DXGI_FORMAT_R8_UINT,
    DXGI_FORMAT_R8_SNORM,
    DXGI_FORMAT_R8_SINT,
    DXGI_FORMAT_A8_UNORM,
    DXGI_FORMAT_R1_UNORM,
    DXGI_FORMAT_R9G9B9E5_SHAREDEXP,
    DXGI_FORMAT_R8G8_B8G8_UNORM,
    DXGI_FORMAT_G8R8_G8B8_UNORM,
    DXGI_FORMAT_BC1_TYPELESS,
    DXGI_FORMAT_BC1_UNORM,
    DXGI_FORMAT_BC1_UNORM_SRGB,
    DXGI_FORMAT_BC2_TYPELESS,
    DXGI_FORMAT_BC2_UNORM,
    DXGI_FORMAT_BC2_UNORM_SRGB,
    DXGI_FORMAT_BC3_TYPELESS,
    DXGI_FORMAT_BC3_UNORM,
    DXGI_FORMAT_BC3_UNORM_SRGB,
    DXGI_FORMAT_BC4_TYPELESS,
    DXGI_FORMAT_BC4_UNORM,
    DXGI_FORMAT_BC4_SNORM,
    DXGI_FORMAT_BC5_TYPELESS,
    DXGI_FORMAT_BC5_UNORM,
    DXGI_FORMAT_BC5_SNORM,
    DXGI_FORMAT_B5G6R5_UNORM,
    DXGI_FORMAT_B5G5R5A1_UNORM,
    DXGI_FORMAT_B8G8R8A8_UNORM,
    DXGI_FORMAT_B8G8R8X8_UNORM,
    DXGI_FORMAT_R10G10B10_XR_BIAS_A2_UNORM,
    DXGI_FORMAT_B8G8R8A8_TYPELESS,
    DXGI_FORMAT_B8G8R8A8_UNORM_SRGB,
    DXGI_FORMAT_B8G8R8X8_TYPELESS,
    DXGI_FORMAT_B8G8R8X8_UNORM_SRGB,
    DXGI_FORMAT_BC6H_TYPELESS,
    DXGI_FORMAT_BC6H_UF16,
    DXGI_FORMAT_BC6H_SF16,
    DXGI_FORMAT_BC7_TYPELESS,
    DXGI_FORMAT_BC7_UNORM,
    DXGI_FORMAT_BC7_UNORM_SRGB,
    DXGI_FORMAT_AYUV,
    DXGI_FORMAT_Y410,
    DXGI_FORMAT_Y416,
    DXGI_FORMAT_NV12,
    DXGI_FORMAT_P010,
    DXGI_FORMAT_P016,
    DXGI_FORMAT_420_OPAQUE,
    DXGI_FORMAT_YUY2,
    DXGI_FORMAT_Y210,
    DXGI_FORMAT_Y216,
    DXGI_FORMAT_NV11,
    DXGI_FORMAT_AI44,
    DXGI_FORMAT_IA44,
    DXGI_FORMAT_P8,
    DXGI_FORMAT_A8P8,
    DXGI_FORMAT_B4G4R4A4_UNORM,
    DXGI_FORMAT_P208 = 130,
    DXGI_FORMAT_V208 = 131,
    DXGI_FORMAT_V408 = 132
}

public enum D3D11_USAGE : int
{
    D3D11_USAGE_DEFAULT,
    D3D11_USAGE_IMMUTABLE,
    D3D11_USAGE_DYNAMIC,
    D3D11_USAGE_STAGING
}

namespace GluonTest
{
    public enum Foo : int
    {
        Doo,
        Boo,
        Noo = 3,
        Blu = 5
    }

    public enum NoiseEngineState : int
    {
        Idle,
        Running,
        Failed
    }

    public enum NoiseChannels : int
    {
        Mono,
        Stereo
    }

    public enum NoiseDistribution : int
    {
        Uniform,
        Gaussian
    }

    public enum PlotType : int
    {
        Signal,
        FFT
    }

    public delegate int NamedDelegate(string a, string b);
    public delegate double PrimitivesCB(bool inTest, out char outTest, ref int refTest);
    public delegate string StringsCB(string inTest, out string outTest, ref string refTest);
    public delegate BlittableStruct SimpleStructsCB(BlittableStruct inTest, out BlittableStruct outTest, ref BlittableStruct refTest);
    public delegate ComplexStruct ComplexStructsCB(ComplexStruct inTest, out ComplexStruct outTest, ref ComplexStruct refTest);
    public delegate DummyClass ObjectsCB(DummyClass inTest, out DummyClass outTest, ref DummyClass refTest);
    public delegate NamedDelegate NamedDelegatesCB(NamedDelegate inTest, out NamedDelegate outTest, ref NamedDelegate refTest);
    public delegate Func<int,int> GenericDelegatesCB(Action<string> inTest, out Action<Func<int,int>> outTest, ref Func<char[],string[]> refTest);
    public delegate double[] PrimitiveArraysCB(bool[] inTest, out char[] outTest, ref int[] refTest);
    public delegate string[] StringArraysCB(string[] inTest, out string[] outTest, ref string[] refTest);
    public delegate BlittableStruct[] SimpleStructArraysCB(BlittableStruct[] inTest, out BlittableStruct[] outTest, ref BlittableStruct[] refTest);
    public delegate ComplexStruct[] ComplexStructArraysCB(ComplexStruct[] inTest, out ComplexStruct[] outTest, ref ComplexStruct[] refTest);
    public delegate DummyClass[] ObjectArraysCB(DummyClass[] inTest, out DummyClass[] outTest, ref DummyClass[] refTest);
    public delegate NamedDelegate[] NamedDelegateArraysCB(NamedDelegate[] inTest, out NamedDelegate[] outTest, ref NamedDelegate[] refTest);
    public delegate Func<int,int>[] GenericDelegateArraysCB(Action<string>[] inTest, out Action<Func<int,int>>[] outTest, ref Func<char[],string[]>[] refTest);
    public delegate ITestClass AddSomeShit(int a, int b);
}

public struct DXGI_SAMPLE_DESC
{
    public uint Count;
    public uint Quality;

    public DXGI_SAMPLE_DESC(uint _Count, uint _Quality)
    {
        Count = _Count;
        Quality = _Quality;
    }
}

public struct D3D11_TEXTURE2D_DESC
{
    public uint Width;
    public uint Height;
    public uint MipLevels;
    public uint ArraySize;
    public DXGI_FORMAT Format;
    public global::DXGI_SAMPLE_DESC SampleDesc;
    public D3D11_USAGE Usage;
    public uint BindFlags;
    public uint CPUAccessFlags;
    public uint MiscFlags;

    public D3D11_TEXTURE2D_DESC(uint _Width, uint _Height, uint _MipLevels, uint _ArraySize, DXGI_FORMAT _Format, global::DXGI_SAMPLE_DESC _SampleDesc, D3D11_USAGE _Usage, uint _BindFlags, uint _CPUAccessFlags, uint _MiscFlags)
    {
        Width = _Width;
        Height = _Height;
        MipLevels = _MipLevels;
        ArraySize = _ArraySize;
        Format = _Format;
        SampleDesc = _SampleDesc;
        Usage = _Usage;
        BindFlags = _BindFlags;
        CPUAccessFlags = _CPUAccessFlags;
        MiscFlags = _MiscFlags;
    }
}

namespace GluonTest
{
    public struct BlittableStruct
    {
        public int x;
        public int y;
        public double u;
        public double v;

        public BlittableStruct(int _x, int _y, double _u, double _v)
        {
            x = _x;
            y = _y;
            u = _u;
            v = _v;
        }
    }

    public struct ComplexStruct
    {
        public string Name;
        public BlittableStruct Sub;
        public DummyClass Obj;
        public Func<int,int,int> Del;

        public ComplexStruct(string _Name, BlittableStruct _Sub, DummyClass _Obj, Func<int,int,int> _Del)
        {
            Name = _Name;
            Sub = _Sub;
            Obj = _Obj;
            Del = _Del;
        }
    }

    public struct StructMemberTest
    {
        public bool Boolean;
        public double Primitive;
        public IntPtr PrimitivePtr;
        public string String;
        public BlittableStruct BlittableSt;
        public ComplexStruct ComplexSt;
        public DummyClass Object;
        public NamedDelegate NamedDelegate;
        public Func<double,double> GenericDelegate;

        public StructMemberTest(bool _Boolean, double _Primitive, IntPtr _PrimitivePtr, string _String, BlittableStruct _BlittableSt, ComplexStruct _ComplexSt, DummyClass _Object, NamedDelegate _NamedDelegate, Func<double,double> _GenericDelegate)
        {
            Boolean = _Boolean;
            Primitive = _Primitive;
            PrimitivePtr = _PrimitivePtr;
            String = _String;
            BlittableSt = _BlittableSt;
            ComplexSt = _ComplexSt;
            Object = _Object;
            NamedDelegate = _NamedDelegate;
            GenericDelegate = _GenericDelegate;
        }
    }

    public struct TestStruct
    {
        public char a;
        public int b;
        public long c;
        public int d;
        public string e;
        public int[] f;

        public TestStruct(char _a, int _b, long _c, int _d, string _e, int[] _f)
        {
            a = _a;
            b = _b;
            c = _c;
            d = _d;
            e = _e;
            f = _f;
        }
    }
}
