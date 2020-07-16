#pragma once
#include "GluonTest.Common.h"

namespace GluonTest { 
    class comid("7db242cd-a8a1-3983-dd16-1029353b0ac9")
    SignalBuffer : public ComObject<SignalBuffer, Object, ::ABI::GluonTest::SignalBuffer, IBlob>
    {
                #pragma region Gluon Maintained
    // clang-format off
    public:
        typedef ::ABI::GluonTest::SignalBuffer ABIType;

        SignalBuffer(int samples, int channels, int alignment = 32);
        SignalBuffer(int samples);

        PROPERTY_READONLY(int, ChannelCount);
        int GetChannelCount() const;

        PROPERTY_READONLY(int, SampleCount);
        int GetSampleCount() const;

        int CopyTo(Array<double> arr);
        int CopyTo(Array<float> arr);
        int CopyTo(Array<short> arr);

    private:
#ifndef __INTELLISENSE__
        METHOD _CopyTo(double* arr, int arr_count, int* ___ret);
        METHOD _CopyTo_1(float* arr, int arr_count, int* ___ret);
        METHOD _CopyTo_2(short* arr, int arr_count, int* ___ret);

        METHOD _GetChannelCount(int* ___ret);
        METHOD _GetSampleCount(int* ___ret);
#endif
    // clang-format on
    #pragma endregion







	public:
		virtual LPVOID STDMETHODCALLTYPE GetBufferPointer(void);
		virtual SIZE_T STDMETHODCALLTYPE GetBufferSize(void);

	public:
		~SignalBuffer();

	private:
		double* _data;
		int _channels;
		int _samples;
	};
}
