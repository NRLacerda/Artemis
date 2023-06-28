List<string> MatchingFiles = new List<string>();

List<string> SearchFiles(string folderPath, string[] extensions)
{
    foreach (string file in Directory.EnumerateFiles(folderPath, "*", SearchOption.AllDirectories))
    {
        if (Array.Exists(extensions, ext => file.EndsWith(ext, StringComparison.OrdinalIgnoreCase))) MatchingFiles.Add(file);
    }
    return MatchingFiles;
}
Console.WriteLine("-------------------------------------------------");
Console.WriteLine("Bem vindo a Artemis, a caçadora de arquivos.");
Console.WriteLine("-------------------------------------------------");
Console.WriteLine("Insira a pasta da qual você deseja caçar:");
string folderPath = Console.ReadLine();
Console.WriteLine("Agora o formato (separado por vírgula):");
string[] extensions = Console.ReadLine().Split(',');
Console.WriteLine("-------------------------------------------------");
Console.WriteLine("Caminho Selecionado: " + folderPath);
Console.WriteLine("Formato: " + string.Join(", ", extensions));
MatchingFiles = SearchFiles(folderPath, extensions);
Console.WriteLine("-------------------------------------------------");

if (MatchingFiles.Count > 0)
{
    Console.WriteLine("Após algum tempo caçando, isto foi o que encontramos:");
    Console.WriteLine("---------------------------------------------------");
    foreach (string file in MatchingFiles)
    {
        FileInfo fileInfo = new FileInfo(file);
        long fileSize = fileInfo.Length;
        double fileSizeInMegabytes = (double)fileSize / 1024 / 1024;
        double convertidoFileSize = Math.Round(fileSizeInMegabytes, 2);
        Console.WriteLine($"{file}");
        Console.WriteLine($"Tamanho: {convertidoFileSize} megabytes");
        Console.WriteLine("---------------------------------------------------");
    }
}
else
{
    Console.WriteLine("A caça não resultou em nada.");
}
Console.ReadLine();
