NUGET=nuget
MSBUILD=msbuild
SOLUTION=ReactNative.Droid.csproj
NUSPEC=ReactNative.Droid.nuspec

all: nuget

build:
	$(MSBUILD) $(SOLUTION) /t:Restore
	$(MSBUILD) $(SOLUTION) /p:Configuration=Debug /t:Rebuild

nuget:
	$(MAKE) build
	$(NUGET) pack $(NUSPEC)
	mv *.nupkg bin/

clean:
	rm -rf bin/ obj/
