#include "PCH.h"
#include "SignalBuffer.h"

using namespace GluonTest;

SignalBuffer::SignalBuffer(int samples, int channels, int alignment) :
	_data((double*)_aligned_malloc(samples * channels * sizeof(double), alignment)),
	_channels(channels),
	_samples(samples)
{
}

SignalBuffer::SignalBuffer(int samples) : SignalBuffer(samples, 2, 32)
{
}

SignalBuffer::~SignalBuffer()
{
	_aligned_free(_data);
	_data = nullptr;
}

int SignalBuffer::GetChannelCount() const
{
	return _channels;
}

int SignalBuffer::GetSampleCount() const
{
	return _samples;
}

int SignalBuffer::CopyTo(Array<double> arr)
{
	int writeElements = _channels * MIN(_samples, (int)arr.size() / _channels);
	for (int i = 0; i < writeElements; i++)
		arr[i] = _data[i];
	return writeElements;
}

int SignalBuffer::CopyTo(Array<float> arr)
{
	int writeElements = _channels * MIN(_samples, (int)arr.size() / _channels);
	for (int i = 0; i < writeElements; i++)
		arr[i] = (float)_data[i];
	return writeElements;
}

int SignalBuffer::CopyTo(Array<short> arr)
{
	int writeElements = _channels * MIN(_samples, (int)arr.size() / _channels);
	for (int i = 0; i < writeElements; i++)
		arr[i] = (short)(_data[i] * MAXSHORT);
	return writeElements;
}

/* IBlob */
void* SignalBuffer::GetBufferPointer()
{
	return _data;
}

SIZE_T SignalBuffer::GetBufferSize()
{
	return _samples * _channels * sizeof(double);
}

