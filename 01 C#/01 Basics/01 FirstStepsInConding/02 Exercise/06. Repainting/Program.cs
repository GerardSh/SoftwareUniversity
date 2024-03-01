int kolichestvoNailon = int.Parse(Console.ReadLine());
int kolichestvoBoia = int.Parse(Console.ReadLine());
int kolichestvoRazreditel = int.Parse(Console.ReadLine());
int hours = int.Parse(Console.ReadLine());

double sumMaterials = (kolichestvoNailon + 2) * 1.5 + (kolichestvoBoia + kolichestvoBoia * 0.10) * 14.50 + kolichestvoRazreditel * 5 + 0.4;
double work = (sumMaterials * 0.3) * hours;
Console.WriteLine(sumMaterials + work);