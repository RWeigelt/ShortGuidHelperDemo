using ShortGuidHelperDemo;

var originalGuid = Guid.NewGuid();
Console.WriteLine($"From GUID   : {originalGuid:N}");

var shortId=ShortGuidHelper.GetShortId(originalGuid);
Console.WriteLine($"To short ID : {shortId}");

var recreatedGuid=ShortGuidHelper.GetGuid(shortId);
Console.WriteLine($"Back to GUID: {recreatedGuid:N}");

Console.ReadKey();