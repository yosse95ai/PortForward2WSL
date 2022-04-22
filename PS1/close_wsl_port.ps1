if (!([Security.Principal.WindowsPrincipal][Security.Principal.WindowsIdentity]::GetCurrent()).IsInRole("Administrators")) { Start-Process powershell.exe "-File `"$PSCommandPath`"" -Verb RunAs -Wait; }

$ports = @([Environment]::GetEnvironmentVariable("PORT","User") -Split " ");

for( $i = 0; $i -lt $ports.length; $i++ ){
  $port = $ports[$i];
  iex "netsh interface portproxy delete v4tov4 listenport=$port";
  echo "clesed Port:$port"
}
[Environment]::SetEnvironmentVariable('PORT',"","User")


# Show proxies
iex "netsh interface portproxy show v4tov4";