#pragma once

#include "windows.h"

using namespace System;

namespace CSCPP {

	public ref class Class1
	{
		// TODO: Add your methods for this class here.
	public:
		String^ GetText() {
			WCHAR acUserName[100];
			DWORD nUserName = sizeof(acUserName);
			if (GetUserName(acUserName, &nUserName)) {
				String^ name = gcnew String(acUserName);
				return String::Format("Hello {0} !", name);
			}
			else {
				return gcnew String("Error!");
			}
		}
	};
}