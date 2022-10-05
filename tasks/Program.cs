// See https://aka.ms/new-console-template for more information
//Console.Clear();

Console.WriteLine(@"Введите:
1 - задача 41,
2 - задача 43,
3 - дополнительная задача с *,
4 - дополнительная задача с **.");
string answer = Console.ReadLine();
switch(answer){
    case "1": Task41(); break;
    case "2": Task43(); break;
    case "3": starTask(); break;
    case "4": doubleStarTask(); break;
    default: Console.WriteLine("Вы ввели неверное значение."); break;
}

void Task41(){
    Console.WriteLine(@"Вводите числа, нажимая после каждого клавишу Enter.
    Для остановки ввода нажмите повторно клавишу Enter.");
    int number = 0;
    int counter = 0;
    while(true){
        if(!int.TryParse(Console.ReadLine(), out number)){
            Console.WriteLine($"Количество введенных чисел больше нуля равно {counter}");
            break;
        } else if (number > 0) counter++;
    }
}

void Task43(){
    Console.WriteLine(@"Введите параметры первого уравнения: k1 = ");
    double k1 = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("b1 = ");
    double b1 = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine(@"Введите параметры второго уравнения: k2 = ");
    double k2 = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("b2 = ");
    double b2 = Convert.ToInt32(Console.ReadLine());
    
    double x = 0;
    double y = 0;
    if (k1-k2!=0){
        x = Math.Round((b2-b1)/(k1-k2), 2);
        y = Math.Round(k1 * x + b1, 2);
        Console.WriteLine($"Координаты точки пересечения двух прямых ({x}, {y})");
    }
    else Console.WriteLine("У заданных прямых нет точки пересечения");
}

void starTask(){
    int[] array = FillIntArray(1, 10);
    int[] moveArray = new int[array.Length];
    Console.WriteLine(@"Выберите вариант действия:
    1 - если хотите сдвинуть массив вправо;
    2 - если хотите сдвинуть массив влево");
    string answer = Console.ReadLine();
    switch(answer){
        case "1": moveArray = MoveToRight(array);
            break;
        case "2": moveArray = MoveToLeft(array);
            break;
        default: Console.WriteLine("Вы ввели неверное значение.");
              break;
    }
    Console.WriteLine($"Было: [" + String.Join(",", array) + "], стало: [" 
    +String.Join(",", moveArray)+"]");

    int[] MoveToRight(int[] arr){
        int[] newArray = new int[arr.Length];
        for(int i = 0; i < arr.Length - 1; i++){
            newArray[i + 1] = arr[i];
        }
        newArray[0] = arr[arr.Length - 1];
        return newArray;
    }

    int[] MoveToLeft(int[] arr){
        int[] newArray = new int[arr.Length];
        for (int i = 1; i < arr.Length; i++){
            newArray[i-1] = arr[i];
        }
        newArray[newArray.Length - 1] = arr[0];
        return newArray;
    }
}

void doubleStarTask(){
    int[] array = FillIntArray(1, 10);
    Console.WriteLine($"Было: [" + String.Join(",", array) + "]");
    bool repeat = false;
    for (int i = 1; i < array.Length; i++){
        if(array[i - 1] == array[i]){
            array[i] = array.Max() + 1;
            repeat = true;
        }
    }
    if (repeat){
        Console.WriteLine($"Стало: [" + String.Join(",", array) + "]");
    }
    else Console.WriteLine("Повторов не обнаружено!");
    
}

int[] FillIntArray(int minNumber, int maxNumber){
            Console.WriteLine("Введите размер массива");
            int size = Convert.ToInt32(Console.ReadLine());
            int[] array = new int[size];
            for (int i = 0; i < size; i++){
                array[i] = new Random().Next(minNumber, maxNumber);
            }
            return array;
    }