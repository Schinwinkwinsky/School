dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=cobertura --% /p:Exclude=\"[School.Domain*]*,[*]School.Domain*,[School.Data*]*,[*]School.Data*\"