dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=cobertura --% /p:ExcludeByFile=\"**/src/School.WebAPI/Program.cs\" /p:Exclude=\"[School.Application.DTO*]*,[*]School.Application.DTO*,[School.Application.Models*]*,[*]School.Application.Models*,[School.Application.Profiles*]*,[*]School.Application.Profiles*,[School.Application.Results*]*,[*]School.Application.Results*,[School.Domain*]*,[*]School.Domain*,[School.Data*]*,[*]School.Data*,[School.WebAPI.Attributes*]*,[*]School.WebAPI.Attributes*,[School.WebAPI.Behaviors*]*,[*]School.WebAPI.Behaviors*,[School.WebAPI.Extensions*]*,[*]School.WebAPI.Extensions*,[School.WebAPI.Filters*]*,[*]School.WebAPI.Filters*,[School.WebAPI.Helpers*]*,[*]School.WebAPI.Helpers*,[School.WebAPI.Middlewares*]*,[*]School.WebAPI.Middlewares*\"