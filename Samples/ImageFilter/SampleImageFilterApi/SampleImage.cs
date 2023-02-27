using SampleImageFilterApi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SampleImageFilter
{
    public interface SampleImage
    {
        SampleImage Create(byte[] data, int width, int height);

        int Width { get; }
        int Height { get; }

        void CopyDataTo(out byte[] data);
        void Save(string path);

        Thing GetThing();
        Thing2 AnotherThing();
    }
}
