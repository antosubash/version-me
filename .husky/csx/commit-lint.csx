using System.Text.RegularExpressions;

private var pattern = @"^(?<type>feat|fix|docs|style|refactor|test|build|chore|wip)(?:\(\w+\))?!?:\s{1,2}(?<Description>.+?)\s{0,2}(?:(?<id>\(#\w+-\d+\))|(?<id>\(#untracked\)))?(?:\r?\n(?!feat|fix).+)?$";
private var msg = File.ReadAllLines(Args[0])[0];

if (Regex.IsMatch(msg, pattern))
    return 0;

Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine("Invalid commit message");
Console.ResetColor();
Console.WriteLine("e.g: 'feat(scope): subject' or 'fix: subject'");
Console.ForegroundColor = ConsoleColor.Gray;
Console.WriteLine("more info: https://www.conventionalcommits.org/en/v1.0.0/");

return 1;