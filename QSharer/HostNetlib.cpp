#include "HostNetlib.h"

HostNetlib::HostNetlib()
{
	InitHostedNetWork();
	StartHostedNetWork();
	StopHostedNetWork();
}

HostNetlib::~HostNetlib()
{
	ExitHostedNetWork();
}

bool HostNetlib::isFormatStr(const char *s)
{
	bool b = true;

	while (*s)
	{
		if (!((*s >= 'A' && *s <= 'Z') || (*s >= 'a' && *s <= 'z') || (*s >= '0' && *s <= '9')))
		{
			b = false;
			break;
		}
		s++;
	}

	return b;
}

bool HostNetlib::isKEYLength(const char *s)
{
	QString qs = QObject::tr(s);
	int length = qs.length();

	return length >= 8 && length <= 13;
}

bool HostNetlib::isSSIDLength(const char *s)
{
	QString qs = QObject::tr(s);
	int length = qs.length();

	return length >= 1 && length <= 13;
}

int HostNetlib::ExitHostedNetWork(void)
{
	DWORD dwResult = WlanCloseHandle(hClient, NULL);
	if (ERROR_SUCCESS != dwResult)
	{
		return -1;
	}
	else
	{
		return 0;
	}
}

int HostNetlib::InitHostedNetWork(void)
{

	DWORD dwCurVersion = 0;
	DWORD dwResult = WlanOpenHandle(WLAN_API_VERSION, NULL, &dwCurVersion, &hClient);

	if (ERROR_SUCCESS != dwResult)
	{
		return -1;
	}
	else
	{
		return 0;
	}
}

int HostNetlib::AllowHostedNetWork(bool allow)
{
	DWORD dwResult = 0;
	BOOL bIsAllow = allow;
	WLAN_HOSTED_NETWORK_REASON dwFailedReason;

	dwResult = WlanHostedNetworkSetProperty(hClient,
											wlan_hosted_network_opcode_enable,
											sizeof(BOOL),
											&bIsAllow,
											&dwFailedReason,
											NULL);

	if (ERROR_SUCCESS != dwResult)
	{
		return dwFailedReason;
	}
	else
	{
		return 0;
	}
}

int HostNetlib::StartHostedNetWork(void)
{

	WLAN_HOSTED_NETWORK_REASON dwFailedReason;
	DWORD dwResult = WlanHostedNetworkForceStart(hClient, &dwFailedReason, NULL);

	if (dwResult != ERROR_SUCCESS)
	{
		return dwFailedReason;
	}
	else
	{
		return 0;
	}
}

int HostNetlib::StopHostedNetWork(void)
{

	WLAN_HOSTED_NETWORK_REASON dwFailedReason;
	DWORD dwResult = WlanHostedNetworkForceStop(hClient, &dwFailedReason, NULL);

	if (dwResult != ERROR_SUCCESS)
	{
		return dwFailedReason;
	}
	else
	{
		return 0;
	}
}

QString HostNetlib::GetMacAt(int i)
{

	PWLAN_HOSTED_NETWORK_STATUS ppWlanHostedNetworkStatus = NULL;

	WlanHostedNetworkQueryStatus(hClient, &ppWlanHostedNetworkStatus, NULL);

	WLAN_HOSTED_NETWORK_PEER_STATE *a = ppWlanHostedNetworkStatus->PeerList;

	char b[64];

	sprintf(b, "%02X:%02X:%02X:%02X:%02X:%02X",
			a[i].PeerMacAddress[0],
			a[i].PeerMacAddress[1],
			a[i].PeerMacAddress[2],
			a[i].PeerMacAddress[3],
			a[i].PeerMacAddress[4],
			a[i].PeerMacAddress[5]);

	return QObject::tr(b);
}

int HostNetlib::GetPeerNumber(void)
{

	PWLAN_HOSTED_NETWORK_STATUS ppWlanHostedNetworkStatus = NULL;
	int retval = WlanHostedNetworkQueryStatus(hClient, &ppWlanHostedNetworkStatus, NULL);

	if (retval != ERROR_SUCCESS)
	{
		return -1;
	}
	else
	{
		return (int)(ppWlanHostedNetworkStatus->dwNumberOfPeers);
	}
}

int HostNetlib::HostedNetworkOn(void)
{

	PWLAN_HOSTED_NETWORK_STATUS ppWlanHostedNetworkStatus = NULL;
	int retval = WlanHostedNetworkQueryStatus(hClient, &ppWlanHostedNetworkStatus, NULL);

	if (retval != ERROR_SUCCESS)
	{
		return -1;
	}
	else
	{
		switch (ppWlanHostedNetworkStatus->HostedNetworkState)
		{
		case wlan_hosted_network_unavailable:
			return -2;
			break;
		case wlan_hosted_network_idle:
			return -3;
			break;
		default:
			return 0;
			break; // wlan_hosted_network_active
		}
	}
}

QString HostNetlib::GetKEY(void)
{

	DWORD KeyLength;
	PUCHAR KeyData;
	BOOL IsPassPhrase;
	BOOL Persistent;
	WLAN_HOSTED_NETWORK_REASON FailReason;
	WlanHostedNetworkQuerySecondaryKey(
		hClient,
		&KeyLength,
		&KeyData,
		&IsPassPhrase,
		&Persistent,
		&FailReason,
		NULL);

	const char *p = (const char *)(char *)(KeyData);

	if (isKEYLength(p) && isFormatStr(p))
	{
		return QObject::tr(p);
	}
	else
	{
		return QString::number(12345678);
	}
}

QString HostNetlib::GetSSID(void)
{
	DWORD DataSize;
	WLAN_OPCODE_VALUE_TYPE WlanOpcodeValueType;
	UCHAR *SSID_;
	PWLAN_HOSTED_NETWORK_CONNECTION_SETTINGS pHostedNetworkConnectionSettings = NULL;
	if (ERROR_SUCCESS == WlanHostedNetworkQueryProperty(
							 hClient,
							 wlan_hosted_network_opcode_connection_settings,
							 &DataSize,
							 (PVOID *)&pHostedNetworkConnectionSettings,
							 &WlanOpcodeValueType,
							 NULL))
	{
		SSID_ = pHostedNetworkConnectionSettings->hostedNetworkSSID.ucSSID;
		const char *p = (const char *)(char *)(SSID_);

		if (isSSIDLength(p) && isFormatStr(p))
		{
			return QObject::tr(p);
		}
		else
		{
			return QObject::tr("WifiHostSpot");
		}
	}
	else
	{
		return QObject::tr("WifiHostSpot");
	}
}

int HostNetlib::SetKEY(const char *key)
{
	char chkey[64] = {""};
	int index = 0;
	for (index = 0; index < strlen((const char *)key) + 1; index++)
	{
		chkey[index] = key[index];
	}
	chkey[index] = '\0';

	WLAN_HOSTED_NETWORK_REASON dwFailedReason;

	DWORD dwResult = WlanHostedNetworkSetSecondaryKey(hClient,
													  strlen((const char *)chkey) + 1,
													  (PUCHAR)chkey,
													  TRUE,
													  FALSE,
													  &dwFailedReason,
													  NULL);

	if (ERROR_SUCCESS != dwResult)
	{
		return dwFailedReason;
	}
	else
	{
		return 0;
	}
}

int HostNetlib::SetSSID(const char *ssidname)
{

	char chname[64] = {""};
	int index = 0;

	for (index = 0; index < strlen((const char *)ssidname) + 1; index++)
	{
		chname[index] = ssidname[index];
	}
	chname[index] = '\0';

	DWORD dwResult = 0;
	WLAN_HOSTED_NETWORK_REASON dwFailedReason;
	WLAN_HOSTED_NETWORK_CONNECTION_SETTINGS cfg;

	memset(&cfg, 0, sizeof(WLAN_HOSTED_NETWORK_CONNECTION_SETTINGS));
	memcpy(cfg.hostedNetworkSSID.ucSSID, chname, strlen(chname));
	cfg.hostedNetworkSSID.uSSIDLength = strlen((const char *)cfg.hostedNetworkSSID.ucSSID);
	cfg.dwMaxNumberOfPeers = 100;

	dwResult = WlanHostedNetworkSetProperty(hClient,
											wlan_hosted_network_opcode_connection_settings,
											sizeof(WLAN_HOSTED_NETWORK_CONNECTION_SETTINGS),
											&cfg,
											&dwFailedReason,
											NULL);

	if (ERROR_SUCCESS != dwResult)
	{
		return dwFailedReason;
	}
	else
	{
		return 0;
	}
}