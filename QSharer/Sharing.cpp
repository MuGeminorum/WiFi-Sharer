#include "NetCon.h"
#include "Sharing.h"

#include <iostream>
using namespace std;

Sharing::Sharing() // QString devName)
{
	// srcDev = devName;
}

Sharing::~Sharing()
{
}

// void Sharing::SetSrcDev(QString devName)
// {
// 	srcDev = devName;
// }

BYTE Sharing::bit(int p)
{
	switch (p)
	{
	case 1:
		return 0x01;
		break;
	case 2:
		return 0x02;
		break;
	case 3:
		return 0x04;
		break;
	case 4:
		return 0x08;
		break;
	case 5:
		return 0x10;
		break;
	case 6:
		return 0x20;
		break;
	case 7:
		return 0x40;
		break;
	case 8:
		return 0x80;
		break;
	default:
		return 0x00;
		break;
	}
}

void Sharing::InitCon(void)
{
	CoInitialize(NULL);
	CoInitializeSecurity(
		NULL,
		-1,
		NULL,
		NULL,
		RPC_C_AUTHN_LEVEL_PKT,
		RPC_C_IMP_LEVEL_IMPERSONATE,
		NULL,
		EOAC_NONE,
		NULL);
}

void Sharing::ExitCon(void)
{
	CoUninitialize();
}

QStringList Sharing::LoadSrc(void)
{
	InitCon();

	INetSharingManager *pNSM = NULL;
	INetSharingEveryConnectionCollection *pNSECC = NULL;
	IUnknown *pUnk = NULL;
	IEnumVARIANT *pEV = NULL;
	INetConnection *pNC = NULL;
	INetSharingConfiguration *pNSC = NULL;
	NETCON_PROPERTIES *pNP = NULL;

	VARIANT v;

	QStringList srcDevices;
	BYTE err = 0x00;

	if (!(S_OK == CoCreateInstance(__uuidof(NetSharingManager), NULL, CLSCTX_ALL, __uuidof(INetSharingManager), (void **)&pNSM) && pNSM))
	{
		err |= bit(1);
	}

	if (!(S_OK == pNSM->get_EnumEveryConnection(&pNSECC) && pNSECC))
	{
		err |= bit(2);
	}

	if (!(S_OK == pNSECC->get__NewEnum(&pUnk) && pUnk))
	{
		err |= bit(3);
	}

	if (!(S_OK == pUnk->QueryInterface(__uuidof(IEnumVARIANT), (void **)&pEV) && pEV))
	{
		err |= bit(4);
	}

	VariantInit(&v);

	while (S_OK == pEV->Next(1, &v, NULL))
	{
		if (V_VT(&v) == VT_UNKNOWN)
		{
			V_UNKNOWN(&v)->QueryInterface(__uuidof(INetConnection), (void **)&pNC);

			pNC->GetProperties(&pNP);

			QString DeviceName = QString::fromWCharArray((wchar_t *)(pNP->pszwDeviceName));
			int Status = (int)(pNP->Status);
			if (isSource(DeviceName, Status))
			{
				srcDevices.append(DeviceName);
			}

			pNSM->get_INetSharingConfigurationForINetConnection(pNC, &pNSC);

		} // end of if

		pNSC->Release();
		pNC->Release();
	} // end of while

	ExitCon();

	return srcDevices;
}

int Sharing::StartSharing(QString srcDev)
{
	InitCon();

	INetSharingManager *pNSM = NULL;
	INetSharingEveryConnectionCollection *pNSECC = NULL;
	IUnknown *pUnk = NULL;
	IEnumVARIANT *pEV = NULL;
	INetConnection *pNC = NULL;
	INetSharingConfiguration *pNSC = NULL;
	NETCON_PROPERTIES *pNP = NULL;

	VARIANT v;

	int sN = 0;
	int dN = 0;
	BYTE err = 0x00;

	if (!(S_OK == CoCreateInstance(__uuidof(NetSharingManager), NULL, CLSCTX_ALL, __uuidof(INetSharingManager), (void **)&pNSM) && pNSM))
	{
		err |= bit(1);
	}

	if (!(S_OK == pNSM->get_EnumEveryConnection(&pNSECC) && pNSECC))
	{
		err |= bit(2);
	}

	if (!(S_OK == pNSECC->get__NewEnum(&pUnk) && pUnk))
	{
		err |= bit(3);
	}

	if (!(S_OK == pUnk->QueryInterface(__uuidof(IEnumVARIANT), (void **)&pEV) && pEV))
	{
		err |= bit(4);
	}

	VariantInit(&v);

	while (S_OK == pEV->Next(1, &v, NULL))
	{
		if (V_VT(&v) == VT_UNKNOWN)
		{
			V_UNKNOWN(&v)->QueryInterface(__uuidof(INetConnection), (void **)&pNC);

			pNC->GetProperties(&pNP);

			QString DeviceName = QString::fromWCharArray((wchar_t *)(pNP->pszwDeviceName));
			int Status = (int)(pNP->Status);

			pNSM->get_INetSharingConfigurationForINetConnection(pNC, &pNSC);
			pNSC->DisableSharing();

			if (srcDev == DeviceName && Status == 2)
			{
				if (S_OK != pNSC->EnableSharing(ICSSHARINGTYPE_PUBLIC))
				{
					err |= bit(5);
				}
				sN++;
			}
			else if (isDest(DeviceName, Status))
			{
				if (S_OK != pNSC->EnableSharing(ICSSHARINGTYPE_PRIVATE))
				{
					err |= bit(6);
				}
				dN++;
			}

		} // end of if

		pNSC->Release();
		pNC->Release();

		if (sN == 1 && dN == 1)
		{
			break;
		}

	} // end of while

	ExitCon();

	if (sN != 1)
	{ // sharing source count
		err |= bit(7);
	}

	if (dN != 1) // sharing dest count
	{
		err |= bit(8);
	}

	return (int)err;
}

int Sharing::StopSharing()
{
	InitCon();

	INetSharingManager *pNSM = NULL;
	INetSharingEveryConnectionCollection *pNSECC = NULL;
	IUnknown *pUnk = NULL;
	IEnumVARIANT *pEV = NULL;
	INetConnection *pNC = NULL;
	INetSharingConfiguration *pNSC = NULL;

	VARIANT v;

	BYTE err = 0x00;

	if (!(S_OK == CoCreateInstance(__uuidof(NetSharingManager), NULL, CLSCTX_ALL, __uuidof(INetSharingManager), (void **)&pNSM) && pNSM))
	{
		err |= bit(1);
	}

	if (!(S_OK == pNSM->get_EnumEveryConnection(&pNSECC) && pNSECC))
	{
		err |= bit(2);
	}

	if (!(S_OK == pNSECC->get__NewEnum(&pUnk) && pUnk))
	{
		err |= bit(3);
	}

	if (!(S_OK == pUnk->QueryInterface(__uuidof(IEnumVARIANT), (void **)&pEV) && pEV))
	{
		err |= bit(4);
	}

	VariantInit(&v);

	while (S_OK == pEV->Next(1, &v, NULL))
	{
		if (V_VT(&v) == VT_UNKNOWN)
		{
			V_UNKNOWN(&v)->QueryInterface(__uuidof(INetConnection), (void **)&pNC);
			pNSM->get_INetSharingConfigurationForINetConnection(pNC, &pNSC);

			pNSC->DisableSharing();
		}

		pNSC->Release();
		pNC->Release();
	}

	ExitCon();

	return (int)err;
}

bool Sharing::isDest(QString devName, int Status)
{
	bool NetOn = (Status == 2);
	bool isAdapter = devName.contains("Microsoft Hosted Network Virtual Adapter", Qt::CaseSensitive);

	return NetOn && isAdapter;
}

bool Sharing::isSource(QString devName, int Status)
{
	// bool NetOn = (Status == 2);
	// bool isWire = devName.contains("Controller", Qt::CaseSensitive);
	// bool isWireless = devName.contains("802.11", Qt::CaseSensitive);

	// return NetOn && (isWire || isWireless);

	if (!devName.contains("Microsoft Hosted Network Virtual Adapter", Qt::CaseSensitive))
	{
		if (!devName.contains("VMnet", Qt::CaseSensitive))
		{
			return Status == 2;
		}
	}

	return false;
}
