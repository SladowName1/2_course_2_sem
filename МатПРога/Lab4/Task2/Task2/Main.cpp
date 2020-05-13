#include <algorithm>
#include <iostream>
#include <ctime>
#include <iomanip>
#include "Levenshtein.h"
using namespace std;
int main(int argc, char* argv[])
{
    setlocale(LC_ALL, "rus");
    clock_t t1 = 0, t2 = 0, t3, t4;
    char x[] = "abcdefghklmnoxm", y[] = "xyabcdefghomnkm";
    int  lx = sizeof(x) - 1, ly = sizeof(y) - 1;
    std::cout << std::endl;
    std::cout << std::endl << "-- расстояние Левенштейна -----" << std::endl;
    std::cout << std::endl << "--длина --- рекурсия -- дин.програм. ---"
        << std::endl;


	float k[] = { 0.04, 0.05, 0.0625, 0.1, 0.2, 0.5, 1 };
    int dist = 0;


	cout << "Дистанция Левенштейна с помощью динамического программирования: " << dist << endl;
	cout << "Время вычисления алгоритма: (мс) " << t2 - t1 << endl;
	t1 = clock();
	dist = levenshtein_r(300 * k[0], x, 250 * k[0], y);
	t2 = clock();
	cout << "Дистанция Левенштейна с помощью рекурсии: " << dist << endl;
	cout << "Время вычисления алгоритма: (мс) " << t2 - t1 << endl;
    system("pause");
    return 0;
}
