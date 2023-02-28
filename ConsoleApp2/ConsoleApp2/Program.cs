DateOnly birthDate = new DateOnly(1999, 7, 8);
TimeSpan difference = DateTime.Today - birthDate.ToDateTime(TimeOnly.Parse("00:00"));
int age = (int)(difference.TotalDays / 365.25);
Console.WriteLine(age);