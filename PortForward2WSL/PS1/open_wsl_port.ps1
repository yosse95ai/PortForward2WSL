if (!([Security.Principal.WindowsPrincipal][Security.Principal.WindowsIdentity]::GetCurrent()).IsInRole("Administrators")) { 
  Start-Process powershell.exe "-File `"$PSCommandPath`"" -WindowStyle hidden -Verb RunAs -Wait; exit;
}
$ip = bash.exe -c "ip r |tail -n1|cut -d ' ' -f9"
if( ! $ip ){
  exit;
}
if (([Security.Principal.WindowsPrincipal][Security.Principal.WindowsIdentity]::GetCurrent()).IsInRole("Administrators")){
  # All the ports you want to forward separated by comma
  $ports_a = [Environment]::GetEnvironmentVariable('PORT',"User");
  $ports=@([Environment]::GetEnvironmentVariable("PORT","User") -Split ",");

  if (0 -lt $ports.length){  # Remove Firewall Exception Rules
    iex "Remove-NetFireWallRule -DisplayName 'WSL 2 Firewall Unlock' ";

    # Adding Exception Rules for inbound and outbound Rules
    iex "New-NetFireWallRule -DisplayName 'WSL 2 Firewall Unlock' -Direction Outbound -LocalPort $ports_a -Action Allow -Protocol TCP";
    iex "New-NetFireWallRule -DisplayName 'WSL 2 Firewall Unlock' -Direction Inbound -LocalPort $ports_a -Action Allow -Protocol TCP";

    for( $i = 0; $i -lt $ports.length; $i++ ){
      $port = $ports[$i];
      iex "netsh interface portproxy add v4tov4 listenport=$port listenaddress=* connectport=$port connectaddress=$ip";
    }
  }
}
