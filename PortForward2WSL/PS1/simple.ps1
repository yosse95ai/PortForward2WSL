if (!([Security.Principal.WindowsPrincipal][Security.Principal.WindowsIdentity]::GetCurrent()).IsInRole("Administrators")) 
{ 
  $item = Start-Process powershell.exe "-File `"$PSCommandPath`"" -Verb RunAs -Wait; 
}