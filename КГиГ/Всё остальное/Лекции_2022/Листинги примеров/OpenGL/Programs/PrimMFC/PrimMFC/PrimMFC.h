// PrimMFC.h : main header file for the PrimMFC application
//
#pragma once

#ifndef __AFXWIN_H__
	#error "include 'stdafx.h' before including this file for PCH"
#endif

#include "resource.h"       // main symbols


// CPrimMFCApp:
// See PrimMFC.cpp for the implementation of this class
//

class CPrimMFCApp : public CWinApp
{
public:
	CPrimMFCApp();


// Overrides
public:
	virtual BOOL InitInstance();

// Implementation

public:
	afx_msg void OnAppAbout();
	DECLARE_MESSAGE_MAP()
};

extern CPrimMFCApp theApp;