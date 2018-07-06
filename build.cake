#tool "nuget:?package=xunit.runner.console"

var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");

Task("dotnet-restore")
	.Does(() => 
	{
		DotNetCoreRestore("./HidApiNet.sln");
	});


Task("dotnet-build")
	.IsDependentOn("dotnet-restore")	
	.Does(() => 
	{
		DotNetCoreBuild("./HidApiNet.sln", new DotNetCoreBuildSettings 
		{
			Configuration = configuration
		});
	});

Task("run-xunit-tests")	
	.IsDependentOn("dotnet-build")
	.Does(() => 
	{
		/*DotNetCoreTest("./tests/SomeProject.Tests.csproj", new DotNetCoreTestSettings
		{
			Configuration = configuration
		});*/
	});	
	
Task("publish")	
	.IsDependentOn("run-xunit-tests")
	.Does(() => 
	{
		DotNetCorePack("./HidApiNet.sln",new DotNetCorePackSettings
		{
			Configuration = configuration,
			OutputDirectory = "./artifacts/"
		 });
	});	

Task("Default")
	.IsDependentOn("run-xunit-tests");

RunTarget(target);