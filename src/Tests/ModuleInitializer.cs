﻿[assembly: NonParallelizable]

public static class ModuleInitializer
{
    [ModuleInitializer]
    public static void Initialize()
    {
        VerifyDiffPlex.Initialize(OutputType.Compact);
        VerifierSettings.UniqueForOSPlatform();
    }
}