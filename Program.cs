using TechnicalInterview.Extensions;

const int COUNT = 10_000_000;
var random = new Random();

// Genera una lista o arreglo de 10.000.000 números enteros aleatorios entre -100.000 y 100.000
long[] RangeOfNumber()
{
    var numbers = new long[COUNT];

    for (int i = 0; i < COUNT; i++)
    {
        numbers[i] = random.Next(-100_000, 100_001);
    }

    return numbers;
}

var numbers = RangeOfNumber();
// Console.WriteLine(string.Join("\r\n", numbers.Take(100)));


/* 
Imprime en distintas líneas por consola los siguientes datos:
    -La cantidad total de elementos del arreglo.
    - El valor más alto en el arreglo.
    - El valor más bajo en el arreglo.
    - El promedio de todos los valores en el arreglo.
 */

void ShowRangeDetails(long[] numbers)
{
    var totalCount = numbers.Length;
    var highest = numbers.Max();
    var lowest = numbers.Min();
    var mean = numbers.Sum() / totalCount;

    Console.WriteLine($"La cantidad total de elementos del arreglo: {totalCount}");
    Console.WriteLine($"El valor más alto en el arreglo: {highest}");
    Console.WriteLine($"El valor más bajo en el arreglo: {lowest}");
    Console.WriteLine($"El promedio de todos los valores en el arreglo: {mean}");
}

// ShowRangeDetails(arrOfNumbers);


// Imprime la cantidad de veces que se obtuvo el valor 0.
void ZerosCount(long[] numbers)
{
    var zeros = numbers.Count(n => n == 0);
    Console.WriteLine($"cantidad de veces que se obtuvo el valor 0: {zeros}");
}

// ZerosCount(arrOfNumbers);

// Imprime los 5 valores que más se repiten desde el más repetido al que menos lo hace, indicando para cada uno cuántas veces se repite.
void ShowModeValues(long[] numbers)
{
    var valueCounts = numbers.GroupBy(m => m)
        .Select(g => new
        {
            Group = g.Key,
            Count = g.Count(),
        })
        .OrderByDescending(vc => vc.Count)
        .Take(5)
        .ToList();

    foreach(var value in valueCounts)
    {
        Console.WriteLine($"El valor {value.Group} se repite: {value.Count} veces.");
    }

}

// ShowModeValues(arrOfNumbers);
 
//1-5.- Ordena el arreglo desde el valor más pequeño al más alto, con cualquier algoritmo de ordenamiento, implementado por ti (sin usar .Sort() o métodos similares).
 
void OrderArrOfNumbers(long[] numbers)
{
    Console.WriteLine(string.Join(", ", numbers.Take(100)));

    numbers.MergeSort(0, numbers.Length - 1);

    Console.WriteLine(string.Join(", ", numbers.Take(100)));
}

// OrderArrOfNumbers(numbers);

// Modifica todos los valores impares del arreglo, y reemplázalos por cualquier valor par.=
void TransformOddsIntoEvens(long[] numbers)
{
    var oddCount = numbers.Count(n =>  n % 2 != 0);
    var evenCount = numbers.Count(n => n % 2 == 0);

    Console.WriteLine($"Impares: {oddCount}");
    Console.WriteLine($"Pares: {evenCount}");

    for (int i = 0; i < numbers.Length; i++)
    {
        var value = numbers[i];
        if (value % 2 != 0)
        {
            numbers[i] = value - 1;
        }
    }
     oddCount = numbers.Count(n => n % 2 != 0);
     evenCount = numbers.Count(n => n % 2 == 0);

    Console.WriteLine($"Impares: {oddCount}");
    Console.WriteLine($"Pares: {evenCount}");

}

//TransformOddsIntoEvens(arrOfNumbers);

/*
Genera una lista de 10.000.000 palabras, de 4 letras minúsculas cada una (de la a a la z, sin ñ)
e Imprime la cantidad de veces que se generó la palabra 'hola'
    - (caracteres del 97 al 122)
        char aleatorio = 97 + random(26);
*/


void Wordsgenerator()
{
    var words = new string[COUNT];


    for (int i = 0; i < COUNT; i++)
    {
        var word = new char[4];
        for (int j = 0; j < 4; j++)
        {
            word[j] = (char)(97 + random.Next(0, 26));
        }

        words[i] = string.Join("", word);
    }

    Console.WriteLine(string.Join(", ", words.Take(10)));

    var helloCount = words.Count(word => word.Equals("hola"));

    Console.WriteLine($"Cantidad de veces que aparece hola: {helloCount}");
    Console.WriteLine(string.Join(", ", words.Where(word => word.Equals("hola"))));
}

// Wordsgenerator();


// Paradoja del cumpleaños
void DateRange()
{
    var dates = new DateTime[57];
    for (int i = 0; i < 57; i++)
    {
        var start = new DateTime(1995, 1, 1);
        var daysSpan = (DateTime.Now - start).Days;

        dates[i] = start.AddDays(random.Next(daysSpan));
    }

    var groupOfDates = dates.GroupBy(date => new
    {
        Month = date.Month,
        Day = date.Day,
    }).Select(g => new
    {
        Month = g.Key.Month,
        Day = g.Key.Day,
        Count = g.Count()
    }).ToList();


    foreach (var group in groupOfDates)
    {
        Console.WriteLine($"Mes: {group.Month}, dia: {group.Day}, Cantidad: {group.Count}");
    }

}





















