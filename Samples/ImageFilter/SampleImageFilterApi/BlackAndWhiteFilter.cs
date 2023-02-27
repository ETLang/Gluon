using System;
using System.Collections.Generic;
using System.Text;

namespace SampleImageFilter
{
    public interface BlackAndWhiteFilter
    {
        bool IsFiltering { get; }

        event Action<SampleImage> FilteringComplete;

        void BeginFiltering(SampleImage image);
    }
}
