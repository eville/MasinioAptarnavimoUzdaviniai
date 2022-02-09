// See https://aka.ms/new-console-template for more information
using MainioAptarnavimoUzdaviniuSkaiciuokle;

Console.WriteLine("Prekybos centre kasininkė vieną klientą aptarnauja vidutiniškai per 3 minutes. Į parduotuvę pirkėjai ateina vidutiniškai kas 1 minutę. Pirkėjai laukia eilėje, jei joje yra ne daugiau nei 4 žmonės.");
Console.WriteLine("Kiek reikia kasininkių, kad būtų aptarnauta ne mažiau nei 90% pirkėjų (100% pirkėjų)?");

var skaiciuokle = new MasinioAptarnavimoSkaiciuokle();

int maxlaukianciujuEile = 4;

int laikoTarpasMinutemis = 1;

int paraiskuSrautasLaikoVieneteMinutemis = 3;

int lamba_paraiskuSrautoIntensyvumas = 1;
double miu_ParaiskuAptarnavimoIntensyvumas = skaiciuokle.SkaiciuotiParaiskuAptarnavimoIntensyvuma(laikoTarpasMinutemis, paraiskuSrautasLaikoVieneteMinutemis);

double alfa_santykisParaiskuSrautoSuParaiskuAptarnavimoIntensyvumu = skaiciuokle.SkaiciuotiSantykisParaiskuSrautoSuParaiskuAptarnavimoIntensyvumu(lamba_paraiskuSrautoIntensyvumas, miu_ParaiskuAptarnavimoIntensyvumas);

double gautaParaiskuAtmetimoTikimybe = 0;

Atsakymas? atsakymas90 = null;

Atsakymas? atsakymas100 = null;

double q = 0;
int n = 1;
while ( q <= 1)
{
    Console.WriteLine($"Kasininku skaicius: {n}");
    if (n == 1)
    {        
        gautaParaiskuAtmetimoTikimybe = skaiciuokle.skaiciuotiVienakanaleSuEileParaiksuAtmetimoTikimybe(alfa_santykisParaiskuSrautoSuParaiskuAptarnavimoIntensyvumu, maxlaukianciujuEile);
        q = skaiciuokle.SkaiciuotiSantykineAptarnavimoGeba(gautaParaiskuAtmetimoTikimybe);

    }
    else if (n > 1)
    {
        gautaParaiskuAtmetimoTikimybe = skaiciuokle.SkaiciuotiDaugiakanaleSuEileAtmetimoTikimybe(n, maxlaukianciujuEile, alfa_santykisParaiskuSrautoSuParaiskuAptarnavimoIntensyvumu);
        q = skaiciuokle.SkaiciuotiSantykineAptarnavimoGeba(gautaParaiskuAtmetimoTikimybe);
    }

    if(q >= 0.9 && atsakymas90 == null)
    {
        atsakymas90 = new Atsakymas(n, q);
    }

    if (q >= 1 && atsakymas100 == null)
    {
        atsakymas100 = new Atsakymas(n, q);
    }

    Console.WriteLine($"Gauta paraisku atmetimo tikimybe (P ats): {gautaParaiskuAtmetimoTikimybe}");
    Console.WriteLine($"Santykine aptarnavimo geba (q): {q}");

    n++;
}

Console.WriteLine($"Kasininu kskaicius: {atsakymas90.KanaluSkaicius} aptarnauta klientu (q): {atsakymas90.SantykineAptarnavimoGeba * 100} %");
Console.WriteLine($"Kasininu kskaicius: {atsakymas100.KanaluSkaicius} aptarnauta klientu (q): {atsakymas100.SantykineAptarnavimoGeba * 100} %");

// antras uzdavinys
Console.WriteLine("Į degalinę vairuotojai atvažiuoja piltis degalus, jei būna laisva nors viena kolonėlė.");
Console.WriteLine("Per valandą atvažiuoja 120 automobilių. Vienas automobilis aptarnaujamas vidutiniškai per 6 minutes. Reikia nustatyti:");

Console.WriteLine("Sprendimas");

var autoLaikoTarpasMinutemis = 60;
var autoParaiskos = 120;
var autoParaiskosAptarnavimoLaikas = 6;
var autoParaiskuSrautasLaikoVieneteMinutemis = 1;

//
var autoLambda = skaiciuokle.SkaiciuotiParaiskuAptarnavimoIntensyvuma(autoParaiskos, autoLaikoTarpasMinutemis);
var autoMiu = skaiciuokle.SkaiciuotiParaiskuAptarnavimoIntensyvuma(autoParaiskuSrautasLaikoVieneteMinutemis, autoParaiskosAptarnavimoLaikas);

var autoAlfa = skaiciuokle.SkaiciuotiSantykisParaiskuSrautoSuParaiskuAptarnavimoIntensyvumu(autoLambda, autoMiu);

var atsakymai = new Dictionary<string, double>()
{
    { "1 kolonele" , skaiciuokle.SkaiciuotiVienakanaleAtmetimoTikimybeBeEiles(lamba_paraiskuSrautoIntensyvumas, autoMiu)},
    { "2 koloneles", skaiciuokle.SkaiciuotiDaugiakanaleTikimybeAtmetimoBeEiles(2, autoAlfa) },
    { "3 koloneles", skaiciuokle.SkaiciuotiDaugiakanaleTikimybeAtmetimoBeEiles(3, autoAlfa) },
    { "4 koloneles", skaiciuokle.SkaiciuotiDaugiakanaleTikimybeAtmetimoBeEiles(4, autoAlfa) }
};

Console.WriteLine("a) Kiek automobilių lieka neaptarnautų, jei degalinėje veikia viena, dvi, trys, keturios kolonėlės.");

foreach (var atsakymas in atsakymai)
{
    Console.WriteLine($" {atsakymas.Key}, lieka neaptarnautų automobilių {atsakymas.Value * 100} %");
}

Console.WriteLine("b) Kiek degalinei reikia turėti kolonėlių, kad būtų aptarnauta ne mažiau nei 90% visų atvykusių automobilių.");

double auto_q = 0;
int koloneliuSkaicius = 1;

var x11 = skaiciuokle.SkaiciuotiDaugiakanaleTikimybeAtmetimoBeEiles(11, autoAlfa);
var x12 = skaiciuokle.SkaiciuotiDaugiakanaleTikimybeAtmetimoBeEiles(12, autoAlfa);
var x13 = skaiciuokle.SkaiciuotiDaugiakanaleTikimybeAtmetimoBeEiles(13, autoAlfa);
var x14 = skaiciuokle.SkaiciuotiDaugiakanaleTikimybeAtmetimoBeEiles(14, autoAlfa);

Atsakymas atsakymasB = null;

while (auto_q < 1)
{
    if(koloneliuSkaicius == 1)
    {
        q = 1 - skaiciuokle.SkaiciuotiVienakanaleAtmetimoTikimybeBeEiles(lamba_paraiskuSrautoIntensyvumas, autoMiu);
    }
    else if(koloneliuSkaicius > 0)
    {
        var x = autoAlfa;
        var pats = skaiciuokle.SkaiciuotiDaugiakanaleTikimybeAtmetimoBeEiles(koloneliuSkaicius, autoAlfa);
        q = 1 - pats;
           
    }

    if(atsakymasB == null && q >= 0.9)
    {
        atsakymasB = new Atsakymas(koloneliuSkaicius, q);
        break;
    }
    koloneliuSkaicius++;
}

if (atsakymasB != null)
{
    Console.WriteLine($" Kad būtų aptarnauta ne mažiau nei 90% automobilių, kolonėlių turi būti {atsakymasB.KanaluSkaicius }, kur sant. aptarnavimo geba {atsakymasB.SantykineAptarnavimoGeba * 100} %.");
    Console.WriteLine($" Jei būtų {atsakymasB.KanaluSkaicius-1}, tai aptarnautų { (1 - skaiciuokle.SkaiciuotiDaugiakanaleTikimybeAtmetimoBeEiles(atsakymasB.KanaluSkaicius-1, autoAlfa)) * 100} % ");
}
