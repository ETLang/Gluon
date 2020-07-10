/* This file is automatically maintained by Gluon.
 * Do not attempt to modify, as any modifications will be overwritten.
 */

#pragma once
#include "Prototypes.abi.h"
#include "ValueTypes.abi.h"

namespace ABI { 

    ABI_CONSTRUCTOR Create_IBlob(IBlob** outInstance);

    interface comid("3c45ab9f-8487-4fde-92eb-9d58728fec74") IBlob : public IUnknown
    {
        METHOD _GetBufferPointer(void** _outReturn) = 0;
        METHOD _GetBufferSize(void** _outReturn) = 0;
    };

}
