if (!([Security.Principal.WindowsPrincipal][Security.Principal.WindowsIdentity]::GetCurrent()).IsInRole("Administrators")) { 
  Start-Process powershell.exe "-File `"$PSCommandPath`"" -WindowStyle hidden -Verb RunAs -Wait; exit;
}
if (([Security.Principal.WindowsPrincipal][Security.Principal.WindowsIdentity]::GetCurrent()).IsInRole("Administrators")) { 

  $ports = @([Environment]::GetEnvironmentVariable("PORT","User") -Split ",");

  for( $i = 0; $i -lt $ports.length; $i++ ){
    $port = $ports[$i];
    iex "netsh interface portproxy delete v4tov4 listenport=$port";
  }
  [Environment]::SetEnvironmentVariable('PORT',"","User")
}